namespace GUI_QuanLy
{
    partial class GUI_ChiPhi
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpTimKiemChiPhi = new System.Windows.Forms.DateTimePicker();
            this.btnTimKiemChiPhi = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvChiPhi = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXoaChiPhi = new System.Windows.Forms.Button();
            this.btnSuaChiPhi = new System.Windows.Forms.Button();
            this.btnThemChiPhi = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenChiPhi = new System.Windows.Forms.TextBox();
            this.btnResetChiPhi = new System.Windows.Forms.Button();

            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiPhi)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnResetChiPhi);

            this.groupBox1.Controls.Add(this.dtpTimKiemChiPhi);
            this.groupBox1.Controls.Add(this.btnTimKiemChiPhi);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dgvChiPhi);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(554, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(733, 465);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // dtpTimKiemChiPhi
            // 
            this.dtpTimKiemChiPhi.CustomFormat = "dd/MM/yyyy";
            this.dtpTimKiemChiPhi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimKiemChiPhi.Location = new System.Drawing.Point(140, 56);
            this.dtpTimKiemChiPhi.Name = "dtpTimKiemChiPhi";
            this.dtpTimKiemChiPhi.Size = new System.Drawing.Size(289, 35);
            this.dtpTimKiemChiPhi.TabIndex = 14;
            this.dtpTimKiemChiPhi.Value = new System.DateTime(2025, 7, 10, 0, 0, 0, 0);
            // 
            // btnTimKiemChiPhi
            // 
            this.btnTimKiemChiPhi.Location = new System.Drawing.Point(435, 54);
            this.btnTimKiemChiPhi.Name = "btnTimKiemChiPhi";
            this.btnTimKiemChiPhi.Size = new System.Drawing.Size(164, 37);
            this.btnTimKiemChiPhi.TabIndex = 14;
            this.btnTimKiemChiPhi.Text = "Tìm kiếm";
            this.btnTimKiemChiPhi.UseVisualStyleBackColor = true;
            this.btnTimKiemChiPhi.Click += new System.EventHandler(this.btnTimKiemChiPhi_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 61);

            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 29);
            this.label5.TabIndex = 2;
            this.label5.Text = "Tìm kiếm";
            // 
            // dgvChiPhi
            // 
            this.dgvChiPhi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiPhi.Location = new System.Drawing.Point(26, 107);
            this.dgvChiPhi.Name = "dgvChiPhi";
            this.dgvChiPhi.Size = new System.Drawing.Size(689, 252);
            this.dgvChiPhi.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpNgayLap);
            this.groupBox3.Controls.Add(this.txtMoTa);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnXoaChiPhi);
            this.groupBox3.Controls.Add(this.btnSuaChiPhi);
            this.groupBox3.Controls.Add(this.btnThemChiPhi);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtSoTien);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtTenChiPhi);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(8, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(540, 465);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayLap.Location = new System.Drawing.Point(177, 184);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(343, 35);
            this.dtpNgayLap.TabIndex = 13;
            this.dtpNgayLap.Value = new System.DateTime(2025, 7, 10, 0, 0, 0, 0);
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(177, 237);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(343, 35);
            this.txtMoTa.TabIndex = 12;
            this.txtMoTa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 29);
            this.label6.TabIndex = 11;
            this.label6.Text = "Mô tả";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ngày lập";
            // 
            // btnXoaChiPhi
            // 
            this.btnXoaChiPhi.Location = new System.Drawing.Point(373, 312);
            this.btnXoaChiPhi.Name = "btnXoaChiPhi";
            this.btnXoaChiPhi.Size = new System.Drawing.Size(114, 47);
            this.btnXoaChiPhi.TabIndex = 9;
            this.btnXoaChiPhi.Text = "Xóa";
            this.btnXoaChiPhi.UseVisualStyleBackColor = true;
            this.btnXoaChiPhi.Click += new System.EventHandler(this.btnXoaChiPhi_Click);
            // 
            // btnSuaChiPhi
            // 
            this.btnSuaChiPhi.Location = new System.Drawing.Point(206, 312);
            this.btnSuaChiPhi.Name = "btnSuaChiPhi";
            this.btnSuaChiPhi.Size = new System.Drawing.Size(114, 47);
            this.btnSuaChiPhi.TabIndex = 8;
            this.btnSuaChiPhi.Text = "Sửa";
            this.btnSuaChiPhi.UseVisualStyleBackColor = true;
            this.btnSuaChiPhi.Click += new System.EventHandler(this.btnSuaChiPhi_Click);
            // 
            // btnThemChiPhi
            // 
            this.btnThemChiPhi.Location = new System.Drawing.Point(50, 312);
            this.btnThemChiPhi.Name = "btnThemChiPhi";
            this.btnThemChiPhi.Size = new System.Drawing.Size(114, 47);
            this.btnThemChiPhi.TabIndex = 7;
            this.btnThemChiPhi.Text = "Thêm";
            this.btnThemChiPhi.UseVisualStyleBackColor = true;
            this.btnThemChiPhi.Click += new System.EventHandler(this.btnThemChiPhi_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Số tiền";
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(177, 127);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(343, 35);
            this.txtSoTien.TabIndex = 5;
            this.txtSoTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tên Chi Phí";
            // 
            // txtTenChiPhi
            // 
            this.txtTenChiPhi.Location = new System.Drawing.Point(177, 72);
            this.txtTenChiPhi.Name = "txtTenChiPhi";
            this.txtTenChiPhi.Size = new System.Drawing.Size(343, 35);
            this.txtTenChiPhi.TabIndex = 3;
            this.txtTenChiPhi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnResetChiPhi
            // 
            this.btnResetChiPhi.Location = new System.Drawing.Point(605, 53);
            this.btnResetChiPhi.Name = "btnResetChiPhi";
            this.btnResetChiPhi.Size = new System.Drawing.Size(110, 37);
            this.btnResetChiPhi.TabIndex = 15;
            this.btnResetChiPhi.Text = "Reset";
            this.btnResetChiPhi.UseVisualStyleBackColor = true;
            // 
            // GUI_ChiPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(1283, 512);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "GUI_ChiPhi";
            this.Text = "GUI_ChiPhi";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiPhi)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpTimKiemChiPhi;
        private System.Windows.Forms.Button btnTimKiemChiPhi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvChiPhi;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXoaChiPhi;
        private System.Windows.Forms.Button btnSuaChiPhi;
        private System.Windows.Forms.Button btnThemChiPhi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenChiPhi;
        private System.Windows.Forms.Button btnResetChiPhi;
    }
}