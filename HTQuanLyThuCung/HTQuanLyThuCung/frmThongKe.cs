using System;
using System.Globalization;
using System.Windows.Forms;

namespace HTQuanLyThuCung
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgvHoaDon.Rows.Clear();

            // Dữ liệu thật từ frmKhachHang
            dgvHoaDon.Rows.Add("101", "15/01/2026 10:30:00", "Nguyễn Văn Minh", "Nguyễn Thị Hương", "1.250.000đ");
            dgvHoaDon.Rows.Add("102", "20/02/2026 14:15:00", "Nguyễn Văn Minh", "Trần Văn Nam", "850.000đ");
            dgvHoaDon.Rows.Add("103", "05/03/2026 09:45:00", "Trần Thị Lan", "Nguyễn Thị Hương", "2.100.000đ");
            dgvHoaDon.Rows.Add("104", "10/03/2026 16:20:00", "Lê Hoàng Dũng", "Lê Thị Mai", "650.000đ");
            dgvHoaDon.Rows.Add("105", "12/03/2026 11:00:00", "Phạm Thị Mai", "Nguyễn Thị Hương", "1.500.000đ");
            dgvHoaDon.Rows.Add("106", "15/03/2026 14:30:00", "Hoàng Văn Tuấn", "Trần Văn Nam", "750.000đ");
            dgvHoaDon.Rows.Add("107", "18/03/2026 10:00:00", "Hoàng Văn Tuấn", "Lê Thị Mai", "450.000đ");

            // Hiển thị khoảng ngày có dữ liệu
            ShowDateRange();

            // Set DateTimePicker về khoảng ngày có data
            dtpTuNgay.Value = new DateTime(2026, 1, 1);
            dtpDenNgay.Value = new DateTime(2026, 12, 31);

            CalculateStatistics();
        }

        // Hiển thị khoảng ngày có dữ liệu
        private void ShowDateRange()
        {
            DateTime? minDate = null;
            DateTime? maxDate = null;

            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.Cells["clNgayLap"].Value != null)
                {
                    string ngayLapString = row.Cells["clNgayLap"].Value.ToString();
                    DateTime ngayLap;

                    if (DateTime.TryParseExact(ngayLapString,
                        new string[] { "dd/MM/yyyy HH:mm:ss", "dd/MM/yyyy HH:mm" },
                        CultureInfo.GetCultureInfo("vi-VN"),
                        DateTimeStyles.None,
                        out ngayLap))
                    {
                        if (!minDate.HasValue || ngayLap < minDate.Value)
                            minDate = ngayLap;

                        if (!maxDate.HasValue || ngayLap > maxDate.Value)
                            maxDate = ngayLap;
                    }
                }
            }

            if (minDate.HasValue && maxDate.HasValue)
            {
                lblKhoangNgay.Text = $"📊 Dữ liệu từ {minDate.Value:dd/MM/yyyy} đến {maxDate.Value:dd/MM/yyyy}";
            }
            else
            {
                lblKhoangNgay.Text = "Không có dữ liệu";
            }
        }

        // Tính toán thống kê tự động
        private void CalculateStatistics()
        {
            int soHoaDon = 0;
            decimal tongSanPham = 0;
            decimal tongDichVu = 0;
            decimal tongTien = 0;

            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.Visible && row.Cells["clTongTien"].Value != null)
                {
                    soHoaDon++;

                    string thanhTien = row.Cells["clTongTien"].Value.ToString()
                        .Replace("đ", "").Replace(".", "").Trim();

                    if (decimal.TryParse(thanhTien, out decimal tien))
                    {
                        tongTien += tien;
                        tongSanPham += tien * 0.7m;
                        tongDichVu += tien * 0.3m;
                    }
                }
            }

            lblSanPham.Text = $"{tongSanPham:N0}đ";
            lblDichVu.Text = $"{tongDichVu:N0}đ";
            lblSoHoaDon.Text = soHoaDon.ToString();
            lblTongTien.Text = $"Tổng tiền: {tongTien:N0} VND";
        }

        // Double-click vào DataGridView
        private void dgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                XemChiTietHoaDon();
            }
        }

        // Nút Xem chi tiết
        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow != null)
            {
                XemChiTietHoaDon();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xem!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Hàm xem chi tiết
        private void XemChiTietHoaDon()
        {
            frmChiTietHoaDon frmChiTiet = new frmChiTietHoaDon();
            frmChiTiet.ShowDialog();
        }

        // Nút Lọc
        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);

                int soLuongLoc = 0;

                foreach (DataGridViewRow row in dgvHoaDon.Rows)
                {
                    if (row.Cells["clNgayLap"].Value != null)
                    {
                        string ngayLapString = row.Cells["clNgayLap"].Value.ToString();

                        DateTime ngayLap;
                        bool parsed = DateTime.TryParseExact(
                            ngayLapString,
                            new string[] { "dd/MM/yyyy HH:mm:ss", "dd/MM/yyyy HH:mm", "d/M/yyyy h:mm:ss tt" },
                            CultureInfo.GetCultureInfo("vi-VN"),
                            DateTimeStyles.None,
                            out ngayLap
                        );

                        if (parsed)
                        {
                            if (ngayLap.Date >= tuNgay && ngayLap.Date < denNgay)
                            {
                                row.Visible = true;
                                soLuongLoc++;
                            }
                            else
                            {
                                row.Visible = false;
                            }
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }

                CalculateStatistics();

                string thongBao = $"Đã lọc {soLuongLoc} hóa đơn từ {tuNgay:dd/MM/yyyy} đến {denNgay.AddDays(-1):dd/MM/yyyy}";

                if (soLuongLoc == 0)
                {
                    thongBao += "\n\nKhông có hóa đơn nào trong khoảng thời gian này.";
                }

                MessageBox.Show(thongBao, "Kết quả lọc",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Xem tất cả
        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            // Hiện tất cả dòng
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                row.Visible = true;
            }

            // Reset DateTimePicker về khoảng rộng
            dtpTuNgay.Value = new DateTime(2026, 1, 1);
            dtpDenNgay.Value = new DateTime(2026, 12, 31);

            CalculateStatistics();

            MessageBox.Show("Đã hiển thị tất cả hóa đơn", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Các sự kiện khác
        private void btnTrangChu_Click(object sender, EventArgs e) { }
        private void btnKhachHang_Click(object sender, EventArgs e) { }
        private void btnBanHang_Click(object sender, EventArgs e) { }
        private void btnThongKe_Click(object sender, EventArgs e) { }
        private void btnHangHoa_Click(object sender, EventArgs e) { }
        private void btnDichVu_Click(object sender, EventArgs e) { }
        private void btnNhanVien_Click(object sender, EventArgs e) { }
        private void btnDangXuat_Click(object sender, EventArgs e) { }
    }
}