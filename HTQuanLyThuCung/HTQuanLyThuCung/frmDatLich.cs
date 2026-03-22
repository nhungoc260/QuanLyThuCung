using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTQuanLyThuCung
{
    public partial class frmDatLich : Form
    {
        public string TenKH;
        public string ThuCung;
        public string DichVu;
        public string Gio;

        public frmDatLich()
        {
            InitializeComponent();

            cboDichVu.Items.Add("Tiêm Phòng");
            cboDichVu.Items.Add("Khám Sức Khỏe");
            cboDichVu.Items.Add("Tắm Spa");
            cboDichVu.Items.Add("Cắt Tỉa Lông");

            btnLuu.Click += btnLuu_Click;
            btnHuy.Click += btnHuy_Click;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Text == "" || txtThuCung.Text == "" || cboDichVu.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ!");
                return;
            }

            TenKH = txtTenKH.Text;
            ThuCung = txtThuCung.Text;
            DichVu = cboDichVu.Text;
            Gio = dtpNgay.Value.ToString("HH:mm dd/MM/yyyy");

            this.DialogResult = DialogResult.OK;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}