namespace GUI_QuanLy
{
    partial class GUI_MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyNhanVienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baoCaoThongKeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbCaLam = new System.Windows.Forms.Label();
            this.lbHidden = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimer = new System.Windows.Forms.TextBox();
            this.dgvCaLamViec = new System.Windows.Forms.DataGridView();
            this.btnChamCong = new System.Windows.Forms.Button();
            this.lbHello = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chiPhíToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaLamViec)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.quanLyKhoToolStripMenuItem,
            this.quanLyNhanVienToolStripMenuItem,
            this.baoCaoThongKeToolStripMenuItem,
            this.chiPhíToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1029, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // quanLyKhoToolStripMenuItem
            // 
            this.quanLyKhoToolStripMenuItem.Name = "quanLyKhoToolStripMenuItem";
            this.quanLyKhoToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.quanLyKhoToolStripMenuItem.Text = "Quản lý kho";
            this.quanLyKhoToolStripMenuItem.Click += new System.EventHandler(this.quanLyKhoToolStripMenuItem_Click);
            // 
            // quanLyNhanVienToolStripMenuItem
            // 
            this.quanLyNhanVienToolStripMenuItem.Name = "quanLyNhanVienToolStripMenuItem";
            this.quanLyNhanVienToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.quanLyNhanVienToolStripMenuItem.Text = "Quản lý nhân viên";
            this.quanLyNhanVienToolStripMenuItem.Click += new System.EventHandler(this.quanLyNhanVienToolStripMenuItem_Click);
            // 
            // baoCaoThongKeToolStripMenuItem
            // 
            this.baoCaoThongKeToolStripMenuItem.Name = "baoCaoThongKeToolStripMenuItem";
            this.baoCaoThongKeToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.baoCaoThongKeToolStripMenuItem.Text = "Báo cáo thống kê";
            this.baoCaoThongKeToolStripMenuItem.Click += new System.EventHandler(this.baoCaoThongKeToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbCaLam);
            this.groupBox1.Controls.Add(this.lbHidden);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTimer);
            this.groupBox1.Controls.Add(this.dgvCaLamViec);
            this.groupBox1.Controls.Add(this.btnChamCong);
            this.groupBox1.Controls.Add(this.lbHello);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1005, 509);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // lbCaLam
            // 
            this.lbCaLam.AutoSize = true;
            this.lbCaLam.Location = new System.Drawing.Point(54, 307);
            this.lbCaLam.Name = "lbCaLam";
            this.lbCaLam.Size = new System.Drawing.Size(150, 29);
            this.lbCaLam.TabIndex = 6;
            this.lbCaLam.Text = "Hidden label";
            // 
            // lbHidden
            // 
            this.lbHidden.AutoSize = true;
            this.lbHidden.Location = new System.Drawing.Point(616, 74);
            this.lbHidden.Name = "lbHidden";
            this.lbHidden.Size = new System.Drawing.Size(150, 29);
            this.lbHidden.TabIndex = 5;
            this.lbHidden.Text = "Hidden label";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Thời gian hiện tại";
            // 
            // txtTimer
            // 
            this.txtTimer.Enabled = false;
            this.txtTimer.Location = new System.Drawing.Point(267, 247);
            this.txtTimer.Name = "txtTimer";
            this.txtTimer.Size = new System.Drawing.Size(167, 35);
            this.txtTimer.TabIndex = 3;
            this.txtTimer.Text = "00:00:00";
            // 
            // dgvCaLamViec
            // 
            this.dgvCaLamViec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaLamViec.Location = new System.Drawing.Point(59, 74);
            this.dgvCaLamViec.Name = "dgvCaLamViec";
            this.dgvCaLamViec.Size = new System.Drawing.Size(530, 150);
            this.dgvCaLamViec.TabIndex = 2;
            // 
            // btnChamCong
            // 
            this.btnChamCong.Location = new System.Drawing.Point(59, 355);
            this.btnChamCong.Name = "btnChamCong";
            this.btnChamCong.Size = new System.Drawing.Size(157, 46);
            this.btnChamCong.TabIndex = 1;
            this.btnChamCong.Text = "Chấm công";
            this.btnChamCong.UseVisualStyleBackColor = true;
            this.btnChamCong.Click += new System.EventHandler(this.btnChamCong_Click);
            // 
            // lbHello
            // 
            this.lbHello.AutoSize = true;
            this.lbHello.Location = new System.Drawing.Point(54, 31);
            this.lbHello.Name = "lbHello";
            this.lbHello.Size = new System.Drawing.Size(129, 29);
            this.lbHello.TabIndex = 0;
            this.lbHello.Text = "Hello label";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chiPhíToolStripMenuItem
            // 
            this.chiPhíToolStripMenuItem.Name = "chiPhíToolStripMenuItem";
            this.chiPhíToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.chiPhíToolStripMenuItem.Text = "Chi phí";
            this.chiPhíToolStripMenuItem.Click += new System.EventHandler(this.chiPhíToolStripMenuItem_Click);
            // 
            // GUI_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 548);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GUI_MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.GUI_MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaLamViec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quanLyKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyNhanVienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baoCaoThongKeToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbHello;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimer;
        private System.Windows.Forms.DataGridView dgvCaLamViec;
        private System.Windows.Forms.Button btnChamCong;
        private System.Windows.Forms.Label lbHidden;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbCaLam;
        private System.Windows.Forms.ToolStripMenuItem chiPhíToolStripMenuItem;
    }
}