using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace HTQuanLyThuCung
{
    public partial class frmInHoaDon : Form
    {
        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;
        private string maHoaDon, ngayLap, tenKhachHang, nhanVien;
        private decimal tongTien;

        public frmInHoaDon()
        {
            InitializeComponent();
            SetupPrintDocument();
        }

        public frmInHoaDon(string maHD, string ngay, string khachHang, string nv, decimal tong)
        {
            InitializeComponent();
            this.maHoaDon = maHD;
            this.ngayLap = ngay;
            this.tenKhachHang = khachHang;
            this.nhanVien = nv;
            this.tongTien = tong;
            SetupPrintDocument();
            LoadData();
        }

        private void LoadData()
        {
            lblMaHD.Text = "Mã HĐ: " + maHoaDon;
            lblNgayLap.Text = "Ngày: " + ngayLap;
            lblKhachHang.Text = "Khách hàng: " + tenKhachHang;
            lblNhanVien.Text = "Nhân viên: " + nhanVien;
            lblTongTien.Text = "Tổng cộng: " + tongTien.ToString("N0") + "đ";

            dgvSanPham.Rows.Clear();
            dgvSanPham.Rows.Add("26", "Thức ăn cho chó", "1", "150,000đ", "150,000đ");
            dgvSanPham.Rows.Add("27", "Thức ăn cho mèo", "1", "200,000đ", "200,000đ");

            dgvDichVu.Rows.Clear();
            dgvDichVu.Rows.Add("28", "Cắt tỉa lông", "1", "100,000đ", "100,000đ");
        }

        private void SetupPrintDocument()
        {
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
            printDocument.DocumentName = "HoaDon_" + maHoaDon;

            // Tạo Print Preview Dialog
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.Width = 900;
            printPreviewDialog.Height = 700;
            printPreviewDialog.StartPosition = FormStartPosition.CenterParent;
            printPreviewDialog.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fontTitle = new Font("Arial", 18, FontStyle.Bold);
            Font fontSubtitle = new Font("Arial", 12, FontStyle.Bold);
            Font fontNormal = new Font("Arial", 10, FontStyle.Regular);
            Font fontSmall = new Font("Arial", 9, FontStyle.Italic);
            Font fontTotal = new Font("Arial", 14, FontStyle.Bold);

            int y = 30, x = 40, pageWidth = e.PageBounds.Width;

            // Tiêu đề công ty
            string tenCongTy = "Z618 - HỆ THỐNG QUẢN LÝ THÚ CƯNG";
            SizeF sizeCongTy = g.MeasureString(tenCongTy, fontTitle);
            g.DrawString(tenCongTy, fontTitle, Brushes.DarkBlue, (pageWidth - sizeCongTy.Width) / 2, y);
            y += 30;

            g.DrawString("Địa chỉ: 123 Nguyễn Văn A, P.5, Q.3, TP.HCM", fontNormal, Brushes.Gray, (pageWidth - 300) / 2, y);
            y += 20;
            g.DrawString("Hotline: 0901234567", fontNormal, Brushes.Gray, (pageWidth - 150) / 2, y);
            y += 40;

            // Tiêu đề hóa đơn
            string title = "HÓA ĐƠN BÁN HÀNG";
            SizeF titleSize = g.MeasureString(title, fontSubtitle);
            g.DrawString(title, fontSubtitle, Brushes.Black, (pageWidth - titleSize.Width) / 2, y);
            y += 30;
            g.DrawLine(new Pen(Color.Black, 2), x, y, pageWidth - 40, y);
            y += 15;

            // Thông tin hóa đơn
            g.DrawString(lblMaHD.Text, fontNormal, Brushes.Black, x, y); y += 25;
            g.DrawString(lblNgayLap.Text, fontNormal, Brushes.Black, x, y); y += 25;
            g.DrawString(lblKhachHang.Text, fontNormal, Brushes.Black, x, y); y += 25;
            g.DrawString(lblNhanVien.Text, fontNormal, Brushes.Black, x, y); y += 30;
            g.DrawLine(Pens.Gray, x, y, pageWidth - 40, y);
            y += 15;

            // SẢN PHẨM
            g.DrawString("SẢN PHẨM", fontSubtitle, Brushes.DarkBlue, x, y); y += 25;
            string[] headers = { "Mã", "Tên sản phẩm", "SL", "Đơn giá", "Thành tiền" };
            int[] colWidths = { 50, 250, 50, 100, 100 };
            int startX = x, rowHeight = 25;

            for (int i = 0; i < headers.Length; i++)
            {
                g.DrawString(headers[i], fontSubtitle, Brushes.White, startX, y);
                startX += colWidths[i];
            }
            g.FillRectangle(Brushes.DarkBlue, x, y, colWidths.Sum(), rowHeight);
            y += rowHeight;

            foreach (DataGridViewRow row in dgvSanPham.Rows)
            {
                if (row.Cells.Count >= 5)
                {
                    startX = x;
                    for (int i = 0; i < 5; i++)
                    {
                        string text = row.Cells[i].Value?.ToString() ?? "";
                        g.DrawString(text, fontNormal, Brushes.Black, startX, y);
                        startX += colWidths[i];
                    }
                    y += 22;
                }
            }
            y += 15;

            // DỊCH VỤ
            g.DrawString("DỊCH VỤ", fontSubtitle, Brushes.DarkBlue, x, y); y += 25;
            startX = x;
            for (int i = 0; i < headers.Length; i++)
            {
                g.DrawString(headers[i], fontSubtitle, Brushes.White, startX, y);
                startX += colWidths[i];
            }
            g.FillRectangle(Brushes.DarkBlue, x, y, colWidths.Sum(), rowHeight);
            y += rowHeight;

            foreach (DataGridViewRow row in dgvDichVu.Rows)
            {
                if (row.Cells.Count >= 5)
                {
                    startX = x;
                    for (int i = 0; i < 5; i++)
                    {
                        string text = row.Cells[i].Value?.ToString() ?? "";
                        g.DrawString(text, fontNormal, Brushes.Black, startX, y);
                        startX += colWidths[i];
                    }
                    y += 22;
                }
            }
            y += 30;
            g.DrawLine(Pens.Gray, x, y, pageWidth - 40, y);
            y += 15;

            // TỔNG CỘNG
            string tongText = "TỔNG CỘNG: " + lblTongTien.Text.Replace("Tổng cộng: ", "");
            SizeF tongSize = g.MeasureString(tongText, fontTotal);
            g.DrawString(tongText, fontTotal, Brushes.Red, pageWidth - tongSize.Width - 40, y);
            y += 40;
            g.DrawLine(new Pen(Color.Black, 2), x, y, pageWidth - 40, y);
            y += 30;

            // Chân trang
            g.DrawString("Xin chân thành cảm ơn quý khách!", fontNormal, Brushes.DarkGreen, (pageWidth - 250) / 2, y);
            y += 25;
            g.DrawString("Hẹn gặp lại quý khách!", fontNormal, Brushes.DarkGreen, (pageWidth - 180) / 2, y);
            y += 40;
            g.DrawString("Hóa đơn này được tạo tự động từ hệ thống Z618", fontSmall, Brushes.Gray, (pageWidth - 300) / 2, y);

            fontTitle.Dispose(); fontSubtitle.Dispose(); fontNormal.Dispose();
            fontSmall.Dispose(); fontTotal.Dispose();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            // ✅ HIỂN THỊ PRINT PREVIEW TRƯỚC KHI IN
            if (printPreviewDialog.ShowDialog() == DialogResult.OK)
            {
                // Nếu người dùng click "Print" trong preview dialog
                try
                {
                    printDocument.Print();
                    MessageBox.Show("In hóa đơn thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi in:\n" + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}