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
    public partial class frmKHDanhGia : Form
    {
        public frmKHDanhGia()
        {
            InitializeComponent();
        }

        private void frmKHDanhGia_Load(object sender, EventArgs e)
        {
            txtNhanXet.Text = "Hãy chia sẻ trải nghiệm của thú cưng tại đây...";
            txtNhanXet.ForeColor = Color.Black;
        }

        int rating = 0;
        string dichVuDaChon = "";

        void UpdateStars()
        {
            PictureBox[] stars = { picStar1, picStar2, picStar3, picStar4, picStar5 };

            for (int i = 0; i < stars.Length; i++)
            {
                if (i < rating)
                    stars[i].Image = Properties.Resources.StarFull;
                else
                    stars[i].Image = Properties.Resources.Star;
            }
        }

        private void picStar1_Click(object sender, EventArgs e)
        {
            rating = 1;
            UpdateStars();
        }

        private void picStar2_Click(object sender, EventArgs e)
        {
            rating = 2;
            UpdateStars();
        }

        private void picStar3_Click(object sender, EventArgs e)
        {
            rating = 3;
            UpdateStars();
        }

        private void picStar4_Click(object sender, EventArgs e)
        {
            rating = 4;
            UpdateStars();
        }

        private void picStar5_Click(object sender, EventArgs e)
        {
            rating = 5;
            UpdateStars();
        }

        void ResetButton()
        {
            Button[] buttons = { btnKhamSucKhoe, btnTam, btnCatTiaLong, btnTiemPhong };

            foreach (Button btn in buttons)
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
            }
        }

        void ChonDichVu(Button btn, string tenDichVu)
        {
            ResetButton();

            btn.BackColor = Color.FromArgb(0, 150, 136); 
            btn.ForeColor = Color.White;

            dichVuDaChon = tenDichVu;
        }

        private void btnKhamSucKhoe_Click(object sender, EventArgs e)
        {
            ChonDichVu(btnKhamSucKhoe, "Khám sức khỏe");
        }

        private void btnTiemPhong_Click(object sender, EventArgs e)
        {
            ChonDichVu(btnTiemPhong, "Tiêm phòng");
        }

        private void btnTam_Click(object sender, EventArgs e)
        {
            ChonDichVu(btnTam, "Tắm");
        }

        private void btnCatTiaLong_Click(object sender, EventArgs e)
        {
            ChonDichVu(btnCatTiaLong, "Cắt tỉa lông");
        }

        private void txtNhanXet_TextChanged(object sender, EventArgs e)
        {
            if (txtNhanXet.Text == "Hãy chia sẻ trải nghiệm của thú cưng tại đây...")
            {
                txtNhanXet.Text = "";
                txtNhanXet.ForeColor = Color.Black;
            }
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            if (dichVuDaChon == "")
            {
                MessageBox.Show("Vui lòng chọn dịch vụ!");
                return;
            }

            if (rating == 0)
            {
                MessageBox.Show("Vui lòng chọn số sao đánh giá!");
                return;
            }

            string nhanXet = txtNhanXet.Text;

            MessageBox.Show(
                "Cảm ơn bạn đã đánh giá và góp ý dịch vụ của chúng tôi!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            txtNhanXet.Text = "";
            rating = 0;
            dichVuDaChon = "";

            ResetButton();
            UpdateStars();

            this.Close();
        }


        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Chọn ảnh thú cưng";
            ofd.Filter = "Image Files|*.jpg;*.png;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void picAnh_Click(object sender, EventArgs e)
        {
            btnChonAnh.PerformClick();
        }

        private void btnXoaAnh_Click(object sender, EventArgs e)
        {
            picAnh.Image = null;
        }

    }
}
