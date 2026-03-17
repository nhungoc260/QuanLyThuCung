namespace QuanLyThuCung
{
    partial class frmKhachHang_ChiTiet
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

        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.dgvPurchaseHistory = new System.Windows.Forms.DataGridView();
            this.colInvoiceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPurchaseHistory = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtOtherInfo = new System.Windows.Forms.TextBox();
            this.lblOtherInfo = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseHistory)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.panelMain.Controls.Add(this.dgvPurchaseHistory);
            this.panelMain.Controls.Add(this.lblPurchaseHistory);
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Controls.Add(this.txtOtherInfo);
            this.panelMain.Controls.Add(this.lblOtherInfo);
            this.panelMain.Controls.Add(this.txtEmail);
            this.panelMain.Controls.Add(this.lblEmail);
            this.panelMain.Controls.Add(this.txtAddress);
            this.panelMain.Controls.Add(this.lblAddress);
            this.panelMain.Controls.Add(this.txtPhone);
            this.panelMain.Controls.Add(this.lblPhone);
            this.panelMain.Controls.Add(this.txtName);
            this.panelMain.Controls.Add(this.lblName);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(35, 30, 35, 30);
            this.panelMain.Size = new System.Drawing.Size(950, 650);
            this.panelMain.TabIndex = 0;
            // 
            // dgvPurchaseHistory
            // 
            this.dgvPurchaseHistory.AllowUserToAddRows = false;
            this.dgvPurchaseHistory.AllowUserToDeleteRows = false;
            this.dgvPurchaseHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvPurchaseHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPurchaseHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInvoiceId,
            this.colDate,
            this.colTotal,
            this.colEmployee});
            this.dgvPurchaseHistory.EnableHeadersVisualStyles = false;
            this.dgvPurchaseHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.dgvPurchaseHistory.Location = new System.Drawing.Point(35, 450);
            this.dgvPurchaseHistory.Name = "dgvPurchaseHistory";
            this.dgvPurchaseHistory.ReadOnly = true;
            this.dgvPurchaseHistory.RowHeadersVisible = false;
            this.dgvPurchaseHistory.RowTemplate.Height = 38;
            this.dgvPurchaseHistory.Size = new System.Drawing.Size(880, 170);
            this.dgvPurchaseHistory.TabIndex = 16;
            // 
            // colInvoiceId
            // 
            this.colInvoiceId.HeaderText = "Mã HD";
            this.colInvoiceId.Name = "colInvoiceId";
            this.colInvoiceId.ReadOnly = true;
            this.colInvoiceId.Width = 130;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Ngày lập";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 280;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Tổng tiền";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 200;
            // 
            // colEmployee
            // 
            this.colEmployee.HeaderText = "Nhân viên";
            this.colEmployee.Name = "colEmployee";
            this.colEmployee.ReadOnly = true;
            this.colEmployee.Width = 240;
            // 
            // lblPurchaseHistory
            // 
            this.lblPurchaseHistory.AutoSize = true;
            this.lblPurchaseHistory.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPurchaseHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.lblPurchaseHistory.Location = new System.Drawing.Point(32, 415);
            this.lblPurchaseHistory.Name = "lblPurchaseHistory";
            this.lblPurchaseHistory.Size = new System.Drawing.Size(198, 25);
            this.lblPurchaseHistory.TabIndex = 15;
            this.lblPurchaseHistory.Text = "Lịch sử mua hàng";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnEdit);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Location = new System.Drawing.Point(505, 360);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(410, 45);
            this.panelButtons.TabIndex = 14;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(160)))), ((int)(((byte)(71)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(295, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(110, 38);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(165, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 38);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtOtherInfo
            // 
            this.txtOtherInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtOtherInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOtherInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtOtherInfo.Location = new System.Drawing.Point(35, 365);
            this.txtOtherInfo.Multiline = true;
            this.txtOtherInfo.Name = "txtOtherInfo";
            this.txtOtherInfo.ReadOnly = true;
            this.txtOtherInfo.Size = new System.Drawing.Size(450, 38);
            this.txtOtherInfo.TabIndex = 9;
            // 
            // lblOtherInfo
            // 
            this.lblOtherInfo.AutoSize = true;
            this.lblOtherInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblOtherInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblOtherInfo.Location = new System.Drawing.Point(32, 342);
            this.lblOtherInfo.Name = "lblOtherInfo";
            this.lblOtherInfo.Size = new System.Drawing.Size(106, 17);
            this.lblOtherInfo.TabIndex = 8;
            this.lblOtherInfo.Text = "Thông tin thêm";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(495, 270);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(420, 38);
            this.txtEmail.TabIndex = 7;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblEmail.Location = new System.Drawing.Point(492, 247);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 17);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddress.Location = new System.Drawing.Point(35, 270);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(420, 38);
            this.txtAddress.TabIndex = 5;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblAddress.Location = new System.Drawing.Point(32, 247);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(56, 17);
            this.lblAddress.TabIndex = 4;
            this.lblAddress.Text = "Địa chỉ";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhone.Location = new System.Drawing.Point(495, 175);
            this.txtPhone.Multiline = true;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(420, 38);
            this.txtPhone.TabIndex = 3;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblPhone.Location = new System.Drawing.Point(492, 152);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(95, 17);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Số điện thoại";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtName.Location = new System.Drawing.Point(35, 175);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(420, 38);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblName.Location = new System.Drawing.Point(32, 152);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Tên";
            // 
            // frmKhachHang_ChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 650);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmKhachHang_ChiTiet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin khách hàng";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseHistory)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView dgvPurchaseHistory;
        private System.Windows.Forms.Label lblPurchaseHistory;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtOtherInfo;
        private System.Windows.Forms.Label lblOtherInfo;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployee;
    }
}