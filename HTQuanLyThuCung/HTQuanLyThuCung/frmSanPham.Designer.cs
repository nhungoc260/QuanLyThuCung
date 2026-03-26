using System;

namespace HTQuanLyThuCung
{
    partial class frmSanPham
    {
        
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbTrangThai = new System.Windows.Forms.TextBox();
            this.labTrangThai = new System.Windows.Forms.Label();
            this.labGiaXuat = new System.Windows.Forms.Label();
            this.labGiaNhap = new System.Windows.Forms.Label();
            this.labSoluong = new System.Windows.Forms.Label();
            this.labName = new System.Windows.Forms.Label();
            this.tbGiaXuat = new System.Windows.Forms.TextBox();
            this.cbTen = new System.Windows.Forms.ComboBox();
            this.tbGiaNhap = new System.Windows.Forms.TextBox();
            this.tbSoLuong = new System.Windows.Forms.TextBox();
            this.btSua = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.btNhapHang = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbTrangThai);
            this.panel1.Controls.Add(this.labTrangThai);
            this.panel1.Controls.Add(this.labGiaXuat);
            this.panel1.Controls.Add(this.labGiaNhap);
            this.panel1.Controls.Add(this.labSoluong);
            this.panel1.Controls.Add(this.labName);
            this.panel1.Controls.Add(this.tbGiaXuat);
            this.panel1.Controls.Add(this.cbTen);
            this.panel1.Controls.Add(this.tbGiaNhap);
            this.panel1.Controls.Add(this.tbSoLuong);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1498, 201);
            this.panel1.TabIndex = 0;
            // 
            // tbTrangThai
            // 
            this.tbTrangThai.Location = new System.Drawing.Point(1143, 127);
            this.tbTrangThai.Name = "tbTrangThai";
            this.tbTrangThai.Size = new System.Drawing.Size(222, 22);
            this.tbTrangThai.TabIndex = 6;
            // 
            // labTrangThai
            // 
            this.labTrangThai.AutoSize = true;
            this.labTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labTrangThai.Location = new System.Drawing.Point(1136, 55);
            this.labTrangThai.Name = "labTrangThai";
            this.labTrangThai.Size = new System.Drawing.Size(207, 42);
            this.labTrangThai.TabIndex = 5;
            this.labTrangThai.Text = "Trạng thái ";
            // 
            // labGiaXuat
            // 
            this.labGiaXuat.AutoSize = true;
            this.labGiaXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labGiaXuat.Location = new System.Drawing.Point(860, 55);
            this.labGiaXuat.Name = "labGiaXuat";
            this.labGiaXuat.Size = new System.Drawing.Size(165, 42);
            this.labGiaXuat.TabIndex = 3;
            this.labGiaXuat.Text = "Giá xuất";
            // 
            // labGiaNhap
            // 
            this.labGiaNhap.AutoSize = true;
            this.labGiaNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labGiaNhap.Location = new System.Drawing.Point(609, 64);
            this.labGiaNhap.Name = "labGiaNhap";
            this.labGiaNhap.Size = new System.Drawing.Size(178, 42);
            this.labGiaNhap.TabIndex = 2;
            this.labGiaNhap.Text = "Giá nhập";
            // 
            // labSoluong
            // 
            this.labSoluong.AutoSize = true;
            this.labSoluong.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labSoluong.Location = new System.Drawing.Point(320, 64);
            this.labSoluong.Name = "labSoluong";
            this.labSoluong.Size = new System.Drawing.Size(185, 42);
            this.labSoluong.TabIndex = 1;
            this.labSoluong.Text = " Số lượng";
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labName.Location = new System.Drawing.Point(28, 64);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(279, 42);
            this.labName.TabIndex = 0;
            this.labName.Text = "Tên Sản Phẩm";
            // 
            // tbGiaXuat
            // 
            this.tbGiaXuat.Location = new System.Drawing.Point(849, 125);
            this.tbGiaXuat.Name = "tbGiaXuat";
            this.tbGiaXuat.Size = new System.Drawing.Size(222, 22);
            this.tbGiaXuat.TabIndex = 4;
            // 
            // cbTen
            // 
            this.cbTen.FormattingEnabled = true;
            this.cbTen.Location = new System.Drawing.Point(35, 125);
            this.cbTen.Name = "cbTen";
            this.cbTen.Size = new System.Drawing.Size(258, 24);
            this.cbTen.TabIndex = 1;
            this.cbTen.SelectedIndexChanged += new System.EventHandler(this.cbTen_SelectedIndexChanged);
            
            // 
            // tbGiaNhap
            // 
            this.tbGiaNhap.Location = new System.Drawing.Point(607, 127);
            this.tbGiaNhap.Name = "tbGiaNhap";
            this.tbGiaNhap.Size = new System.Drawing.Size(221, 22);
            this.tbGiaNhap.TabIndex = 3;
            // 
            // tbSoLuong
            // 
            this.tbSoLuong.Location = new System.Drawing.Point(327, 127);
            this.tbSoLuong.Name = "tbSoLuong";
            this.tbSoLuong.Size = new System.Drawing.Size(221, 22);
            this.tbSoLuong.TabIndex = 2;
            this.tbSoLuong.TextChanged += new System.EventHandler(this.tbSoLuong_TextChanged);
            // 
            // btSua
            // 
            this.btSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btSua.Location = new System.Drawing.Point(36, 245);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(271, 90);
            this.btSua.TabIndex = 6;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = true;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btXoa
            // 
            this.btXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btXoa.Location = new System.Drawing.Point(340, 245);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(271, 90);
            this.btXoa.TabIndex = 7;
            this.btXoa.Text = "Xóa ";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btNhapHang
            // 
            this.btNhapHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btNhapHang.Location = new System.Drawing.Point(1017, 245);
            this.btNhapHang.Name = "btNhapHang";
            this.btNhapHang.Size = new System.Drawing.Size(348, 90);
            this.btNhapHang.TabIndex = 9;
            this.btNhapHang.Text = "NHẬP HÀNG";
            this.btNhapHang.UseVisualStyleBackColor = true;
            this.btNhapHang.Click += new System.EventHandler(this.btNhapHang_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 358);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1353, 446);
            this.dataGridView.TabIndex = 10;
           // this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            // 
            // frmSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1498, 847);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btNhapHang);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btSua);
            this.Controls.Add(this.panel1);
            this.Name = "frmSanPham";
            this.Text = "frmSanPham";
            this.Load += new System.EventHandler(this.frmSanPham_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labGiaXuat;
        private System.Windows.Forms.Label labGiaNhap;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.ComboBox cbTen;
        private System.Windows.Forms.TextBox tbSoLuong;
        private System.Windows.Forms.TextBox tbGiaNhap;
        private System.Windows.Forms.TextBox tbGiaXuat;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btXoa;
       // private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btNhapHang;
        private System.Windows.Forms.TextBox tbTrangThai;
        private System.Windows.Forms.Label labTrangThai;
        private System.Windows.Forms.Label labSoluong;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}