using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace HTQuanLyThuCung
{
    public partial class frmChiTietHoaDon : Form
    {
        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;
        private int currentSection = 0; // 0: Sản phẩm, 1: Dịch vụ

        public frmChiTietHoaDon()
        {
            InitializeComponent();
            LoadData();
            SetupPrintDocument();
        }

        private void LoadData()
        {
            // Sản phẩm
            dgvSanPham.Rows.Clear();
            dgvSanPham.Rows.Add("26", "Thức ăn cho chó", "1", "150,000đ", "150,000đ");
            dgvSanPham.Rows.Add("27", "Thức ăn cho mèo", "1", "200,000đ", "200,000đ");

            // Dịch vụ
            dgvDichVu.Rows.Clear();
            dgvDichVu.Rows.Add("28", "Cắt tỉa lông", "1", "100,000đ", "100,000đ");

            // Tổng tiền
            lblTong.Text = "Tổng: 450,000đ";
        }

        // Cấu hình PrintDocument
        private void SetupPrintDocument()
        {
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
            printDocument.DocumentName = "HoaDonBanHang";

            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.Width = 800;
            printPreviewDialog.Height = 600;
        }

        // Sự kiện in
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fontTitle = new Font("Arial", 16, FontStyle.Bold);
            Font fontHeader = new Font("Arial", 12, FontStyle.Bold);
            Font fontContent = new Font("Arial", 10, FontStyle.Regular);
            Font fontTotal = new Font("Arial", 14, FontStyle.Bold);

            int y = 50;
            int x = 50;
            int pageWidth = e.PageBounds.Width;

            // Tiêu đề
            string title = "HÓA ĐƠN BÁN HÀNG";
            SizeF titleSize = g.MeasureString(title, fontTitle);
            g.DrawString(title, fontTitle, Brushes.Black, (pageWidth - titleSize.Width) / 2, y);
            y += 40;

            // Thông tin cửa hàng
            g.DrawString("Z618 - Hệ thống quản lý thú cưng", fontContent, Brushes.Black, x, y);
            y += 20;
            g.DrawString("Ngày in: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontContent, Brushes.Black, x, y);
            y += 30;

            // Phần Sản phẩm
            g.DrawString("SẢN PHẨM", fontHeader, Brushes.Black, x, y);
            y += 25;

            // Header table
            string[] headers = { "Mã HĐ", "Tên", "Số lượng", "Đơn giá", "Thành tiền" };
            int[] colWidths = { 60, 200, 80, 100, 100 };
            int startX = x;

            for (int i = 0; i < headers.Length; i++)
            {
                g.DrawString(headers[i], fontHeader, Brushes.Black, startX, y);
                startX += colWidths[i];
            }
            y += 25;

            // Line
            g.DrawLine(Pens.Black, x, y, x + colWidths.Sum(), y);
            y += 5;

            // Data rows - Sản phẩm
            foreach (DataGridViewRow row in dgvSanPham.Rows)
            {
                if (row.Cells.Count >= 5)
                {
                    startX = x;
                    for (int i = 0; i < 5; i++)
                    {
                        string text = row.Cells[i].Value?.ToString() ?? "";
                        g.DrawString(text, fontContent, Brushes.Black, startX, y);
                        startX += colWidths[i];
                    }
                    y += 20;
                }
            }

            y += 20;

            // Phần Dịch vụ
            g.DrawString("DỊCH VỤ", fontHeader, Brushes.Black, x, y);
            y += 25;

            // Header table
            startX = x;
            for (int i = 0; i < headers.Length; i++)
            {
                g.DrawString(headers[i], fontHeader, Brushes.Black, startX, y);
                startX += colWidths[i];
            }
            y += 25;

            // Line
            g.DrawLine(Pens.Black, x, y, x + colWidths.Sum(), y);
            y += 5;

            // Data rows - Dịch vụ
            foreach (DataGridViewRow row in dgvDichVu.Rows)
            {
                if (row.Cells.Count >= 5)
                {
                    startX = x;
                    for (int i = 0; i < 5; i++)
                    {
                        string text = row.Cells[i].Value?.ToString() ?? "";
                        g.DrawString(text, fontContent, Brushes.Black, startX, y);
                        startX += colWidths[i];
                    }
                    y += 20;
                }
            }

            y += 30;

            // Tổng tiền
            string totalText = "TỔNG CỘNG: " + lblTong.Text.Replace("Tổng: ", "");
            SizeF totalSize = g.MeasureString(totalText, fontTotal);
            g.DrawString(totalText, fontTotal, Brushes.Red, pageWidth - totalSize.Width - 50, y);

            y += 40;

            // Chân trang
            g.DrawString("Xin cảm ơn quý khách!", fontContent, Brushes.Gray, (pageWidth - 150) / 2, y);
            y += 20;
            g.DrawString("Hẹn gặp lại!", fontContent, Brushes.Gray, (pageWidth - 100) / 2, y);

            // Cleanup
            fontTitle.Dispose();
            fontHeader.Dispose();
            fontContent.Dispose();
            fontTotal.Dispose();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            // Hiển thị dialog chọn máy in
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            printDialog.UseEXDialog = true;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
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
    }
}