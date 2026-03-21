using HTQuanLyThuCung.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyThuCung
{
    public partial class frmKhachHang : Form
    {
        private List<Customer> customers;
        private List<Pet> pets;
        private int currentMaxId = 0;
        private int currentMaxPetId = 0;

        private readonly Color primaryColor = Color.FromArgb(41, 128, 185);
        private readonly Color secondaryColor = Color.FromArgb(52, 152, 219);
        private readonly Color accentColor = Color.FromArgb(46, 204, 113);
        private readonly Color dangerColor = Color.FromArgb(231, 76, 60);
        private readonly Color bgColor = Color.FromArgb(236, 240, 241);
        private readonly Color cardColor = Color.White;
        private readonly Color textColor = Color.FromArgb(44, 62, 80);

        public frmKhachHang()
        {
            InitializeComponent();
            LoadDataFromDB();
            LoadCustomerList();
            SetButtonRounded(btnAdd, 18);
            ApplyModernTheme();
        }

        private void LoadDataFromDB()
        {
            try
            {
                customers = new List<Customer>();
                DataTable dtCustomers = DatabaseHelper.ExecuteQuery(
                    "SELECT * FROM Customers ORDER BY Id");
                foreach (DataRow row in dtCustomers.Rows)
                {
                    customers.Add(new Customer
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Name = row["CustomerName"].ToString(),
                        Phone = row["Phone"].ToString(),
                        Address = row["Address"].ToString(),
                        Email = "",
                        OtherInfo = ""
                    });
                }

                pets = new List<Pet>();
                DataTable dtPets = DatabaseHelper.ExecuteStoredProcedure("sp_GetPets");
                foreach (DataRow row in dtPets.Rows)
                {
                    var owner = customers.FirstOrDefault(
                        c => c.Name == row["CustomerName"].ToString());
                    pets.Add(new Pet
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Name = row["PetName"].ToString(),
                        Type = row["Species"].ToString(),
                        Breed = row["Breed"].ToString(),
                        Age = Convert.ToInt32(row["Age"]),
                        CustomerId = owner?.Id ?? 0
                    });
                }

                currentMaxId = customers.Count > 0 ? customers.Max(c => c.Id) : 0;
                currentMaxPetId = pets.Count > 0 ? pets.Max(p => p.Id) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu từ DB: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                customers = new List<Customer>();
                pets = new List<Pet>();
            }
        }

        private void AddCustomerToDB(Customer c)
        {
            string query = @"INSERT INTO Customers (CustomerName, Phone, Address)
                             VALUES (@Name, @Phone, @Address);
                             SELECT SCOPE_IDENTITY();";
            var id = DatabaseHelper.ExecuteScalar(query,
                new System.Data.SqlClient.SqlParameter("@Name", c.Name),
                new System.Data.SqlClient.SqlParameter("@Phone", c.Phone),
                new System.Data.SqlClient.SqlParameter("@Address", c.Address));
            c.Id = Convert.ToInt32(id);
        }

        private void DeleteCustomerFromDB(int customerId)
        {
            DatabaseHelper.ExecuteNonQuery(
                @"DELETE FROM Appointments WHERE PetId IN
                  (SELECT Id FROM Pets WHERE CustomerId = @Id)",
                new System.Data.SqlClient.SqlParameter("@Id", customerId));

            DatabaseHelper.ExecuteNonQuery(
                "DELETE FROM Pets WHERE CustomerId = @Id",
                new System.Data.SqlClient.SqlParameter("@Id", customerId));

            DatabaseHelper.ExecuteNonQuery(
                "DELETE FROM Customers WHERE Id = @Id",
                new System.Data.SqlClient.SqlParameter("@Id", customerId));
        }

        private void ApplyModernTheme()
        {
            this.BackColor = bgColor;
            this.ForeColor = textColor;
            panelMain.BackColor = bgColor;

            dgvCustomers.BackgroundColor = cardColor;
            dgvCustomers.GridColor = Color.FromArgb(189, 195, 199);
            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCustomers.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvCustomers.ColumnHeadersHeight = 45;
            dgvCustomers.EnableHeadersVisualStyles = false;
            dgvCustomers.RowTemplate.Height = 45;
            dgvCustomers.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvCustomers.DefaultCellStyle.ForeColor = textColor;
            dgvCustomers.DefaultCellStyle.BackColor = cardColor;
            dgvCustomers.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 249, 250);
            dgvCustomers.DefaultCellStyle.SelectionBackColor = secondaryColor;
            dgvCustomers.DefaultCellStyle.SelectionForeColor = Color.White;

            btnAdd.BackColor = accentColor;
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(39, 174, 96);
            btnAdd.FlatAppearance.MouseDownBackColor = Color.FromArgb(39, 174, 96);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            lblTitle.ForeColor = primaryColor;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        }

        private void ResetIds()
        {
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

        private class frmNhapKhachHang : Form
        {
            private TextBox txtName, txtPhone, txtAddress;
            private Button btnLuu, btnHuy;
            private Label lblName, lblPhone, lblAddress;
            private Panel headerPanel;
            private Label lblTitleForm;

            public frmNhapKhachHang()
            {
                InitializeFormComponents();
            }

            private void InitializeFormComponents()
            {
                Color primaryColor = Color.FromArgb(41, 128, 185);
                Color accentColor = Color.FromArgb(46, 204, 113);
                Color dangerColor = Color.FromArgb(231, 76, 60);
                Color bgColor = Color.FromArgb(245, 247, 250);
                Color cardColor = Color.White;
                Color textColor = Color.FromArgb(44, 62, 80);

                this.Text = "Thêm khách hàng mới";
                this.Size = new Size(560, 400);
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.StartPosition = FormStartPosition.CenterParent;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.BackColor = bgColor;

                headerPanel = new Panel
                {
                    BackColor = primaryColor,
                    Location = new Point(0, 0),
                    Size = new Size(560, 70)
                };
                lblTitleForm = new Label
                {
                    Text = "📝 THÊM KHÁCH HÀNG MỚI",
                    Location = new Point(0, 20),
                    Size = new Size(560, 30),
                    Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                    ForeColor = Color.White,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                headerPanel.Controls.Add(lblTitleForm);
                this.Controls.Add(headerPanel);

                // Helper tạo label
                Action<Label, string, int> addLabel = (lbl, text, y) =>
                {
                    lbl.Text = text;
                    lbl.Location = new Point(30, y);
                    lbl.Size = new Size(500, 22);
                    lbl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    lbl.ForeColor = textColor;
                    this.Controls.Add(lbl);
                };

                Action<TextBox, int> addTextBox = (txt, y) =>
                {
                    txt.Location = new Point(30, y);
                    txt.Size = new Size(500, 32);
                    txt.Font = new Font("Segoe UI", 10F);
                    txt.BackColor = cardColor;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    this.Controls.Add(txt);
                };

                lblName = new Label(); txtName = new TextBox();
                lblPhone = new Label(); txtPhone = new TextBox();
                lblAddress = new Label(); txtAddress = new TextBox();

                addLabel(lblName, "Họ và tên:", 85); addTextBox(txtName, 110);
                addLabel(lblPhone, "Số điện thoại:", 152); addTextBox(txtPhone, 177);
                addLabel(lblAddress, "Địa chỉ:", 219); addTextBox(txtAddress, 244);

                btnLuu = new Button
                {
                    Text = "💾 Lưu",
                    Location = new Point(190, 295),
                    Size = new Size(140, 42),
                    BackColor = accentColor,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand
                };
                btnLuu.FlatAppearance.BorderSize = 0;
                btnLuu.FlatAppearance.MouseOverBackColor = Color.FromArgb(39, 174, 96);
                btnLuu.Click += btnLuu_Click;
                this.Controls.Add(btnLuu);

                btnHuy = new Button
                {
                    Text = "❌ Hủy",
                    Location = new Point(345, 295),
                    Size = new Size(140, 42),
                    BackColor = dangerColor,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    DialogResult = DialogResult.Cancel
                };
                btnHuy.FlatAppearance.BorderSize = 0;
                btnHuy.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 57, 43);
                this.Controls.Add(btnHuy);

                this.AcceptButton = btnLuu;
                this.CancelButton = btnHuy;
            }

            private void btnLuu_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus(); return;
                }
                if (string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus(); return;
                }
                if (string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAddress.Focus(); return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            public Customer GetCustomerData()
            {
                return new Customer
                {
                    Name = txtName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Email = "",
                    OtherInfo = ""
                };
            }
        }

        private void LoadCustomerList()
        {
            dgvCustomers.Rows.Clear();
            int stt = 1;
            foreach (var customer in customers)
            {
                int rowIndex = dgvCustomers.Rows.Add();
                dgvCustomers.Rows[rowIndex].Cells["colId"].Value = stt++;
                dgvCustomers.Rows[rowIndex].Cells["colName"].Value = customer.Name;
                dgvCustomers.Rows[rowIndex].Cells["colAddress"].Value = customer.Address;
                dgvCustomers.Rows[rowIndex].Cells["colPhone"].Value = customer.Phone;
                dgvCustomers.Rows[rowIndex].Cells["colEmail"].Value = customer.Email;
                dgvCustomers.Rows[rowIndex].Cells["colOtherInfo"].Value = customer.OtherInfo;
                dgvCustomers.Rows[rowIndex].Tag = customer.Id; // ✅ Lưu ID thật
            }
            dgvCustomers.Refresh();
        }

        private void dgvCustomers_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvCustomers.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                e.RowIndex % 2 == 0 ? Color.FromArgb(248, 249, 250) : Color.White;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (frmNhapKhachHang inputForm = new frmNhapKhachHang())
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    Customer newCustomer = inputForm.GetCustomerData();
                    try
                    {
                        AddCustomerToDB(newCustomer);
                        customers.Add(newCustomer);
                        currentMaxId = newCustomer.Id;
                        LoadCustomerList();
                        MessageBox.Show(
                            $"✅ Thêm thành công!\n👤 Tên: {newCustomer.Name}",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi thêm khách hàng: " + ex.Message,
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int customerId = (int)dgvCustomers.Rows[e.RowIndex].Tag;

            if (dgvCustomers.Columns[e.ColumnIndex].Name == "colView")
            {
                ViewCustomerDetail(customerId);
            }
            else if (dgvCustomers.Columns[e.ColumnIndex].Name == "colDelete")
            {
                string name = dgvCustomers.Rows[e.RowIndex].Cells["colName"].Value.ToString();
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng \"{name}\"?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    == DialogResult.Yes)
                {
                    DeleteCustomer(customerId);
                }
            }
        }

        private void ViewCustomerDetail(int customerId)
        {
            Customer customer = customers.Find(c => c.Id == customerId);
            if (customer == null) return;

            var histories = new List<PurchaseHistory>();
            var customerPets = pets.FindAll(p => p.CustomerId == customerId);

            frmKhachHang_ChiTiet detailForm =
                new frmKhachHang_ChiTiet(customer, histories, customerPets, this);
            detailForm.ShowDialog();
        }

        private void DeleteCustomer(int customerId)
        {
            try
            {
                DeleteCustomerFromDB(customerId);
                customers.RemoveAll(c => c.Id == customerId);
                pets.RemoveAll(p => p.CustomerId == customerId);
                ResetIds();
                LoadCustomerList();
                MessageBox.Show("Xóa khách hàng thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa khách hàng: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshPetList(int customerId, List<Pet> updatedPets)
        {
            pets.RemoveAll(p => p.CustomerId == customerId);
            pets.AddRange(updatedPets.Where(p => p.CustomerId == customerId));
            if (pets.Count > 0) currentMaxPetId = pets.Max(p => p.Id);
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