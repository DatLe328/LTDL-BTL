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
    public partial class QuanLyKho : Form
    {
        private BUS_HangHoa busHangHoa;
        private BUS_LoaiHangHoa busLoaiHangHoa;

        public QuanLyKho()
        {
            InitializeComponent();
            busHangHoa = new BUS_HangHoa();
            busLoaiHangHoa = new BUS_LoaiHangHoa();
        }

        private void QuanLyKho_Load(object sender, EventArgs e)
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
            PerformSearch();
        }
        private void PerformSearch()
        {
            string keyword = txtTimKiem.Text.Trim();
            dgvHangHoa.DataSource = busHangHoa.GetHangHoa(tenHangHoa: keyword);
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void txtTimKiem_TextChanged_1(object sender, EventArgs e)
        {
            PerformSearch();
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

        private void btnThem_Click(object sender, EventArgs e)
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
                    PerformSearch();
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
            PerformSearch();
        }

        private void btnXoa_Click(object sender, EventArgs e)
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
                        PerformSearch();
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

        private void btnSua_Click(object sender, EventArgs e)
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
                        PerformSearch();
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
    }
}
