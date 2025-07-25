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
        private BUS_ChiTietLuong busChiTietLuong;
        private BUS_BangChamCong busBangChamCong;

        public GUI_BaoCaoThongKe()
        {
            InitializeComponent();
            busChiPhi = new BUS_ChiPhi();
            busHoaDonMua = new BUS_HoaDonMua();
            busChiTietLuong = new BUS_ChiTietLuong();
            busBangChamCong = new BUS_BangChamCong();
            this.Load += new EventHandler(GUI_BaoCaoThongKe_Load);
        }

        private void GUI_BaoCaoThongKe_Load(object sender, EventArgs e)
        {
            LoadBieuDoChiPhiTheoThang();
            LoadPieChartTop5ChiPhi();
            LoadBieuDoHoaDonMuaTheoNgay();
            LoadBieuDoHoaDonMuaTheoThang();
            LoadBieuDoLuongTheoLoai();
            LoadTop5NhanVienLuongCaoNhat();
            LoadThongKeNgayCong(DateTime.Now.Month, DateTime.Now.Year);
        }

        //Bao cao thong ke chi phi
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

        //Bao cao thong ke hoa don mua
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


        //Bao cao thong ke tien luong
        private void LoadBieuDoLuongTheoLoai()
        {
            try
            {
                DataTable dt = busChiTietLuong.ThongKeTatCaLuongTheoLoaiKhoan();

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu lương để hiển thị.");
                    return;
                }

                chartLuong.Series.Clear();
                if (chartLuong.ChartAreas.Count == 0)
                {
                    chartLuong.ChartAreas.Add(new ChartArea("Default"));
                }

                chartLuong.ChartAreas[0].AxisX.Title = "Loại khoản";
                chartLuong.ChartAreas[0].AxisY.Title = "Tổng tiền";

                Series series = new Series("Tiền lương");
                series.ChartType = SeriesChartType.Column;
                series.IsValueShownAsLabel = true;

                foreach (DataRow row in dt.Rows)
                {
                    string loai = row["LoaiKhoan"].ToString();
                    decimal tong = Convert.ToDecimal(row["TongTien"]);
                    series.Points.AddXY(loai, tong);
                }

                chartLuong.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải biểu đồ lương: " + ex.Message);
            }
        }
        private void LoadTop5NhanVienLuongCaoNhat()
        {
            try
            {
                DataTable dt = busChiTietLuong.GetTop5NhanVienLuongCaoNhat();

                chartTopLuong.Series.Clear();
                if (chartTopLuong.ChartAreas.Count == 0)
                    chartTopLuong.ChartAreas.Add(new ChartArea("Default"));

                chartTopLuong.ChartAreas[0].AxisX.Title = "Nhân viên";
                chartTopLuong.ChartAreas[0].AxisY.Title = "Tổng lương";

                Series series = new Series("Top 5 Lương");
                series.ChartType = SeriesChartType.Column;
                series.IsValueShownAsLabel = true;

                foreach (DataRow row in dt.Rows)
                {
                    string tenNV = row["HoTenNV"].ToString();
                    decimal tongLuong = Convert.ToDecimal(row["TongLuong"]);
                    series.Points.AddXY(tenNV, tongLuong);
                }

                chartTopLuong.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải biểu đồ Top 5 lương: " + ex.Message);
            }
        }

        private void LoadThongKeNgayCong(int thang, int nam)
        {
            DataTable dt = busBangChamCong.ThongKeNgayCongTheoThang(thang, nam);

            chartNgayCong.Series.Clear();
            chartNgayCong.ChartAreas[0].AxisX.Title = "Nhân viên";
            chartNgayCong.ChartAreas[0].AxisY.Title = "Số ngày công";

            Series series = new Series("Ngày công");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;

            foreach (DataRow row in dt.Rows)
            {
                string tenNV = row["TenNhanVien"].ToString();
                int soNgayCong = Convert.ToInt32(row["SoNgayCong"]);
                series.Points.AddXY(tenNV, soNgayCong);
            }
            chartNgayCong.Series.Add(series);
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
                DateTime ngayChon = dtpChonThangNam.Value;
                int thang = ngayChon.Month;
                int nam = ngayChon.Year;

                LoadThongKeNgayCong(thang, nam);
        }
    }
}
