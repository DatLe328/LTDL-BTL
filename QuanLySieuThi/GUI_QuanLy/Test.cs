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
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        BUS_KhachHang busKhachHang = new BUS_KhachHang();
        private void Test_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = busKhachHang.GetAllKhachHang();
        }
        private void PerformSearch()
        {
            string searchTerm = textBox1.Text.Trim();
            DataTable dt = busKhachHang.SearchKhachHang(searchTerm);
            DataView dv = new DataView(dt);
            
            dataGridView1.DataSource = dv;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }
    }
}
