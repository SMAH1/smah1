using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SMAH1.Forms.Chart.Component.Axile
{
    public class AxileDrawManager : IDrawManager, IDisposable
    {
        #region Object method
        public override bool Equals(System.Object obj)
        {
            if (obj == null) return false;
            if (!ReferenceEquals(this, obj)) return false;

            return Equals(obj as AxileDrawManager);
        }

        public bool Equals(AxileDrawManager adm)
        {
            if (adm == null) return false;
            if (!ReferenceEquals(this, adm)) return false;

            if (!base.Equals(adm)) return false;
            if (adm.beginDraw != beginDraw) return false;
            if (adm.coordinated != coordinated) return false;
            if (adm.dicDraw != dicDraw) return false;
            if (adm.disposed != disposed) return false;

            return true;
        }

        public static bool operator ==(AxileDrawManager a, AxileDrawManager b)
        {
            bool ab = a is null;
            bool bb = b is null;
            if (ab && bb)
                return true;
            if (ab && !bb)
                return false;
            return a.Equals(b); //No we have object of a (a is not null)
        }

        public static bool operator !=(AxileDrawManager a, AxileDrawManager b) { return !(a == b); }

        public override int GetHashCode()
        {
            return base.GetHashCode() +
                beginDraw.GetHashCode() +
                coordinated.GetHashCode() +
                dicDraw.GetHashCode() +
                disposed.GetHashCode();
        }
        #endregion

        #region Fields and constructor
        List<Coordinated> coordinated;
        bool disposed;

        public AxileDrawManager()
        {
            coordinated = new List<Coordinated>();
            disposed = false;
        }

        ~AxileDrawManager()
        {
            Dispose();
        }
        #endregion

        #region Manage (add,...)
        /// <summary>
        /// Add Group of Chart for coordinating with the defined axile
        /// </summary>
        /// <param name="axile">Which axile for coordinating</param>
        /// <param name="charts">Group of Chart</param>
        /// <returns>return 'ID' for add chart to this group later</returns>
        public int AddCoordinatorGroup(Axile axile, params Chart[] charts)
        {
            foreach (Coordinated c in coordinated)
                foreach (Chart chart in charts)
                {
                    if (chart.Component == null)
                        throw new Exception("Chart has not axile component");
                    else
                    {
                        AxileBase ab = chart.Component as AxileBase;
                        if (ab == null)
                            throw new Exception("Chart has not axile component");
                        else
                        {
                            if (c.Contains(chart) && c.Axile == axile)
                                throw new Exception("Repeat add axile chart");
                        }
                    }
                }
            SetChartDrawManager(charts);

            Coordinated co = new Coordinated(axile);
            co.AddRange(charts);
            coordinated.Add(co);

            return coordinated.Count - 1;
        }

        /// <summary>
        /// Add Group of Chart for coordinating with the defined axile to existing group
        /// </summary>
        /// <param name="axile">Which axile for coordinating</param>
        /// <param name="group">Send 'ID' of existing group</param>
        /// <param name="charts">Group of Chart</param>
        public void InsertCoordinator(Axile axile, int group, params Chart[] charts)
        {
            foreach (Coordinated c in coordinated)
                foreach (Chart chart in charts)
                {
                    if (chart.Component == null)
                        throw new Exception("Chart has not axile component");
                    else
                    {
                        AxileBase ab = chart.Component as AxileBase;
                        if (ab == null)
                            throw new Exception("Chart has not axile component");
                        else
                        {
                            if (c.Contains(chart) && c.Axile == axile)
                                throw new Exception("Repeat add axile chart");
                        }
                    }
                }

            SetChartDrawManager(charts);

            coordinated[group].AddRange(charts);
        }

        private void SetChartDrawManager(Chart[] charts)
        {
            foreach (Chart chart in charts)
            {
                if (chart.DrawManager == null)
                {
                    chart.DrawManager = this;
                    chart.ComponentChanged += new EventHandler(Chart_ComponentChanged);
                }
                else if (!this.Equals(chart.DrawManager))
                    throw new Exception("Chart has other DrawManager");
            }
        }

        void Chart_ComponentChanged(object sender, EventArgs e)
        {
            Chart c = (Chart)sender;
            if (c.Component == null)
                throw new Exception("Chart has not axile component");
            else
            {
                AxileBase ab = c.Component as AxileBase;
                if (ab == null)
                    throw new Exception("Chart has not axile component");
            }
        }

        public void Remove(params Chart[] charts)
        {
            foreach (Coordinated c in coordinated)
                foreach (Chart chart in charts)
                    if (c.Contains(chart))
                    {
                        c.Remove(chart);
                        chart.DrawManager = null;
                        chart.RedrawChart();
                    }
        }
        #endregion

        #region Draw & Save Chart
        public void Redraw(Chart sender)
        {
            if (beginDraw)
                return;

            //If only one chart is not draw,we dont draw all chart
            foreach (Coordinated c in coordinated)
                foreach (Chart chart in c.Charts)
                    if (!chart.Redrawable)
                    {
                        return;
                    }

            dicDraw.Clear();
            dicDraw.Add(sender, new ChartInfo(sender));
            foreach (Coordinated c in coordinated)
                foreach (Chart chart in c.Charts)
                    if (!dicDraw.ContainsKey(chart))
                        dicDraw.Add(chart, new ChartInfo(chart));

            int a = 0;
            beginDraw = true;
            CalculateToXAxileSpace(null, ref a, ref a, ref a);
            beginDraw = false;

            foreach (Chart chart in dicDraw.Keys)
                chart.RedrawChartFinalCallFromIDrawManager();
        }

        public Dictionary<Chart, Bitmap> SaveImageOfChart(Size sizeOfImage, Dictionary<Chart, RectangleF> dicArea = null)
        {
            dicDraw.Clear();
            foreach (Coordinated c in coordinated)
                foreach (Chart chart in c.Charts)
                    if (!dicDraw.ContainsKey(chart))
                        dicDraw.Add(chart, new ChartInfo(chart, sizeOfImage));

            int a = 0;
            beginDraw = true;
            CalculateToXAxileSpace(null, ref a, ref a, ref a);
            beginDraw = false;

            Dictionary<Chart, Bitmap> dic = new Dictionary<Chart, Bitmap>();
            foreach (ChartInfo ci in dicDraw.Values)
            {
                if (dicArea != null)
                    dicArea.Add(ci.Chart, ci.Chart.Component.CurrentChartDrawArea);
                dic.Add(ci.Chart, ci.Bitmap);
            }

            return dic;
        }
        #endregion

        #region Calculate XAxile Space
        bool beginDraw = false;
        Dictionary<Chart, ChartInfo> dicDraw = new Dictionary<Chart, ChartInfo>();
        internal void CalculateToXAxileSpace(Chart chart, ref int xAxileSpace, ref int yAxileSpace1, ref int yAxileSpace2)
        {
            if (chart != null)
            {
                dicDraw[chart].XAxileSpace = xAxileSpace;
                dicDraw[chart].YAxileSpace1 = yAxileSpace1;
                dicDraw[chart].YAxileSpace2 = yAxileSpace2;
            }

            Chart nextChart = null;
            bool breakNext = (chart == null);
            //Get next of curent chart
            foreach (Chart c in dicDraw.Keys)
            {
                nextChart = c;
                if (breakNext) break;
                if (c == chart)
                    breakNext = true;
            }

            if (chart != nextChart)//Not End loop
            {
                Bitmap bmp = dicDraw[nextChart].Bitmap;
                if (bmp == null)//Draw control
                    nextChart.RedrawChartCallFromIDrawManager();
                else//Save Bitmap
                    nextChart.SaveImageOfChartByDrawManager(bmp);
            }
            else
            {
                //Calculate max space
                foreach (Coordinated c in coordinated)
                {
                    if (c.Axile == Axile.X)
                    {
                        int max = 0;
                        foreach (Chart ch in c.Charts)
                            max = Math.Max(max, dicDraw[ch].XAxileSpace);
                        foreach (Chart ch in c.Charts)
                            dicDraw[ch].XAxileSpace = max;
                    }
                    else if (c.Axile == Axile.Y)
                    {
                        int max1 = 0;
                        int max2 = 0;
                        foreach (Chart ch in c.Charts)
                        {
                            max1 = Math.Max(max1, dicDraw[ch].YAxileSpace1);
                            max2 = Math.Max(max2, dicDraw[ch].YAxileSpace2);
                        }
                        foreach (Chart ch in c.Charts)
                        {
                            dicDraw[ch].YAxileSpace1 = max1;
                            dicDraw[ch].YAxileSpace2 = max2;
                        }
                    }
                }
            }

            if (chart != null)
            {
                xAxileSpace = dicDraw[chart].XAxileSpace;
                yAxileSpace1 = dicDraw[chart].YAxileSpace1;
                yAxileSpace2 = dicDraw[chart].YAxileSpace2;
            }
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            if (disposed) return;

            foreach (Coordinated c in coordinated)
                foreach (Chart chart in c.Charts)
                {
                    chart.DrawManager = null;
                    chart.ComponentChanged -= new EventHandler(Chart_ComponentChanged);
                }

            disposed = true;
        }
        #endregion
    }
}
