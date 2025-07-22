namespace GUI_QuanLy
{
    partial class GUI_BaoCaoThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chartChiPhiThang = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTop5ChiPhi = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartHoaDonMuaTheoThang = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartHoaDonMuaTheoNgay = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartChiPhiThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTop5ChiPhi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHoaDonMuaTheoThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHoaDonMuaTheoNgay)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1030, 560);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chartTop5ChiPhi);
            this.tabPage1.Controls.Add(this.chartChiPhiThang);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1022, 523);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chi Phí";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chartHoaDonMuaTheoNgay);
            this.tabPage2.Controls.Add(this.chartHoaDonMuaTheoThang);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1022, 523);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hoá đơn mua";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chartChiPhiThang
            // 
            chartArea2.Name = "ChartArea1";
            this.chartChiPhiThang.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartChiPhiThang.Legends.Add(legend2);
            this.chartChiPhiThang.Location = new System.Drawing.Point(6, 21);
            this.chartChiPhiThang.Name = "chartChiPhiThang";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartChiPhiThang.Series.Add(series2);
            this.chartChiPhiThang.Size = new System.Drawing.Size(506, 507);
            this.chartChiPhiThang.TabIndex = 0;
            this.chartChiPhiThang.Text = "chart1";
            // 
            // chartTop5ChiPhi
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTop5ChiPhi.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTop5ChiPhi.Legends.Add(legend1);
            this.chartTop5ChiPhi.Location = new System.Drawing.Point(513, 21);
            this.chartTop5ChiPhi.Name = "chartTop5ChiPhi";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTop5ChiPhi.Series.Add(series1);
            this.chartTop5ChiPhi.Size = new System.Drawing.Size(506, 507);
            this.chartTop5ChiPhi.TabIndex = 1;
            this.chartTop5ChiPhi.Text = "chart2";
            // 
            // chartHoaDonMuaTheoThang
            // 
            chartArea4.Name = "ChartArea1";
            this.chartHoaDonMuaTheoThang.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartHoaDonMuaTheoThang.Legends.Add(legend4);
            this.chartHoaDonMuaTheoThang.Location = new System.Drawing.Point(6, 17);
            this.chartHoaDonMuaTheoThang.Name = "chartHoaDonMuaTheoThang";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartHoaDonMuaTheoThang.Series.Add(series4);
            this.chartHoaDonMuaTheoThang.Size = new System.Drawing.Size(505, 503);
            this.chartHoaDonMuaTheoThang.TabIndex = 0;
            this.chartHoaDonMuaTheoThang.Text = "chart1";
            // 
            // chartHoaDonMuaTheoNgay
            // 
            chartArea3.Name = "ChartArea1";
            this.chartHoaDonMuaTheoNgay.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartHoaDonMuaTheoNgay.Legends.Add(legend3);
            this.chartHoaDonMuaTheoNgay.Location = new System.Drawing.Point(517, 17);
            this.chartHoaDonMuaTheoNgay.Name = "chartHoaDonMuaTheoNgay";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartHoaDonMuaTheoNgay.Series.Add(series3);
            this.chartHoaDonMuaTheoNgay.Size = new System.Drawing.Size(499, 503);
            this.chartHoaDonMuaTheoNgay.TabIndex = 1;
            this.chartHoaDonMuaTheoNgay.Text = "chart2";
            // 
            // GUI_BaoCaoThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 584);
            this.Controls.Add(this.tabControl1);
            this.Name = "GUI_BaoCaoThongKe";
            this.Text = "GUI_BaoCaoThongKe";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartChiPhiThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTop5ChiPhi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHoaDonMuaTheoThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHoaDonMuaTheoNgay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTop5ChiPhi;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartChiPhiThang;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHoaDonMuaTheoNgay;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHoaDonMuaTheoThang;
    }
}