using BUS_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private BUS_ChiTietLuong busChiTietLuong;
        private BUS_BangLuong busBangLuong;
        private Stopwatch _sw = new Stopwatch();
        private TimeSpan _baseElapsed = TimeSpan.Zero;
        public GUI_MainForm()
        {
            InitializeComponent();
            busCaLamViec = new BUS_CaLamViec();
            busBangChamCong = new BUS_BangChamCong();
            busChiTietLuong = new BUS_ChiTietLuong();
            busBangLuong = new BUS_BangLuong();
        }
        private void GUI_MainForm_Load(object sender, EventArgs e)
        {
            //lbHidden.Text = "";
            lbCaLam.Text = "";
            lbHello.Text = "Xin chào, " + Globals.TenDangNhap + "!";
            GenerateTodaySchedule();
            GenerateBangLuong();
            LoadCaLamViec();
            DropOut();
            ToolStripMenuItem quanLyKhoItem = new ToolStripMenuItem("Quản lý kho");
            ToolStripMenuItem quanLyNhanVienItem = new ToolStripMenuItem("Quản lý nhân viên");
            ToolStripMenuItem chiPhiItem = new ToolStripMenuItem("Quản lý chi phí");
            ToolStripMenuItem baoCaoItem = new ToolStripMenuItem("Báo cáo thống kê");

            bool isQuanLy = Globals.ChucVu == EnumExtensions.GetDescription(PhanQuyen.QuanLy);
            Console.WriteLine("DEBUG (GUI_MainForm): ChucVu = " + Globals.ChucVu);
            if (isQuanLy || Globals.ChucVu == EnumExtensions.GetDescription(PhanQuyen.ThuKho))
            {
                menuStrip1.Items.Add(quanLyKhoItem);
            }
            if (isQuanLy ||  Globals.ChucVu == EnumExtensions.GetDescription(PhanQuyen.QuanLyNhanSu))
            {
                menuStrip1.Items.Add(quanLyNhanVienItem);
            }
            if (isQuanLy || Globals.ChucVu == EnumExtensions.GetDescription(PhanQuyen.KeToan))
            {
                menuStrip1.Items.Add(baoCaoItem);
                menuStrip1.Items.Add(chiPhiItem);
            }
            quanLyKhoItem.Click += quanLyKhoToolStripMenuItem_Click;
            quanLyNhanVienItem.Click += quanLyNhanVienToolStripMenuItem_Click;
            chiPhiItem.Click += chiPhiToolStripMenuItem_Click;
            baoCaoItem.Click += baoCaoThongKeToolStripMenuItem_Click;

        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void chiPhiToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void GenerateBangLuong()
        {
            if (!Utils.IsInWorkDay(DateTime.Today)) return;
            int thang = DateTime.Today.Month;
            int nam = DateTime.Today.Year;
            DataTable dt = busBangLuong.GetBangLuong(Globals.MaNhanVien, thang, nam);
            if (dt.Rows.Count > 0) return;
            busBangLuong.AddBangLuong(Globals.MaNhanVien, thang, nam, 0, EnumExtensions.GetDescription(TrangThaiBangLuong.DangXuLy));
        }
        private void GenerateTodaySchedule()
        {
            if (!Utils.IsInWorkDay(DateTime.Today) || !Globals.TuDongTaoCaLamViec) return;

            var from = DateTime.Today;
            var to = DateTime.Today.AddDays(1).AddTicks(-1);

            if (busCaLamViec.GetCaLamViec(from, to).Rows.Count == 0)
            {
                var caSang = new DTO_CaLamViec { NgayLamViec = DateTime.Today, GioBatDau = new TimeSpan(7, 0, 0), GioKetThuc = new TimeSpan(11, 0, 0), GhiChu = "Ca sáng" };
                var caChieu = new DTO_CaLamViec { NgayLamViec = DateTime.Today, GioBatDau = new TimeSpan(13, 0, 0), GioKetThuc = new TimeSpan(17, 0, 0), GhiChu = "Ca chiều" };
                busCaLamViec.AddCaLamViec(caSang);
                busCaLamViec.AddCaLamViec(caChieu);
            }
        }
        private void LoadCaLamViec()
        {
            Utils.MyDataGridViewFormat(dgvCaLamViec);
            var dt = busCaLamViec.GetCaLamViec(DateTime.Today, DateTime.Today.AddDays(1).AddTicks(-1));
            dgvCaLamViec.DataSource = dt;


            if (dt.Rows.Count == 0)
            {
                //lbHidden.Text = "Không có ca làm việc nào\ntrong ngày hôm nay.";
                btnChamCong.Enabled = false;
                return;
            }

            //lbHidden.Text = "";
            btnChamCong.Enabled = true;

            dgvCaLamViec.ClearSelection();
            if (dt.Rows.Count == 1) dgvCaLamViec.Rows[0].Selected = true;
        }
        private bool DropOut()
        {
            int maChamCong = busBangChamCong.GetMaChamCongLatest(Globals.MaNhanVien);
            DTO_BangChamCong dto = busBangChamCong.GetBangChamCongByMaChamCong(maChamCong);

            if (dto != null && dto.TrangThai == EnumExtensions.GetDescription(TrangThaiChamCong.DangLamViec))
            {
                DateTime start = dto.NgayChamCong.Date + dto.GioVao;
                _baseElapsed = DateTime.Now - start;
                if (_baseElapsed < TimeSpan.Zero) _baseElapsed = TimeSpan.Zero;

                txtTimer.Text = _baseElapsed.ToString(@"hh\:mm\:ss");

                timer1.Interval = 1000;
                _sw.Restart();
                timer1.Start();

                dgvCaLamViec.ClearSelection();
                dgvCaLamViec.Enabled = false;
                lbCaLam.Text = $"Ca làm việc: {dto.NgayChamCong:dd/MM/yyyy} - {dto.GioVao:hh\\:mm}";
                btnChamCong.Text = "Kết ca";
                return true;
            }
            return false;
        }
        private static TimeSpan GetTimeSpanCell(DataGridViewRow row, string colName)
        {
            var val = row.Cells[colName].Value;
            if (val is TimeSpan ts) return ts;
            if (val is string s && TimeSpan.TryParse(s, out var parsed)) return parsed;
            throw new InvalidCastException($"Cột {colName} không phải TimeSpan hợp lệ.");
        }

        private const int MIN_OVERLAP_MINUTES = 30;

        private void FinalizeAttendanceAcrossShifts()
        {

            int maChamCong = busBangChamCong.GetMaChamCongLatest(Globals.MaNhanVien);
            DTO_BangChamCong dto = busBangChamCong.GetBangChamCongByMaChamCong(maChamCong);
            Console.WriteLine("DEBUG: dto = " + dto.MaCa);
            if (dto == null) return;

            DateTime now = DateTime.Now;

            DateTime workStart = dto.NgayChamCong.Date + dto.GioVao;
            DateTime workEnd   = now;
            if (workEnd < workStart) workEnd = workStart;

            DateTime dayStart = dto.NgayChamCong.Date;
            DateTime dayEnd   = dayStart.AddDays(1).AddTicks(-1);
            DataTable caTrongNgay = busCaLamViec.GetCaLamViec(dayStart, dayEnd);

            var rows = caTrongNgay.AsEnumerable()
                .OrderBy(r => r.Field<TimeSpan>("GioBatDau"))
                .ToList();
            //Console.WriteLine("DEBUG: Có " + rows.Count + " ca làm việc trong ngày " + dayStart.ToString("dd/MM/yyyy"));
            //Console.WriteLine("DEBUG: Ma ca hiện tại: " + dto.MaCa);
            int soNgayCong = 0;
            foreach (var r in rows)
            {
                int maCa = r.Field<int>("MaCa");
                //Console.WriteLine("DEBUG: Xử lý ca " + maCa);
                var caStart = dayStart + r.Field<TimeSpan>("GioBatDau");
                var caEnd   = dayStart + r.Field<TimeSpan>("GioKetThuc");

                int overlap = Utils.OverlapMinutes(workStart, workEnd, caStart, caEnd);

                //if (overlap < MIN_OVERLAP_MINUTES) continue; // không đủ thời gian để tính ca

                DateTime inForThisShift  = Utils.Clamp(workStart, caStart, caEnd);
                DateTime outForThisShift = Utils.Clamp(workEnd,   caStart, caEnd);
                Console.WriteLine(maCa + " " + dto.MaCa);
                if (maCa == dto.MaCa)
                {
                    busBangChamCong.UpdateBangChamCong(
                        maChamCong,
                        outForThisShift,
                        EnumExtensions.GetDescription(TrangThaiChamCong.DaChamCong)
                    );
                    Console.WriteLine("DEBUG: Chốt ca thứ 2: " + outForThisShift);
                }
                else
                {
                    if (busBangChamCong.AddBangChamCong(
                        Globals.MaNhanVien,
                        inForThisShift,
                        inForThisShift.TimeOfDay,
                        EnumExtensions.GetDescription(TrangThaiChamCong.DangLamViec),
                        maCa
                    ))
                            {

                            }
                    int newId = busBangChamCong.GetMaChamCongLatest(Globals.MaNhanVien);

                     busBangChamCong.UpdateBangChamCong(
                        newId,
                        outForThisShift,
                        EnumExtensions.GetDescription(TrangThaiChamCong.DaChamCong)
                    );
                }
                soNgayCong++;
            }
            var bangLuong = busBangLuong.GetLastBangLuongByMaNhanVien(Globals.MaNhanVien);
            Console.WriteLine(bangLuong.SoNgayCong);
            busBangLuong.UpdateBangLuong(
                bangLuong.MaLuong,
                bangLuong.SoNgayCong + soNgayCong
            );
        }
        /*
         * Thêm phạt đi trễ khi chấm công
         */
        private void btnChamCong_Click(object sender, EventArgs e)
        {
            int maChamCong = busBangChamCong.GetMaChamCongLatest(Globals.MaNhanVien);
            DTO_BangChamCong dto = busBangChamCong.GetBangChamCongByMaChamCong(maChamCong);
            bool isDangLam = dto != null && dto.TrangThai == EnumExtensions.GetDescription(TrangThaiChamCong.DangLamViec);

            // Nếu đang chạy timer => đây là KẾT CA
            if (timer1.Enabled)
            {
                var result = MessageBox.Show("Xác nhận chấm công (kết ca)?", "Chấm công",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    timer1.Stop();
                    _sw.Stop();

                    // Thay vì chỉ update 1 record, chốt theo giao thoa các ca:
                    FinalizeAttendanceAcrossShifts();

                    dgvCaLamViec.Enabled = true;
                    btnChamCong.Text = "Bắt đầu";
                    lbCaLam.Text = "";
                    LoadCaLamViec();
                }
                return;
            }

            if (dgvCaLamViec.SelectedRows.Count != 1)
            {
                MessageBox.Show("Vui lòng chọn đúng một ca làm việc trong danh sách.");
                return;
            }

            var row = dgvCaLamViec.SelectedRows[0];

            var gioKetThuc = GetTimeSpanCell(row, "GioKetThuc");
            if (DateTime.Now.TimeOfDay > gioKetThuc)
            {
                MessageBox.Show("Không thể chọn ca này vì đã quá giờ.");
                return;
            }

            int maCa = Convert.ToInt32(row.Cells["MaCa"].Value);
            var gioBatDau = GetTimeSpanCell(row, "GioBatDau");
            var now = DateTime.Now;

            int graceMinutes = Globals.PhutChoTre > 0 ? Globals.PhutChoTre : 5;
            int penaltyPerMinute = Globals.TienPhatMoiPhut;

            int minutesLateRaw = (int)Math.Floor((now.TimeOfDay - gioBatDau).TotalMinutes);
            int minutesLate = Math.Max(0, minutesLateRaw);
            int minutesCharge = Math.Max(0, minutesLate - graceMinutes);
            int tienPhat = minutesCharge * penaltyPerMinute;

            if (minutesLate > 0)
            {
                string msg = minutesCharge > 0
                    ? $"Bạn vào ca trễ {minutesLate} phút.\nPhần trễ bị tính phạt: {minutesCharge} phút.\nTiền phạt tạm tính: {tienPhat}đ."
                    : $"Bạn vào ca trễ {minutesLate} phút (trong mức cho phép {graceMinutes} phút, KHÔNG tính phạt).";
                if (minutesCharge > 0)
                {
                    int maLuong = busBangLuong.GetLastMaLuongNhanVien(Globals.MaNhanVien);
                    busChiTietLuong.AddChiTietLuong(
                        maLuong,
                        EnumExtensions.GetDescription(LoaiKhoan.Phat),
                        tienPhat,
                        $"Đi trễ {minutesLate} phút, phạt {tienPhat}đ."
                    );
                }
                MessageBox.Show(msg, "Đi trễ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (busBangChamCong.AddBangChamCong(
                Globals.MaNhanVien,
                now,
                now.TimeOfDay,
                EnumExtensions.GetDescription(TrangThaiChamCong.DangLamViec),
                maCa
            ))
            {
                //lbHidden.Text = $"Chấm công thành công!{(minutesCharge > 0 ? $" Đi trễ {minutesLate} phút, phạt {tienPhat}đ." : "")}";
            }
            else
            {
                MessageBox.Show("Lỗi khi chấm công. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _baseElapsed = TimeSpan.Zero;
            txtTimer.Text = "00:00:00";
            timer1.Interval = 1000;
            _sw.Restart();
            timer1.Start();

            dgvCaLamViec.Enabled = false;
            btnChamCong.Text = "Kết ca";
            lbCaLam.Text = $"Ca làm việc: {DateTime.Now:dd/MM/yyyy} - {DateTime.Now:HH\\:mm}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var elapsed = _baseElapsed + _sw.Elapsed;
            if (elapsed < TimeSpan.Zero) elapsed = TimeSpan.Zero;
            txtTimer.Text = elapsed.ToString(@"hh\:mm\:ss");
        }
    }
}
