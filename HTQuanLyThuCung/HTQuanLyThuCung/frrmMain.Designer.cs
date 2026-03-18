using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HTQuanLyThuCung
{
    partial class frmMain
    {
        private Panel panelMenu;
        private Panel panelTop;
        private Panel panelMain;
        private Panel panelDashboard;

        private Label lblTitle;
        private Label lblLogo;

        private Label lblPets;
        private Label lblCustomers;
        private Label lblServices;
        private Label lblAppointments;

        private Label lblChartTitle;
        private Label lblTableTitle;

        private Chart chartStats;
        private DataGridView dgvAppointments;

        private Button btnTrangChu;
        private Button btnKhachHang;
        private Button btnBanHang;
        private Button btnThongKe;
        private Button btnHangHoa;
        private Button btnDichVu;
        private Button btnNhanVien;
        private Button btnDangXuat;

        private void InitializeComponent()
        {
            panelMenu = new Panel();
            panelTop = new Panel();
            panelMain = new Panel();
            panelDashboard = new Panel();

            lblTitle = new Label();
            lblLogo = new Label();

            chartStats = new Chart();
            dgvAppointments = new DataGridView();

            lblChartTitle = new Label();
            lblTableTitle = new Label();

            btnTrangChu = new Button();
            btnKhachHang = new Button();
            btnBanHang = new Button();
            btnThongKe = new Button();
            btnHangHoa = new Button();
            btnDichVu = new Button();
            btnNhanVien = new Button();
            btnDangXuat = new Button();

            SuspendLayout();

            WindowState = FormWindowState.Maximized;
            Text = "Hệ thống quản lý thú cưng";

            panelMenu.Dock = DockStyle.Left;
            panelMenu.Width = 200;
            panelMenu.BackColor = Color.FromArgb(200, 90, 80);

            lblLogo = new Label();
            lblLogo.Text = "🐾 Z618";
            lblLogo.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;

            lblLogo.AutoSize = false;
            lblLogo.Width = 200;
            lblLogo.Height = 70;

            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            lblLogo.Location = new Point(0, 20);

            panelMenu.Controls.Add(lblLogo);

            int top = 130;

            CreateButton(btnTrangChu, "🏠 Trang chủ", top, btnTrangChu_Click);
            CreateButton(btnKhachHang, "👤 Khách hàng", top += 60, btnKhachHang_Click);
            CreateButton(btnBanHang, "💳 Bán hàng", top += 60, btnBanHang_Click);
            CreateButton(btnThongKe, "📊 Thống kê", top += 60, btnThongKe_Click);
            CreateButton(btnHangHoa, "📦 Hàng hóa", top += 60, btnHangHoa_Click);
            CreateButton(btnDichVu, "❤️ Dịch vụ", top += 60, btnDichVu_Click);
            CreateButton(btnNhanVien, "👨‍💼 Nhân viên", top += 60, btnNhanVien_Click);
            CreateButton(btnDangXuat, "🔌 Đăng xuất", top += 70, btnDangXuat_Click);

            panelMenu.Controls.AddRange(new Control[]
            {
                btnTrangChu,btnKhachHang,btnBanHang,
                btnThongKe,btnHangHoa,btnDichVu,
                btnNhanVien,btnDangXuat
            });

            // TOP BAR
            panelTop.Dock = DockStyle.Top;
            panelTop.Height = 80;
            panelTop.BackColor = Color.White;

            lblTitle.Text = "Trang chủ";
            lblTitle.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblTitle.Location = new Point(30, 20);
            lblTitle.AutoSize = true;

            panelTop.Controls.Add(lblTitle);

            // MAIN
            panelMain.Dock = DockStyle.Fill;
            panelMain.BackColor = Color.WhiteSmoke;

            // DASHBOARD
            panelDashboard.Dock = DockStyle.Fill;

            lblPets = CreateCard(80);
            lblCustomers = CreateCard(350);
            lblServices = CreateCard(620);
            lblAppointments = CreateCard(890);

            panelDashboard.Controls.Add(lblPets);
            panelDashboard.Controls.Add(lblCustomers);
            panelDashboard.Controls.Add(lblServices);
            panelDashboard.Controls.Add(lblAppointments);

            // CHART TITLE
            lblChartTitle.Text = "📊 Biểu đồ cột hiển thị số liệu";
            lblChartTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblChartTitle.Location = new Point(80, 200);
            lblChartTitle.AutoSize = true;

            panelDashboard.Controls.Add(lblChartTitle);

            // CHART
            chartStats.Location = new Point(80, 240);
            chartStats.Size = new Size(600, 320);

            ChartArea area = new ChartArea();
            chartStats.ChartAreas.Add(area);

            panelDashboard.Controls.Add(chartStats);

            // TABLE TITLE
            lblTableTitle.Text = "📋 Bảng lịch hẹn hôm nay";
            lblTableTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTableTitle.Location = new Point(720, 200);
            lblTableTitle.AutoSize = true;

            panelDashboard.Controls.Add(lblTableTitle);

            // TABLE
            dgvAppointments.Location = new Point(720, 240);
            dgvAppointments.Size = new Size(550, 320);

            panelDashboard.Controls.Add(dgvAppointments);

            panelMain.Controls.Add(panelDashboard);

            Controls.Add(panelMain);
            Controls.Add(panelTop);
            Controls.Add(panelMenu);

            Load += frmMain_Load;

            ResumeLayout(false);
        }

        private void CreateButton(Button btn, string text, int top, EventHandler click)
        {
            btn.Text = text;
            btn.Width = 200;
            btn.Height = 55;
            btn.Top = top;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.BackColor = Color.FromArgb(200, 90, 80);

            btn.Click += click;
        }

        private Label CreateCard(int left)
        { 
            Label lbl = new Label();

            lbl.Width = 220;
            lbl.Height = 110;
            lbl.Left = left;
            lbl.Top = 60;

            lbl.BackColor = Color.White;
            lbl.BorderStyle = BorderStyle.FixedSingle;

            lbl.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lbl.TextAlign = ContentAlignment.MiddleCenter;

            return lbl;
        }
    }
}