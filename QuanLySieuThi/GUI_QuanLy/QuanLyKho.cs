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

namespace GUI_QuanLy
{
    public partial class QuanLyKho : Form
    {
        private BUS_HangHoa busHangHoa;
        private BUS_LoaiHangHoa busLoaiHangHoa;
        private BUS_LoHang busLoHang;
        private BUS_NhaCungCap busNhaCungCap;
        private BUS_HoaDonMua busHoaDonMua;

        public QuanLyKho()
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
            LoadQuanLyHangHoa();
            LoadLoHang();
            LoadQuanLyDatHang();
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
                    dgvDanhSachDatMua.Rows.Add(maLoaiHangHoa, maHangHoa, tenHangHoa, giaBan, soLuong, donViTinh, maNhaCungCap, hanSuDungTieuChuan, donViHanSuDung);
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
                    DTO_LoHang loHang = new DTO_LoHang
                    {
                        MaHangHoa = Convert.ToInt32(row.Cells["MaHangHoa"].Value),
                        SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value),
                        SoLuongTonKho = Convert.ToInt32(row.Cells["SoLuong"].Value),
                        DonGia = Convert.ToInt32(row.Cells["GiaBan"].Value),
                        NgaySanXuat = DateTime.Now,
                        HanSuDung = TinhHanSuDung(DateTime.Now, Convert.ToInt32(row.Cells["HanSuDungTieuChuan"]), row.Cells["DonViHanSuDung"].Value.ToString()),
                        MaHoaDonMua = maHoaDonMua,
                        MaKho = -1
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
