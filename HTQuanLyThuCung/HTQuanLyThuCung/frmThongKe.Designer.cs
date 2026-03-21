namespace HTQuanLyThuCung
{
    partial class frmThongKe
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnXemChiTiet = new System.Windows.Forms.Button();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.clMaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNgayLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.btnXemTatCa = new System.Windows.Forms.Button();
            this.lblKhoangNgay = new System.Windows.Forms.Label();
            this.btnLoc = new System.Windows.Forms.Button();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDen = new System.Windows.Forms.Label();
            this.lblTu = new System.Windows.Forms.Label();
            this.panelThongKe = new System.Windows.Forms.Panel();
            this.lblSoHoaDon = new System.Windows.Forms.Label();
            this.lblDichVu = new System.Windows.Forms.Label();
            this.lblSanPham = new System.Windows.Forms.Label();
            this.lblTitleSoHD = new System.Windows.Forms.Label();
            this.lblTitleDV = new System.Windows.Forms.Label();
            this.lblTitleSP = new System.Windows.Forms.Label();
            this.panelFilter.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.panelThongKe.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelMain.Controls.Add(this.lblTongTien);
            this.panelMain.Controls.Add(this.btnXemChiTiet);
            this.panelMain.Controls.Add(this.dgvHoaDon);
            this.panelMain.Controls.Add(this.panelFilter);
            this.panelMain.Controls.Add(this.panelThongKe);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(950, 680);
            this.panelMain.TabIndex = 0;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.Location = new System.Drawing.Point(720, 630);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(157, 20);
            this.lblTongTien.TabIndex = 5;
            this.lblTongTien.Text = "Tổng tiền: 0 VND";
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnXemChiTiet.FlatAppearance.BorderSize = 0;
            this.btnXemChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnXemChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnXemChiTiet.Location = new System.Drawing.Point(25, 620);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(150, 40);
            this.btnXemChiTiet.TabIndex = 4;
            this.btnXemChiTiet.Text = "📄 Xem chi tiết";
            this.btnXemChiTiet.UseVisualStyleBackColor = false;
            this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            this.dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clMaHD,
            this.clNgayLap,
            this.clKhachHang,
            this.clNhanVien,
            this.clTongTien});
            this.dgvHoaDon.Location = new System.Drawing.Point(25, 240);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(900, 370);
            this.dgvHoaDon.TabIndex = 3;
            this.dgvHoaDon.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellDoubleClick);
            // 
            // clMaHD
            // 
            this.clMaHD.HeaderText = "#";
            this.clMaHD.Name = "clMaHD";
            this.clMaHD.ReadOnly = true;
            this.clMaHD.Width = 50;
            // 
            // clNgayLap
            // 
            this.clNgayLap.HeaderText = "Ngày lập";
            this.clNgayLap.Name = "clNgayLap";
            this.clNgayLap.ReadOnly = true;
            this.clNgayLap.Width = 180;
            // 
            // clKhachHang
            // 
            this.clKhachHang.HeaderText = "Tên khách hàng";
            this.clKhachHang.Name = "clKhachHang";
            this.clKhachHang.ReadOnly = true;
            this.clKhachHang.Width = 200;
            // 
            // clNhanVien
            // 
            this.clNhanVien.HeaderText = "Nhân viên";
            this.clNhanVien.Name = "clNhanVien";
            this.clNhanVien.ReadOnly = true;
            this.clNhanVien.Width = 200;
            // 
            // clTongTien
            // 
            this.clTongTien.HeaderText = "Tổng tiền";
            this.clTongTien.Name = "clTongTien";
            this.clTongTien.ReadOnly = true;
            this.clTongTien.Width = 150;
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.White;
            this.panelFilter.Controls.Add(this.btnXemTatCa);
            this.panelFilter.Controls.Add(this.lblKhoangNgay);
            this.panelFilter.Controls.Add(this.btnLoc);
            this.panelFilter.Controls.Add(this.dtpDenNgay);
            this.panelFilter.Controls.Add(this.dtpTuNgay);
            this.panelFilter.Controls.Add(this.lblDen);
            this.panelFilter.Controls.Add(this.lblTu);
            this.panelFilter.Location = new System.Drawing.Point(25, 145);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(900, 80);
            this.panelFilter.TabIndex = 2;
            // 
            // btnXemTatCa
            // 
            this.btnXemTatCa.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnXemTatCa.FlatAppearance.BorderSize = 0;
            this.btnXemTatCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemTatCa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnXemTatCa.ForeColor = System.Drawing.Color.White;
            this.btnXemTatCa.Location = new System.Drawing.Point(780, 10);
            this.btnXemTatCa.Name = "btnXemTatCa";
            this.btnXemTatCa.Size = new System.Drawing.Size(120, 35);
            this.btnXemTatCa.TabIndex = 6;
            this.btnXemTatCa.Text = "📅 Xem tất cả";
            this.btnXemTatCa.UseVisualStyleBackColor = false;
            this.btnXemTatCa.Click += new System.EventHandler(this.btnXemTatCa_Click);
            // 
            // lblKhoangNgay
            // 
            this.lblKhoangNgay.AutoSize = true;
            this.lblKhoangNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.lblKhoangNgay.ForeColor = System.Drawing.Color.FromArgb(128, 128, 128);
            this.lblKhoangNgay.Location = new System.Drawing.Point(3, 55);
            this.lblKhoangNgay.Name = "lblKhoangNgay";
            this.lblKhoangNgay.Size = new System.Drawing.Size(250, 15);
            this.lblKhoangNgay.TabIndex = 5;
            this.lblKhoangNgay.Text = "📊 Dữ liệu từ: ... đến: ...";
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnLoc.FlatAppearance.BorderSize = 0;
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(650, 10);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(120, 35);
            this.btnLoc.TabIndex = 4;
            this.btnLoc.Text = "🔍 Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(430, 13);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(150, 20);
            this.dtpDenNgay.TabIndex = 3;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(210, 13);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(150, 20);
            this.dtpTuNgay.TabIndex = 2;
            // 
            // lblDen
            // 
            this.lblDen.AutoSize = true;
            this.lblDen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblDen.Location = new System.Drawing.Point(370, 15);
            this.lblDen.Name = "lblDen";
            this.lblDen.Size = new System.Drawing.Size(54, 15);
            this.lblDen.TabIndex = 1;
            this.lblDen.Text = "Đến ngày";
            // 
            // lblTu
            // 
            this.lblTu.AutoSize = true;
            this.lblTu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblTu.Location = new System.Drawing.Point(150, 15);
            this.lblTu.Name = "lblTu";
            this.lblTu.Size = new System.Drawing.Size(44, 15);
            this.lblTu.TabIndex = 0;
            this.lblTu.Text = "Từ ngày";
            // 
            // panelThongKe
            // 
            this.panelThongKe.BackColor = System.Drawing.Color.White;
            this.panelThongKe.Controls.Add(this.lblSoHoaDon);
            this.panelThongKe.Controls.Add(this.lblDichVu);
            this.panelThongKe.Controls.Add(this.lblSanPham);
            this.panelThongKe.Controls.Add(this.lblTitleSoHD);
            this.panelThongKe.Controls.Add(this.lblTitleDV);
            this.panelThongKe.Controls.Add(this.lblTitleSP);
            this.panelThongKe.Location = new System.Drawing.Point(25, 25);
            this.panelThongKe.Name = "panelThongKe";
            this.panelThongKe.Size = new System.Drawing.Size(900, 110);
            this.panelThongKe.TabIndex = 0;
            // 
            // lblSoHoaDon
            // 
            this.lblSoHoaDon.AutoSize = true;
            this.lblSoHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblSoHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblSoHoaDon.Location = new System.Drawing.Point(620, 65);
            this.lblSoHoaDon.Name = "lblSoHoaDon";
            this.lblSoHoaDon.Size = new System.Drawing.Size(21, 24);
            this.lblSoHoaDon.TabIndex = 5;
            this.lblSoHoaDon.Text = "0";
            // 
            // lblDichVu
            // 
            this.lblDichVu.AutoSize = true;
            this.lblDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblDichVu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblDichVu.Location = new System.Drawing.Point(340, 65);
            this.lblDichVu.Name = "lblDichVu";
            this.lblDichVu.Size = new System.Drawing.Size(21, 24);
            this.lblDichVu.TabIndex = 4;
            this.lblDichVu.Text = "0";
            // 
            // lblSanPham
            // 
            this.lblSanPham.AutoSize = true;
            this.lblSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblSanPham.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblSanPham.Location = new System.Drawing.Point(60, 65);
            this.lblSanPham.Name = "lblSanPham";
            this.lblSanPham.Size = new System.Drawing.Size(21, 24);
            this.lblSanPham.TabIndex = 3;
            this.lblSanPham.Text = "0";
            // 
            // lblTitleSoHD
            // 
            this.lblTitleSoHD.AutoSize = true;
            this.lblTitleSoHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTitleSoHD.Location = new System.Drawing.Point(600, 35);
            this.lblTitleSoHD.Name = "lblTitleSoHD";
            this.lblTitleSoHD.Size = new System.Drawing.Size(97, 20);
            this.lblTitleSoHD.TabIndex = 2;
            this.lblTitleSoHD.Text = "Số hóa đơn";
            // 
            // lblTitleDV
            // 
            this.lblTitleDV.AutoSize = true;
            this.lblTitleDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTitleDV.Location = new System.Drawing.Point(340, 35);
            this.lblTitleDV.Name = "lblTitleDV";
            this.lblTitleDV.Size = new System.Drawing.Size(58, 20);
            this.lblTitleDV.TabIndex = 1;
            this.lblTitleDV.Text = "Dịch vụ";
            // 
            // lblTitleSP
            // 
            this.lblTitleSP.AutoSize = true;
            this.lblTitleSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTitleSP.Location = new System.Drawing.Point(60, 35);
            this.lblTitleSP.Name = "lblTitleSP";
            this.lblTitleSP.Size = new System.Drawing.Size(67, 20);
            this.lblTitleSP.TabIndex = 0;
            this.lblTitleSP.Text = "Sản phẩm";
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 680);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThongKe";
            this.Text = "Thống kê";
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.panelThongKe.ResumeLayout(false);
            this.panelThongKe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnXemChiTiet;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDen;
        private System.Windows.Forms.Label lblTu;
        private System.Windows.Forms.Panel panelThongKe;
        private System.Windows.Forms.Label lblSoHoaDon;
        private System.Windows.Forms.Label lblDichVu;
        private System.Windows.Forms.Label lblSanPham;
        private System.Windows.Forms.Label lblTitleSoHD;
        private System.Windows.Forms.Label lblTitleDV;
        private System.Windows.Forms.Label lblTitleSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNgayLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn clKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTongTien;
        private System.Windows.Forms.Button btnXemTatCa;
        private System.Windows.Forms.Label lblKhoangNgay;
    }
}