using BUS_QuanLy;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI_QuanLy
{
    public partial class GUI_BaoCaoThongKe : Form
    {
        private BUS_ChiPhi busChiPhi;
        private BUS_HoaDonMua busHoaDonMua;


        public GUI_BaoCaoThongKe()
        {
            InitializeComponent();
            busChiPhi = new BUS_ChiPhi();
            busHoaDonMua = new BUS_HoaDonMua();
            this.Load += new EventHandler(GUI_BaoCaoThongKe_Load);
        }

        private void GUI_BaoCaoThongKe_Load(object sender, EventArgs e)
        {
            LoadBieuDoChiPhiTheoThang();
            LoadPieChartTop5ChiPhi();
            LoadBieuDoHoaDonMuaTheoNgay();
            LoadBieuDoHoaDonMuaTheoThang();

        }

        private void LoadBieuDoChiPhiTheoThang()
        {
            try
            {
                DataTable dt = busChiPhi.GetTongChiPhiTheoThang();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu chi phí để hiển thị biểu đồ.");
                    return;
                }

                if (chartChiPhiThang.ChartAreas.Count == 0)
                {
                    chartChiPhiThang.ChartAreas.Add(new ChartArea("Default"));
                }

                chartChiPhiThang.Series.Clear();
                chartChiPhiThang.ChartAreas[0].AxisX.Title = "Tháng";
                chartChiPhiThang.ChartAreas[0].AxisY.Title = "Tổng Chi Phí";

                Series series = new Series("Tổng Chi Phí");
                series.ChartType = SeriesChartType.Column;
                series.IsValueShownAsLabel = true;

                foreach (DataRow row in dt.Rows)
                {
                    int thang = Convert.ToInt32(row["Thang"]);
                    decimal tongChiPhi = Convert.ToDecimal(row["TongChiPhi"]);
                    series.Points.AddXY("Tháng " + thang, tongChiPhi);
                }

                chartChiPhiThang.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải biểu đồ: " + ex.Message);
            }
        }
        private void LoadPieChartTop5ChiPhi()
        {
            try
            {
                DataTable dt = busChiPhi.GetTop5ChiPhiNhieuNhat();

                chartTop5ChiPhi.Series.Clear();
                chartTop5ChiPhi.ChartAreas[0].Area3DStyle.Enable3D = true;

                Series series = new Series("Top 5 Chi Phí");
                series.ChartType = SeriesChartType.Pie;
                series.IsValueShownAsLabel = true;

                foreach (DataRow row in dt.Rows)
                {
                    string tenChiPhi = row["TenChiPhi"].ToString();
                    decimal soTien = Convert.ToDecimal(row["SoTien"]);
                    series.Points.AddXY(tenChiPhi, soTien);
                }

                chartTop5ChiPhi.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải biểu đồ Top 5 Chi Phí: " + ex.Message);
            }
        }
        private void LoadBieuDoHoaDonMuaTheoNgay()
        {
            try
            {
                DataTable dt = busHoaDonMua.GetTongTienTheoNgay();

                chartHoaDonMuaTheoNgay.Series.Clear();
                chartHoaDonMuaTheoNgay.ChartAreas[0].AxisX.Title = "Ngày";
                chartHoaDonMuaTheoNgay.ChartAreas[0].AxisY.Title = "Tổng tiền";

                Series series = new Series("Hóa đơn theo ngày");
                series.ChartType = SeriesChartType.Line;
                series.IsValueShownAsLabel = true;

                foreach (DataRow row in dt.Rows)
                {
                    DateTime ngay = Convert.ToDateTime(row["NgayLap"]);
                    decimal tongTien = Convert.ToDecimal(row["TongTien"]);
                    series.Points.AddXY(ngay.ToString("dd/MM/yyyy"), tongTien);
                }

                chartHoaDonMuaTheoNgay.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải biểu đồ hóa đơn mua theo ngày: " + ex.Message);
            }
        }


        private void LoadBieuDoHoaDonMuaTheoThang()
        {
            try
            {
                DataTable dt = busHoaDonMua.GetTongTienTheoThang();

                Series series = new Series("Theo tháng");
                series.ChartType = SeriesChartType.Column;
                series.IsValueShownAsLabel = true;

                foreach (DataRow row in dt.Rows)
                {
                    string thang = "Tháng " + row["Thang"].ToString();
                    decimal tongTien = Convert.ToDecimal(row["TongTien"]);
                    series.Points.AddXY(thang, tongTien);
                }

                chartHoaDonMuaTheoThang.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải biểu đồ hóa đơn mua theo tháng: " + ex.Message);
            }
        }

    }
}
