using HTQuanLyThuCung.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HTQuanLyThuCung
{
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

    public partial class frmBanHang : Form
    {
        private List<Item> database = new List<Item>();
        private List<CartItem> cart = new List<CartItem>();
        private bool isShowingService = false;

        private Panel pnlLeftArea, pnlRightArea, pnlPayment;
        private DataGridView dgvList, dgvCartProd, dgvCartSer;
        private Button btnTabSP, btnTabDV, btnThanhToan;
        private Label lblTongTien, lblTamTinh;
        private TextBox txtSearch, txtGiamGia;

        public frmBanHang()
        {
            LoadDataFromDB();
            InitializeCustomComponents();
            RefreshMainList();
        }

        private void LoadDataFromDB()
        {
            database.Clear();
            try
            {
                DataTable dtServices = DatabaseHelper.ExecuteStoredProcedure("sp_GetServices");
                foreach (DataRow row in dtServices.Rows)
                {
                    database.Add(new Item
                    {
                        ID = Convert.ToInt32(row["Id"]),
                        Ten = row["ServiceName"].ToString(),
                        Gia = Convert.ToDouble(row["Price"]),
                        TonKho = 0,
                        IsService = true
                    });
                }

                database.Add(new Item { ID = 101, Ten = "Thức ăn cho chó", Gia = 150000, TonKho = 99, IsService = false });
                database.Add(new Item { ID = 102, Ten = "Thức ăn cho mèo", Gia = 200000, TonKho = 199, IsService = false });
                database.Add(new Item { ID = 103, Ten = "Vòng cổ thú cưng", Gia = 85000, TonKho = 50, IsService = false });
                database.Add(new Item { ID = 104, Ten = "Lồng chó mèo", Gia = 350000, TonKho = 20, IsService = false });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                database.Add(new Item { ID = 101, Ten = "Thức ăn cho chó", Gia = 150000, TonKho = 99, IsService = false });
                database.Add(new Item { ID = 102, Ten = "Thức ăn cho mèo", Gia = 200000, TonKho = 199, IsService = false });
                database.Add(new Item { ID = 5, Ten = "Cắt tỉa lông", Gia = 120000, TonKho = 0, IsService = true });
                database.Add(new Item { ID = 6, Ten = "Tắm rửa", Gia = 80000, TonKho = 0, IsService = true });
            }
        }

        private void SaveAppointmentsToDB()
        {
            try
            {
                foreach (var c in cart.Where(x => x.RootItem.IsService))
                {
                    for (int i = 0; i < c.SoLuong; i++)
                    {
                        DatabaseHelper.ExecuteStoredProcedure("sp_CreateAppointment",
                            new SqlParameter("@PetId", 1),
                            new SqlParameter("@ServiceId", c.RootItem.ID),
                            new SqlParameter("@AppointmentDate", DateTime.Now));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu lịch hẹn: " + ex.Message,
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Hệ thống Bán hàng";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);
            this.BackColor = Color.FromArgb(245, 246, 250);

            pnlLeftArea = new Panel
            {
                Dock = DockStyle.Left,
                Width = 530,
                Padding = new Padding(20),
                BackColor = Color.White
            };

            Panel pnlTopLeft = new Panel { Dock = DockStyle.Top, Height = 110, BackColor = Color.White };

            btnTabSP = new Button
            {
                Text = "🛍 SẢN PHẨM",
                Size = new Size(140, 42),
                Location = new Point(0, 5),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(41, 128, 185),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnTabSP.FlatAppearance.BorderSize = 0;

            btnTabDV = new Button
            {
                Text = "💅 DỊCH VỤ",
                Size = new Size(140, 42),
                Location = new Point(150, 5),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(189, 195, 199),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnTabDV.FlatAppearance.BorderSize = 0;

            txtSearch = new TextBox
            {
                Text = "Tìm kiếm...",
                ForeColor = Color.Gray,
                Location = new Point(0, 60),
                Width = 480,
                Font = new Font("Segoe UI", 10F),
                Height = 32
            };
            txtSearch.GotFocus += (s, e) =>
            {
                if (txtSearch.Text == "Tìm kiếm...")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            };
            txtSearch.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "Tìm kiếm...";
                    txtSearch.ForeColor = Color.Gray;
                }
            };
            txtSearch.TextChanged += (s, e) => RefreshMainList();

            pnlTopLeft.Controls.AddRange(new Control[] { btnTabSP, btnTabDV, txtSearch });

            dgvList = CreateGrid();
            dgvList.Dock = DockStyle.Fill;
            dgvList.Columns.Add("ID", "#");
            dgvList.Columns.Add("Ten", "Tên sản phẩm / dịch vụ");
            dgvList.Columns.Add("Gia", "Giá");
            dgvList.Columns.Add("Ton", "Tồn kho");
            dgvList.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Add",
                Text = "+",
                UseColumnTextForButtonValue = true,
                Width = 50,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle =
                {
                    BackColor = Color.FromArgb(46, 204, 113),
                    ForeColor = Color.White,
                    Font      = new Font("Segoe UI", 12F, FontStyle.Bold)
                }
            });

            StyleGrid(dgvList, Color.FromArgb(41, 128, 185));
            pnlLeftArea.Controls.AddRange(new Control[] { dgvList, pnlTopLeft });

            pnlRightArea = new Panel
            {
                Dock = DockStyle.Left,
                Width = 450,
                Padding = new Padding(15),
                BackColor = Color.FromArgb(245, 246, 250)
            };

            Label lblCart = new Label
            {
                Text = "🛒 GIỎ HÀNG",
                Dock = DockStyle.Top,
                Height = 35,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Panel pnlCarts = new Panel { Dock = DockStyle.Top, Height = 380, BackColor = Color.White };

            Label lblProd = new Label
            {
                Text = "Sản phẩm",
                Dock = DockStyle.Top,
                Height = 28,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(41, 128, 185),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5, 0, 0, 0)
            };

            dgvCartProd = CreateGrid();
            dgvCartProd.Height = 150;
            dgvCartProd.Dock = DockStyle.Top;
            dgvCartProd.Columns.Add("ID", "#");
            dgvCartProd.Columns.Add("Ten", "Tên");
            dgvCartProd.Columns.Add("SL", "SL");
            dgvCartProd.Columns.Add("Gia", "Thành tiền");
            StyleGrid(dgvCartProd, Color.FromArgb(52, 152, 219));

            Label lblSer = new Label
            {
                Text = "Dịch vụ",
                Dock = DockStyle.Top,
                Height = 28,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(155, 89, 182),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5, 0, 0, 0)
            };

            dgvCartSer = CreateGrid();
            dgvCartSer.Height = 150;
            dgvCartSer.Dock = DockStyle.Top;
            dgvCartSer.Columns.Add("ID", "#");
            dgvCartSer.Columns.Add("Ten", "Tên");
            dgvCartSer.Columns.Add("SL", "SL");
            dgvCartSer.Columns.Add("Gia", "Thành tiền");
            StyleGrid(dgvCartSer, Color.FromArgb(155, 89, 182));

            pnlCarts.Controls.AddRange(new Control[] { dgvCartSer, lblSer, dgvCartProd, lblProd });

            // PAYMENT PANEL
            pnlPayment = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 190,
                BackColor = Color.White,
                Padding = new Padding(15)
            };

            Label lblLine = new Label
            {
                Dock = DockStyle.Top,
                Height = 2,
                BackColor = Color.FromArgb(220, 220, 220)
            };

            Label lblKM = new Label
            {
                Text = "Khuyến mãi (%):",
                Location = new Point(15, 18),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(44, 62, 80)
            };

            txtGiamGia = new TextBox
            {
                Location = new Point(160, 15),
                Width = 80,
                Text = "0",
                Font = new Font("Segoe UI", 10F)
            };

            lblTamTinh = new Label
            {
                Text = "Tạm tính:         0 đ",
                Location = new Point(15, 55),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(44, 62, 80)
            };

            lblTongTien = new Label
            {
                Text = "Tổng tiền:        0 đ",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                Location = new Point(15, 90),
                AutoSize = true,
                ForeColor = Color.FromArgb(192, 57, 43)
            };

            btnThanhToan = new Button
            {
                Text = "💳 THANH TOÁN",
                Size = new Size(180, 50),
                Location = new Point(240, 120),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnThanhToan.FlatAppearance.BorderSize = 0;
            btnThanhToan.FlatAppearance.MouseOverBackColor = Color.FromArgb(39, 174, 96);

            pnlPayment.Controls.AddRange(new Control[]
                { lblLine, lblTamTinh, lblTongTien, lblKM, txtGiamGia, btnThanhToan });

            pnlRightArea.Controls.AddRange(new Control[] { pnlPayment, pnlCarts, lblCart });
            this.Controls.AddRange(new Control[] { pnlRightArea, pnlLeftArea });

            btnTabSP.Click += (s, e) =>
            {
                isShowingService = false;
                btnTabSP.BackColor = Color.FromArgb(41, 128, 185);
                btnTabDV.BackColor = Color.FromArgb(189, 195, 199);
                RefreshMainList();
            };
            btnTabDV.Click += (s, e) =>
            {
                isShowingService = true;
                btnTabDV.BackColor = Color.FromArgb(155, 89, 182);
                btnTabSP.BackColor = Color.FromArgb(189, 195, 199);
                RefreshMainList();
            };

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
                ReadOnly = true,
                BorderStyle = BorderStyle.None
            };
        }

        private void StyleGrid(DataGridView dgv, Color headerColor)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 36;
            dgv.RowTemplate.Height = 36;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
        }

        private void RefreshMainList()
        {
            dgvList.Rows.Clear();
            var items = database.Where(x => x.IsService == isShowingService);

            string keyword = txtSearch?.Text;
            if (!string.IsNullOrWhiteSpace(keyword) && keyword != "Tìm kiếm...")
                items = items.Where(x => x.Ten.ToLower().Contains(keyword.ToLower()));

            foreach (var i in items)
                dgvList.Rows.Add(i.ID, i.Ten, i.Gia.ToString("N0") + " đ",
                    i.IsService ? "—" : i.TonKho.ToString());
        }

        private void DgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != dgvList.Columns["Add"].Index || e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells["ID"].Value);
            var item = database.FirstOrDefault(x => x.ID == id);
            if (item == null) return;

            if (!item.IsService && item.TonKho <= 0)
            {
                MessageBox.Show("Sản phẩm đã hết hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cartItem = cart.FirstOrDefault(x => x.RootItem.ID == id);
            if (cartItem != null) cartItem.SoLuong++;
            else cart.Add(new CartItem { RootItem = item, SoLuong = 1 });

            UpdateCartGrids();
        }

        private void UpdateCartGrids()
        {
            dgvCartProd.Rows.Clear();
            dgvCartSer.Rows.Clear();
            foreach (var c in cart)
            {
                double tt = c.ThanhTien;
                if (c.RootItem.IsService)
                    dgvCartSer.Rows.Add(c.RootItem.ID, c.RootItem.Ten, c.SoLuong, tt.ToString("N0") + " đ");
                else
                    dgvCartProd.Rows.Add(c.RootItem.ID, c.RootItem.Ten, c.SoLuong, tt.ToString("N0") + " đ");
            }
            UpdateCartTotal();
        }

        private void UpdateCartTotal()
        {
            double subtotal = cart.Sum(c => c.ThanhTien);
            double.TryParse(txtGiamGia.Text, out double discount);
            double final = subtotal * (1 - discount / 100);

            lblTamTinh.Text = $"Tạm tính:         {subtotal.ToString("N0")} đ";
            lblTongTien.Text = $"Tổng tiền:        {final.ToString("N0")} đ";
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var c in cart)
                if (!c.RootItem.IsService) c.RootItem.TonKho -= c.SoLuong;

            SaveAppointmentsToDB();

            MessageBox.Show("✅ Thanh toán thành công!\n💰 " + lblTongTien.Text,
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            cart.Clear();
            txtGiamGia.Text = "0";
            UpdateCartGrids();
            RefreshMainList();
        }
    }
}