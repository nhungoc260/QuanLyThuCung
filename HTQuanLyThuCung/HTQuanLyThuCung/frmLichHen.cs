using HTQuanLyThuCung;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HTQuanLyThuCung
{
    public partial class frmLichHen : Form
    {
        int rowIndexDangChon = -1;

        public frmLichHen()
        {
            InitializeComponent();

            SetupContextMenu();

            dgvLichHen.CellMouseClick += dgvLichHen_CellMouseClick;
            btnThem.Click += btnThem_Click;

            this.Load += (s, e) => {
                dgvLichHen.ClearSelection();
                dgvLichHen.CurrentCell = null;
            };

            LoadData();
        }

        private void SetupContextMenu()
        {
            menuTacVu.Items.Clear();

            ToolStripMenuItem itemHoanThanh = new ToolStripMenuItem("Xác nhận hoàn thành");
            itemHoanThanh.Font = new Font(menuTacVu.Font, FontStyle.Bold);
            itemHoanThanh.Click += (s, e) => CapNhatTrangThaiDong("Hoàn thành", Color.Honeydew);

            ToolStripMenuItem itemHuyMoi = new ToolStripMenuItem("Hủy lịch hẹn");
            itemHuyMoi.Click += Huy_Click;

            ToolStripMenuItem itemXoaMoi = new ToolStripMenuItem("Xóa lịch hẹn");
            itemXoaMoi.Click += Xoa_Click;

            menuTacVu.Items.Add(itemHoanThanh);
            menuTacVu.Items.Add(new ToolStripSeparator());
            menuTacVu.Items.Add(itemHuyMoi);
            menuTacVu.Items.Add(itemXoaMoi);
        }

        void LoadData()
        {
            dgvLichHen.Rows.Clear();

            dgvLichHen.Rows.Add("Chó Pug", "Nguyễn Tuấn Anh", "Tắm Spa", "09:00 25/03/2026", "Đang chờ", "👁");
            dgvLichHen.Rows.Add("Sư Tử", "Trần Thị Tuyết", "Cắt tỉa lông", "10:30 20/03/2026", "Hoàn thành", "👁");
            dgvLichHen.Rows.Add("Chó Chihuahua", "Cao Nhân", "Khám sức khỏe", "14:00 28/02/2026", "Đang chờ", "👁");
            dgvLichHen.Rows.Add("Mèo Munchkin", "Phạm Thanh Tùng", "Tiêm phòng", "15:30 29/03/2026", "Đang chờ", "👁");
            dgvLichHen.Rows.Add("Mèo Tuxedo", "Nguyễn Trúc Nhân", "Khám sức khỏe", "14:00 21/3/2026", "Hoàn thành", "👁");
            dgvLichHen.Rows.Add("Chó Poodle", "Tuyết Anh", "Tiêm phòng", "15:30 20/03/2026", "Hủy", "👁");

            CapNhatThongKe();
        }

        private void dgvLichHen_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowIndex >= 0 && e.ColumnIndex == 5)
            {
                rowIndexDangChon = e.RowIndex;
                dgvLichHen.ClearSelection();
                dgvLichHen.Rows[e.RowIndex].Selected = true;

                menuTacVu.Show(Cursor.Position);
            }


        }
        void CapNhatTrangThaiDong(string trangThaiMoi, Color mauNen)
        {
            if (rowIndexDangChon >= 0)
            {
                dgvLichHen.Rows[rowIndexDangChon].Cells[4].Value = trangThaiMoi;
                dgvLichHen.Rows[rowIndexDangChon].DefaultCellStyle.BackColor = mauNen;
                CapNhatThongKe();
            }
        }

        void Huy_Click(object sender, EventArgs e)
        {
            CapNhatTrangThaiDong("Đã hủy", Color.LightGray);
            MessageBox.Show("Đã hủy lịch hẹn này!");
        }

        void Xoa_Click(object sender, EventArgs e)
        {
            if (rowIndexDangChon < 0) return;
            var dr = MessageBox.Show("Xóa vĩnh viễn dòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                dgvLichHen.Rows.RemoveAt(rowIndexDangChon);
                rowIndexDangChon = -1;
                CapNhatThongKe();
            }
        }

        void CapNhatThongKe()
        {
            int tong = 0, cho = 0, xong = 0, huy = 0;

            foreach (DataGridViewRow row in dgvLichHen.Rows)
            {
                if (row.IsNewRow) continue;
                tong++;
                string status = row.Cells[4].Value?.ToString();

                if (status == "Đang chờ" || status == "Đã đến") cho++;
                else if (status == "Hoàn thành") xong++;
                else if (status == "Đã hủy" || status == "Hủy")
                {
                    huy++;
                }
            }

            lblTong.Text = tong.ToString("D2");
            lblCho.Text = cho.ToString("D2");
            lblHoanThanh.Text = xong.ToString("D2");
            lblHuy.Text = huy.ToString("D2");
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            using (frmDatLich f = new frmDatLich())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    dgvLichHen.Rows.Add(f.ThuCung, f.TenKH, f.DichVu, f.Gio, "Đang chờ", "👁");
                    CapNhatThongKe();
                }
            }
        }

        private void pnlTong_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(52, 152, 219)), 0, 0, pnlTong.Width, 8);
        }

        private void pnlCho_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(243, 156, 18)), 0, 0, pnlCho.Width, 8);
        }

        private void pnlHoanThanh_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(46, 204, 113)), 0, 0, pnlHoanThanh.Width, 8);
        }

        private void pnlHuy_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(231, 76, 60)), 0, 0, pnlHuy.Width, 8);
        }
    }
}