namespace GUI_QuanLy
{
    partial class GUI_OrderDetail
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
            this.dgvLoHang = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoHang)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLoHang
            // 
            this.dgvLoHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoHang.Location = new System.Drawing.Point(12, 12);
            this.dgvLoHang.Name = "dgvLoHang";
            this.dgvLoHang.Size = new System.Drawing.Size(776, 426);
            this.dgvLoHang.TabIndex = 0;
            // 
            // GUI_OrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvLoHang);
            this.Name = "GUI_OrderDetail";
            this.Text = "GUI_OrderDetail";
            this.Load += new System.EventHandler(this.GUI_OrderDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLoHang;
    }
}