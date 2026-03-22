using HTQuanLyThuCung.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HTQuanLyThuCung.frmDichVu;

namespace HTQuanLyThuCung
{
    public partial class frmDichVu : Form
    {
        int Id = -1;
        bool isLoading = true;

        public frmDichVu()
        {
            InitializeComponent();
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            isLoading = true;
            SetupInterface();
            LoadServices();

            // Reset Form về trạng thái trống
            ClearForm();

            // Quan trọng: Bỏ chọn dòng mặc định của DataGridView
            this.BeginInvoke(new MethodInvoker(() => {
                dgvDichVu.ClearSelection();
                dgvDichVu.CurrentCell = null;
            }));

            isLoading = false;
        }

        void SetupInterface()
        {
            dgvDichVu.EnableHeadersVisualStyles = false;

            dgvDichVu.ColumnHeadersDefaultCellStyle.BackColor = Color.White; 
            dgvDichVu.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White; 

            dgvDichVu.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvDichVu.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black; 

            dgvDichVu.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dgvDichVu.ColumnHeadersHeight = 45;

            dgvDichVu.DefaultCellStyle.SelectionBackColor = Color.FromArgb(204, 229, 255); 
            dgvDichVu.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvDichVu.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);

            dgvDichVu.RowHeadersVisible = false; 
            dgvDichVu.BackgroundColor = Color.White;
            dgvDichVu.BorderStyle = BorderStyle.None;
            dgvDichVu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDichVu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        void LoadServices()
        {
            dgvDichVu.AutoGenerateColumns = true;
            string query = "SELECT * FROM Services";
            dgvDichVu.DataSource = DatabaseHelper.ExecuteQuery(query);

            foreach (DataGridViewColumn column in dgvDichVu.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (DataGridViewRow row in dgvDichVu.Rows)
            {
                row.Height = 40;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenDichVu.Text == "" || txtGiaTien.Text == "")
            {
                MessageBox.Show("Thêm dịch vụ thành công!");
                return;
            }

            string query = @"INSERT INTO Services(ServiceName, Price, Description)
                             VALUES (@Name, @Price, @Desc)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Name", txtTenDichVu.Text),
                new SqlParameter("@Price", decimal.Parse(txtGiaTien.Text)),
                new SqlParameter("@Desc", txtChiTiet.Text)
            };

            DatabaseHelper.ExecuteNonQuery(query, parameters);

            MessageBox.Show("Add service successfully!");

            LoadServices();
            ClearForm();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (Id == -1)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ!");
                return;
            }

            decimal price;
            if (!decimal.TryParse(txtGiaTien.Text, out price))
            {
                MessageBox.Show("Giá tiền không hợp lệ!");
                return;
            }

            string query = @"UPDATE Services 
                     SET ServiceName=@Name, Price=@Price, Description=@Desc
                     WHERE Id=@Id";

            SqlParameter[] parameters =
            {
        new SqlParameter("@Name", txtTenDichVu.Text),
        new SqlParameter("@Price", price),
        new SqlParameter("@Desc", txtChiTiet.Text),
        new SqlParameter("@Id", Id)
    };

            try
            {
                DatabaseHelper.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Cập nhật  thành công!");

                LoadServices();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (Id == -1)
            {
                MessageBox.Show("Vui lòng chọn một dịch vụ từ danh sách để xóa!");
                return;
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ này không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (rs == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM Services WHERE Id=@Id";
                    SqlParameter[] parameters = { new SqlParameter("@Id", Id) };

                    DatabaseHelper.ExecuteNonQuery(query, parameters);

                    MessageBox.Show("Xóa thành công!");
                    LoadServices(); // Nạp lại bảng
                    ClearForm();    // Reset Id về -1
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }

        void ClearForm()
        {
            txtTenDichVu.Clear();
            txtGiaTien.Clear();
            txtChiTiet.Clear();
            Id = -1;
        }

        private void btnLichHen_Click(object sender, EventArgs e)
        {
            frmLichHen f = new frmLichHen();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog(); 
        }

        private void btnDanhGia_Click(object sender, EventArgs e)
        {
            frmKHDanhGia f = new frmKHDanhGia();
            // Đảm bảo Form không bị tự ý co dãn theo Font hệ thống
            f.AutoScaleMode = AutoScaleMode.None;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu nhấp vào hàng hợp lệ (không phải tiêu đề)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDichVu.Rows[e.RowIndex];

                // Kiểm tra Id có giá trị không
                if (row.Cells[0].Value != null && row.Cells[0].Value != DBNull.Value)
                {
                    Id = Convert.ToInt32(row.Cells[0].Value);
                    // Gán dữ liệu vào Textbox
                    txtTenDichVu.Text = row.Cells[1].Value?.ToString();
                    txtGiaTien.Text = row.Cells[2].Value?.ToString();
                    txtChiTiet.Text = row.Cells[3].Value?.ToString();
                }
            }
        }
    }
}
