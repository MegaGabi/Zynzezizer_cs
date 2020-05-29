namespace Zynzezizer_cs
{
    partial class Plotter
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chrt_Plot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chrt_Plot)).BeginInit();
            this.SuspendLayout();
            // 
            // chrt_Plot
            // 
            chartArea1.Name = "ChartArea1";
            this.chrt_Plot.ChartAreas.Add(chartArea1);
            this.chrt_Plot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chrt_Plot.Location = new System.Drawing.Point(0, 0);
            this.chrt_Plot.Name = "chrt_Plot";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Name = "Graph";
            this.chrt_Plot.Series.Add(series1);
            this.chrt_Plot.Size = new System.Drawing.Size(488, 450);
            this.chrt_Plot.TabIndex = 0;
            this.chrt_Plot.Text = "chart1";
            // 
            // Plotter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 450);
            this.Controls.Add(this.chrt_Plot);
            this.Name = "Plotter";
            this.Text = "Plot";
            ((System.ComponentModel.ISupportInitialize)(this.chrt_Plot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chrt_Plot;
    }
}