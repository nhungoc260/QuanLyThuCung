namespace HTQuanLyThuCung
{
    partial class frmChiTietHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnIn = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelSanPham = new System.Windows.Forms.Panel();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.clSP_MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSP_Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSP_SL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSP_DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSP_ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTieuDeSP = new System.Windows.Forms.Label();
            this.panelDichVu = new System.Windows.Forms.Panel();
            this.dgvDichVu = new System.Windows.Forms.DataGridView();
            this.clDV_MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDV_Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDV_SL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDV_DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDV_ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTieuDeDV = new System.Windows.Forms.Label();
            this.lblTong = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.panelDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelHeader.Controls.Add(this.btnIn);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(850, 90);
            this.panelHeader.TabIndex = 0;
            // 
            // btnIn
            // 
            this.btnIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnIn.FlatAppearance.BorderSize = 0;
            this.btnIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnIn.ForeColor = System.Drawing.Color.White;
            this.btnIn.Location = new System.Drawing.Point(25, 25);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(110, 45);
            this.btnIn.TabIndex = 1;
            this.btnIn.Text = "🖨️ In";
            this.btnIn.UseVisualStyleBackColor = false;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(350, 35);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(167, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Chi tiết thống kê";
            // 
            // panelSanPham
            // 
            this.panelSanPham.BackColor = System.Drawing.Color.White;
            this.panelSanPham.Controls.Add(this.dgvSanPham);
            this.panelSanPham.Controls.Add(this.lblTieuDeSP);
            this.panelSanPham.Location = new System.Drawing.Point(25, 110);
            this.panelSanPham.Name = "panelSanPham";
            this.panelSanPham.Size = new System.Drawing.Size(800, 220);
            this.panelSanPham.TabIndex = 1;
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.AllowUserToDeleteRows = false;
            this.dgvSanPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clSP_MaHD,
            this.clSP_Ten,
            this.clSP_SL,
            this.clSP_DonGia,
            this.clSP_ThanhTien});
            this.dgvSanPham.Location = new System.Drawing.Point(20, 55);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.Size = new System.Drawing.Size(760, 145);
            this.dgvSanPham.TabIndex = 1;
            // 
            // clSP_MaHD
            // 
            this.clSP_MaHD.HeaderText = "Mã HĐ";
            this.clSP_MaHD.Name = "clSP_MaHD";
            this.clSP_MaHD.ReadOnly = true;
            this.clSP_MaHD.Width = 80;
            // 
            // clSP_Ten
            // 
            this.clSP_Ten.HeaderText = "Tên";
            this.clSP_Ten.Name = "clSP_Ten";
            this.clSP_Ten.ReadOnly = true;
            this.clSP_Ten.Width = 280;
            // 
            // clSP_SL
            // 
            this.clSP_SL.HeaderText = "Số lượng";
            this.clSP_SL.Name = "clSP_SL";
            this.clSP_SL.ReadOnly = true;
            // 
            // clSP_DonGia
            // 
            this.clSP_DonGia.HeaderText = "Đơn giá";
            this.clSP_DonGia.Name = "clSP_DonGia";
            this.clSP_DonGia.ReadOnly = true;
            this.clSP_DonGia.Width = 130;
            // 
            // clSP_ThanhTien
            // 
            this.clSP_ThanhTien.HeaderText = "Thành tiền";
            this.clSP_ThanhTien.Name = "clSP_ThanhTien";
            this.clSP_ThanhTien.ReadOnly = true;
            this.clSP_ThanhTien.Width = 130;
            // 
            // lblTieuDeSP
            // 
            this.lblTieuDeSP.AutoSize = true;
            this.lblTieuDeSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeSP.Location = new System.Drawing.Point(340, 15);
            this.lblTieuDeSP.Name = "lblTieuDeSP";
            this.lblTieuDeSP.Size = new System.Drawing.Size(110, 26);
            this.lblTieuDeSP.TabIndex = 0;
            this.lblTieuDeSP.Text = "Sản phẩm";
            // 
            // panelDichVu
            // 
            this.panelDichVu.BackColor = System.Drawing.Color.White;
            this.panelDichVu.Controls.Add(this.dgvDichVu);
            this.panelDichVu.Controls.Add(this.lblTieuDeDV);
            this.panelDichVu.Location = new System.Drawing.Point(25, 350);
            this.panelDichVu.Name = "panelDichVu";
            this.panelDichVu.Size = new System.Drawing.Size(800, 160);
            this.panelDichVu.TabIndex = 2;
            // 
            // dgvDichVu
            // 
            this.dgvDichVu.AllowUserToAddRows = false;
            this.dgvDichVu.AllowUserToDeleteRows = false;
            this.dgvDichVu.BackgroundColor = System.Drawing.Color.White;
            this.dgvDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDichVu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clDV_MaHD,
            this.clDV_Ten,
            this.clDV_SL,
            this.clDV_DonGia,
            this.clDV_ThanhTien});
            this.dgvDichVu.Location = new System.Drawing.Point(20, 55);
            this.dgvDichVu.Name = "dgvDichVu";
            this.dgvDichVu.ReadOnly = true;
            this.dgvDichVu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDichVu.Size = new System.Drawing.Size(760, 90);
            this.dgvDichVu.TabIndex = 1;
            // 
            // clDV_MaHD
            // 
            this.clDV_MaHD.HeaderText = "Mã HĐ";
            this.clDV_MaHD.Name = "clDV_MaHD";
            this.clDV_MaHD.ReadOnly = true;
            this.clDV_MaHD.Width = 80;
            // 
            // clDV_Ten
            // 
            this.clDV_Ten.HeaderText = "Tên";
            this.clDV_Ten.Name = "clDV_Ten";
            this.clDV_Ten.ReadOnly = true;
            this.clDV_Ten.Width = 280;
            // 
            // clDV_SL
            // 
            this.clDV_SL.HeaderText = "Số lượng";
            this.clDV_SL.Name = "clDV_SL";
            this.clDV_SL.ReadOnly = true;
            // 
            // clDV_DonGia
            // 
            this.clDV_DonGia.HeaderText = "Đơn giá";
            this.clDV_DonGia.Name = "clDV_DonGia";
            this.clDV_DonGia.ReadOnly = true;
            this.clDV_DonGia.Width = 130;
            // 
            // clDV_ThanhTien
            // 
            this.clDV_ThanhTien.HeaderText = "Thành tiền";
            this.clDV_ThanhTien.Name = "clDV_ThanhTien";
            this.clDV_ThanhTien.ReadOnly = true;
            this.clDV_ThanhTien.Width = 130;
            // 
            // lblTieuDeDV
            // 
            this.lblTieuDeDV.AutoSize = true;
            this.lblTieuDeDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeDV.Location = new System.Drawing.Point(350, 15);
            this.lblTieuDeDV.Name = "lblTieuDeDV";
            this.lblTieuDeDV.Size = new System.Drawing.Size(89, 26);
            this.lblTieuDeDV.TabIndex = 0;
            this.lblTieuDeDV.Text = "Dịch vụ";
            // 
            // lblTong
            // 
            this.lblTong.AutoSize = true;
            this.lblTong.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblTong.Location = new System.Drawing.Point(340, 540);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(171, 29);
            this.lblTong.TabIndex = 3;
            this.lblTong.Text = "Tổng: 0đ";
            // 
            // frmChiTietHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(850, 600);
            this.Controls.Add(this.lblTong);
            this.Controls.Add(this.panelDichVu);
            this.Controls.Add(this.panelSanPham);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmChiTietHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết hóa đơn bán hàng";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelSanPham.ResumeLayout(false);
            this.panelSanPham.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.panelDichVu.ResumeLayout(false);
            this.panelDichVu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelSanPham;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Label lblTieuDeSP;
        private System.Windows.Forms.Panel panelDichVu;
        private System.Windows.Forms.DataGridView dgvDichVu;
        private System.Windows.Forms.Label lblTieuDeDV;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSP_MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSP_Ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSP_SL;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSP_DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSP_ThanhTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDV_MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDV_Ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDV_SL;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDV_DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDV_ThanhTien;
    }
}