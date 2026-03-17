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
        private int currentMaxId = 0;

        public frmKhachHang()
        {
            InitializeComponent();
            InitializeData();
            LoadCustomerList();
            SetButtonRounded(btnAdd, 18);
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

        // Form nhập liệu khách hàng đầy đủ
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

            public frmNhapKhachHang()
            {
                InitializeComponent();
            }

            private void InitializeComponent()
            {
                this.Text = "Thêm khách hàng mới";
                this.Size = new System.Drawing.Size(550, 500);
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.StartPosition = FormStartPosition.CenterParent;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.BackColor = Color.FromArgb(245, 245, 245);

                this.lblName = new Label();
                this.lblName.Text = "Tên khách hàng:";
                this.lblName.Location = new Point(30, 25);
                this.lblName.Size = new Size(470, 20);
                this.lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                this.Controls.Add(this.lblName);

                this.txtName = new TextBox();
                this.txtName.Location = new Point(30, 50);
                this.txtName.Size = new Size(470, 30);
                this.txtName.Font = new Font("Segoe UI", 10F);
                this.Controls.Add(this.txtName);

                this.lblPhone = new Label();
                this.lblPhone.Text = "Số điện thoại:";
                this.lblPhone.Location = new Point(30, 95);
                this.lblPhone.Size = new Size(470, 20);
                this.lblPhone.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                this.Controls.Add(this.lblPhone);

                this.txtPhone = new TextBox();
                this.txtPhone.Location = new Point(30, 120);
                this.txtPhone.Size = new Size(470, 30);
                this.txtPhone.Font = new Font("Segoe UI", 10F);
                this.Controls.Add(this.txtPhone);

                this.lblAddress = new Label();
                this.lblAddress.Text = "Địa chỉ:";
                this.lblAddress.Location = new Point(30, 165);
                this.lblAddress.Size = new Size(470, 20);
                this.lblAddress.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                this.Controls.Add(this.lblAddress);

                this.txtAddress = new TextBox();
                this.txtAddress.Location = new Point(30, 190);
                this.txtAddress.Size = new Size(470, 30);
                this.txtAddress.Font = new Font("Segoe UI", 10F);
                this.Controls.Add(this.txtAddress);

                this.lblEmail = new Label();
                this.lblEmail.Text = "Email:";
                this.lblEmail.Location = new Point(30, 235);
                this.lblEmail.Size = new Size(470, 20);
                this.lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                this.Controls.Add(this.lblEmail);

                this.txtEmail = new TextBox();
                this.txtEmail.Location = new Point(30, 260);
                this.txtEmail.Size = new Size(470, 30);
                this.txtEmail.Font = new Font("Segoe UI", 10F);
                this.Controls.Add(this.txtEmail);

                this.lblOtherInfo = new Label();
                this.lblOtherInfo.Text = "Thông tin thêm:";
                this.lblOtherInfo.Location = new Point(30, 305);
                this.lblOtherInfo.Size = new Size(470, 20);
                this.lblOtherInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                this.Controls.Add(this.lblOtherInfo);

                this.txtOtherInfo = new TextBox();
                this.txtOtherInfo.Location = new Point(30, 330);
                this.txtOtherInfo.Size = new Size(470, 50);
                this.txtOtherInfo.Multiline = true;
                this.txtOtherInfo.Font = new Font("Segoe UI", 10F);
                this.Controls.Add(this.txtOtherInfo);

                // ✅ SỬA: Thêm event Click thay vì set DialogResult
                this.btnLuu = new Button();
                this.btnLuu.Text = "Lưu";
                this.btnLuu.Location = new Point(280, 400);
                this.btnLuu.Size = new Size(100, 35);
                this.btnLuu.BackColor = Color.FromArgb(76, 175, 80);
                this.btnLuu.ForeColor = Color.White;
                this.btnLuu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                this.btnLuu.FlatStyle = FlatStyle.Flat;
                this.btnLuu.FlatAppearance.BorderSize = 0;
                this.btnLuu.Cursor = Cursors.Hand;
                this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click); // ✅ Event click
                this.Controls.Add(this.btnLuu);

                this.btnHuy = new Button();
                this.btnHuy.Text = "Hủy";
                this.btnHuy.Location = new Point(400, 400);
                this.btnHuy.Size = new Size(100, 35);
                this.btnHuy.BackColor = Color.FromArgb(158, 158, 158);
                this.btnHuy.ForeColor = Color.White;
                this.btnHuy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                this.btnHuy.FlatStyle = FlatStyle.Flat;
                this.btnHuy.FlatAppearance.BorderSize = 0;
                this.btnHuy.Cursor = Cursors.Hand;
                this.btnHuy.DialogResult = DialogResult.Cancel;
                this.Controls.Add(this.btnHuy);

                this.AcceptButton = this.btnLuu;
                this.CancelButton = this.btnHuy;
            }

            // ✅ VALIDATION Ở ĐÂY - KHÔNG ĐÓNG FORM NẾU LỖI
            private void btnLuu_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrWhiteSpace(this.txtName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtName.Focus();
                    return; // ✅ Không đóng form
                }

                if (string.IsNullOrWhiteSpace(this.txtPhone.Text))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtPhone.Focus();
                    return; // ✅ Không đóng form
                }

                // ✅ Validation pass mới đóng form
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
                new Customer { Id = 5, Name = "Hoàng Văn Tuấn", Address = "654 Nguyễn Đình Chiểu, P.3, Q.1, TP.HCM", Phone = "0945678901", Email = "tuan.hoang@gmail.com", OtherInfo = "" },
                new Customer { Id = 6, Name = "Võ Thị Hương", Address = "987 Pasteur, P.Bến Nghé, Q.1, TP.HCM", Phone = "0956789012", Email = "huong.vo@gmail.com", OtherInfo = "Khách VIP" },
                new Customer { Id = 7, Name = "Đặng Văn Cường", Address = "246 Nguyễn Trãi, P.Nguyễn Cư Trinh, Q.1, TP.HCM", Phone = "0967890123", Email = "cuong.dang@gmail.com", OtherInfo = "" },
                new Customer { Id = 8, Name = "Bùi Thị Nhung", Address = "135 Nguyễn Văn Cừ, P.2, Q.5, TP.HCM", Phone = "0978901234", Email = "nhung.bui@gmail.com", OtherInfo = "Thích mua thức ăn cho chó" },
                new Customer { Id = 9, Name = "Lý Văn Hùng", Address = "468 Điện Biên Phủ, P.11, Q.10, TP.HCM", Phone = "0989012345", Email = "hung.ly@gmail.com", OtherInfo = "" },
                new Customer { Id = 10, Name = "Trương Thị Mỹ Linh", Address = "579 Nguyễn Kiệm, P.9, Phú Nhuận, TP.HCM", Phone = "0990123456", Email = "mylinh.truong@gmail.com", OtherInfo = "Khách quen" }
            };

            purchaseHistories = new List<PurchaseHistory>
            {
                new PurchaseHistory { InvoiceId = 101, CustomerId = 1, Date = new DateTime(2024, 1, 15, 10, 30, 0), TotalAmount = 1250000, Employee = "Nguyễn Thị Hương" },
                new PurchaseHistory { InvoiceId = 102, CustomerId = 1, Date = new DateTime(2024, 2, 20, 14, 15, 0), TotalAmount = 850000, Employee = "Trần Văn Nam" },
                new PurchaseHistory { InvoiceId = 103, CustomerId = 2, Date = new DateTime(2024, 3, 5, 9, 45, 0), TotalAmount = 2100000, Employee = "Nguyễn Thị Hương" },
                new PurchaseHistory { InvoiceId = 104, CustomerId = 3, Date = new DateTime(2024, 3, 10, 16, 20, 0), TotalAmount = 650000, Employee = "Lê Thị Mai" },
                new PurchaseHistory { InvoiceId = 105, CustomerId = 4, Date = new DateTime(2024, 3, 12, 11, 0, 0), TotalAmount = 1500000, Employee = "Nguyễn Thị Hương" },
                new PurchaseHistory { InvoiceId = 106, CustomerId = 5, Date = new DateTime(2024, 3, 15, 15, 30, 0), TotalAmount = 950000, Employee = "Trần Văn Nam" },
                new PurchaseHistory { InvoiceId = 107, CustomerId = 6, Date = new DateTime(2024, 3, 18, 10, 0, 0), TotalAmount = 3200000, Employee = "Lê Thị Mai" },
                new PurchaseHistory { InvoiceId = 108, CustomerId = 7, Date = new DateTime(2024, 3, 20, 14, 45, 0), TotalAmount = 780000, Employee = "Nguyễn Thị Hương" },
                new PurchaseHistory { InvoiceId = 109, CustomerId = 8, Date = new DateTime(2024, 3, 22, 9, 15, 0), TotalAmount = 1100000, Employee = "Trần Văn Nam" },
                new PurchaseHistory { InvoiceId = 110, CustomerId = 9, Date = new DateTime(2024, 3, 25, 16, 0, 0), TotalAmount = 2500000, Employee = "Lê Thị Mai" }
            };

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
                dgvCustomers.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
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

                    // ✅ Validation đã xử lý trong form rồi
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

                    MessageBox.Show($"✅ Thêm thành công!\nID: {newCustomer.Id}\nTên: {newCustomer.Name}",
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

            frmKhachHang_ChiTiet detailForm = new frmKhachHang_ChiTiet(customer, customerHistories);
            detailForm.ShowDialog();
        }

        private void DeleteCustomer(int customerId)
        {
            customers.RemoveAll(c => c.Id == customerId);
            purchaseHistories.RemoveAll(h => h.CustomerId == customerId);

            ResetIds();

            LoadCustomerList();
            MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int GetNextId()
        {
            return currentMaxId + 1;
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