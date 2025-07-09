using BUS_QuanLy;
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
    public partial class QuanLyHangHoa : Form
    {
        private BUS_HangHoa busHangHoa = new BUS_HangHoa();
        private BUS_LoaiHangHoa busLoaiHangHoa = new BUS_LoaiHangHoa();
        public QuanLyHangHoa()
        {
            InitializeComponent();
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

        private void QuanLyHangHoa_Load(object sender, EventArgs e)
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
    }
}
