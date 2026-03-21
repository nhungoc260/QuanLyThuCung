using HTQuanLyThuCung.DataAccess;
using QuanLyThuCung;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HTQuanLyThuCung
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            lblTitle.Text = "Trang chủ";

            try
            {
                string query = @"
                    SELECT 
                        (SELECT COUNT(*) FROM Pets)         AS TotalPets,
                        (SELECT COUNT(*) FROM Customers)    AS TotalCustomers,
                        (SELECT COUNT(*) FROM Services)     AS TotalServices,
                        (SELECT COUNT(*) FROM Appointments) AS TotalAppointments";

                DataTable stats = DatabaseHelper.ExecuteQuery(query);

                int pets = 0, customers = 0, services = 0, appointments = 0;

                if (stats != null && stats.Rows.Count > 0)
                {
                    DataRow row = stats.Rows[0];
                    pets         = Convert.ToInt32(row["TotalPets"]);
                    customers    = Convert.ToInt32(row["TotalCustomers"]);
                    services     = Convert.ToInt32(row["TotalServices"]);
                    appointments = Convert.ToInt32(row["TotalAppointments"]);
                }

                lblPets.Text         = "🐶 Thú cưng\n"      + pets;
                lblCustomers.Text    = "👤 Khách hàng\n"    + customers;
                lblServices.Text     = "💅 Dịch vụ\n"       + services;
                lblAppointments.Text = "📅 Tổng lịch hẹn\n" + appointments;

                LoadChart(pets, customers, services, appointments);
                LoadAppointments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dashboard: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChart(int pets, int customers, int services, int sales)
        {
            chartStats.Series.Clear();
            chartStats.ChartAreas[0].BackColor     = Color.White;
            chartStats.BackColor                   = Color.White;
            chartStats.BorderlineColor             = Color.LightGray;
            chartStats.BorderlineDashStyle         = ChartDashStyle.Solid;
            chartStats.BorderlineWidth             = 1;

            ChartArea area = chartStats.ChartAreas[0];
            area.AxisX.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);
            area.AxisX.LineColor           = Color.LightGray;
            area.AxisY.LineColor           = Color.LightGray;
            area.AxisX.LabelStyle.Font     = new Font("Segoe UI", 9f);
            area.AxisY.LabelStyle.Font     = new Font("Segoe UI", 9f);
            area.AxisY.Minimum             = 0;

            Series s = new Series("Số liệu");
            s.ChartType           = SeriesChartType.Column;
            s.IsValueShownAsLabel = true;
            s.Font                = new Font("Segoe UI", 9f, FontStyle.Bold);
            s.LabelForeColor      = Color.FromArgb(50, 50, 50);

            s.Points.AddXY("Thú cưng",   pets);
            s.Points[0].Color = Color.FromArgb(52, 152, 219);

            s.Points.AddXY("Khách hàng", customers);
            s.Points[1].Color = Color.FromArgb(46, 204, 113);

            s.Points.AddXY("Dịch vụ",    services);
            s.Points[2].Color = Color.FromArgb(155, 89, 182);

            s.Points.AddXY("Lịch hẹn",   sales);
            s.Points[3].Color = Color.FromArgb(230, 126, 34);

            chartStats.Series.Add(s);
            chartStats.Legends.Clear();
        }

        private void LoadAppointments()
        {
            try
            {
                string query = @"
                    SELECT 
                        p.PetName      AS [Thú cưng],
                        s.ServiceName  AS [Dịch vụ],
                        CONVERT(NVARCHAR, a.AppointmentDate, 103) AS [Thời gian],
                        c.CustomerName AS [Khách hàng]
                    FROM Appointments a
                    INNER JOIN Pets     p ON a.PetId      = p.Id
                    INNER JOIN Services s ON a.ServiceId  = s.Id
                    INNER JOIN Customers c ON p.CustomerId = c.Id
                    WHERE CAST(a.AppointmentDate AS DATE) >= CAST(GETDATE() AS DATE)
                    ORDER BY a.AppointmentDate ASC";

                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgvAppointments.DataSource = dt;

                dgvAppointments.EnableHeadersVisualStyles = false;
                dgvAppointments.ColumnHeadersDefaultCellStyle.BackColor =
                    Color.FromArgb(52, 152, 219);
                dgvAppointments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvAppointments.ColumnHeadersDefaultCellStyle.Font =
                    new Font("Segoe UI", 9f, FontStyle.Bold);
                dgvAppointments.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
                dgvAppointments.AlternatingRowsDefaultCellStyle.BackColor =
                    Color.FromArgb(245, 245, 245);
                dgvAppointments.RowHeadersVisible   = false;
                dgvAppointments.BorderStyle         = BorderStyle.None;
                dgvAppointments.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch hẹn: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CloseAllChildForms()
        {
            for (int i = panelMain.Controls.Count - 1; i >= 0; i--)
            {
                if (panelMain.Controls[i] is Form)
                {
                    Form oldForm = (Form)panelMain.Controls[i];
                    panelMain.Controls.RemoveAt(i);
                    oldForm.Close();
                    oldForm.Dispose();
                }
            }
        }

        private void OpenChildForm(Form childForm)
        {
            CloseAllChildForms();
            childForm.TopLevel        = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock            = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            childForm.Show();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            CloseAllChildForms();
            LoadDashboard();
            panelDashboard.Visible = true;
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            lblTitle.Text          = "Khách hàng";
            panelDashboard.Visible = false;
            OpenChildForm(new frmKhachHang());
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            lblTitle.Text          = "Bán hàng";
            panelDashboard.Visible = false;
            OpenChildForm(new frmBanHang());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            lblTitle.Text          = "Thống kê";
            panelDashboard.Visible = false;

            MessageBox.Show(
                "Chức năng Thống kê đang được phát triển!\nVui lòng quay lại sau.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHangHoa_Click(object sender, EventArgs e)
        {
            lblTitle.Text          = "Hàng hóa";
            panelDashboard.Visible = false;
            MessageBox.Show("Chức năng Hàng hóa đang được phát triển!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            lblTitle.Text          = "Dịch vụ";
            panelDashboard.Visible = false;
            MessageBox.Show("Chức năng Dịch vụ đang được phát triển!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            lblTitle.Text          = "Nhân viên";
            panelDashboard.Visible = false;
            MessageBox.Show("Chức năng Nhân viên đang được phát triển!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn đăng xuất?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}