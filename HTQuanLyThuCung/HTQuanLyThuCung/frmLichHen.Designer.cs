using System.Windows.Forms;

namespace HTQuanLyThuCung
{
    partial class frmLichHen
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.pnlTong = new System.Windows.Forms.Panel();
            this.lblTitleTong = new System.Windows.Forms.Label();
            this.lblTong = new System.Windows.Forms.Label();
            this.pnlCho = new System.Windows.Forms.Panel();
            this.lblTitleCho = new System.Windows.Forms.Label();
            this.lblCho = new System.Windows.Forms.Label();
            this.pnlHoanThanh = new System.Windows.Forms.Panel();
            this.lblTitleHT = new System.Windows.Forms.Label();
            this.lblHoanThanh = new System.Windows.Forms.Label();
            this.pnlHuy = new System.Windows.Forms.Panel();
            this.lblTitleHuy = new System.Windows.Forms.Label();
            this.lblHuy = new System.Windows.Forms.Label();
            this.dgvLichHen = new System.Windows.Forms.DataGridView();
            this.colPet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colService = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.menuTacVu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pnlTong.SuspendLayout();
            this.pnlCho.SuspendLayout();
            this.pnlHoanThanh.SuspendLayout();
            this.pnlHuy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichHen)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(378, 46);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "📅 Lịch Hẹn Chăm Sóc";
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.LightCoral;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.Transparent;
            this.btnThem.Location = new System.Drawing.Point(822, 27);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(178, 45);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "➕ Thêm lịch hẹn";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // pnlTong
            // 
            this.pnlTong.BackColor = System.Drawing.Color.White;
            this.pnlTong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTong.Controls.Add(this.lblTitleTong);
            this.pnlTong.Controls.Add(this.lblTong);
            this.pnlTong.Location = new System.Drawing.Point(25, 100);
            this.pnlTong.Name = "pnlTong";
            this.pnlTong.Size = new System.Drawing.Size(220, 90);
            this.pnlTong.TabIndex = 3;
            this.pnlTong.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTong_Paint_1);
            // 
            // lblTitleTong
            // 
            this.lblTitleTong.AutoSize = true;
            this.lblTitleTong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTitleTong.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitleTong.Location = new System.Drawing.Point(15, 12);
            this.lblTitleTong.Name = "lblTitleTong";
            this.lblTitleTong.Size = new System.Drawing.Size(109, 20);
            this.lblTitleTong.TabIndex = 0;
            this.lblTitleTong.Text = "Tổng lịch hẹn";
            // 
            // lblTong
            // 
            this.lblTong.AutoSize = true;
            this.lblTong.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTong.Location = new System.Drawing.Point(10, 35);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(64, 50);
            this.lblTong.TabIndex = 1;
            this.lblTong.Text = "04";
            // 
            // pnlCho
            // 
            this.pnlCho.BackColor = System.Drawing.Color.White;
            this.pnlCho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCho.Controls.Add(this.lblTitleCho);
            this.pnlCho.Controls.Add(this.lblCho);
            this.pnlCho.Location = new System.Drawing.Point(270, 100);
            this.pnlCho.Name = "pnlCho";
            this.pnlCho.Size = new System.Drawing.Size(220, 90);
            this.pnlCho.TabIndex = 4;
            this.pnlCho.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCho_Paint);
            // 
            // lblTitleCho
            // 
            this.lblTitleCho.AutoSize = true;
            this.lblTitleCho.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTitleCho.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitleCho.Location = new System.Drawing.Point(15, 12);
            this.lblTitleCho.Name = "lblTitleCho";
            this.lblTitleCho.Size = new System.Drawing.Size(80, 20);
            this.lblTitleCho.TabIndex = 0;
            this.lblTitleCho.Text = "Đang chờ";
            // 
            // lblCho
            // 
            this.lblCho.AutoSize = true;
            this.lblCho.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.lblCho.Location = new System.Drawing.Point(10, 35);
            this.lblCho.Name = "lblCho";
            this.lblCho.Size = new System.Drawing.Size(64, 50);
            this.lblCho.TabIndex = 1;
            this.lblCho.Text = "03";
            // 
            // pnlHoanThanh
            // 
            this.pnlHoanThanh.BackColor = System.Drawing.Color.White;
            this.pnlHoanThanh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHoanThanh.Controls.Add(this.lblTitleHT);
            this.pnlHoanThanh.Controls.Add(this.lblHoanThanh);
            this.pnlHoanThanh.Location = new System.Drawing.Point(515, 100);
            this.pnlHoanThanh.Name = "pnlHoanThanh";
            this.pnlHoanThanh.Size = new System.Drawing.Size(220, 90);
            this.pnlHoanThanh.TabIndex = 5;
            this.pnlHoanThanh.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHoanThanh_Paint);
            // 
            // lblTitleHT
            // 
            this.lblTitleHT.AutoSize = true;
            this.lblTitleHT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTitleHT.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitleHT.Location = new System.Drawing.Point(15, 12);
            this.lblTitleHT.Name = "lblTitleHT";
            this.lblTitleHT.Size = new System.Drawing.Size(95, 20);
            this.lblTitleHT.TabIndex = 0;
            this.lblTitleHT.Text = "Hoàn thành";
            // 
            // lblHoanThanh
            // 
            this.lblHoanThanh.AutoSize = true;
            this.lblHoanThanh.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblHoanThanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblHoanThanh.Location = new System.Drawing.Point(10, 35);
            this.lblHoanThanh.Name = "lblHoanThanh";
            this.lblHoanThanh.Size = new System.Drawing.Size(64, 50);
            this.lblHoanThanh.TabIndex = 1;
            this.lblHoanThanh.Text = "01";
            // 
            // pnlHuy
            // 
            this.pnlHuy.BackColor = System.Drawing.Color.White;
            this.pnlHuy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHuy.Controls.Add(this.lblTitleHuy);
            this.pnlHuy.Controls.Add(this.lblHuy);
            this.pnlHuy.Location = new System.Drawing.Point(760, 100);
            this.pnlHuy.Name = "pnlHuy";
            this.pnlHuy.Size = new System.Drawing.Size(220, 90);
            this.pnlHuy.TabIndex = 6;
            this.pnlHuy.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHuy_Paint);
            // 
            // lblTitleHuy
            // 
            this.lblTitleHuy.AutoSize = true;
            this.lblTitleHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTitleHuy.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitleHuy.Location = new System.Drawing.Point(15, 12);
            this.lblTitleHuy.Name = "lblTitleHuy";
            this.lblTitleHuy.Size = new System.Drawing.Size(61, 20);
            this.lblTitleHuy.TabIndex = 0;
            this.lblTitleHuy.Text = "Đã hủy";
            // 
            // lblHuy
            // 
            this.lblHuy.AutoSize = true;
            this.lblHuy.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblHuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblHuy.Location = new System.Drawing.Point(10, 35);
            this.lblHuy.Name = "lblHuy";
            this.lblHuy.Size = new System.Drawing.Size(64, 50);
            this.lblHuy.TabIndex = 1;
            this.lblHuy.Text = "00";
            // 
            // dgvLichHen
            // 
            this.dgvLichHen.AllowUserToAddRows = false;
            this.dgvLichHen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichHen.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.dgvLichHen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvLichHen.ColumnHeadersHeight = 45;
            this.dgvLichHen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPet,
            this.colCustomer,
            this.colService,
            this.colTime,
            this.colStatus,
            this.colAction});
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLichHen.DefaultCellStyle = dataGridViewCellStyle24;
            this.dgvLichHen.EnableHeadersVisualStyles = false;
            this.dgvLichHen.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.dgvLichHen.Location = new System.Drawing.Point(25, 220);
            this.dgvLichHen.MultiSelect = false;
            this.dgvLichHen.Name = "dgvLichHen";
            this.dgvLichHen.RowHeadersVisible = false;
            this.dgvLichHen.RowHeadersWidth = 51;
            this.dgvLichHen.RowTemplate.Height = 45;
            this.dgvLichHen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichHen.Size = new System.Drawing.Size(975, 420);
            this.dgvLichHen.TabIndex = 7;
            this.dgvLichHen.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLichHen_CellMouseClick);
            // 
            // colPet
            // 
            this.colPet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPet.FillWeight = 76.39501F;
            this.colPet.HeaderText = "Thú cưng";
            this.colPet.MinimumWidth = 6;
            this.colPet.Name = "colPet";
            // 
            // colCustomer
            // 
            this.colCustomer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCustomer.FillWeight = 135.5439F;
            this.colCustomer.HeaderText = "Khách hàng";
            this.colCustomer.MinimumWidth = 6;
            this.colCustomer.Name = "colCustomer";
            // 
            // colService
            // 
            this.colService.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colService.FillWeight = 144.385F;
            this.colService.HeaderText = "Dịch vụ";
            this.colService.MinimumWidth = 6;
            this.colService.Name = "colService";
            // 
            // colTime
            // 
            this.colTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTime.FillWeight = 107.6453F;
            this.colTime.HeaderText = "Giờ hẹn";
            this.colTime.MinimumWidth = 6;
            this.colTime.Name = "colTime";
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStatus.FillWeight = 71.57243F;
            this.colStatus.HeaderText = "Trạng thái";
            this.colStatus.MinimumWidth = 6;
            this.colStatus.Name = "colStatus";
            // 
            // colAction
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.colAction.DefaultCellStyle = dataGridViewCellStyle23;
            this.colAction.FillWeight = 64.45827F;
            this.colAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colAction.HeaderText = "Thao tác";
            this.colAction.MinimumWidth = 7;
            this.colAction.Name = "colAction";
            this.colAction.Text = "👁";
            this.colAction.UseColumnTextForButtonValue = true;
            // 
            // menuTacVu
            // 
            this.menuTacVu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuTacVu.Name = "menuTacVu";
            this.menuTacVu.Size = new System.Drawing.Size(61, 4);
            // 
            // frmLichHen
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1030, 680);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.pnlTong);
            this.Controls.Add(this.pnlCho);
            this.Controls.Add(this.pnlHoanThanh);
            this.Controls.Add(this.pnlHuy);
            this.Controls.Add(this.dgvLichHen);
            this.Name = "frmLichHen";
            this.Text = "Quản lý lịch hẹn chăm sóc";
            this.pnlTong.ResumeLayout(false);
            this.pnlTong.PerformLayout();
            this.pnlCho.ResumeLayout(false);
            this.pnlCho.PerformLayout();
            this.pnlHoanThanh.ResumeLayout(false);
            this.pnlHoanThanh.PerformLayout();
            this.pnlHuy.ResumeLayout(false);
            this.pnlHuy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichHen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Panel pnlTong, pnlCho, pnlHoanThanh, pnlHuy;
        private System.Windows.Forms.Label lblTong, lblCho, lblHoanThanh, lblHuy;
        private System.Windows.Forms.Label lblTitleTong, lblTitleCho, lblTitleHT, lblTitleHuy;
        private System.Windows.Forms.DataGridView dgvLichHen;
        private System.Windows.Forms.ContextMenuStrip menuTacVu;
        private DataGridViewTextBoxColumn colPet;
        private DataGridViewTextBoxColumn colCustomer;
        private DataGridViewTextBoxColumn colService;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewButtonColumn colAction;
    }
}