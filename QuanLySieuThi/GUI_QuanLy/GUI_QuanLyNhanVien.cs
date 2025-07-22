using BUS_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class GUI_QuanLyNhanVien : Form
    {
        BUS_ChucVu busChucVu;
        BUS_NhanVien busNhanVien;
        BUS_TaiKhoan busTaiKhoan;
        BUS_CaLamViec busCaLamViec;
        BUS_BangLuong busBangLuong;
        BUS_ChiTietLuong busChiTietLuong;
        BUS_BangChamCong busBangChamCong;
        public GUI_QuanLyNhanVien()
        {
            InitializeComponent();
            busChucVu = new BUS_ChucVu();
            busNhanVien = new BUS_NhanVien();
            busTaiKhoan = new BUS_TaiKhoan();
            busCaLamViec = new BUS_CaLamViec();
            busBangLuong = new BUS_BangLuong();
            busChiTietLuong = new BUS_ChiTietLuong();
            busBangChamCong = new BUS_BangChamCong();
            LoadQuanLyNhanVien();
        }
        private void LoadQuanLyNhanVien()
        {
            LoadChucVu();
            LoadNhanVien();
            LoadQuanLyCaLamViec();
            LoadQuanLyLuong();
            Utils.MyDataGridViewFormat(dgvNhanVien);
        }
        private void LoadNhanVien()
        {
            dgvNhanVien.DataSource = busNhanVien.GetNhanVien();
        }

        private void LoadChucVu()
        {
            DataSet dsChucVu = busChucVu.GetChucVu();
            cbChucVu.DataSource = dsChucVu.Tables[0];
            cbChucVu.DisplayMember = "TenChucVu";
            cbChucVu.ValueMember = "MaChucVu";
        }
        private string GenerateRandomPassword()
        {
            Random random = new Random();
            string password = "";
            for (int i = 0; i < 6; i++)
            {
                int num = random.Next(0, 10);
                password += num.ToString();
            }
            return password;
        }
        private string GenerateUsername(string email)
        {
            string username = email.Split('@')[0];
            int count = 1;
            while (busTaiKhoan.CheckUsernameExists(username))
            {
                username = email.Split('@')[0] + count;
                count++;
            }
            return username;
        }
        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            txtSDT.Text = txtSDT.Text.Trim();
            string hoTenNV = txtHoTen.Text.Trim();
            string email = txtEmail.Text.Trim();
            string soDienThoai = txtSDT.Text;
            DateTime ngaySinh;
            if (!DateTime.TryParse(txtNgaySinh.Text.Trim(), out ngaySinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ.");
                return;
            }
            int maChucVu = Convert.ToInt32(cbChucVu.SelectedValue);
            if (string.IsNullOrEmpty(hoTenNV) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(soDienThoai))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin nhân viên.");
                return;
            }
            if (busNhanVien.AddNhanVien(hoTenNV, soDienThoai, email, ngaySinh, maChucVu))
            {
                string random_password = GenerateRandomPassword();
                string username = GenerateUsername(email);
                MessageBox.Show("Thêm nhân viên thành công.\nTên đăng nhập:" + username + "\nMật khẩu: " + random_password);
                LoadNhanVien();
                txtHoTen.Clear();
                txtEmail.Clear();
                txtSDT.Clear();
                txtNgaySinh.Clear();
                int id = busNhanVien.GetLastMaNhanVien();
                busTaiKhoan.AddTaiKhoan(username, random_password, id);
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại.");
            }
        }

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgvNhanVien.SelectedRows[0];
                txtHoTen.Text = row.Cells["HoTenNV"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtNgaySinh.Text = Convert.ToDateTime(row.Cells["NgaySinh"].Value).ToString("yyyy-MM-dd");
                txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
                cbChucVu.SelectedValue = row.Cells["MaChucVu"].Value;
            }
        }

        private void btnXoaNhanVien_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgvNhanVien.SelectedRows[0];
                int maNhanVien = Convert.ToInt32(row.Cells["MaNhanVien"].Value);
                if (busNhanVien.DeleteNhanVien(maNhanVien))
                {
                    MessageBox.Show("Xóa nhân viên thành công.");
                    LoadNhanVien();
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên thất bại.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.");
            }
        }

        private void btnSuaNhanVien_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvNhanVien.SelectedRows[0];
                int maNhanVien = Convert.ToInt32(row.Cells["MaNhanVien"].Value);
                string hoTenNV = txtHoTen.Text;
                string email = txtEmail.Text;
                string soDienThoai = txtSDT.Text;
                DateTime ngaySinh;
                if (!DateTime.TryParse(txtNgaySinh.Text.Trim(), out ngaySinh))
                {
                    MessageBox.Show("Ngày sinh không hợp lệ.");
                    return;
                }
                int maChucVu = Convert.ToInt32(cbChucVu.SelectedValue);
                if (busNhanVien.UpdateNhanVien(maNhanVien, hoTenNV, soDienThoai, email, ngaySinh, maChucVu))
                {
                    MessageBox.Show("Cập nhật nhân viên thành công.");
                    LoadNhanVien();
                }
                else
                {
                    MessageBox.Show("Cập nhật nhân viên thất bại.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa.");
            }
        }
        private void PerformSearch() 
        {             
            string searchText = txtTimKiemNhanVien.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                LoadNhanVien();
                return;
            }
            DataTable dt = busNhanVien.GetNhanVien();
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("HoTenNV LIKE '%{0}%' OR Email LIKE '%{0}%' OR SoDienThoai LIKE '%{0}%'", searchText);
            dgvNhanVien.DataSource = dv;
        }
        private void txtTimKiemNhanVien_TextChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }
        // Quản lý ca làm việc
        private void LoadQuanLyCaLamViec()
        {
            LoadDanhSachCaLamViec();
            Utils.MyDataGridViewFormat(dgvCaLamViec);
        }

        private void LoadDanhSachCaLamViec()
        {
            dgvCaLamViec.DataSource = busCaLamViec.GetCaLamViec();
        }

        private void btnThemCaLam_Click(object sender, EventArgs e)
        {
            DateTime ngayLamViec, gioBatDau, gioKetThuc;
            if (!DateTime.TryParse(dateNgayLamViec.Text.Trim(), out ngayLamViec) ||
                !DateTime.TryParse(timeBatDau.Text.Trim(), out gioBatDau) ||
                !DateTime.TryParse(timeKetThuc.Text.Trim(), out gioKetThuc))
            {
                MessageBox.Show("Thông tin ngày hoặc giờ không hợp lệ.");
                return;
            }
            if (gioBatDau >= gioKetThuc)
            {
                MessageBox.Show("Giờ bắt đầu phải trước giờ kết thúc.");
                return;
            }
            string ghiChu = txtGhiChu.Text.Trim();
            DTO_CaLamViec dTO_CaLamViec = new DTO_CaLamViec
            {
                NgayLamViec = ngayLamViec,
                GioBatDau = gioBatDau.TimeOfDay,
                GioKetThuc = gioKetThuc.TimeOfDay,
                GhiChu = ghiChu
            };
            if (busCaLamViec.AddCaLamViec(dTO_CaLamViec))
            {
                MessageBox.Show("Thêm ca làm việc thành công.");
                LoadDanhSachCaLamViec();
                dateNgayLamViec.Value = DateTime.Now;
                timeBatDau.Value = DateTime.Now;
                timeKetThuc.Value = DateTime.Now;
                txtGhiChu.Clear();
            }
            else
            {
                MessageBox.Show("Thêm ca làm việc thất bại.");
            }
        }

        private void btnXoaCaLam_Click(object sender, EventArgs e)
        {
            if (dgvCaLamViec.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgvCaLamViec.SelectedRows[0];
                int maCaLamViec = Convert.ToInt32(row.Cells["MaCa"].Value);
                if (busCaLamViec.DeleteCaLamViec(maCaLamViec))
                {
                    MessageBox.Show("Xóa ca làm việc thành công.");
                    LoadDanhSachCaLamViec();
                }
                else
                {
                    MessageBox.Show("Xóa ca làm việc thất bại.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một ca làm việc để xóa.");
            }
        }

        private void dgvCaLamViec_Click(object sender, EventArgs e)
        {
            if (dgvCaLamViec.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgvCaLamViec.SelectedRows[0];
                dateNgayLamViec.Value = Convert.ToDateTime(row.Cells["NgayLamViec"].Value);
                timeBatDau.Value = DateTime.Today + TimeSpan.Parse(row.Cells["GioBatDau"].Value.ToString());
                timeKetThuc.Value = DateTime.Today + TimeSpan.Parse(row.Cells["GioKetThuc"].Value.ToString());
                txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();
            }
        }

        private void btnLocCaLamViec_Click(object sender, EventArgs e)
        {
            DateTime tuNgay, denNgay;
            if (!DateTime.TryParse(dateTuNgay.Text.Trim(), out tuNgay) ||
                !DateTime.TryParse(dateDenNgay.Text.Trim(), out denNgay))
            {
                MessageBox.Show("Thông tin ngày không hợp lệ.");
                return;
            }
            if (tuNgay > denNgay)
            {
                MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc.");
                return;
            }
            DataTable dt = busCaLamViec.GetCaLamViec(tuNgay, denNgay);
            if (dt != null && dt.Rows.Count > 0)
            {
                dgvCaLamViec.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Không có ca làm việc trong khoảng thời gian này.");
                LoadDanhSachCaLamViec();
            }
        }

        private void btnSuaCaLam_Click(object sender, EventArgs e)
        {
            if (dgvCaLamViec.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCaLamViec.SelectedRows[0];
                int maCaLamViec = Convert.ToInt32(row.Cells["MaCa"].Value);
                DateTime ngayLamViec, gioBatDau, gioKetThuc;
                if (!DateTime.TryParse(dateNgayLamViec.Text.Trim(), out ngayLamViec) ||
                    !DateTime.TryParse(timeBatDau.Text.Trim(), out gioBatDau) ||
                    !DateTime.TryParse(timeKetThuc.Text.Trim(), out gioKetThuc))
                {
                    MessageBox.Show("Thông tin ngày hoặc giờ không hợp lệ.");
                    return;
                }
                if (gioBatDau >= gioKetThuc)
                {
                    MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc và giờ bắt đầu phải trước giờ kết thúc.");
                    return;
                }
                string ghiChu = txtGhiChu.Text.Trim();
                DTO_CaLamViec dTO_CaLamViec = new DTO_CaLamViec
                {
                    MaCa = maCaLamViec,
                    NgayLamViec = ngayLamViec,
                    GioBatDau = gioBatDau.TimeOfDay,
                    GioKetThuc = gioKetThuc.TimeOfDay,
                    GhiChu = ghiChu
                };
                if (busCaLamViec.UpdateCaLamViec(dTO_CaLamViec))
                {
                    MessageBox.Show("Cập nhật ca làm việc thành công.");
                    LoadDanhSachCaLamViec();
                }
                else
                {
                    MessageBox.Show("Cập nhật ca làm việc thất bại.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một ca làm việc để sửa.");
            }
        }




        // Quản lý lương
        /* TODO
         * - Chọn nhân viên để xem bảng lương
         * - Lọc lương theo tháng
         * - Thêm, sửa, xóa các khoản lương
         * - Số ngày công
         * - Tiền lương dự tính
         * - Tự động tạo bảng lương cho nhân viên
         * - Chấm công
         * - Xử lý các trường hợp ngoại lệ:
         *  + Các thao tác trên bảng (chưa chọn NV, chọn bảng lương, chọn khoản lương)
         *  + Trường hợp chốt lương trong tháng cần giải quyết vấn đề tự tạo bảng lương mới
         *  + Thoát ứng dụng khi chưa chấm công
         * - Đưa các xử lý tự tạo vào MainForm
         */




        private void LoadQuanLyLuong()
        {
            CustomDatetimepicker();
            btnThemKhoanLuong.Enabled = false;
            btnSuaKhoanLuong.Enabled = false;
            btnXoaKhoanLuong.Enabled = false;
            btnLocLuongTheoThang.Enabled = false;
            Utils.MyDataGridViewFormat(dgvCacKhoanLuong);
            Utils.MyDataGridViewFormat(dgvTinhLuongNhanVien);
        }
        private void LoadComboBoxLoaiKhoan()
        {
            List<string> loaiKhoanList = EnumExtensions.GetDescriptions<LoaiKhoan>();
            cbLoaiKhoan.DataSource = loaiKhoanList;
        }
        private void CustomDatetimepicker()
        {
            monthYearPicker.Format = DateTimePickerFormat.Custom;
            monthYearPicker.CustomFormat = "MM/yyyy";
            monthYearPicker.ShowUpDown = true;
        }
        private void btnLocLuongTheoThang_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = monthYearPicker.Value;
            if (string.IsNullOrEmpty(txtMaNhanVienChon.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên trước khi lọc lương.");
                return;
            }
            int maNhanVien = int.Parse(txtMaNhanVienChon.Text);
            DataTable dt = busBangLuong.GetBangLuong(maNhanVien, selectedDate.Month, selectedDate.Year);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            if (dt != null && dt.Rows.Count > 0)
            {
                dgvTinhLuongNhanVien.DataSource = bs;
                RefreshCacKhoanLuong();
            }
            else
            {
                MessageBox.Show("Không có bảng lương cho nhân viên này trong tháng " + selectedDate.ToString("MM/yyyy"));
                dgvTinhLuongNhanVien.DataSource = null;
                dgvCacKhoanLuong.DataSource = null;
            }
        }
        private void RefreshCacKhoanLuong()
        {
            try
            {
                DataGridViewRow row = dgvTinhLuongNhanVien.SelectedRows[0];
                int maBangLuong = Convert.ToInt32(row.Cells["MaLuong"].Value);
                txtSoTienKhoan.Clear();
                txtGhiChuLuong.Clear();
                dgvCacKhoanLuong.DataSource = busChiTietLuong.GetChiTietLuong(maBangLuong);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error refreshing CacKhoanLuong: " + ex.Message);
                dgvCacKhoanLuong.DataSource = null;
            }
        }
        private void GenerateBangLuong(int maNhanVien, int thang, int nam)
        {
            DTO_ChucVu chucVu = busNhanVien.GetChucVu(maNhanVien);
            busBangLuong.AddBangLuong(maNhanVien, thang, nam, 0, EnumExtensions.GetDescription(TrangThaiBangLuong.DangXuLy));
            int maLuong = busBangLuong.GetLastMaLuong();
            busChiTietLuong.AddChiTietLuong(maLuong, LoaiKhoan.LuongCoBan.ToString(), chucVu.MucLuong, "Lương cơ bản");
        }
        private int TinhSoNgayCong(int maNhanVien, DateTime thangNamBatDau, DateTime thangNamKetThuc)
        {
            DataTable dt = busBangChamCong.GetBangChamCong(maNhanVien, thangNamBatDau, thangNamKetThuc);
            if (dt == null || dt.Rows.Count == 0)
            {
                return 0;
            }
            int soNgayCong = 0;
            TimeSpan thoiGianTreToiDa = Globals.ThoiGianTreToiDa;
            foreach (DataRow row in dt.Rows)
            {
                TimeSpan gioVao = (TimeSpan)row["GioVao"];
                TimeSpan gioRa = (TimeSpan)row["GioRa"];
                DateTime ngayChamCong = Convert.ToDateTime(row["NgayChamCong"]);
                DataTable caLamViec = busCaLamViec.GetCaLamViec(ngayChamCong, ngayChamCong);
                if (caLamViec.Rows.Count > 0)
                {
                    TimeSpan thoiGianLamViec = gioRa - gioVao;
                    double soPhutLamViec = thoiGianLamViec.TotalMinutes;
                    foreach (DataRow caRow in caLamViec.Rows)
                    {
                        TimeSpan gioBatDauCa = (TimeSpan)caRow["GioBatDau"];
                        TimeSpan gioKetThucCa = (TimeSpan)caRow["GioKetThuc"];
                        TimeSpan thoiGianHoanThanhCa = gioKetThucCa - gioBatDauCa;
                        double soPhutCa = thoiGianHoanThanhCa.TotalMinutes;
                        if (gioVao - thoiGianTreToiDa > gioBatDauCa && gioRa >= gioKetThucCa)
                        {
                            if (soPhutLamViec >= 0.8 * soPhutCa)
                            {
                                soNgayCong += 1;
                                int maBangLuong = (int)busBangLuong.GetBangLuong(maNhanVien, ngayChamCong.Month, ngayChamCong.Year).Rows[0]["MaLuong"];
                                busChiTietLuong.AddChiTietLuong(
                                    maBangLuong,
                                    EnumExtensions.GetDescription(LoaiKhoan.Phat),
                                    -100000,
                                    "Đi trễ " + (gioVao - gioBatDauCa).ToString(@"hh\:mm")
                                );
                            }
                        }
                        else if (gioVao - thoiGianTreToiDa <= gioBatDauCa && gioRa >= gioKetThucCa)
                        {
                            soNgayCong += 1;
                        }
                    }
                }
            }
            return soNgayCong;
        }
        private void LoadSoNgayCong()
        {
            int maNhanVien = int.Parse(txtMaNhanVienChon.Text);
            
            DateTime thangTruoc = DateTime.Now.AddMonths(-1);
            DateTime ngayDauTienThangTruoc = new DateTime(thangTruoc.Year, thangTruoc.Month, 1);
            //DateTime ngayHomQua = DateTime.Now.AddDays(-1);
            DateTime ngayHomQua = DateTime.Now;
            DataTable bangLuongThangTruoc = busBangLuong.GetBangLuong(maNhanVien, thangTruoc.Month, thangTruoc.Year);
            if (bangLuongThangTruoc.Rows.Count == 0)
            {
                txtSoNgayCong.Text = TinhSoNgayCong(maNhanVien, ngayDauTienThangTruoc, ngayHomQua).ToString();
                Console.WriteLine(ngayHomQua.ToString("dd/MM/yyyy"));
            }
            else
            {
                DateTime ngayChotLuongThangTruoc = Convert.ToDateTime(bangLuongThangTruoc.Rows[0]["NgayChotLuong"]);
                txtSoNgayCong.Text = TinhSoNgayCong(maNhanVien, ngayChotLuongThangTruoc, ngayHomQua).ToString();
            }
        }
        private void LoadSoLuongDuTinh()
        {
            int maBangLuong = dgvTinhLuongNhanVien.SelectedRows.Count > 0 ? Convert.ToInt32(dgvTinhLuongNhanVien.SelectedRows[0].Cells["MaLuong"].Value) : 0;
            txtTienLuongDuTinh.Text = busChiTietLuong.GetTongTienLuong(maBangLuong).ToString();
        }
        private void btnChonNhanVien_Click(object sender, EventArgs e)
        {
            using (GUI_NhanVienPopup popup = new GUI_NhanVienPopup())
            {
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    txtMaNhanVienChon.Text = popup.SelectedEmployeeId;
                    DataRow row = busNhanVien.GetNhanVien(int.Parse(popup.SelectedEmployeeId)).Rows[0];
                    txtMaNhanVienChon.Text = row["MaNhanVien"].ToString();
                    txtTenNhanVienChon.Text = row["HoTenNV"].ToString();
                    LoadLuongNhanVien();
                    LoadSoNgayCong();
                    LoadSoLuongDuTinh();
                    DataTable dataTable = busBangLuong.GetBangLuong(int.Parse(txtMaNhanVienChon.Text));
                    btnThemKhoanLuong.Enabled = true;
                    btnSuaKhoanLuong.Enabled = true;
                    btnXoaKhoanLuong.Enabled = true;
                    btnLocLuongTheoThang.Enabled = true;
                    dgvCacKhoanLuong.DataSource = null;
                }
            }
        }
        private void LoadLuongNhanVien()
        {
            if (txtTenNhanVienChon.Text == string.Empty)
            {
                return;
            }
            int maNhanVien = int.Parse(txtMaNhanVienChon.Text);
            DataTable dt = busBangLuong.GetBangLuong(maNhanVien, DateTime.Now.Month, DateTime.Now.Year);
            bool hasBangLuongThisMonth = dt.Rows.Count > 0;
            if (!hasBangLuongThisMonth)
            {
                Console.WriteLine("Chưa có bảng lương cho nhân viên này trong tháng hiện tại.");
                Console.WriteLine("Thêm bảng lương mới cho nhân viên vào tháng " + DateTime.Now.Month + ", năm " + DateTime.Now.Year);
                GenerateBangLuong(maNhanVien, DateTime.Now.Month, DateTime.Now.Year);
            }
            DateTime thangSau = DateTime.Now.AddMonths(1);
            if (dt.Rows[0]["TrangThai"].ToString() == EnumExtensions.GetDescription(TrangThaiBangLuong.DaXuLy))
            {
                dt = busBangLuong.GetBangLuong(maNhanVien, thangSau.Month, thangSau.Year);
                if (dt.Rows.Count == 0)
                {
                    Console.WriteLine("Debug(GUI_QuanLyNhanVien): Bảng lương đã được chốt, tự động tạo bảng cho tháng mới.");
                    GenerateBangLuong(maNhanVien, thangSau.Month, thangSau.Year);
                    return;
                }
            }

            dt = busBangLuong.GetBangLuong(maNhanVien);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dgvTinhLuongNhanVien.DataSource = bs;
        }

        private void dgvTinhLuongNhanVien_Click(object sender, EventArgs e)
        {
            if (dgvTinhLuongNhanVien.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgvTinhLuongNhanVien.SelectedRows[0];
                int maBangLuong = Convert.ToInt32(row.Cells["MaLuong"].Value);
                DataTable dt = busChiTietLuong.GetChiTietLuong(maBangLuong);
                dgvCacKhoanLuong.DataSource = dt;
                string trangThai = row.Cells["TrangThai"].Value.ToString();
                txtTrangThai.Text = trangThai;
                if (trangThai == EnumExtensions.GetDescription(TrangThaiBangLuong.DangXuLy))
                {
                    txtTrangThai.ForeColor = Color.Red;
                    LoadSoNgayCong();
                    txtTienLuongDuTinh.Text = busChiTietLuong.GetTongTienLuong(maBangLuong).ToString();
                }
                else
                {
                    txtTrangThai.ForeColor = Color.Green;
                    txtSoNgayCong.Text = row.Cells["SoNgayCong"].Value.ToString();
                    txtTienLuongDuTinh.Text = row.Cells["TongLuong"].Value.ToString();
                }
                

                if (trangThai == EnumExtensions.GetDescription(TrangThaiBangLuong.DangXuLy))
                {
                    btnChotLuong.Enabled = true;
                    btnThemKhoanLuong.Enabled = true;
                    btnSuaKhoanLuong.Enabled = true;
                    btnXoaKhoanLuong.Enabled = true;
                    cbLoaiKhoan.Enabled = true;
                    txtGhiChuLuong.Enabled = true;
                    txtSoTienKhoan.Enabled = true;
                    LoadComboBoxLoaiKhoan();
                }
                else
                {
                    btnChotLuong.Enabled = false;
                    btnThemKhoanLuong.Enabled = false;
                    btnSuaKhoanLuong.Enabled = false;
                    btnXoaKhoanLuong.Enabled = false;
                    cbLoaiKhoan.Enabled = false;
                    txtGhiChuLuong.Enabled = false;
                    txtSoTienKhoan.Enabled = false;
                }
            }
        }

        private void btnThemKhoanLuong_Click(object sender, EventArgs e)
        {
            if (dgvTinhLuongNhanVien.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgvTinhLuongNhanVien.SelectedRows[0];
                int maBangLuong = Convert.ToInt32(row.Cells["MaLuong"].Value);
                string loaiKhoan = cbLoaiKhoan.SelectedItem?.ToString();
                int soTien = txtSoTienKhoan.Text.Trim() == string.Empty ? 0 : int.Parse(txtSoTienKhoan.Text.Trim());
                string ghiChu = txtGhiChuLuong.Text.Trim();
                if (string.IsNullOrEmpty(loaiKhoan))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin khoản lương.");
                    return;
                }
                if (busChiTietLuong.AddChiTietLuong(maBangLuong, loaiKhoan, soTien, ghiChu))
                {
                    MessageBox.Show("Thêm khoản lương thành công.");
                }
                else
                {
                    MessageBox.Show("Thêm khoản lương thất bại.");
                }
                RefreshCacKhoanLuong();
            }
            LoadSoLuongDuTinh();
        }

        private void btnXoaKhoanLuong_Click(object sender, EventArgs e)
        {
            if (dgvCacKhoanLuong.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgvCacKhoanLuong.SelectedRows[0];
                int maChiTietLuong = Convert.ToInt32(row.Cells["MaChiTietLuong"].Value);
                if (busChiTietLuong.DeleteChiTietLuong(maChiTietLuong))
                {
                    MessageBox.Show("Xóa khoản lương thành công.");
                    RefreshCacKhoanLuong();
                }
                else
                {
                    MessageBox.Show("Xóa khoản lương thất bại.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khoản lương để xóa.");
            }
            LoadSoLuongDuTinh();
        }

        private void btnSuaKhoanLuong_Click(object sender, EventArgs e)
        {
            if (dgvCacKhoanLuong.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgvCacKhoanLuong.SelectedRows[0];
                int maChiTietLuong = Convert.ToInt32(row.Cells["MaChiTietLuong"].Value);
                string loaiKhoan = cbLoaiKhoan.SelectedItem?.ToString();
                int soTien = txtSoTienKhoan.Text.Trim() == string.Empty ? 0 : int.Parse(txtSoTienKhoan.Text.Trim());
                string ghiChu = txtGhiChuLuong.Text.Trim();
                if (string.IsNullOrEmpty(loaiKhoan) || soTien <= 0)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin khoản lương.");
                    return;
                }
                if (busChiTietLuong.UpdateChiTietLuong(maChiTietLuong, loaiKhoan, soTien, ghiChu))
                {
                    MessageBox.Show("Cập nhật khoản lương thành công.");
                    RefreshCacKhoanLuong();
                }
                else
                {
                    MessageBox.Show("Cập nhật khoản lương thất bại.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khoản lương để sửa.");
            }
            LoadSoLuongDuTinh();
        }

        private void dgvCacKhoanLuong_Click(object sender, EventArgs e)
        {
            if (dgvCacKhoanLuong.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgvCacKhoanLuong.SelectedRows[0];
                cbLoaiKhoan.SelectedItem = row.Cells["LoaiKhoan"].Value.ToString();
                txtSoTienKhoan.Text = row.Cells["SoTien"].Value.ToString();
                txtGhiChuLuong.Text = row.Cells["GhiChu"].Value.ToString();
            }
            else
            {
                cbLoaiKhoan.SelectedIndex = -1;
                txtSoTienKhoan.Clear();
                txtGhiChuLuong.Clear();
            }
            LoadSoLuongDuTinh();
        }

        private void btnChotLuong_Click(object sender, EventArgs e)
        {
            if (dgvTinhLuongNhanVien.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgvTinhLuongNhanVien.SelectedRows[0];
                int maNhanVien = int.Parse(txtMaNhanVienChon.Text);
                DataTable dt = busBangLuong.GetBangLuong(maNhanVien, DateTime.Now.Month, DateTime.Now.Year);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Chưa có bảng lương cho nhân viên này trong tháng hiện tại.");
                    return;
                }
                Console.WriteLine("Debug(GUI_QuanLyNhanVien): " + row.Cells["Thang"].Value.ToString() + " " + row.Cells["Nam"].Value.ToString());
                if (row.Cells["Thang"].Value.ToString() != DateTime.Now.Month.ToString() || row.Cells["Nam"].Value.ToString() != DateTime.Now.Year.ToString())
                {
                    MessageBox.Show("Không thể chốt lương sớm vào tháng này\nHãy liên hệ hỗ trợ.");
                    return;
                }
                int maBangLuong = Convert.ToInt32(dt.Rows[0]["MaLuong"]);
                int soNgayCong = int.Parse(txtSoNgayCong.Text);
                string txtGhiChu = txtGhiChuLuong.Text.Trim();
                if (busBangLuong.UpdateBangLuong(maBangLuong, soNgayCong, DateTime.Now, EnumExtensions.GetDescription(TrangThaiBangLuong.DaXuLy)))
                {
                    MessageBox.Show("Chốt lương thành công.");
                    LoadLuongNhanVien();
                    RefreshCacKhoanLuong();
                    LoadSoLuongDuTinh();
                }
                else
                {
                    MessageBox.Show("Chốt lương thất bại.");
                }
            }
        }

        private void ckbChuaXuLy_CheckedChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource(); 
            bs = dgvTinhLuongNhanVien.DataSource as BindingSource;
            if (ckbChuaXuLy.Checked)
            {
                bs.Filter = "TrangThai = 'Đang xử lý'";
            }
            else
            {
                bs.Filter = string.Empty;
            }
        }
    }
}
