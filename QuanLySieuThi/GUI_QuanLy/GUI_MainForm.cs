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
    public partial class GUI_MainForm : Form
    {
        public GUI_MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void quanLyKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new GUI_QuanLyKho();
            form.Show();
        }

        private void quanLyNhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new GUI_QuanLyNhanVien();
            form.Show();
        }

        private void baoCaoThongKeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new GUI_BaoCaoThongKe();
            form.Show();
        }
    }
}
