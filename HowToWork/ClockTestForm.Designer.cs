namespace HowToWork
{
    partial class ClockTestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ctbHMSM = new SMAH1.Forms.Clock.ClockTextBox();
            this.ctbHMS = new SMAH1.Forms.Clock.ClockTextBox();
            this.ctbHM = new SMAH1.Forms.Clock.ClockTextBox();
            this.ctbMinute = new SMAH1.Forms.Clock.ClockTextBox();
            this.meeGoClock1 = new SMAH1.Forms.Clock.MeeGoClock();
            this.ctbHour = new SMAH1.Forms.Clock.ClockTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ctbHMSM2 = new SMAH1.Forms.Clock.ClockTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Hour";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Minute";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hour-Minute";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 376);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Hour-Minute-Second";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 403);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Hour to Millisecond";
            // 
            // ctbHMSM
            // 
            this.ctbHMSM.BackColor = System.Drawing.SystemColors.Window;
            this.ctbHMSM.Location = new System.Drawing.Point(145, 400);
            this.ctbHMSM.MinimumSize = new System.Drawing.Size(50, 21);
            this.ctbHMSM.Name = "ctbHMSM";
            this.ctbHMSM.Size = new System.Drawing.Size(188, 20);
            this.ctbHMSM.TabIndex = 5;
            this.ctbHMSM.Text = "00:00:00:000";
            this.ctbHMSM.TimeStatus = SMAH1.Forms.Clock.TimeLayout.HourMinuteSecondMillisecond;
            // 
            // ctbHMS
            // 
            this.ctbHMS.BackColor = System.Drawing.SystemColors.Window;
            this.ctbHMS.Location = new System.Drawing.Point(145, 373);
            this.ctbHMS.MinimumSize = new System.Drawing.Size(50, 21);
            this.ctbHMS.Name = "ctbHMS";
            this.ctbHMS.Size = new System.Drawing.Size(188, 20);
            this.ctbHMS.TabIndex = 4;
            this.ctbHMS.Text = "00:00:00";
            this.ctbHMS.TimeStatus = SMAH1.Forms.Clock.TimeLayout.HourMinuteSecond;
            // 
            // ctbHM
            // 
            this.ctbHM.BackColor = System.Drawing.SystemColors.Window;
            this.ctbHM.Location = new System.Drawing.Point(145, 346);
            this.ctbHM.MinimumSize = new System.Drawing.Size(50, 21);
            this.ctbHM.Name = "ctbHM";
            this.ctbHM.Size = new System.Drawing.Size(188, 20);
            this.ctbHM.TabIndex = 3;
            this.ctbHM.Text = "00:00";
            this.ctbHM.TimeStatus = SMAH1.Forms.Clock.TimeLayout.HourMinute;
            // 
            // ctbMinute
            // 
            this.ctbMinute.BackColor = System.Drawing.SystemColors.Window;
            this.ctbMinute.Location = new System.Drawing.Point(145, 319);
            this.ctbMinute.MinimumSize = new System.Drawing.Size(50, 21);
            this.ctbMinute.Name = "ctbMinute";
            this.ctbMinute.Size = new System.Drawing.Size(188, 20);
            this.ctbMinute.TabIndex = 2;
            this.ctbMinute.Text = "00";
            this.ctbMinute.TimeStatus = SMAH1.Forms.Clock.TimeLayout.Minute;
            // 
            // meeGoClock1
            // 
            this.meeGoClock1.CenterCircleEdgeColor = System.Drawing.Color.Gray;
            this.meeGoClock1.CenterCircleEndGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.meeGoClock1.CenterCircleStartGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.meeGoClock1.CenterEdgeThickness = 2F;
            this.meeGoClock1.ClockCircleEdgeColor = System.Drawing.Color.WhiteSmoke;
            this.meeGoClock1.ClockCircleEndGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.meeGoClock1.ClockCircleStartGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.meeGoClock1.ClockEdgeThickness = 1F;
            this.meeGoClock1.HourCircleEdgeColor = System.Drawing.Color.WhiteSmoke;
            this.meeGoClock1.HourCircleEndGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.meeGoClock1.HourCircleStartGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.meeGoClock1.HourEdgeThickness = 1F;
            this.meeGoClock1.HourForeColor = System.Drawing.Color.Black;
            this.meeGoClock1.Location = new System.Drawing.Point(12, 12);
            this.meeGoClock1.MinuteCircleEdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(127)))), ((int)(((byte)(100)))));
            this.meeGoClock1.MinuteCircleEndGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(23)))), ((int)(((byte)(14)))));
            this.meeGoClock1.MinuteCircleStartGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(23)))), ((int)(((byte)(8)))));
            this.meeGoClock1.MinuteEdgeThickness = 1F;
            this.meeGoClock1.MinuteForeColor = System.Drawing.Color.White;
            this.meeGoClock1.Name = "meeGoClock1";
            this.meeGoClock1.SecondCircleEdgeColor = System.Drawing.Color.Red;
            this.meeGoClock1.SecondCircleEndGradientColor = System.Drawing.Color.Red;
            this.meeGoClock1.SecondCircleStartGradientColor = System.Drawing.Color.Red;
            this.meeGoClock1.SecondEdgeThickness = 1F;
            this.meeGoClock1.Size = new System.Drawing.Size(321, 237);
            this.meeGoClock1.TabIndex = 1;
            // 
            // ctbHour
            // 
            this.ctbHour.BackColor = System.Drawing.SystemColors.Window;
            this.ctbHour.Location = new System.Drawing.Point(145, 292);
            this.ctbHour.MinimumSize = new System.Drawing.Size(50, 21);
            this.ctbHour.Name = "ctbHour";
            this.ctbHour.Size = new System.Drawing.Size(188, 20);
            this.ctbHour.TabIndex = 0;
            this.ctbHour.Text = "00";
            this.ctbHour.TimeStatus = SMAH1.Forms.Clock.TimeLayout.Hour;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 429);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Hour to Millisecond (RTL)";
            // 
            // ctbHMSM2
            // 
            this.ctbHMSM2.BackColor = System.Drawing.SystemColors.Window;
            this.ctbHMSM2.Location = new System.Drawing.Point(145, 426);
            this.ctbHMSM2.MinimumSize = new System.Drawing.Size(50, 21);
            this.ctbHMSM2.Name = "ctbHMSM2";
            this.ctbHMSM2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctbHMSM2.Size = new System.Drawing.Size(188, 20);
            this.ctbHMSM2.TabIndex = 11;
            this.ctbHMSM2.Text = "00:00:00:000";
            this.ctbHMSM2.TimeStatus = SMAH1.Forms.Clock.TimeLayout.HourMinuteSecondMillisecond;
            // 
            // ClockTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 456);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ctbHMSM2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctbHMSM);
            this.Controls.Add(this.ctbHMS);
            this.Controls.Add(this.ctbHM);
            this.Controls.Add(this.ctbMinute);
            this.Controls.Add(this.meeGoClock1);
            this.Controls.Add(this.ctbHour);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClockTestForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clock Controls";
            this.Load += new System.EventHandler(this.ClockForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SMAH1.Forms.Clock.ClockTextBox ctbHour;
        private SMAH1.Forms.Clock.MeeGoClock meeGoClock1;
        private SMAH1.Forms.Clock.ClockTextBox ctbMinute;
        private SMAH1.Forms.Clock.ClockTextBox ctbHM;
        private SMAH1.Forms.Clock.ClockTextBox ctbHMS;
        private SMAH1.Forms.Clock.ClockTextBox ctbHMSM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private SMAH1.Forms.Clock.ClockTextBox ctbHMSM2;
    }
}