using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Windows.Forms;

//Base from codeproject

namespace SMAH1.Print
{
    public class PrintToGraphics
    {
        private DataTable table;

        private readonly bool isCenterOnPage; // Determine if the report will be printed in the Top-Center of the page
        private readonly bool isWithTitle; // Determine if the page contain title text
        private readonly Font titleFont; // The font to be used with the title text (if isWithTitle is set to true)
        private readonly Color titleColor; // The color to be used with the title text (if isWithTitle is set to true)
        private readonly bool isWithPaging; // Determine if paging is used

        private int currentRow; // A parameter that keep track on which Row (in the DataGridView control) that should be printed
        private int pageNumber;

        private float dataGridViewWidth;
        private readonly float lineWidth;

        private readonly int pageWidth;
        private readonly int pageHeight;
        private readonly int leftMargin;
        private readonly int rightMargin;

        private float currentY; // A parameter that keep track on the y coordinate of the page, so the next object to be printed will start from this y coordinate

        private float rowHeaderHeight;
        private List<float> rowsHeight;
        private List<float> columnsWidth;

        // Maintain a generic list to hold start/stop points for the column printing
        // This will be used for wrapping in situations where the DataGridView will not fit on a single page
        private List<int[]> mColumnPoints;
        private List<float> mColumnPointsWidth;
        private int mColumnPoint;

        bool calculate;
        readonly Font font;
        Padding cellPadding;

        // The class constructor
        public PrintToGraphics(DataTable table, Font font,
            int width, int height, int leftMargin, int rightMargin,
            bool centerOnPage,
            bool withTitle, Font titleFont, Color titleColor,
            bool withPaging,
            Padding cellPadding,
            float lineWidth)
        {
            this.table = table ?? throw new ArgumentNullException("table");
            this.font = font ?? throw new ArgumentNullException("font");
            this.isCenterOnPage = centerOnPage;
            this.isWithTitle = withTitle;
            this.titleFont = titleFont;
            this.titleColor = titleColor;
            this.isWithPaging = withPaging;
            this.pageWidth = width;
            this.pageHeight = height;
            this.leftMargin = leftMargin;
            this.rightMargin = rightMargin;
            this.cellPadding = cellPadding;
            this.lineWidth = lineWidth;
            if (titleFont == null)
                this.titleFont = font;
            else
                this.titleFont = titleFont;

            this.pageNumber = 0;
            this.currentRow = 0;		// First, the current row to be printed is the first row in the DataGridView control
            this.calculate = false;

            this.rowsHeight = new List<float>();
            this.columnsWidth = new List<float>();
            this.mColumnPoints = new List<int[]>();
            this.mColumnPointsWidth = new List<float>();
        }

        // The function that calculate the height of each row (including the header row), the width of each column (according to the longest text in all its cells including the header cell), and the whole DataGridView width
        private void Calculate(Graphics gr)
        {
            if (!calculate) // Just calculate once
            {
                calculate = true;
                this.dataGridViewWidth = 0f;

                SizeF tmpSize = new SizeF();
                float tmpWidth;

                for (int i = 0; i < table.Columns.Count; i++)
                {
                    int paddingTP = cellPadding.Top + cellPadding.Bottom;
                    int paddingLR = cellPadding.Left + cellPadding.Right;

                    tmpSize = gr.MeasureString(table.Columns[i].ColumnName, font);
                    tmpWidth = tmpSize.Width;
                    tmpWidth += paddingLR;
                    rowHeaderHeight = tmpSize.Height;
                    rowHeaderHeight += paddingTP;

                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        object o = table.Rows[j].ItemArray[i];
                        SizeF sz2 = gr.MeasureString(o == null || o == System.DBNull.Value ? string.Empty : o.ToString(), font);

                        rowsHeight.Add(Math.Max(sz2.Height + paddingTP, rowHeaderHeight));

                        float tmpWidth2 = sz2.Width + paddingLR;
                        if (tmpWidth2 > tmpWidth)
                            tmpWidth = tmpWidth2;
                    }
                    columnsWidth.Add(tmpWidth);
                    this.dataGridViewWidth += tmpWidth;
                }

                // Define the start/stop column points based on the page width and the DataGridView Width
                // We will use this to determine the columns which are drawn on each page and how wrapping will be handled
                // By default, the wrapping will occurr such that the maximum number of columns for a page will be determine
                int k;

                int mStartPoint = 0;

                int mEndPoint = table.Columns.Count - 1;

                float mTempWidth = this.dataGridViewWidth;
                float mTempPrintArea = (float)pageWidth - (float)leftMargin - (float)rightMargin;

                // We only care about handling where the total datagridview width is bigger then the print area
                if (this.dataGridViewWidth > mTempPrintArea)
                {
                    mTempWidth = 0.0F;
                    for (k = 0; k < table.Columns.Count; k++)
                    {
                        mTempWidth += columnsWidth[k];
                        // If the width is bigger than the page area, then define a new column print range
                        if (mTempWidth > mTempPrintArea)
                        {
                            mTempWidth -= columnsWidth[k];
                            mColumnPoints.Add(new int[] { mStartPoint, mEndPoint });
                            mColumnPointsWidth.Add(mTempWidth);
                            mStartPoint = k;
                            mTempWidth = columnsWidth[k];
                        }
                        // Our end point is actually one index above the current index
                        mEndPoint = k + 1;
                    }
                }
                // Add the last set of columns
                mColumnPoints.Add(new int[] { mStartPoint, mEndPoint });
                mColumnPointsWidth.Add(mTempWidth);
                mColumnPoint = 0;
            }
        }

        // The funtion that print the title, page number, and the header row
        private void DrawHeader(Graphics g, int topMargin, int bottomMargin, string title)
        {
            currentY = (float)topMargin;

            // Printing the page number (if isWithPaging is set to true)
            if (isWithPaging)
            {
                pageNumber++;
                string pageString = "Page " + pageNumber.ToString();

                StringFormat pageStringFormat = new StringFormat
                {
                    Trimming = StringTrimming.Word,
                    FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip,
                    Alignment = StringAlignment.Far
                };

                float height = g.MeasureString(pageString, font).Height;
                RectangleF layoutRectangle = new RectangleF((float)leftMargin, currentY, (float)pageWidth - (float)rightMargin - (float)leftMargin, height);

                g.DrawString(pageString, font, new SolidBrush(Color.Black), layoutRectangle, pageStringFormat);

                currentY += height;
                pageStringFormat.Dispose();
            }

            // Printing the title (if IsWithTitle is set to true)
            if (isWithTitle)
            {
                StringFormat titleFormat = new StringFormat
                {
                    Trimming = StringTrimming.Word,
                    FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip
                };
                if (isCenterOnPage)
                    titleFormat.Alignment = StringAlignment.Center;
                else
                    titleFormat.Alignment = StringAlignment.Near;

                RectangleF titleRectangle = new RectangleF((float)leftMargin, currentY, (float)pageWidth - (float)rightMargin - (float)leftMargin, g.MeasureString(title, titleFont).Height);

                Brush br = new SolidBrush(titleColor);
                g.DrawString(title, titleFont, br, titleRectangle, titleFormat);
                br.Dispose();

                currentY += g.MeasureString(title, titleFont).Height;
                titleFormat.Dispose();
            }

            // Calculating the starting x coordinate that the printing process will start from
            float currentX = (float)leftMargin;
            if (isCenterOnPage)
                currentX += (((float)pageWidth - (float)rightMargin - (float)leftMargin) - mColumnPointsWidth[mColumnPoint]) / 2.0F;

            // Setting the HeaderFore style
            Color headerForeColor = Color.Black;
            SolidBrush headerForeBrush = new SolidBrush(headerForeColor);

            // Setting the HeaderBack style
            Color headerBackColor = Color.White;
            SolidBrush headerBackBrush = new SolidBrush(headerBackColor);

            // Setting the LinePen that will be used to draw lines and rectangles (derived from the GridColor property of the DataGridView control)
            Pen linePen = new Pen(Color.DarkGray, lineWidth);

            // Calculating and drawing the HeaderBounds        
            RectangleF headerBounds = new RectangleF(currentX, currentY, mColumnPointsWidth[mColumnPoint], rowHeaderHeight);
            g.FillRectangle(headerBackBrush, headerBounds);

            // Setting the format that will be used to print each cell of the header row
            StringFormat cellFormat = new StringFormat
            {
                Trimming = StringTrimming.Word,
                FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip
            };

            // Printing each visible cell of the header row
            RectangleF cellBounds;
            float width;
            for (int i = (int)mColumnPoints[mColumnPoint].GetValue(0); i < (int)mColumnPoints[mColumnPoint].GetValue(1); i++)
            {
                width = columnsWidth[i];

                // Check the CurrentCell alignment and apply it to the CellFormat
                cellFormat.Alignment = StringAlignment.Near;

                cellBounds = new RectangleF(currentX + cellPadding.Left, currentY + cellPadding.Top, width, rowHeaderHeight);

                // Printing the cell text
                g.DrawString(table.Columns[i].ColumnName, font, headerForeBrush, cellBounds, cellFormat);

                g.DrawRectangle(linePen, currentX, currentY, width, rowHeaderHeight);

                currentX += width;
            }

            currentY += rowHeaderHeight;

            headerForeBrush.Dispose();
            headerBackBrush.Dispose();
            linePen.Dispose();
            cellFormat.Dispose();
        }

        // The function that print a bunch of rows that fit in one page
        // When it returns true, meaning that there are more rows still not printed, so another PagePrint action is required
        // When it returns false, meaning that all rows are printed (the CureentRow parameter reaches the last row of the DataGridView control) and no further PagePrint action is required
        private bool DrawRows(Graphics g, int topMargin, int bottomMargin)
        {
            // Setting the LinePen that will be used to draw lines and rectangles (derived from the GridColor property of the DataGridView control)
            Pen linePen = new Pen(Color.DarkGray, lineWidth);

            // The style paramters that will be used to print each cell
            Color rowForeColor;
            Color rowBackColor;
            SolidBrush rowForeBrush = null;
            SolidBrush rowBackBrush = null;
            SolidBrush rowAlternatingBackBrush = null;

            // Setting the format that will be used to print each cell
            StringFormat cellFormat = new StringFormat
            {
                Trimming = StringTrimming.Word,
                FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit
            };

            // Printing each visible cell
            RectangleF rowBounds;
            float currentX;
            float width;
            while (currentRow < table.Rows.Count)
            {
                // Setting the RowFore style
                rowForeColor = Color.Black;
                rowForeBrush = new SolidBrush(rowForeColor);

                // Setting the RowBack (for even rows) and the RowAlternatingBack (for odd rows) styles
                rowBackColor = Color.White;
                rowBackBrush = new SolidBrush(rowBackColor);
                rowAlternatingBackBrush = new SolidBrush(rowBackColor);

                // Calculating the starting x coordinate that the printing process will start from
                currentX = (float)leftMargin;
                if (isCenterOnPage)
                    currentX += (((float)pageWidth - (float)rightMargin - (float)leftMargin) - mColumnPointsWidth[mColumnPoint]) / 2F;

                // Calculating the entire CurrentRow bounds                
                rowBounds = new RectangleF(currentX, currentY, mColumnPointsWidth[mColumnPoint], rowsHeight[currentRow]);

                // Filling the back of the CurrentRow
                if (currentRow % 2 == 0)
                    g.FillRectangle(rowBackBrush, rowBounds);
                else
                    g.FillRectangle(rowAlternatingBackBrush, rowBounds);

                // Printing each visible cell of the CurrentRow                
                for (int currentCell = (int)mColumnPoints[mColumnPoint].GetValue(0); currentCell < (int)mColumnPoints[mColumnPoint].GetValue(1); currentCell++)
                {
                    // Check the CurrentCell alignment and apply it to the CellFormat
                    cellFormat.Alignment = StringAlignment.Near;

                    width = columnsWidth[currentCell];
                    RectangleF cellBounds = new RectangleF(currentX + cellPadding.Left, currentY + cellPadding.Top, width, rowsHeight[currentRow]);

                    // Printing the cell text
                    object o = table.Rows[currentRow].ItemArray[currentCell];
                    g.DrawString(o == null || o == System.DBNull.Value ? string.Empty : o.ToString(), font, rowForeBrush, cellBounds, cellFormat);

                    // Drawing the cell bounds
                    g.DrawRectangle(linePen, currentX, currentY, width, rowsHeight[currentRow]);

                    currentX += width;
                }
                currentY += rowsHeight[currentRow];

                if (rowForeBrush != null)
                {
                    rowForeBrush.Dispose();
                    rowForeBrush = null;
                }
                if (rowBackBrush != null)
                {
                    rowBackBrush.Dispose();
                    rowBackBrush = null;
                }
                if (rowAlternatingBackBrush != null)
                {
                    rowAlternatingBackBrush.Dispose();
                    rowAlternatingBackBrush = null;
                }

                currentRow++;

                // Checking if the CurrentY is exceeds the page boundries
                // If so then exit the function and returning true meaning another PagePrint action is required
                if ((int)currentY > (pageHeight - topMargin - bottomMargin))
                {
                    cellFormat.Dispose();
                    return true;
                }
            }

            cellFormat.Dispose();

            currentRow = 0;
            mColumnPoint++; // Continue to print the next group of columns

            if (mColumnPoint == mColumnPoints.Count) // Which means all columns are printed
            {
                mColumnPoint = 0;
                return false;
            }
            return true;
        }

        // The method that calls all other functions
        public bool Draw(Graphics g, int topMargin, int bottomMargin, string title, bool withHeader)
        {
            Calculate(g);
            if (withHeader)
                DrawHeader(g, topMargin, bottomMargin, title);
            else
                currentY = topMargin;
            return DrawRows(g, topMargin, bottomMargin);
        }
    }
}