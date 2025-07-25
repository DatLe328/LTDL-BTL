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
    public partial class GUI_MainForm : Form
    {
        private BUS_CaLamViec busCaLamViec;
        private BUS_BangChamCong busBangChamCong;
        private TimeSpan _elapsedTime;
        public GUI_MainForm()
        {
            InitializeComponent();
            busCaLamViec = new BUS_CaLamViec();
            busBangChamCong = new BUS_BangChamCong();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void chiPhíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new GUI_ChiPhi();
            form.Show();
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

        private void GUI_MainForm_Load(object sender, EventArgs e)
        {
            lbHidden.Text = "";
            lbCaLam.Text = "";
            lbHello.Text = "Xin chào, " + Globals.TenDangNhap + "!";
            GenerateTodaySchedule();
            LoadCaLamViec();
            DropOut();
        }
        private void GenerateTodaySchedule()
        {
            if (Utils.IsInWorkDay(DateTime.Today) == false || Globals.TuDongTaoCaLamViec == false)
            {
                return;
            }
            Console.WriteLine(busCaLamViec.GetCaLamViec(DateTime.Today, DateTime.Today).Rows.Count);
            if (busCaLamViec.GetCaLamViec(DateTime.Today, DateTime.Today).Rows.Count == 0)
            {
                DTO_CaLamViec caSang = new DTO_CaLamViec
                {
                    NgayLamViec = DateTime.Today,
                    GioBatDau = new TimeSpan(7, 0, 0),
                    GioKetThuc = new TimeSpan(11, 0, 0),
                    GhiChu = "Ca sáng"
                };
                DTO_CaLamViec caChieu = new DTO_CaLamViec
                {
                    NgayLamViec = DateTime.Today,
                    GioBatDau = new TimeSpan(13, 0, 0),
                    GioKetThuc = new TimeSpan(17, 0, 0),
                    GhiChu = "Ca Chiều"
                };
                busCaLamViec.AddCaLamViec(caSang);
                busCaLamViec.AddCaLamViec(caChieu);
            }
        }
        private void LoadCaLamViec()
        {
            Utils.MyDataGridViewFormat(dgvCaLamViec);
            DataTable dt = busCaLamViec.GetCaLamViec(DateTime.Today, DateTime.Today.AddDays(1).AddTicks(-1));
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("DEBUG (GUI_MainForm): Không có ca làm việc nào trong ngày" + DateTime.Now.ToString());
                lbHidden.Text = "Không có ca làm việc nào\n trong ngày hôm nay.";
                btnChamCong.Enabled = false;
            }
            dgvCaLamViec.DataSource = dt;
            if (dt.Rows.Count == 1)
            {
                dgvCaLamViec.ClearSelection();
                dgvCaLamViec.Rows[0].Selected = true;
            }
        }
        private bool DropOut()
        {
            int maChamCong = busBangChamCong.GetMaChamCongLatest(Globals.MaNhanVien);
            DTO_BangChamCong dto = busBangChamCong.GetBangChamCongByMaChamCong(maChamCong);
           
            if (dto != null && dto.TrangThai == EnumExtensions.GetDescription(TrangThaiChamCong.DangLamViec))
            {
                Console.WriteLine("DEBUG (GUI_MainForm): Drop out, dto.GioVao = " + dto.GioVao);
                _elapsedTime = DateTime.Now.TimeOfDay - dto.GioVao;
                timer1.Start();
                dgvCaLamViec.ClearSelection();
                dgvCaLamViec.Enabled = false;
                DTO_BangChamCong bangChamCong = busBangChamCong.GetBangChamCongByMaChamCong(maChamCong);
                lbCaLam.Text = "Ca làm việc: " + bangChamCong.NgayChamCong.ToString("dd/MM/yyyy") + " - " + bangChamCong.GioVao.ToString(@"hh\:mm");
                return true;
            }
            else
            {
                Console.WriteLine("DEBUG (GUI_MainForm): No drop out");
                return false;
            }
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            int maChamCong = busBangChamCong.GetMaChamCongLatest(Globals.MaNhanVien);
            DTO_BangChamCong dto = busBangChamCong.GetBangChamCongByMaChamCong(maChamCong);
            bool isDropOut = dto != null && dto.TrangThai == EnumExtensions.GetDescription(TrangThaiChamCong.DangLamViec);
            if (dgvCaLamViec.SelectedRows.Count == 1 || isDropOut)
            {

                if (timer1.Enabled)
                {
                    DialogResult result = MessageBox.Show("Xác nhận chấm công", "Chấm công", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        timer1.Stop();
                        busBangChamCong.UpdateBangChamCong(maChamCong, DateTime.Now, EnumExtensions.GetDescription(TrangThaiChamCong.DaChamCong));
                    }
                }
                else
                {
                    DTO_BangChamCong bangChamCong = busBangChamCong.GetBangChamCongByMaChamCong(maChamCong);
                    DataGridViewRow row = dgvCaLamViec.SelectedRows[0];
                    if (DateTime.Now.TimeOfDay > (TimeSpan)row.Cells["GioKetThuc"].Value)
                    {
                        MessageBox.Show("Không thể chọn ca này vì đã quá giờ");
                        return;
                    }
                    int maCa = Convert.ToInt32(row.Cells["MaCa"].Value);
                    lbCaLam.Text = "Ca làm việc: " + bangChamCong.NgayChamCong.ToString("dd/MM/yyyy") + " - " + bangChamCong.GioVao.ToString(@"hh\:mm");
                    busBangChamCong.AddBangChamCong(Globals.MaNhanVien, DateTime.Now, DateTime.Now.TimeOfDay, EnumExtensions.GetDescription(TrangThaiChamCong.DangLamViec), maCa);
                    _elapsedTime = TimeSpan.Zero;
                    timer1.Start();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _elapsedTime = _elapsedTime.Add(TimeSpan.FromSeconds(1));
            txtTimer.Text = _elapsedTime.ToString(@"hh\:mm\:ss");
        }

        
    }
}
