using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HTQuanLyThuCung
{
    // 1. Đối tượng dữ liệu
    public class Item
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public double Gia { get; set; }
        public int TonKho { get; set; }
        public bool IsService { get; set; }
    }

    public class CartItem
    {
        public Item RootItem { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien { get { return RootItem.Gia * SoLuong; } }
    }

    // 2. Class Form chính
    public partial class frmBanHang : Form
    {
        private List<Item> database = new List<Item>();
        private List<CartItem> cart = new List<CartItem>();
        private bool isShowingService = false;

        // Các Control chính
        private Panel pnlLeftArea, pnlRightArea, pnlPayment;
        private DataGridView dgvList, dgvCartProd, dgvCartSer;
        private Button btnTabSP, btnTabDV, btnThanhToan;
        private Label lblTongTien, lblTamTinh;
        private TextBox txtSearch, txtGiamGia;

        public frmBanHang()
        {
            // Thiết lập dữ liệu giả lập ban đầu
            database.Add(new Item { ID = 10, Ten = "Thức ăn cho chó", Gia = 150000, TonKho = 99, IsService = false });
            database.Add(new Item { ID = 11, Ten = "Thức ăn cho mèo", Gia = 200000, TonKho = 199, IsService = false });
            database.Add(new Item { ID = 5, Ten = "Cắt tỉa lông", Gia = 100000, TonKho = 0, IsService = true });
            database.Add(new Item { ID = 6, Ten = "Tắm", Gia = 500000, TonKho = 0, IsService = true });

            InitializeCustomComponents();
            RefreshMainList();
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Hệ thống Bán hàng";
            this.Size = new Size(1000, 700); // Kích thước form (nhưng sẽ co giãn khi được nhúng)
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);
            this.BackColor = Color.FromArgb(240, 240, 240); // Màu nền trùng màu xám của form chính

            // Phân chia Form thành 2 vùng Left (Danh sách) và Right (Giỏ hàng)
            // Cả hai cùng Dock = Left và có chiều rộng cố định để đảm bảo bố cục không bị vỡ.

            // --- VÙNG TRÁI: Danh sách sản phẩm/dịch vụ ---
            pnlLeftArea = new Panel { Dock = DockStyle.Left, Width = 520, Padding = new Padding(20) };

            Panel pnlTopLeft = new Panel { Dock = DockStyle.Top, Height = 100 };
            btnTabSP = new Button { Text = "SẢN PHẨM", Size = new Size(120, 40), Location = new Point(0, 0), FlatStyle = FlatStyle.Flat, BackColor = Color.DarkGray };
            btnTabDV = new Button { Text = "DỊCH VỤ", Size = new Size(120, 40), Location = new Point(130, 0), FlatStyle = FlatStyle.Flat, BackColor = Color.LightGray };
            txtSearch = new TextBox { Text = "Tìm kiếm...", Location = new Point(0, 55), Width = 400 };
            pnlTopLeft.Controls.AddRange(new Control[] { btnTabSP, btnTabDV, txtSearch });

            dgvList = CreateGrid();
            dgvList.Dock = DockStyle.Fill;
            dgvList.Columns.Add("ID", "#");
            dgvList.Columns.Add("Ten", "Tên");
            dgvList.Columns.Add("Gia", "Giá");
            dgvList.Columns.Add("Ton", "Tồn kho");
            dgvList.Columns.Add(new DataGridViewButtonColumn { Name = "Add", Text = "+", UseColumnTextForButtonValue = true });

            pnlLeftArea.Controls.AddRange(new Control[] { dgvList, pnlTopLeft });


            // --- VÙNG PHẢI: Giỏ hàng và Thanh toán ---
            pnlRightArea = new Panel { Dock = DockStyle.Left, Width = 460, Padding = new Padding(20) };

            Panel pnlCarts = new Panel { Dock = DockStyle.Top, Height = 400 };
            dgvCartProd = CreateGrid(); dgvCartProd.Height = 190; dgvCartProd.Dock = DockStyle.Top;
            dgvCartProd.Columns.Add("ID", "#"); dgvCartProd.Columns.Add("Ten", "Tên"); dgvCartProd.Columns.Add("SL", "SL"); dgvCartProd.Columns.Add("Gia", "Giá");

            Panel pnlSpacer = new Panel { Height = 20, Dock = DockStyle.Top }; // Khoảng cách 2 bảng giỏ hàng

            dgvCartSer = CreateGrid(); dgvCartSer.Height = 190; dgvCartSer.Dock = DockStyle.Top;
            dgvCartSer.Columns.Add("ID", "#"); dgvCartSer.Columns.Add("Ten", "Tên"); dgvCartSer.Columns.Add("SL", "SL"); dgvCartSer.Columns.Add("Gia", "Giá");
            pnlCarts.Controls.AddRange(new Control[] { dgvCartSer, pnlSpacer, dgvCartProd });

            // PAYMENT PANEL
            pnlPayment = new Panel { Dock = DockStyle.Bottom, Height = 180, BackColor = Color.White, Padding = new Padding(15) };
            lblTamTinh = new Label { Text = "Tạm tính: 0đ", Location = new Point(15, 60), AutoSize = true };
            lblTongTien = new Label { Text = "Tổng tiền: 0đ", Font = new Font("Segoe UI", 14, FontStyle.Bold), Location = new Point(15, 100), AutoSize = true, ForeColor = Color.Red };

            Label lblKM = new Label { Text = "Khuyến mãi (%):", Location = new Point(15, 25), AutoSize = true };
            txtGiamGia = new TextBox { Location = new Point(140, 22), Width = 100, Text = "0" };
            btnThanhToan = new Button { Text = "Thanh toán", Size = new Size(160, 50), Location = new Point(270, 90), BackColor = Color.FromArgb(160, 230, 160), FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 11, FontStyle.Bold) };

            pnlPayment.Controls.AddRange(new Control[] { lblTamTinh, lblTongTien, lblKM, txtGiamGia, btnThanhToan });

            pnlRightArea.Controls.AddRange(new Control[] { pnlPayment, pnlCarts });


            // Đưa tất cả vào Form
            this.Controls.AddRange(new Control[] { pnlRightArea, pnlLeftArea });

            // EVENTS
            btnTabSP.Click += (s, e) => { isShowingService = false; RefreshMainList(); };
            btnTabDV.Click += (s, e) => { isShowingService = true; RefreshMainList(); };
            dgvList.CellContentClick += DgvList_CellClick;
            txtGiamGia.TextChanged += (s, e) => UpdateCartTotal();
            btnThanhToan.Click += BtnThanhToan_Click;
        }

        private DataGridView CreateGrid()
        {
            return new DataGridView
            {
                BackgroundColor = Color.White,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ReadOnly = true
            };
        }

        private void RefreshMainList()
        {
            dgvList.Rows.Clear();
            foreach (var i in database.Where(x => x.IsService == isShowingService))
                dgvList.Rows.Add(i.ID, i.Ten, i.Gia.ToString("N0") + "đ", i.IsService ? "-" : i.TonKho.ToString());
        }

        private void DgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvList.Columns["Add"].Index && e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells["ID"].Value);
                var item = database.FirstOrDefault(x => x.ID == id);
                if (item == null) return;

                if (!item.IsService && item.TonKho <= 0) { MessageBox.Show("Hết hàng!"); return; }

                var cartItem = cart.FirstOrDefault(x => x.RootItem.ID == id);
                if (cartItem != null) cartItem.SoLuong++;
                else cart.Add(new CartItem { RootItem = item, SoLuong = 1 });

                UpdateCartGrids();
            }
        }

        private void UpdateCartGrids()
        {
            dgvCartProd.Rows.Clear();
            dgvCartSer.Rows.Clear();
            foreach (var c in cart)
            {
                if (c.RootItem.IsService) dgvCartSer.Rows.Add(c.RootItem.ID, c.RootItem.Ten, c.SoLuong, c.RootItem.Gia.ToString("N0") + "đ");
                else dgvCartProd.Rows.Add(c.RootItem.ID, c.RootItem.Ten, c.SoLuong, c.RootItem.Gia.ToString("N0") + "đ");
            }
            UpdateCartTotal();
        }

        private void UpdateCartTotal()
        {
            double subtotal = 0;
            foreach (var c in cart) subtotal += c.ThanhTien;

            double discountPercent = 0;
            double.TryParse(txtGiamGia.Text, out discountPercent);

            double final = subtotal * (1 - (discountPercent / 100));
            lblTamTinh.Text = "Tạm tính: " + subtotal.ToString("N0") + "đ";
            lblTongTien.Text = "Tổng tiền: " + final.ToString("N0") + "đ";
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0) return;

            // TRỪ TỒN KHO
            foreach (var c in cart)
            {
                if (!c.RootItem.IsService) c.RootItem.TonKho -= c.SoLuong;
            }

            MessageBox.Show("Thanh toán thành công! Tổng tiền: " + lblTongTien.Text);
            cart.Clear();
            txtGiamGia.Text = "0";
            UpdateCartGrids();
            RefreshMainList();
        }
    }
}