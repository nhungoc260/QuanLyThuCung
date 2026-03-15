namespace HTQuanLyThuCung
{
    partial class frmDangNhap
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.CheckBox chkGhiNho;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.LinkLabel linkDangKy;
        private System.Windows.Forms.LinkLabel linkQuenMK;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.lblTaiKhoan = new System.Windows.Forms.Label();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.chkGhiNho = new System.Windows.Forms.CheckBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.linkDangKy = new System.Windows.Forms.LinkLabel();
            this.linkQuenMK = new System.Windows.Forms.LinkLabel();

            this.SuspendLayout();

            // TITLE
            labelTitle.AutoSize = true;
            labelTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            labelTitle.Location = new System.Drawing.Point(120, 20);
            labelTitle.Text = "Z618 STORE LOGIN";

            // USER
            lblTaiKhoan.AutoSize = true;
            lblTaiKhoan.Location = new System.Drawing.Point(60, 90);
            lblTaiKhoan.Text = "Tài khoản";

            txtTaiKhoan.Location = new System.Drawing.Point(60, 110);
            txtTaiKhoan.Size = new System.Drawing.Size(280, 22);
            txtTaiKhoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTaiKhoan_KeyDown);

            // PASS
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new System.Drawing.Point(60, 150);
            lblMatKhau.Text = "Mật khẩu";

            txtMatKhau.Location = new System.Drawing.Point(60, 170);
            txtMatKhau.Size = new System.Drawing.Size(280, 22);
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatKhau_KeyDown);

            // CHECK
            chkGhiNho.AutoSize = true;
            chkGhiNho.Location = new System.Drawing.Point(60, 210);
            chkGhiNho.Text = "Ghi nhớ đăng nhập";

            // BUTTON
            btnDangNhap.Location = new System.Drawing.Point(60, 240);
            btnDangNhap.Size = new System.Drawing.Size(280, 35);
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);

            // LINK REGISTER
            linkDangKy.AutoSize = true;
            linkDangKy.Location = new System.Drawing.Point(230, 290);
            linkDangKy.Text = "Đăng ký";
            linkDangKy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDangKy_LinkClicked);

            // LINK FORGOT
            linkQuenMK.AutoSize = true;
            linkQuenMK.Location = new System.Drawing.Point(60, 290);
            linkQuenMK.Text = "Quên mật khẩu";
            linkQuenMK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkQuenMK_LinkClicked);

            // FORM
            this.ClientSize = new System.Drawing.Size(400, 330);

            this.Controls.Add(labelTitle);
            this.Controls.Add(lblTaiKhoan);
            this.Controls.Add(txtTaiKhoan);
            this.Controls.Add(lblMatKhau);
            this.Controls.Add(txtMatKhau);
            this.Controls.Add(chkGhiNho);
            this.Controls.Add(btnDangNhap);
            this.Controls.Add(linkDangKy);
            this.Controls.Add(linkQuenMK);

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập - Quản lý thú cưng";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}