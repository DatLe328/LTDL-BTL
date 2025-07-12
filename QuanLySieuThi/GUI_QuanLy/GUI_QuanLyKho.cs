using BUS_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI_QuanLy
{
    public partial class GUI_QuanLyKho : Form
    {
        private BUS_HangHoa busHangHoa;
        private BUS_LoaiHangHoa busLoaiHangHoa;
        private BUS_LoHang busLoHang;
        private BUS_NhaCungCap busNhaCungCap;
        private BUS_HoaDonMua busHoaDonMua;

        public GUI_QuanLyKho()
        {
            InitializeComponent();
            busHangHoa = new BUS_HangHoa();
            busLoaiHangHoa = new BUS_LoaiHangHoa();
            busLoHang = new BUS_LoHang();
            busNhaCungCap = new BUS_NhaCungCap();
            busHoaDonMua = new BUS_HoaDonMua();
        }

        private void QuanLyKho_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Mã nhân viên: " + Globals.MaNhanVien);
            if (Globals.MaNhanVien == -1)
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này.");
                this.Close();
            }
        }
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tabControl = sender as TabControl;

            switch (tabControl.SelectedIndex)
            {
                case 0:
                    LoadQuanLyHangHoa();
                    break;
                case 1:
                    LoadLoHang();
                    break;
                case 2:
                    LoadHoaDonMua();
                    break;
                case 3:
                    LoadQuanLyDatHang();
                    break;
            }
        }

        /*
         * Hàng hóa
         */
        private void LoadQuanLyHangHoa()
        {
            LoadComboBoxHangHoa();
            PerformSearchHangHoa();
        }
        private void LoadComboBoxHangHoa()
        {
            DataTable dtLoaiHangHoa = busLoaiHangHoa.GetLoaiHangHoa();
            if (dtLoaiHangHoa != null && dtLoaiHangHoa.Rows.Count > 0)
            {
                cbLoaiHangHoa.DataSource = dtLoaiHangHoa;
                cbLoaiHangHoa.DisplayMember = "TenLoaiHangHoa";
                cbLoaiHangHoa.ValueMember = "MaLoaiHangHoa";
                cbLoaiHangHoa.SelectedIndex = 0;
            }
        }
        private void PerformSearchHangHoa()
        {
            string keyword = txtTimKiemHangHoa.Text.Trim();
            dgvHangHoa.DataSource = busHangHoa.GetHangHoa(tenHangHoa: keyword);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            PerformSearchHangHoa();
        }

        private void dgvHangHoa_Click(object sender, EventArgs e)
        {
            if (dgvHangHoa.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvHangHoa.SelectedRows[0];
                txtTenHangHoa.Text = selectedRow.Cells["TenHangHoa"].Value.ToString();
                cbLoaiHangHoa.SelectedValue = selectedRow.Cells["MaLoaiHangHoa"].Value;
                txtDonViTinh.Text = selectedRow.Cells["DonViTinh"].Value.ToString();
                txtGiaBan.Text = selectedRow.Cells["GiaBan"].Value.ToString();
            }
        }

        private void btnThemHangHoa_Click(object sender, EventArgs e)
        {
            string tenHangHoa = txtTenHangHoa.Text.Trim();
            string donViTinh = txtDonViTinh.Text.Trim();
            int giaBan = txtGiaBan.Text.Trim() == "" ? 0 : Convert.ToInt32(txtGiaBan.Text.Trim());
            try
            {
                if (string.IsNullOrEmpty(tenHangHoa) || string.IsNullOrEmpty(donViTinh))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin hàng hóa.");
                    return;
                }
                int maLoaiHangHoa = Convert.ToInt32(cbLoaiHangHoa.SelectedValue);
                DTO_HangHoa newHangHoa = new DTO_HangHoa
                {
                    TenHangHoa = tenHangHoa,
                    MaLoaiHangHoa = maLoaiHangHoa,
                    DonViTinh = donViTinh,
                    GiaBan = giaBan
                };
                bool result = busHangHoa.AddHangHoa(newHangHoa);
                if (result)
                {
                    MessageBox.Show("Thêm hàng hóa thành công.");
                    PerformSearchHangHoa();
                }
                else
                {
                    MessageBox.Show("Thêm hàng hóa thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
            PerformSearchHangHoa();
        }

        private void btnXoaHangHoa_Click(object sender, EventArgs e)
        {
            if (dgvHangHoa.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvHangHoa.SelectedRows[0];
                int maHangHoa = Convert.ToInt32(selectedRow.Cells["MaLoaiHangHoa"].Value);
                try
                {
                    bool result = busHangHoa.DeleteHangHoa(maHangHoa);
                    if (result)
                    {
                        MessageBox.Show("Xóa hàng hóa thành công.");
                        PerformSearchHangHoa();
                    }
                    else
                    {
                        MessageBox.Show("Xóa hàng hóa thất bại.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }
        }

        private void btnSuaHangHoa_Click(object sender, EventArgs e)
        {
            string tenHangHoa = txtTenHangHoa.Text.Trim();
            string donViTinh = txtDonViTinh.Text.Trim();
            int giaBan = txtGiaBan.Text.Trim() == "" ? 0 : Convert.ToInt32(txtGiaBan.Text.Trim());
            if (dgvHangHoa.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvHangHoa.SelectedRows[0];
                int maHangHoa = Convert.ToInt32(selectedRow.Cells["MaHangHoa"].Value);
                try
                {
                    if (string.IsNullOrEmpty(tenHangHoa) || string.IsNullOrEmpty(donViTinh))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin hàng hóa.");
                        return;
                    }
                    int maLoaiHangHoa = Convert.ToInt32(cbLoaiHangHoa.SelectedValue);
                    DTO_HangHoa updatedHangHoa = new DTO_HangHoa
                    {
                        MaHangHoa = maHangHoa,
                        TenHangHoa = tenHangHoa,
                        MaLoaiHangHoa = maLoaiHangHoa,
                        DonViTinh = donViTinh,
                        GiaBan = giaBan
                    };
                    bool result = busHangHoa.UpdateHangHoa(updatedHangHoa);
                    if (result)
                    {
                        MessageBox.Show("Cập nhật hàng hóa thành công.");
                        PerformSearchHangHoa();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật hàng hóa thất bại.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hàng hóa để sửa.");
            }
        }

        /*
         * Lô hàng
         */
        private void LoadLoHang()
        {
            try
            {
                DataTable dtLoHang = busLoHang.GetLoHang();
                if (dtLoHang != null && dtLoHang.Rows.Count > 0)
                {
                    dgvLoHang.DataSource = dtLoHang;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lô hàng: {ex.Message}");
            }
            dgvLoHang.SelectionChanged += dgvLoHang_SelectionChanged;

        }
        private void dgvLoHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLoHang.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvLoHang.SelectedRows[0];
                txtSoLuong.Text = row.Cells["SoLuong"].Value?.ToString();
                txtSoLuongTonKho.Text = row.Cells["SoLuongTonKho"].Value?.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value?.ToString();
                txtMaKho.Text = row.Cells["MaKho"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["NgaySanXuat"].Value?.ToString(), out DateTime nsx))
                    txtNXS.Text = nsx.ToString("yyyy-MM-dd");
                else
                    txtNXS.Text = "";

                if (DateTime.TryParse(row.Cells["HanSuDung"].Value?.ToString(), out DateTime hsd))
                    txtHSD.Text = hsd.ToString("yyyy-MM-dd");
                else
                    txtHSD.Text = "";
            }
        }

        private void btnSuaLo_Click(object sender, EventArgs e)
        {
            if (dgvLoHang.SelectedRows.Count > 0)
            {
                try
                {
                    int maLo = Convert.ToInt32(dgvLoHang.SelectedRows[0].Cells["MaLoHang"].Value);

                    // Kiểm tra và parse an toàn
                    if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong))
                    {
                        MessageBox.Show("Số lượng không hợp lệ.");
                        return;
                    }

                    if (!int.TryParse(txtSoLuongTonKho.Text.Trim(), out int soLuongTonKho))
                    {
                        MessageBox.Show("Số lượng tồn kho không hợp lệ.");
                        return;
                    }

                    if (!int.TryParse(txtDonGia.Text.Trim(), out int donGia))
                    {
                        MessageBox.Show("Đơn giá không hợp lệ.");
                        return;
                    }

                    if (!DateTime.TryParse(txtNXS.Text.Trim(), out DateTime ngaySanXuat))
                    {
                        MessageBox.Show("Ngày sản xuất không hợp lệ.");
                        return;
                    }

                    if (!DateTime.TryParse(txtHSD.Text.Trim(), out DateTime hanSuDung))
                    {
                        MessageBox.Show("Hạn sử dụng không hợp lệ.");
                        return;
                    }

                    DTO_LoHang lo = new DTO_LoHang
                    {
                        MaLoHang = maLo,
                        SoLuong = soLuong,
                        SoLuongTonKho = soLuongTonKho,
                        DonGia = donGia,
                        NgaySanXuat = ngaySanXuat,
                        HanSuDung = hanSuDung,
                    };

                    if (busLoHang.UpdateLoHang(lo))
                    {
                        MessageBox.Show("Sửa thành công");
                        LoadLoHang();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lô hàng cần sửa.");
            }
        }

        private void dgvLoHang_Click(object sender, EventArgs e)
        {
            if (dgvLoHang.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvLoHang.SelectedRows[0];
                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
                txtSoLuongTonKho.Text = row.Cells["SoLuongTonKho"].Value.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
                txtNXS.Text = Convert.ToDateTime(row.Cells["NgaySanXuat"].Value).ToString("yyyy-MM-dd");
                txtHSD.Text = Convert.ToDateTime(row.Cells["HanSuDung"].Value).ToString("yyyy-MM-dd");
            }
        }

        private void PerformSearchLoHang()
        {
            string keyword = txtTimKiemLoHang.Text.Trim();

            if (int.TryParse(keyword, out int maKho))
            {
                dgvLoHang.DataSource = busLoHang.GetLoHang(maKho);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã kho là số nguyên.");
            }
        }
        private void txtTimKiemLoHang_TextChanged(object sender, EventArgs e)
        {
            PerformSearchLoHang();
        }
        //Hoa don mua
        private void LoadHoaDonMua()
        {
            try
            {
                DataTable dtHoaDon = busHoaDonMua.GetHoaDonMua();
                if (dtHoaDon != null && dtHoaDon.Rows.Count > 0)
                {
                    dgvHoaDonMua.DataSource = dtHoaDon;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hóa đơn mua: " + ex.Message);
            }
            VeBieuDoThongKe();
        }

        private void btnTimKiemHoaDonMua_Click(object sender, EventArgs e)
        {
            PerformSearchHoaDonMua();
            VeBieuDoThongKe();
        }
        private void PerformSearchHoaDonMua()
        {
            DateTime selectedDate = dtpNgayNhap.Value.Date;
            DataTable dt = busHoaDonMua.GetHoaDonMuaByDate(selectedDate);

            if (dt != null && dt.Rows.Count > 0)
            {
                dgvHoaDonMua.DataSource = dt;
            }
            else
            {
                dgvHoaDonMua.DataSource = null;
                MessageBox.Show("Không tìm thấy hóa đơn nào vào ngày đã chọn.");
            }
        }
        private void VeBieuDoThongKe()
        {
            chartThongke.Series.Clear();
            Series series = new Series("Tổng tiền");
            series.ChartType = SeriesChartType.Column;

            if (dgvHoaDonMua.Rows.Count > 0)
            {
                DataGridViewRow row = dgvHoaDonMua.Rows[0];
                if (!row.IsNewRow)
                {
                    string ngay = Convert.ToDateTime(row.Cells["NgayLap"].Value).ToString("dd/MM/yyyy");
                    decimal tongTien = Convert.ToDecimal(row.Cells["TongTien"].Value);

                    series.Points.AddXY(ngay, tongTien);
                }
            }

            chartThongke.Series.Add(series);
        }

        /*
         * Đặt hàng
         */
        private void LoadQuanLyDatHang()
        {
            LoadComboBoxNhaCungCap();
            LoadDanhSachDatMua();
            LoadDanhSachHangHoa();
            LoadDatHang();
        }
        private void LoadDatHang()
        {
            try
            {
                DataTable dtHangHoa = busHangHoa.GetHangHoa();
                if (dtHangHoa != null && dtHangHoa.Rows.Count > 0)
                {
                    dgvDanhSachHangHoa.DataSource = dtHangHoa;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải đặt hàng: {ex.Message}");
            }
        }
        private void LoadDanhSachHangHoa()
        {
            dgvDanhSachHangHoa.RowTemplate.Height = 40;
            dgvDanhSachHangHoa.Columns.Add("MaHangHoa", "Mã Hàng Hóa");
            dgvDanhSachHangHoa.Columns.Add("TenHangHoa", "Tên Hàng Hóa");
            dgvDanhSachHangHoa.Columns.Add("GiaBan", "Giá Bán");
            dgvDanhSachHangHoa.Columns.Add("DonViTinh", "Đơn Vị Tính");
            dgvDanhSachHangHoa.Columns.Add("MaLoaiHangHoa", "Mã Loại Hàng Hóa");

            dgvDanhSachHangHoa.Columns["MaHangHoa"].DataPropertyName = "MaHangHoa";
            dgvDanhSachHangHoa.Columns["TenHangHoa"].DataPropertyName = "TenHangHoa";
            dgvDanhSachHangHoa.Columns["GiaBan"].DataPropertyName = "GiaBan";
            dgvDanhSachHangHoa.Columns["DonViTinh"].DataPropertyName = "DonViTinh";
            dgvDanhSachHangHoa.Columns["MaLoaiHangHoa"].DataPropertyName = "MaLoaiHangHoa";
        }
        private void LoadDanhSachDatMua()
        {
            dgvDanhSachDatMua.RowTemplate.Height = 40;
            dgvDanhSachDatMua.Columns.Add("MaHangHoa", "Mã Hàng Hóa");
            dgvDanhSachDatMua.Columns.Add("TenHangHoa", "Tên Hàng Hóa");
            dgvDanhSachDatMua.Columns.Add("GiaBan", "Giá Bán");
            dgvDanhSachDatMua.Columns.Add("SoLuong", "Số Lượng");
            dgvDanhSachDatMua.Columns.Add("DonViTinh", "Đơn Vị Tính");
            dgvDanhSachDatMua.Columns.Add("MaLoaiHangHoa", "Mã Loại Hàng Hóa");
            dgvDanhSachDatMua.Columns.Add("MaNhaCungCap", "Mã Nhà Cung Cấp");
            dgvDanhSachDatMua.Columns.Add("HanSuDungTieuChuan", "Hạn sử dụng");
            dgvDanhSachDatMua.Columns.Add("DonViHanSuDung", "Đơn vị hạn sử dụng");

            DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();
            btnXoa.HeaderText = "Hành động";
            btnXoa.Text = "Xóa";
            btnXoa.UseColumnTextForButtonValue = true;
            btnXoa.Name = "btnXoa";

            dgvDanhSachDatMua.Columns.Add(btnXoa);
        }
        private void LoadComboBoxNhaCungCap()
        {
            DataTable dtNhaCungCap = busNhaCungCap.GetNhaCungCap();
            if (dtNhaCungCap != null && dtNhaCungCap.Rows.Count > 0)
            {
                cbNhaCungCap.DataSource = dtNhaCungCap;
                cbNhaCungCap.DisplayMember = "TenNCC";
                cbNhaCungCap.ValueMember = "MaNCC";
                cbNhaCungCap.SelectedIndex = 0;
            }
        }
        private void btnThemHangDat_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachHangHoa.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvDanhSachHangHoa.SelectedRows[0];
                int maHangHoa = Convert.ToInt32(selectedRow.Cells["MaHangHoa"].Value);
                string tenHangHoa = selectedRow.Cells["TenHangHoa"].Value.ToString();
                int giaBan = Convert.ToInt32(selectedRow.Cells["GiaBan"].Value);
                int soLuong = String.IsNullOrEmpty(txtSoLuongDatMua.Text.Trim()) ? -1 : Convert.ToInt32(txtSoLuongDatMua.Text.Trim());
                string donViTinh = selectedRow.Cells["DonViTinh"].Value.ToString();
                int maLoaiHangHoa = Convert.ToInt32(selectedRow.Cells["MaLoaiHangHoa"].Value);
                int maNhaCungCap = Convert.ToInt32(cbNhaCungCap.SelectedValue);
                int hanSuDungTieuChuan = selectedRow.Cells["HanSuDungTieuChuan"].Value != null ? Convert.ToInt32(selectedRow.Cells["HanSuDungTieuChuan"].Value) : 0;
                string donViHanSuDung = selectedRow.Cells["DonViHanSuDung"].Value != null ? selectedRow.Cells["DonViHanSuDung"].Value.ToString() : "Ngày";

                if (soLuong <= 0)
                {
                    MessageBox.Show("Số lượng đặt hàng phải lớn hơn 0.");
                    return;
                }
                try
                {
                    foreach (DataGridViewRow item in dgvDanhSachDatMua.Rows)
                    {
                        if (item.IsNewRow) continue;

                        int maHH = Convert.ToInt32(item.Cells["MaHangHoa"].Value);
                        if (maHH == maHangHoa)
                        {
                            dgvDanhSachDatMua.Rows.Remove(item);
                            break;
                        }
                    }
                    dgvDanhSachDatMua.Rows.Add(maHangHoa, tenHangHoa, giaBan, soLuong, donViTinh, maLoaiHangHoa, maNhaCungCap, hanSuDungTieuChuan, donViHanSuDung);
                }
                    catch (Exception ex)
                    {
                    MessageBox.Show($"Lỗi khi đặt hàng: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hàng hóa để đặt.");
            }
        }

        private void dgvDanhSachDatMua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvDanhSachDatMua.Columns[e.ColumnIndex].Name == "btnXoa")
            {
                var result = MessageBox.Show("Bạn có chắc muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    dgvDanhSachDatMua.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
        DateTime TinhHanSuDung(DateTime nsx, int hsdTieuChuan, string donVi)
        {
            return donVi.Equals("Tháng", StringComparison.OrdinalIgnoreCase)
                   ? nsx.AddMonths(hsdTieuChuan)
                   : nsx.AddDays(hsdTieuChuan);
        }
        private void btnDatHang_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDanhSachDatMua.Rows.Count == 0)
                {
                    MessageBox.Show("Không có hàng hóa nào để đặt.");
                    return;
                }
                DTO_HoaDonMua newHoaDonMua = new DTO_HoaDonMua
                {
                    MaNCC = Convert.ToInt32(cbNhaCungCap.SelectedValue),
                    NgayLap = DateTime.Now,
                    TongTien = 0,
                    GhiChu = txtGhiChu.Text.Trim()
                };
                bool result = busHoaDonMua.AddHoaDonMua(newHoaDonMua);
                int maHoaDonMua = busHoaDonMua.GetLastHoaDonMuaId();

                List<DTO_LoHang> danhSachDatHang = new List<DTO_LoHang>();
                foreach (DataGridViewRow row in dgvDanhSachDatMua.Rows)
                {
                    Console.WriteLine(row.Cells["MaHangHoa"].Value);
                    if (row.IsNewRow) continue;
                    var maHangHoa = Convert.ToInt32(row.Cells["MaHangHoa"].Value);
                    var soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    var donGia = Convert.ToInt32(row.Cells["GiaBan"].Value);
                    var ngaySanXuat = DateTime.Now;
                    var hanSuDungTieuChuan = row.Cells["HanSuDungTieuChuan"].Value != null ? Convert.ToInt32(row.Cells["HanSuDungTieuChuan"].Value) : 0;
                    var donViHanSuDung = row.Cells["DonViHanSuDung"].Value != null ? row.Cells["DonViHanSuDung"].Value.ToString() : "Ngày";
                    var hanSuDung = TinhHanSuDung(DateTime.Now, hanSuDungTieuChuan, donViHanSuDung);
                    var maKho = 1;
                    Console.WriteLine($"Mã hàng hóa: {maHangHoa}, Số lượng: {soLuong}, Đơn giá: {donGia}, Ngày sản xuất: {ngaySanXuat}, Hạn sử dụng: {hanSuDung}");
                    Console.WriteLine($"Mã hóa đơn mua: {maHoaDonMua}, Mã kho: {maKho}");

                    DTO_LoHang loHang = new DTO_LoHang
                    {
                        MaHangHoa = maHangHoa,
                        SoLuong = soLuong,
                        SoLuongTonKho = soLuong,
                        DonGia = donGia,
                        NgaySanXuat = ngaySanXuat,
                        HanSuDung = hanSuDung,
                        MaHoaDonMua = maHoaDonMua,
                        MaKho = maKho
                    };
                    danhSachDatHang.Add(loHang);
                }
                newHoaDonMua.TongTien = danhSachDatHang.Sum(x => x.DonGia * x.SoLuong);
                newHoaDonMua.MaHoaDon = maHoaDonMua;
                result = busHoaDonMua.UpdateHoaDonMua(newHoaDonMua);
                result &= busLoHang.AddLoHang(danhSachDatHang);
                if (result)
                {
                    MessageBox.Show("Đặt hàng thành công.");
                    LoadDatHang();
                    dgvDanhSachDatMua.Rows.Clear();
                }
                else
                {
                    MessageBox.Show("Đặt hàng thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đặt hàng: {ex.Message}");
            }
        }
    }
}
