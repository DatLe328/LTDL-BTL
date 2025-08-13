using BUS_QuanLy;
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
    public partial class GUI_OrderDetail : Form
    {
        private int maHoaDon;
        private BUS_LoHang busLoHang;
        public GUI_OrderDetail(int maHoaDon)
        {
            InitializeComponent();
            this.maHoaDon = maHoaDon;
            Console.WriteLine("Order ID: " + maHoaDon);
            busLoHang = new BUS_LoHang();
        }

        private void GUI_OrderDetail_Load(object sender, EventArgs e)
        {
            var dt = busLoHang.GetLoHangByMaHoaDon(maHoaDon);
            if (dt != null && dt.Rows.Count > 0)
            {
                dgvLoHang.DataSource = dt;
                dgvLoHang.Columns["MaLoHang"].HeaderText = "Mã Lô Hàng";
                dgvLoHang.Columns["TenHangHoa"].HeaderText = "Tên Sản Phẩm";
                dgvLoHang.Columns["SoLuong"].HeaderText = "Số Lượng";
                dgvLoHang.Columns["GiaBan"].HeaderText = "Giá Bán";
                dgvLoHang.Columns["NgaySanXuat"].HeaderText = "Ngày Sản Xuất";
                dgvLoHang.Columns["HanSuDung"].HeaderText = "Hạn Sử Dụng";
            }
            else
            {
                MessageBox.Show("Không có dữ liệu cho hóa đơn này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
