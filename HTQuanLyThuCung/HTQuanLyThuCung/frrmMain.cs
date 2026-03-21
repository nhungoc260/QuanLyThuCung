using QuanLyThuCung;
using System;
using System.Data;
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

            int pets = 5;
            int customers = 5;
            int services = 4;
            int appointments = 5;

            lblPets.Text = "🐶 Thú cưng\n" + pets;
            lblCustomers.Text = "👤 Khách hàng\n" + customers;
            lblServices.Text = "💅 Dịch vụ\n" + services;
            lblAppointments.Text = "📅 Tổng lịch hẹn\n" + appointments;

            chartStats.Series.Clear();

            Series s = new Series();
            s.ChartType = SeriesChartType.Column;
            s.IsValueShownAsLabel = true;

            s.Points.AddXY("Thú cưng", pets);
            s.Points.AddXY("Khách hàng", customers);
            s.Points.AddXY("Dịch vụ", services);

            chartStats.Series.Add(s);

            DataTable tb = new DataTable();
            tb.Columns.Add("Thú cưng");
            tb.Columns.Add("Dịch vụ");
            tb.Columns.Add("Thời gian");

            tb.Rows.Add("Milu", "Khám sức khỏe", "15/03");

            dgvAppointments.DataSource = tb;
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

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            CloseAllChildForms();
            LoadDashboard();
            panelDashboard.Visible = true;
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Khách hàng";
            panelDashboard.Visible = false;
            OpenChildForm(new frmKhachHang());
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Bán hàng";
            panelDashboard.Visible = false;
            OpenChildForm(new frmBanHang());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Thống kê";
            panelDashboard.Visible = false;

            MessageBox.Show("Chức năng Thống kê đang được phát triển!\nVui lòng quay lại sau.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnHangHoa_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Hàng hóa";
            panelDashboard.Visible = false;

            MessageBox.Show("Chức năng Hàng hóa đang được phát triển!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Dịch vụ";
            panelDashboard.Visible = false;

            MessageBox.Show("Chức năng Dịch vụ đang được phát triển!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Nhân viên";
            panelDashboard.Visible = false;

            MessageBox.Show("Chức năng Nhân viên đang được phát triển!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn đăng xuất?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void OpenChildForm(Form childForm)
        {
            CloseAllChildForms();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelMain.Controls.Add(childForm);
            childForm.Show();
        }
    }
}