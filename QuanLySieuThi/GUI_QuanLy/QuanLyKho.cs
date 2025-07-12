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
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI_QuanLy
{
    public partial class QuanLyKho : Form
    {
        private BUS_HangHoa busHangHoa;
        private BUS_LoaiHangHoa busLoaiHangHoa;
        private BUS_LoHang busLoHang;
        private BUS_HoaDonMua busHoaDonMua;


        public QuanLyKho()
        {
            InitializeComponent();
            busHangHoa = new BUS_HangHoa();
            busLoaiHangHoa = new BUS_LoaiHangHoa();
            busLoHang = new BUS_LoHang();
            busHoaDonMua = new BUS_HoaDonMua();
        }

        private void QuanLyKho_Load(object sender, EventArgs e)
        {
            LoadComboBoxHangHoa();
            LoadLoHang();
            LoadHoaDonMua();
            PerformSearchHangHoa();
        }

        /*
         * Hàng hóa
         */
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
            else
            {
                MessageBox.Show("Không có dữ liệu loại hàng hóa để hiển thị.");
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
                else
                {
                    MessageBox.Show("Không có dữ liệu lô hàng để hiển thị.");
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

                if (DateTime.TryParse(row.Cells["NSX"].Value?.ToString(), out DateTime nsx))
                    txtNXS.Text = nsx.ToString("yyyy-MM-dd");
                else
                    txtNXS.Text = "";

                if (DateTime.TryParse(row.Cells["HSD"].Value?.ToString(), out DateTime hsd))
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
                txtNXS.Text = Convert.ToDateTime(row.Cells["NSX"].Value).ToString("yyyy-MM-dd");
                txtHSD.Text = Convert.ToDateTime(row.Cells["HSD"].Value).ToString("yyyy-MM-dd");
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
                else
                {
                    MessageBox.Show("Không có dữ liệu hóa đơn mua để hiển thị.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hóa đơn mua: " + ex.Message);
            }
            VeBieuDoThongKe();
        }

        private void txtTimKiemHoaDonMua_TextChanged(object sender, EventArgs e)
        {

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
                    string ngay = Convert.ToDateTime(row.Cells["NgayNhap"].Value).ToString("dd/MM/yyyy");
                    decimal tongTien = Convert.ToDecimal(row.Cells["TongTien"].Value);

                    series.Points.AddXY(ngay, tongTien);
                }
            }

            chartThongke.Series.Add(series);
        }
    }
}
