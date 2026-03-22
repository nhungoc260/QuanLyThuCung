namespace HTQuanLyThuCung
{
    partial class frmDichVu
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
            this.pnlDichVu = new System.Windows.Forms.Panel();
            this.pnl7 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvDichVu = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.txtTenDichVu = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtChiTiet = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGiaTien = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDanhGia = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLichHen = new System.Windows.Forms.Button();
            this.pnlDichVu.SuspendLayout();
            this.pnl7.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDichVu
            // 
            this.pnlDichVu.Controls.Add(this.pnl7);
            this.pnlDichVu.Controls.Add(this.panel1);
            this.pnlDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDichVu.Location = new System.Drawing.Point(0, 0);
            this.pnlDichVu.Name = "pnlDichVu";
            this.pnlDichVu.Size = new System.Drawing.Size(1142, 655);
            this.pnlDichVu.TabIndex = 0;
            // 
            // pnl7
            // 
            this.pnl7.Controls.Add(this.panel3);
            this.pnl7.Controls.Add(this.panel2);
            this.pnl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl7.Location = new System.Drawing.Point(0, 64);
            this.pnl7.Name = "pnl7";
            this.pnl7.Size = new System.Drawing.Size(1142, 591);
            this.pnl7.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvDichVu);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 164);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1142, 427);
            this.panel3.TabIndex = 2;
            // 
            // dgvDichVu
            // 
            this.dgvDichVu.AllowUserToAddRows = false;
            this.dgvDichVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDichVu.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDichVu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDichVu.Location = new System.Drawing.Point(0, 0);
            this.dgvDichVu.Name = "dgvDichVu";
            this.dgvDichVu.RowHeadersVisible = false;
            this.dgvDichVu.RowHeadersWidth = 51;
            this.dgvDichVu.RowTemplate.Height = 24;
            this.dgvDichVu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDichVu.Size = new System.Drawing.Size(1142, 427);
            this.dgvDichVu.TabIndex = 0;
            this.dgvDichVu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDichVu_CellClick);
//            this.dgvDichVu.SelectionChanged += new System.EventHandler(this.dgvDichVu_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.FillWeight = 40.65134F;
            this.Column1.HeaderText = "#";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ServiceName";
            this.Column2.FillWeight = 128.3422F;
            this.Column2.HeaderText = "Tên dịch vụ";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Price";
            this.Column3.FillWeight = 84.46545F;
            this.Column3.HeaderText = "Giá tiền";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Description";
            this.Column4.FillWeight = 146.541F;
            this.Column4.HeaderText = "Chi tiết dịch vụ";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnSua);
            this.panel2.Controls.Add(this.txtTenDichVu);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtChiTiet);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtGiaTien);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1142, 164);
            this.panel2.TabIndex = 1;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.Info;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXoa.Location = new System.Drawing.Point(353, 104);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(131, 43);
            this.btnXoa.TabIndex = 35;
            this.btnXoa.Text = "🗑️ Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.MistyRose;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSua.Location = new System.Drawing.Point(190, 104);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(131, 43);
            this.btnSua.TabIndex = 34;
            this.btnSua.Text = "✏️ Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // txtTenDichVu
            // 
            this.txtTenDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenDichVu.Location = new System.Drawing.Point(19, 51);
            this.txtTenDichVu.Name = "txtTenDichVu";
            this.txtTenDichVu.Size = new System.Drawing.Size(318, 30);
            this.txtTenDichVu.TabIndex = 28;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThem.Location = new System.Drawing.Point(19, 104);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(146, 43);
            this.btnThem.TabIndex = 33;
            this.btnThem.Text = "➕ Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(14, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 25);
            this.label5.TabIndex = 27;
            this.label5.Text = "Tên dịch vụ";
            // 
            // txtChiTiet
            // 
            this.txtChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtChiTiet.Location = new System.Drawing.Point(671, 51);
            this.txtChiTiet.Name = "txtChiTiet";
            this.txtChiTiet.Size = new System.Drawing.Size(445, 30);
            this.txtChiTiet.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(666, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 25);
            this.label6.TabIndex = 31;
            this.label6.Text = "Chi tiết";
            // 
            // txtGiaTien
            // 
            this.txtGiaTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtGiaTien.Location = new System.Drawing.Point(411, 51);
            this.txtGiaTien.Name = "txtGiaTien";
            this.txtGiaTien.Size = new System.Drawing.Size(184, 30);
            this.txtGiaTien.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(406, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 25);
            this.label7.TabIndex = 29;
            this.label7.Text = "Giá tiền";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnDanhGia);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnLichHen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1142, 64);
            this.panel1.TabIndex = 2;
            // 
            // btnDanhGia
            // 
            this.btnDanhGia.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDanhGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDanhGia.Location = new System.Drawing.Point(155, 7);
            this.btnDanhGia.Name = "btnDanhGia";
            this.btnDanhGia.Size = new System.Drawing.Size(66, 50);
            this.btnDanhGia.TabIndex = 35;
            this.btnDanhGia.Text = "⭐";
            this.btnDanhGia.UseVisualStyleBackColor = false;
            this.btnDanhGia.Click += new System.EventHandler(this.btnDanhGia_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.Location = new System.Drawing.Point(11, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 50);
            this.button1.TabIndex = 34;
            this.button1.Text = "🗂";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnLichHen
            // 
            this.btnLichHen.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnLichHen.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLichHen.Location = new System.Drawing.Point(83, 7);
            this.btnLichHen.Name = "btnLichHen";
            this.btnLichHen.Size = new System.Drawing.Size(66, 50);
            this.btnLichHen.TabIndex = 36;
            this.btnLichHen.Text = "📅";
            this.btnLichHen.UseVisualStyleBackColor = false;
            this.btnLichHen.Click += new System.EventHandler(this.btnLichHen_Click);
            // 
            // frmDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 655);
            this.Controls.Add(this.pnlDichVu);
            this.Name = "frmDichVu";
            this.Text = "Quản Lý Các Dịch Vụ";
            this.Load += new System.EventHandler(this.frmDichVu_Load);
            this.pnlDichVu.ResumeLayout(false);
            this.pnl7.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDichVu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.TextBox txtTenDichVu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtChiTiet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGiaTien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnl7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvDichVu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLichHen;
        private System.Windows.Forms.Button btnDanhGia;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}