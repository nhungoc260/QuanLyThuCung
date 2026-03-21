namespace HTQuanLyThuCung
{
    partial class frmInHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.panelSanPham = new System.Windows.Forms.Panel();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.clSP_Ma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSP_Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSP_SL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSP_DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSP_ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTieuDeSP = new System.Windows.Forms.Label();
            this.panelDichVu = new System.Windows.Forms.Panel();
            this.dgvDichVu = new System.Windows.Forms.DataGridView();
            this.clDV_Ma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDV_Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDV_SL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDV_DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDV_ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTieuDeDV = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.panelDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).BeginInit();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.panelHeader.Controls.Add(this.btnIn);
            this.panelHeader.Controls.Add(this.btnDong);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(800, 80);
            this.panelHeader.TabIndex = 0;
            // btnIn
            this.btnIn.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnIn.FlatAppearance.BorderSize = 0;
            this.btnIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnIn.ForeColor = System.Drawing.Color.White;
            this.btnIn.Location = new System.Drawing.Point(550, 20);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(110, 40);
            this.btnIn.TabIndex = 2;
            this.btnIn.Text = "🖨️ In hóa đơn";
            this.btnIn.UseVisualStyleBackColor = false;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // btnDong
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(680, 20);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 40);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(210, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HÓA ĐƠN BÁN HÀNG";
            // panelInfo
            this.panelInfo.BackColor = System.Drawing.Color.White;
            this.panelInfo.Controls.Add(this.lblNhanVien);
            this.panelInfo.Controls.Add(this.lblKhachHang);
            this.panelInfo.Controls.Add(this.lblNgayLap);
            this.panelInfo.Controls.Add(this.lblMaHD);
            this.panelInfo.Location = new System.Drawing.Point(20, 90);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(760, 100);
            this.panelInfo.TabIndex = 1;
            // lblNhanVien
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblNhanVien.Location = new System.Drawing.Point(20, 70);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(90, 17);
            this.lblNhanVien.TabIndex = 3;
            this.lblNhanVien.Text = "Nhân viên: ...";
            // lblKhachHang
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblKhachHang.Location = new System.Drawing.Point(380, 40);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(95, 17);
            this.lblKhachHang.TabIndex = 2;
            this.lblKhachHang.Text = "Khách hàng: ...";
            // lblNgayLap
            this.lblNgayLap.AutoSize = true;
            this.lblNgayLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblNgayLap.Location = new System.Drawing.Point(20, 40);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(65, 17);
            this.lblNgayLap.TabIndex = 1;
            this.lblNgayLap.Text = "Ngày: ...";
            // lblMaHD
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaHD.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblMaHD.Location = new System.Drawing.Point(20, 15);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(85, 18);
            this.lblMaHD.TabIndex = 0;
            this.lblMaHD.Text = "Mã HĐ: ...";
            // panelSanPham
            this.panelSanPham.BackColor = System.Drawing.Color.White;
            this.panelSanPham.Controls.Add(this.dgvSanPham);
            this.panelSanPham.Controls.Add(this.lblTieuDeSP);
            this.panelSanPham.Location = new System.Drawing.Point(20, 200);
            this.panelSanPham.Name = "panelSanPham";
            this.panelSanPham.Size = new System.Drawing.Size(760, 180);
            this.panelSanPham.TabIndex = 2;
            // dgvSanPham
            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.AllowUserToDeleteRows = false;
            this.dgvSanPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clSP_Ma, this.clSP_Ten, this.clSP_SL, this.clSP_DonGia, this.clSP_ThanhTien});
            this.dgvSanPham.Location = new System.Drawing.Point(20, 45);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.Size = new System.Drawing.Size(720, 120);
            this.dgvSanPham.TabIndex = 1;
            // clSP_Ma
            this.clSP_Ma.HeaderText = "Mã"; this.clSP_Ma.Name = "clSP_Ma"; this.clSP_Ma.ReadOnly = true; this.clSP_Ma.Width = 60;
            // clSP_Ten
            this.clSP_Ten.HeaderText = "Tên sản phẩm"; this.clSP_Ten.Name = "clSP_Ten"; this.clSP_Ten.ReadOnly = true; this.clSP_Ten.Width = 250;
            // clSP_SL
            this.clSP_SL.HeaderText = "SL"; this.clSP_SL.Name = "clSP_SL"; this.clSP_SL.ReadOnly = true; this.clSP_SL.Width = 50;
            // clSP_DonGia
            this.clSP_DonGia.HeaderText = "Đơn giá"; this.clSP_DonGia.Name = "clSP_DonGia"; this.clSP_DonGia.ReadOnly = true; this.clSP_DonGia.Width = 120;
            // clSP_ThanhTien
            this.clSP_ThanhTien.HeaderText = "Thành tiền"; this.clSP_ThanhTien.Name = "clSP_ThanhTien"; this.clSP_ThanhTien.ReadOnly = true; this.clSP_ThanhTien.Width = 120;
            // lblTieuDeSP
            this.lblTieuDeSP.AutoSize = true;
            this.lblTieuDeSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeSP.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblTieuDeSP.Location = new System.Drawing.Point(20, 15);
            this.lblTieuDeSP.Name = "lblTieuDeSP";
            this.lblTieuDeSP.Size = new System.Drawing.Size(90, 20);
            this.lblTieuDeSP.TabIndex = 0;
            this.lblTieuDeSP.Text = "SẢN PHẨM";
            // panelDichVu
            this.panelDichVu.BackColor = System.Drawing.Color.White;
            this.panelDichVu.Controls.Add(this.dgvDichVu);
            this.panelDichVu.Controls.Add(this.lblTieuDeDV);
            this.panelDichVu.Location = new System.Drawing.Point(20, 390);
            this.panelDichVu.Name = "panelDichVu";
            this.panelDichVu.Size = new System.Drawing.Size(760, 140);
            this.panelDichVu.TabIndex = 3;
            // dgvDichVu
            this.dgvDichVu.AllowUserToAddRows = false;
            this.dgvDichVu.AllowUserToDeleteRows = false;
            this.dgvDichVu.BackgroundColor = System.Drawing.Color.White;
            this.dgvDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDichVu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clDV_Ma, this.clDV_Ten, this.clDV_SL, this.clDV_DonGia, this.clDV_ThanhTien});
            this.dgvDichVu.Location = new System.Drawing.Point(20, 45);
            this.dgvDichVu.Name = "dgvDichVu";
            this.dgvDichVu.ReadOnly = true;
            this.dgvDichVu.Size = new System.Drawing.Size(720, 80);
            this.dgvDichVu.TabIndex = 1;
            // clDV_Ma
            this.clDV_Ma.HeaderText = "Mã"; this.clDV_Ma.Name = "clDV_Ma"; this.clDV_Ma.ReadOnly = true; this.clDV_Ma.Width = 60;
            // clDV_Ten
            this.clDV_Ten.HeaderText = "Tên dịch vụ"; this.clDV_Ten.Name = "clDV_Ten"; this.clDV_Ten.ReadOnly = true; this.clDV_Ten.Width = 250;
            // clDV_SL
            this.clDV_SL.HeaderText = "SL"; this.clDV_SL.Name = "clDV_SL"; this.clDV_SL.ReadOnly = true; this.clDV_SL.Width = 50;
            // clDV_DonGia
            this.clDV_DonGia.HeaderText = "Đơn giá"; this.clDV_DonGia.Name = "clDV_DonGia"; this.clDV_DonGia.ReadOnly = true; this.clDV_DonGia.Width = 120;
            // clDV_ThanhTien
            this.clDV_ThanhTien.HeaderText = "Thành tiền"; this.clDV_ThanhTien.Name = "clDV_ThanhTien"; this.clDV_ThanhTien.ReadOnly = true; this.clDV_ThanhTien.Width = 120;
            // lblTieuDeDV
            this.lblTieuDeDV.AutoSize = true;
            this.lblTieuDeDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeDV.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblTieuDeDV.Location = new System.Drawing.Point(20, 15);
            this.lblTieuDeDV.Name = "lblTieuDeDV";
            this.lblTieuDeDV.Size = new System.Drawing.Size(82, 20);
            this.lblTieuDeDV.TabIndex = 0;
            this.lblTieuDeDV.Text = "DỊCH VỤ";
            // panelFooter
            this.panelFooter.BackColor = System.Drawing.Color.White;
            this.panelFooter.Controls.Add(this.lblTongTien);
            this.panelFooter.Location = new System.Drawing.Point(20, 540);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(760, 60);
            this.panelFooter.TabIndex = 4;
            // lblTongTien
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.lblTongTien.Location = new System.Drawing.Point(550, 18);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(180, 26);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = "Tổng cộng: 0đ";
            // frmInHoaDon
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelDichVu);
            this.Controls.Add(this.panelSanPham);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmInHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "In hóa đơn";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelSanPham.ResumeLayout(false);
            this.panelSanPham.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.panelDichVu.ResumeLayout(false);
            this.panelDichVu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.Label lblNgayLap;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.Panel panelSanPham;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Label lblTieuDeSP;
        private System.Windows.Forms.Panel panelDichVu;
        private System.Windows.Forms.DataGridView dgvDichVu;
        private System.Windows.Forms.Label lblTieuDeDV;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSP_Ma;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSP_Ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSP_SL;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSP_DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSP_ThanhTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDV_Ma;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDV_Ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDV_SL;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDV_DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDV_ThanhTien;
    }
}