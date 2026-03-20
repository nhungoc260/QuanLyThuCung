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

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            LoadDashboard();
            panelDashboard.Visible = true;

            // Xóa form khách hàng nếu đang mở
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Khách hàng";
            panelDashboard.Visible = false;

            // ✅ MỞ FORM KHÁCH HÀNG
            OpenChildForm(new frmKhachHang());
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Bán hàng";
            panelDashboard.Visible = false;

            // ✅ ĐÃ CÓ CODE - MỞ FORM BÁN HÀNG
            OpenChildForm(new frmBanHang());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Thống kê";
            panelDashboard.Visible = false;

            // ✅ CHƯA LÀM - HIỆN THÔNG BÁO
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

        // ✅ HÀM MỞ FORM CON
        private void OpenChildForm(Form childForm)
        {
            // Đóng form cũ nếu có
            foreach (Form oldForm in this.MdiChildren)
            {
                oldForm.Close();
            }

            // Cấu hình form mới
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Thêm vào panel chính
            panelMain.Controls.Add(childForm);  // Thay panelMain bằng tên panel của bạn
            childForm.Show();
        }
    }
}