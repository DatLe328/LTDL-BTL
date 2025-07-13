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
    public partial class GUI_ChiPhi : Form
    {
        private BUS_ChiPhi busChiPhi;
        public GUI_ChiPhi()
        {
            InitializeComponent();
            busChiPhi = new BUS_ChiPhi();
            LoadChiPhi();
        }
        private void LoadChiPhi()
        {
            try
            {
                DataTable dt = busChiPhi.GetChiPhi();
                if (dt != null)
                {
                    dgvChiPhi.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách chi phí: " + ex.Message);
            }
            this.dgvChiPhi.Click += new System.EventHandler(this.dgvChiPhi_Click);
            this.btnResetChiPhi.Click += new System.EventHandler(this.btnResetChiPhi_Click);


        }
        private void dgvChiPhi_Click(object sender, EventArgs e)
        {
            if (dgvChiPhi.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvChiPhi.SelectedRows[0];

                txtTenChiPhi.Text = row.Cells["TenChiPhi"].Value?.ToString();
                txtSoTien.Text = row.Cells["SoTien"].Value?.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["NgayLap"].Value?.ToString(), out DateTime ngay))
                {
                    dtpNgayLap.Value = ngay;
                }
                else
                {
                    dtpNgayLap.Value = DateTime.Now;
                }
            }
        }
        private void btnThemChiPhi_Click(object sender, EventArgs e)
        {
            string tenChiPhi = txtTenChiPhi.Text.Trim();
            int soTien = int.TryParse(txtSoTien.Text.Trim(), out var st) ? st : 0;
            DateTime ngayLap = dtpNgayLap.Value.Date;
            string moTa = txtMoTa.Text.Trim();
            int maNhanVien = Globals.MaNhanVien;

            if (string.IsNullOrEmpty(tenChiPhi) || soTien <= 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và hợp lệ thông tin.");
                return;
            }

            DTO_ChiPhi chiPhi = new DTO_ChiPhi(0, tenChiPhi, ngayLap, soTien, moTa, maNhanVien);

            if (busChiPhi.AddChiPhi(chiPhi))
            {
                MessageBox.Show("Thêm chi phí thành công.");
                LoadChiPhi();
            }
            else
            {
                MessageBox.Show("Thêm chi phí thất bại.");
            }
        }
        private void btnSuaChiPhi_Click(object sender, EventArgs e)
        {
            if (dgvChiPhi.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvChiPhi.SelectedRows[0];
                int maChiPhi = Convert.ToInt32(row.Cells["MaChiPhi"].Value);
                string tenChiPhi = txtTenChiPhi.Text.Trim();
                int soTien = int.TryParse(txtSoTien.Text.Trim(), out var st) ? st : 0;
                DateTime ngayLap = dtpNgayLap.Value.Date;
                string moTa = txtMoTa.Text.Trim();
                int maNhanVien = Globals.MaNhanVien;

                DTO_ChiPhi chiPhi = new DTO_ChiPhi(maChiPhi, tenChiPhi, ngayLap, soTien, moTa, maNhanVien);

                if (busChiPhi.UpdateChiPhi(chiPhi))
                {
                    MessageBox.Show("Cập nhật chi phí thành công.");
                    LoadChiPhi();
                }
                else
                {
                    MessageBox.Show("Cập nhật chi phí thất bại.");
                }
            }
        }
        private void btnXoaChiPhi_Click(object sender, EventArgs e)
        {
            if (dgvChiPhi.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvChiPhi.SelectedRows[0];
                int maChiPhi = Convert.ToInt32(row.Cells["MaChiPhi"].Value);

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa chi phí này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (busChiPhi.DeleteChiPhi(maChiPhi))
                    {
                        MessageBox.Show("Xóa thành công.");
                        LoadChiPhi();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại.");
                    }
                }
            }
        }
        private void btnTimKiemChiPhi_Click(object sender, EventArgs e)
        {
            DateTime ngay = dtpNgayLap.Value.Date;
            DataTable dt = busChiPhi.GetChiPhiByDate(ngay);

            if (dt != null && dt.Rows.Count > 0)
            {
                dgvChiPhi.DataSource = dt;
            }
            else
            {
                dgvChiPhi.DataSource = null;
                MessageBox.Show("Không có chi phí nào cho ngày này.");
            }
        }
        private void btnResetChiPhi_Click(object sender, EventArgs e)
        {
            dtpNgayLap.Value = DateTime.Now;
            LoadChiPhi();
        }

    }
}
