using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyThuCung
{
    public partial class frmKhachHang_ChiTiet : Form
    {
        private Customer customer;
        private List<PurchaseHistory> purchaseHistories;
        private bool isEditMode = false;

        public frmKhachHang_ChiTiet(Customer customer, List<PurchaseHistory> histories)
        {
            InitializeComponent();
            this.customer = customer;
            this.purchaseHistories = histories;
            LoadData();
        }

        private void LoadData()
        {
            txtName.Text = customer.Name;
            txtPhone.Text = customer.Phone;
            txtAddress.Text = customer.Address;
            txtEmail.Text = customer.Email;
            txtOtherInfo.Text = customer.OtherInfo;

            dgvPurchaseHistory.Rows.Clear();
            foreach (var history in purchaseHistories)
            {
                int rowIndex = dgvPurchaseHistory.Rows.Add();
                dgvPurchaseHistory.Rows[rowIndex].Cells["colInvoiceId"].Value = history.InvoiceId;
                dgvPurchaseHistory.Rows[rowIndex].Cells["colDate"].Value = history.Date.ToString("dd/MM/yyyy HH:mm:ss");
                dgvPurchaseHistory.Rows[rowIndex].Cells["colTotal"].Value = history.TotalAmount.ToString("N0") + "đ";
                dgvPurchaseHistory.Rows[rowIndex].Cells["colEmployee"].Value = history.Employee;
            }

            SetReadOnlyMode(true);
        }

        private void SetReadOnlyMode(bool readOnly)
        {
            txtName.ReadOnly = readOnly;
            txtPhone.ReadOnly = readOnly;
            txtAddress.ReadOnly = readOnly;
            txtEmail.ReadOnly = readOnly;
            txtOtherInfo.ReadOnly = readOnly;

            if (readOnly)
            {
                txtName.BackColor = Color.FromArgb(220, 220, 220);
                txtPhone.BackColor = Color.FromArgb(220, 220, 220);
                txtAddress.BackColor = Color.FromArgb(220, 220, 220);
                txtEmail.BackColor = Color.FromArgb(220, 220, 220);
                txtOtherInfo.BackColor = Color.FromArgb(220, 220, 220);
                btnEdit.Text = "Sửa";
                btnEdit.BackColor = Color.FromArgb(76, 175, 80);
            }
            else
            {
                txtName.BackColor = Color.White;
                txtPhone.BackColor = Color.White;
                txtAddress.BackColor = Color.White;
                txtEmail.BackColor = Color.White;
                txtOtherInfo.BackColor = Color.White;
                btnEdit.Text = "Lưu";
                btnEdit.BackColor = Color.FromArgb(33, 150, 243);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                // Lưu thông tin
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                customer.Name = txtName.Text.Trim();
                customer.Phone = txtPhone.Text.Trim();
                customer.Address = txtAddress.Text.Trim();
                customer.Email = txtEmail.Text.Trim();
                customer.OtherInfo = txtOtherInfo.Text.Trim();

                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isEditMode = false;
                SetReadOnlyMode(true);
            }
            else
            {
                // Chế độ sửa
                isEditMode = true;
                SetReadOnlyMode(false);
                txtName.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}