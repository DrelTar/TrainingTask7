namespace WindowsFormsApp1
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.middle = new System.Windows.Forms.Label();
            this.median = new System.Windows.Forms.Label();
            this.square = new System.Windows.Forms.Label();
            this.dispersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(12, 35);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(776, 403);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // middle
            // 
            this.middle.AutoSize = true;
            this.middle.Location = new System.Drawing.Point(12, 9);
            this.middle.Name = "middle";
            this.middle.Size = new System.Drawing.Size(46, 17);
            this.middle.TabIndex = 1;
            this.middle.Text = "label1";
            // 
            // median
            // 
            this.median.AutoSize = true;
            this.median.Location = new System.Drawing.Point(166, 9);
            this.median.Name = "median";
            this.median.Size = new System.Drawing.Size(46, 17);
            this.median.TabIndex = 2;
            this.median.Text = "label1";
            // 
            // square
            // 
            this.square.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.square.AutoSize = true;
            this.square.Location = new System.Drawing.Point(344, 9);
            this.square.Name = "square";
            this.square.Size = new System.Drawing.Size(46, 17);
            this.square.TabIndex = 3;
            this.square.Text = "label1";
            // 
            // dispersion
            // 
            this.dispersion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dispersion.AutoSize = true;
            this.dispersion.Location = new System.Drawing.Point(545, 9);
            this.dispersion.Name = "dispersion";
            this.dispersion.Size = new System.Drawing.Size(46, 17);
            this.dispersion.TabIndex = 4;
            this.dispersion.Text = "label1";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dispersion);
            this.Controls.Add(this.square);
            this.Controls.Add(this.median);
            this.Controls.Add(this.middle);
            this.Controls.Add(this.chart1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label middle;
        private System.Windows.Forms.Label median;
        private System.Windows.Forms.Label square;
        private System.Windows.Forms.Label dispersion;
    }
}