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
    public partial class GUI_NhanVienPopup : Form
    {
        BUS_NhanVien busNhanVien;
        public string SelectedEmployeeId { get; private set; }
        public GUI_NhanVienPopup()
        {
            InitializeComponent();
            busNhanVien = new BUS_NhanVien();
        }

        private void GUI_NhanVienPopup_Load(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = busNhanVien.GetNhanVien();
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgvNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvNhanVien.Rows[e.RowIndex];
                SelectedEmployeeId = selectedRow.Cells["MaNhanVien"].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
