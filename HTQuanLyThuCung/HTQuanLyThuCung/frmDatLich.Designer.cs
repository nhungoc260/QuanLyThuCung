namespace HTQuanLyThuCung
{
    partial class frmDatLich
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTenKH, lblThuCung, lblDichVu, lblNgay;

        private System.Windows.Forms.TextBox txtTenKH, txtThuCung;
        private System.Windows.Forms.ComboBox cboDichVu;
        private System.Windows.Forms.DateTimePicker dtpNgay;

        private System.Windows.Forms.Button btnLuu, btnHuy;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.lblThuCung = new System.Windows.Forms.Label();
            this.lblDichVu = new System.Windows.Forms.Label();
            this.lblNgay = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtThuCung = new System.Windows.Forms.TextBox();
            this.cboDichVu = new System.Windows.Forms.ComboBox();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(104, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(260, 42);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📅 Đặt lịch hẹn";
            // 
            // lblTenKH
            // 
            this.lblTenKH.Location = new System.Drawing.Point(30, 80);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(100, 23);
            this.lblTenKH.TabIndex = 1;
            this.lblTenKH.Text = "Tên khách hàng:";
            // 
            // lblThuCung
            // 
            this.lblThuCung.Location = new System.Drawing.Point(30, 120);
            this.lblThuCung.Name = "lblThuCung";
            this.lblThuCung.Size = new System.Drawing.Size(100, 23);
            this.lblThuCung.TabIndex = 2;
            this.lblThuCung.Text = "Tên thú cưng:";
            // 
            // lblDichVu
            // 
            this.lblDichVu.Location = new System.Drawing.Point(30, 160);
            this.lblDichVu.Name = "lblDichVu";
            this.lblDichVu.Size = new System.Drawing.Size(100, 23);
            this.lblDichVu.TabIndex = 3;
            this.lblDichVu.Text = "Dịch vụ:";
            // 
            // lblNgay
            // 
            this.lblNgay.Location = new System.Drawing.Point(30, 200);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(100, 23);
            this.lblNgay.TabIndex = 4;
            this.lblNgay.Text = "Ngày giờ:";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(160, 80);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(232, 22);
            this.txtTenKH.TabIndex = 5;
            // 
            // txtThuCung
            // 
            this.txtThuCung.Location = new System.Drawing.Point(160, 120);
            this.txtThuCung.Name = "txtThuCung";
            this.txtThuCung.Size = new System.Drawing.Size(232, 22);
            this.txtThuCung.TabIndex = 6;
            // 
            // cboDichVu
            // 
            this.cboDichVu.Location = new System.Drawing.Point(160, 160);
            this.cboDichVu.Name = "cboDichVu";
            this.cboDichVu.Size = new System.Drawing.Size(232, 24);
            this.cboDichVu.TabIndex = 7;
            // 
            // dtpNgay
            // 
            this.dtpNgay.Location = new System.Drawing.Point(160, 200);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(232, 22);
            this.dtpNgay.TabIndex = 8;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.Green;
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(100, 280);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 40);
            this.btnLuu.TabIndex = 9;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.Gray;
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(230, 280);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 40);
            this.btnHuy.TabIndex = 10;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // frmDatLich
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 400);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTenKH);
            this.Controls.Add(this.lblThuCung);
            this.Controls.Add(this.lblDichVu);
            this.Controls.Add(this.lblNgay);
            this.Controls.Add(this.txtTenKH);
            this.Controls.Add(this.txtThuCung);
            this.Controls.Add(this.cboDichVu);
            this.Controls.Add(this.dtpNgay);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Name = "frmDatLich";
            this.Text = "Đặt lịch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}