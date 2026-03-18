using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyThuCung
{
    public partial class frmKhachHang : Form
    {
        private List<Customer> customers;
        private List<PurchaseHistory> purchaseHistories;
        private List<Pet> pets;
        private int currentMaxId = 0;
        private int currentMaxPetId = 0;

        private readonly Color primaryColor = Color.FromArgb(41, 128, 185);      
        private readonly Color secondaryColor = Color.FromArgb(52, 152, 219);    
        private readonly Color accentColor = Color.FromArgb(46, 204, 113);       
        private readonly Color dangerColor = Color.FromArgb(231, 76, 60);        
        private readonly Color warningColor = Color.FromArgb(241, 196, 15);      
        private readonly Color bgColor = Color.FromArgb(236, 240, 241);          
        private readonly Color cardColor = Color.White;                           
        private readonly Color textColor = Color.FromArgb(44, 62, 80);           

        public frmKhachHang()
        {
            InitializeComponent();
            InitializeData();
            LoadCustomerList();
            SetButtonRounded(btnAdd, 18);
            ApplyModernTheme();
        }

        private void ApplyModernTheme()
        {
            this.BackColor = bgColor;
            this.ForeColor = textColor;

            // Panel chính
            panelMain.BackColor = bgColor;

            // DataGridView
            dgvCustomers.BackgroundColor = cardColor;
            dgvCustomers.GridColor = Color.FromArgb(189, 195, 199);
            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCustomers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvCustomers.ColumnHeadersHeight = 45;
            dgvCustomers.EnableHeadersVisualStyles = false;
            dgvCustomers.RowTemplate.Height = 45;
            dgvCustomers.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvCustomers.DefaultCellStyle.ForeColor = textColor;
            dgvCustomers.DefaultCellStyle.BackColor = cardColor;
            dgvCustomers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvCustomers.DefaultCellStyle.SelectionBackColor = secondaryColor;
            dgvCustomers.DefaultCellStyle.SelectionForeColor = Color.White;

            // Nút Thêm
            btnAdd.BackColor = accentColor;
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(39, 174, 96);
            btnAdd.FlatAppearance.MouseDownBackColor = Color.FromArgb(39, 174, 96);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            // Label tiêu đề
            lblTitle.ForeColor = primaryColor;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        }

        private void ResetIds()
        {
            int newId = 1;
            foreach (var customer in customers)
            {
                customer.Id = newId++;
            }
            currentMaxId = customers.Count > 0 ? customers.Max(c => c.Id) : 0;
        }

        public class Pet
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public string Breed { get; set; }
            public int Age { get; set; }
            public int CustomerId { get; set; }
        }

        // Form nhập liệu khách hàng với màu sắc đẹp
        private class frmNhapKhachHang : Form
        {
            private TextBox txtName;
            private TextBox txtPhone;
            private TextBox txtAddress;
            private TextBox txtEmail;
            private TextBox txtOtherInfo;
            private Button btnLuu;
            private Button btnHuy;
            private Label lblName;
            private Label lblPhone;
            private Label lblAddress;
            private Label lblEmail;
            private Label lblOtherInfo;
            private Panel headerPanel;
            private Label lblTitle;

            public frmNhapKhachHang()
            {
                InitializeComponent();
            }

            private void InitializeComponent()
            {
                Color primaryColor = Color.FromArgb(41, 128, 185);
                Color accentColor = Color.FromArgb(46, 204, 113);
                Color dangerColor = Color.FromArgb(231, 76, 60);
                Color bgColor = Color.FromArgb(245, 247, 250);
                Color cardColor = Color.White;
                Color textColor = Color.FromArgb(44, 62, 80);

                this.Text = "Thêm khách hàng mới";
                this.Size = new System.Drawing.Size(600, 620);
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.StartPosition = FormStartPosition.CenterParent;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.BackColor = bgColor;

                // Header panel với màu gradient
                this.headerPanel = new Panel();
                this.headerPanel.BackColor = primaryColor;
                this.headerPanel.Location = new Point(0, 0);
                this.headerPanel.Size = new Size(600, 80);
                this.Controls.Add(this.headerPanel);

                // Title trong header
                this.lblTitle = new Label();
                this.lblTitle.Text = "📝 THÔNG TIN KHÁCH HÀNG";
                this.lblTitle.Location = new Point(20, 25);
                this.lblTitle.Size = new Size(560, 30);
                this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                this.lblTitle.ForeColor = Color.White;
                this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
                this.headerPanel.Controls.Add(this.lblTitle);

                this.lblName = new Label();
                this.lblName.Text = "Họ và tên:";
                this.lblName.Location = new Point(30, 100);
                this.lblName.Size = new Size(520, 25);
                this.lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                this.lblName.ForeColor = textColor;
                this.Controls.Add(this.lblName);

                this.txtName = new TextBox();
                this.txtName.Location = new Point(30, 128);
                this.txtName.Size = new Size(520, 35);
                this.txtName.Font = new Font("Segoe UI", 10F);
                this.txtName.BackColor = cardColor;
                this.txtName.BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(this.txtName);

                this.lblPhone = new Label();
                this.lblPhone.Text = "Số điện thoại:";
                this.lblPhone.Location = new Point(30, 178);
                this.lblPhone.Size = new Size(520, 25);
                this.lblPhone.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                this.lblPhone.ForeColor = textColor;
                this.Controls.Add(this.lblPhone);

                this.txtPhone = new TextBox();
                this.txtPhone.Location = new Point(30, 206);
                this.txtPhone.Size = new Size(520, 35);
                this.txtPhone.Font = new Font("Segoe UI", 10F);
                this.txtPhone.BackColor = cardColor;
                this.txtPhone.BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(this.txtPhone);

                this.lblAddress = new Label();
                this.lblAddress.Text = "Địa chỉ:";
                this.lblAddress.Location = new Point(30, 256);
                this.lblAddress.Size = new Size(520, 25);
                this.lblAddress.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                this.lblAddress.ForeColor = textColor;
                this.Controls.Add(this.lblAddress);

                this.txtAddress = new TextBox();
                this.txtAddress.Location = new Point(30, 284);
                this.txtAddress.Size = new Size(520, 35);
                this.txtAddress.Font = new Font("Segoe UI", 10F);
                this.txtAddress.BackColor = cardColor;
                this.txtAddress.BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(this.txtAddress);

                this.lblEmail = new Label();
                this.lblEmail.Text = "Email:";
                this.lblEmail.Location = new Point(30, 334);
                this.lblEmail.Size = new Size(520, 25);
                this.lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                this.lblEmail.ForeColor = textColor;
                this.Controls.Add(this.lblEmail);

                this.txtEmail = new TextBox();
                this.txtEmail.Location = new Point(30, 362);
                this.txtEmail.Size = new Size(520, 35);
                this.txtEmail.Font = new Font("Segoe UI", 10F);
                this.txtEmail.BackColor = cardColor;
                this.txtEmail.BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(this.txtEmail);

                this.lblOtherInfo = new Label();
                this.lblOtherInfo.Text = "Thông tin thêm:";
                this.lblOtherInfo.Location = new Point(30, 412);
                this.lblOtherInfo.Size = new Size(520, 25);
                this.lblOtherInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                this.lblOtherInfo.ForeColor = textColor;
                this.Controls.Add(this.lblOtherInfo);

                this.txtOtherInfo = new TextBox();
                this.txtOtherInfo.Location = new Point(30, 440);
                this.txtOtherInfo.Size = new Size(520, 70);
                this.txtOtherInfo.Multiline = true;
                this.txtOtherInfo.Font = new Font("Segoe UI", 10F);
                this.txtOtherInfo.BackColor = cardColor;
                this.txtOtherInfo.BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(this.txtOtherInfo);

                this.btnLuu = new Button();
                this.btnLuu.Text = "💾 Lưu thông tin";
                this.btnLuu.Location = new Point(250, 530);
                this.btnLuu.Size = new Size(150, 40);
                this.btnLuu.BackColor = accentColor;
                this.btnLuu.ForeColor = Color.White;
                this.btnLuu.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                this.btnLuu.FlatStyle = FlatStyle.Flat;
                this.btnLuu.FlatAppearance.BorderSize = 0;
                this.btnLuu.Cursor = Cursors.Hand;
                this.btnLuu.FlatAppearance.MouseOverBackColor = Color.FromArgb(39, 174, 96);
                this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
                this.Controls.Add(this.btnLuu);

                this.btnHuy = new Button();
                this.btnHuy.Text = "❌ Hủy";
                this.btnHuy.Location = new Point(410, 530);
                this.btnHuy.Size = new Size(140, 40);
                this.btnHuy.BackColor = dangerColor;
                this.btnHuy.ForeColor = Color.White;
                this.btnHuy.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                this.btnHuy.FlatStyle = FlatStyle.Flat;
                this.btnHuy.FlatAppearance.BorderSize = 0;
                this.btnHuy.Cursor = Cursors.Hand;
                this.btnHuy.DialogResult = DialogResult.Cancel;
                this.btnHuy.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 57, 43);
                this.Controls.Add(this.btnHuy);

                this.AcceptButton = this.btnLuu;
                this.CancelButton = this.btnHuy;
            }

            private void btnLuu_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrWhiteSpace(this.txtName.Text))
                {
                    MessageBox.Show("❌ Vui lòng nhập tên khách hàng!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(this.txtPhone.Text))
                {
                    MessageBox.Show("❌ Vui lòng nhập số điện thoại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtPhone.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(this.txtAddress.Text))
                {
                    MessageBox.Show("❌ Vui lòng nhập địa chỉ!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtAddress.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(this.txtEmail.Text))
                {
                    MessageBox.Show("❌ Vui lòng nhập email!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtEmail.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(this.txtOtherInfo.Text))
                {
                    MessageBox.Show("❌ Vui lòng nhập thông tin thêm!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtOtherInfo.Focus();
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            public Customer GetCustomerData()
            {
                return new Customer
                {
                    Name = this.txtName.Text.Trim(),
                    Phone = this.txtPhone.Text.Trim(),
                    Address = this.txtAddress.Text.Trim(),
                    Email = this.txtEmail.Text.Trim(),
                    OtherInfo = this.txtOtherInfo.Text.Trim()
                };
            }
        }

        private void InitializeData()
        {
            customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Nguyễn Văn Minh", Address = "123 Nguyễn Văn A, P.5, Q.3, TP.HCM", Phone = "0901234567", Email = "minh.nguyen@gmail.com", OtherInfo = "Khách thân thiết" },
                new Customer { Id = 2, Name = "Trần Thị Lan", Address = "456 Lê Lợi, P.1, Q.1, TP.HCM", Phone = "0912345678", Email = "lan.tran@gmail.com", OtherInfo = "Mua thường xuyên" },
                new Customer { Id = 3, Name = "Lê Hoàng Dũng", Address = "789 Võ Văn Tần, P.6, Q.3, TP.HCM", Phone = "0923456789", Email = "dung.le@gmail.com", OtherInfo = "" },
                new Customer { Id = 4, Name = "Phạm Thị Mai", Address = "321 CM Tháng 8, P.12, Q.10, TP.HCM", Phone = "0934567890", Email = "mai.pham@gmail.com", OtherInfo = "Thích đồ cao cấp" },
                new Customer { Id = 5, Name = "Hoàng Văn Tuấn", Address = "654 Nguyễn Đình Chiểu, P.3, Q.1, TP.HCM", Phone = "0945678901", Email = "tuan.hoang@gmail.com", OtherInfo = "" }
            };

            pets = new List<Pet>
            {
                new Pet { Id = 1, Name = "Pun", Type = "Chó", Breed = "Poodle", Age = 2, CustomerId = 1 },
                new Pet { Id = 2, Name = "Miso", Type = "Chó", Breed = "Poodle", Age = 3, CustomerId = 1 },
                new Pet { Id = 3, Name = "Mimi", Type = "Mèo", Breed = "Anh lông ngắn", Age = 1, CustomerId = 2 },
                new Pet { Id = 4, Name = "Bông", Type = "Mèo", Breed = "Ba Tư", Age = 2, CustomerId = 3 },
                new Pet { Id = 5, Name = "Vàng", Type = "Chó", Breed = "Phốc", Age = 1, CustomerId = 4 }
            };

            purchaseHistories = new List<PurchaseHistory>
            {
                new PurchaseHistory { InvoiceId = 101, CustomerId = 1, Date = new DateTime(2026, 1, 15, 10, 30, 0), TotalAmount = 1250000, Employee = "Nguyễn Thị Hương" },
                new PurchaseHistory { InvoiceId = 102, CustomerId = 1, Date = new DateTime(2026, 2, 20, 14, 15, 0), TotalAmount = 850000, Employee = "Trần Văn Nam" },
                new PurchaseHistory { InvoiceId = 103, CustomerId = 2, Date = new DateTime(2026, 3, 5, 9, 45, 0), TotalAmount = 2100000, Employee = "Nguyễn Thị Hương" },
                new PurchaseHistory { InvoiceId = 104, CustomerId = 3, Date = new DateTime(2026, 3, 10, 16, 20, 0), TotalAmount = 650000, Employee = "Lê Thị Mai" },
                new PurchaseHistory { InvoiceId = 105, CustomerId = 4, Date = new DateTime(2026, 3, 12, 11, 0, 0), TotalAmount = 1500000, Employee = "Nguyễn Thị Hương" }
            };

            currentMaxPetId = pets.Count > 0 ? pets.Max(p => p.Id) : 0;
            ResetIds();
        }

        private void LoadCustomerList()
        {
            dgvCustomers.Rows.Clear();
            dgvCustomers.Refresh();

            foreach (var customer in customers)
            {
                int rowIndex = dgvCustomers.Rows.Add();
                dgvCustomers.Rows[rowIndex].Cells["colId"].Value = customer.Id;
                dgvCustomers.Rows[rowIndex].Cells["colName"].Value = customer.Name;
                dgvCustomers.Rows[rowIndex].Cells["colAddress"].Value = customer.Address;
                dgvCustomers.Rows[rowIndex].Cells["colPhone"].Value = customer.Phone;
                dgvCustomers.Rows[rowIndex].Cells["colEmail"].Value = customer.Email;
                dgvCustomers.Rows[rowIndex].Cells["colOtherInfo"].Value = customer.OtherInfo;
                dgvCustomers.Rows[rowIndex].Cells["colView"].Value = "👁";
                dgvCustomers.Rows[rowIndex].Cells["colDelete"].Value = "🗑";
            }

            dgvCustomers.Update();
            dgvCustomers.Refresh();
        }

        private void dgvCustomers_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dgvCustomers.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            }
            else
            {
                dgvCustomers.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (frmNhapKhachHang inputForm = new frmNhapKhachHang())
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    Customer newCustomer = inputForm.GetCustomerData();

                    newCustomer.Id = GetNextId();
                    customers.Add(newCustomer);

                    currentMaxId = newCustomer.Id;

                    LoadCustomerList();

                    if (dgvCustomers.Rows.Count > 0)
                    {
                        int lastRowIndex = dgvCustomers.Rows.Count - 1;
                        dgvCustomers.FirstDisplayedScrollingRowIndex = lastRowIndex;
                        dgvCustomers.ClearSelection();
                        dgvCustomers.Rows[lastRowIndex].Selected = true;
                    }

                    MessageBox.Show($"✅ Thêm thành công!\n👤 ID: {newCustomer.Id}\n📛 Tên: {newCustomer.Name}",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvCustomers.Columns[e.ColumnIndex].Name == "colView")
            {
                int customerId = Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells["colId"].Value);
                ViewCustomerDetail(customerId);
            }
            else if (dgvCustomers.Columns[e.ColumnIndex].Name == "colDelete")
            {
                int customerId = Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells["colId"].Value);
                string customerName = dgvCustomers.Rows[e.RowIndex].Cells["colName"].Value.ToString();

                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng \"{customerName}\"?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DeleteCustomer(customerId);
                }
            }
        }

        private void ViewCustomerDetail(int customerId)
        {
            Customer customer = customers.Find(c => c.Id == customerId);
            if (customer == null) return;

            var customerHistories = purchaseHistories.FindAll(h => h.CustomerId == customerId);
            var customerPets = pets.FindAll(p => p.CustomerId == customerId);

            frmKhachHang_ChiTiet detailForm = new frmKhachHang_ChiTiet(customer, customerHistories, customerPets, this);
            detailForm.ShowDialog();
        }

        private void DeleteCustomer(int customerId)
        {
            customers.RemoveAll(c => c.Id == customerId);
            purchaseHistories.RemoveAll(h => h.CustomerId == customerId);
            pets.RemoveAll(p => p.CustomerId == customerId);

            ResetIds();

            LoadCustomerList();
            MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int GetNextId()
        {
            return currentMaxId + 1;
        }

        public void RefreshPetList(int customerId, List<Pet> updatedPets)
        {
            pets.RemoveAll(p => p.CustomerId == customerId);
            pets.AddRange(updatedPets.Where(p => p.CustomerId == customerId));

            if (pets.Count > 0)
                currentMaxPetId = pets.Max(p => p.Id);
        }

        private void SetButtonRounded(Button btn, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            btn.Region = new Region(path);
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OtherInfo { get; set; }
    }

    public class PurchaseHistory
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public string Employee { get; set; }
    }
}