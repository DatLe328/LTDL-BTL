﻿using BUS_QuanLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI_QuanLy
{
    public partial class GUI_Login : Form
    {
        public GUI_Login()
        {
            InitializeComponent();
            btnDangNhap.BackColor = Color.MediumSlateBlue;
            btnDangNhap.ForeColor = Color.White;
            btnDangNhap.FlatStyle = FlatStyle.Flat;
            btnDangNhap.FlatAppearance.BorderSize = 0;
            btnDangNhap.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            txtTenDangNhap.BorderStyle = BorderStyle.FixedSingle;
            txtMatKhau.BorderStyle = BorderStyle.FixedSingle;
        }
        private BUS_TaiKhoan busTaiKhoan = new BUS_TaiKhoan();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (busTaiKhoan.Authenticate(tenDangNhap, matKhau))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Globals.TenDangNhap = tenDangNhap;
                Globals.MaNhanVien = busTaiKhoan.GetMaNhanVienByTenDangNhap(tenDangNhap);
                Console.WriteLine("DEBUG (GUI_Login): MaNhanVien = " + Globals.MaNhanVien);
                Console.WriteLine("DEBUG (GUI_Login): TenDangNhap = " + Globals.TenDangNhap);
                // Mở form chính của ứng dụng
                Form mainForm = new GUI_MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTenDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnDangNhap.PerformClick();
            }
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnDangNhap.PerformClick();
            }
        }
    }
}
