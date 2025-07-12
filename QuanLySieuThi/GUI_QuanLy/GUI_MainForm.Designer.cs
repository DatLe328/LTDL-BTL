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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyNhanVienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baoCaoThongKeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.quanLyKhoToolStripMenuItem,
            this.quanLyNhanVienToolStripMenuItem,
            this.baoCaoThongKeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
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
            // GUI_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GUI_MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quanLyKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyNhanVienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baoCaoThongKeToolStripMenuItem;
    }
}