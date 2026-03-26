using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTQuanLyThuCung
{
    public partial class frmSanPham : Form
    {
        Panel panelTop;
        DataGridView dataGridView1;

        Label labelTen, labelSoLuong, labelGiaNhap, labelGiaXuat;
        ComboBox comboTen;
        TextBox txtSoLuong, txtGiaNhap, txtGiaXuat;
        // ================== KẾT NỐI ==================
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=QuanLyThuCung;Integrated Security=True");
        string maSPDangChon = "";
        bool isEditing = false; // Khai báo biến này ở ngoài cùng của Form
        public frmSanPham()
        {
            InitializeComponent();
        }
        // ================== MỞ KẾT NỐI ==================
        void MoKetNoi()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

       
        
        // ================== FORM LOAD ==================
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            MoKetNoi();
            LoadData();
            LoadComboBox();
            ClearInput(); // 🔥 thêm dòng này
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false; // Không cho hiện dòng trống ở dưới
            dataGridView.CellClick += dataGridView_CellClick;
            // 1. THIẾT LẬP TỔNG THỂ
            this.BackColor = Color.White;

            // 2. CHỈNH CÁC Ô NHẬP LIỆU (TEXTBOX & COMBOBOX)
            // Giả sử các TextBox của bạn nằm trong panel1
            foreach (Control c in panel1.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.BackColor = Color.FromArgb(240, 240, 240); // Xám nhạt thanh lịch
                    c.Font = new Font("Segoe UI", 11, FontStyle.Regular);
                    c.ForeColor = Color.Black;

                    if (c is TextBox)
                    {
                        TextBox txt = (TextBox)c;
                        txt.BorderStyle = BorderStyle.None;
                        txt.TextAlign = HorizontalAlignment.Center; // Căn giữa chữ trong ô
                    }

                    if (c is ComboBox)
                    {
                        ((ComboBox)c).FlatStyle = FlatStyle.Flat;
                    }
                }

                if (c is Label)
                {
                    c.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    c.ForeColor = Color.DimGray;
                }
            }

            // 3. CHỈNH 3 NÚT BẤM (SỬA, XÓA, NHẬP HÀNG)
            SetupButton(btSua, Color.FromArgb(0, 166, 81));      // Xanh lá
            SetupButton(btXoa, Color.Red);                       // Đỏ
            SetupButton(btNhapHang, Color.FromArgb(247, 148, 29)); // Cam

            // 4. CHỈNH BẢNG DỮ LIỆU (DATAGRIDVIEW) - ĐÂY LÀ PHẦN LÀM CHO ĐỀU
            dataGridView.BackgroundColor = Color.White;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.GridColor = Color.FromArgb(235, 235, 235);
            dataGridView.RowHeadersVisible = false;

            // Quan trọng: Để bảng giãn đều hết chiều ngang
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Header (Tiêu đề cột)
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.White; // Đổi từ xanh sang trắng
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersHeight = 45; // Cho tiêu đề cao lên nhìn sẽ thoáng

            // Dòng dữ liệu
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(226, 65, 62); // Đỏ đô khi chọn
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView.RowTemplate.Height = 35; // Chiều cao mỗi dòng

            // Gọi các hàm nạp dữ liệu của bạn (nếu có)
            // LoadData(); 
        }

        // Hàm phụ để thiết lập nút cho gọn code
        private void SetupButton(Button btn, Color backColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = backColor;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btn.Cursor = Cursors.Hand; // Hiện bàn tay khi rà chuột vào
            cbTen.SelectedIndex = -1;
            dataGridView.ReadOnly = false;
            tbSoLuong.Enabled = false;
            tbGiaNhap.Enabled = false;
            tbGiaXuat.Enabled = false;
            tbTrangThai.Enabled = false;
            cbTen.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbTen.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbTen.SelectedIndex = -1; // tránh auto chạy
           
        }
        bool isNhapHangMode = false;
        private void SaveFromGrid()
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                string ten = row.Cells[1].Value?.ToString();
                if (string.IsNullOrEmpty(ten)) continue;

                if (!int.TryParse(row.Cells[5].Value?.ToString(), out int soLuong))
                    continue;

                if (!decimal.TryParse(row.Cells[3].Value?.ToString(), out decimal gia))
                    continue;

                if (!decimal.TryParse(row.Cells[4].Value?.ToString(), out decimal giaXuat))
                    continue;

                string trangThai = row.Cells[6].Value?.ToString() ?? "";
                string moTa = row.Cells["MoTa"]?.Value?.ToString() ?? ""; // nếu có cột MoTa

                string query = @"UPDATE SanPham 
                         SET SoLuong = @sl,
                             Gia = @gia,
                             GiaXuat = @giaxuat,
                             TrangThai = @tt,
                             MoTa = @mt
                         WHERE TenSP = @ten";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ten", ten);
                    cmd.Parameters.AddWithValue("@sl", soLuong);
                    cmd.Parameters.AddWithValue("@gia", gia);
                    cmd.Parameters.AddWithValue("@giaxuat", giaXuat);
                    cmd.Parameters.AddWithValue("@tt", trangThai);
                    cmd.Parameters.AddWithValue("@mt", moTa);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Lưu nhập thành công!");
        }
        // ================== LOAD DATA GRID ==================
        void LoadData()
        {
            string query = @"
            SELECT 
                MaSP,
                'SP' + RIGHT('000' + CAST(ROW_NUMBER() OVER (ORDER BY MaSP) AS VARCHAR), 3) AS MaHienThi,
                TenSP,
                LoaiSP,
                Gia,
                GiaXuat,
                SoLuong,
                TrangThai,
                MoTa
            FROM SanPham";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false; // Không cho hiện dòng trống ở dưới
            dataGridView.DataSource = dt;

            // 👉 Ẩn MaSP cho đẹp
            dataGridView.Columns["MaSP"].Visible = false;
            dataGridView.Columns["Gia"].DefaultCellStyle.Format = "N0";
            dataGridView.Columns["GiaXuat"].DefaultCellStyle.Format = "N0";

            dataGridView.Columns["Gia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["GiaXuat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["SoLuong"].DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

        }


        // ================== LOAD COMBOBOX ==================
        void LoadComboBox()
        {
            string query = "SELECT DISTINCT LoaiSP FROM SanPham";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();

            da.Fill(dt);

            cbTen.DataSource = dt;
            cbTen.DisplayMember = "LoaiSP";
             cbTen.SelectedIndex = -1;
        }

        void CapNhatTrangThai()
        {
            if (!int.TryParse(tbSoLuong.Text, out int sl)) return;

            // Nếu số lượng > 0, bất kể trước đó là "Ngừng bán", 
            // chúng ta sẽ cho nó quay lại quỹ đạo tính toán bình thường.
            if (sl > 0)
            {
                if (sl < 100) tbTrangThai.Text = "Sắp hết hàng";
                else if (sl < 1000) tbTrangThai.Text = "Còn hàng";
                else tbTrangThai.Text = "Số lượng lớn";
            }
            else
            {
                // Nếu số lượng vẫn = 0, bạn có thể giữ nguyên "Ngừng bán" 
                // hoặc chuyển sang "Hết hàng" tùy bạn.
                if (tbTrangThai.Text != "Ngừng bán")
                {
                    tbTrangThai.Text = "Hết hàng";
                }
            }
        }
        void LoadDataTheoLoai(string loai)
        {
            string query = "SELECT * FROM SanPham WHERE LoaiSP = @loai";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.SelectCommand.Parameters.AddWithValue("@loai", loai);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView.DataSource = dt;
        }
        // ================== LOAD THÔNG TIN SẢN PHẨM ==================
        
        
        // ================== ĐÓNG KẾT NỐI ==================
        void DongKetNoi()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        
        


        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView.Rows[e.RowIndex];

            string maSP = row.Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(maSP)) return;
            

            if (!int.TryParse(row.Cells[5].Value?.ToString(), out int soLuong))
                return;

            if (!decimal.TryParse(row.Cells[3].Value?.ToString(), out decimal gia))
                return;

            if (!decimal.TryParse(row.Cells[4].Value?.ToString(), out decimal giaXuat))
                return;

            string trangThai = row.Cells[6].Value?.ToString() ?? "";

            string query = @"UPDATE SanPham 
                            SET SoLuong = @sl,
                                Gia = @gia,
                                GiaXuat = @giaxuat,
                                TrangThai = @tt
                            WHERE maSP = @ma";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ma", maSP);
                cmd.Parameters.AddWithValue("@sl", soLuong);
                cmd.Parameters.AddWithValue("@gia", gia);
                cmd.Parameters.AddWithValue("@giaxuat", giaXuat);
                cmd.Parameters.AddWithValue("@tt", trangThai);
                MessageBox.Show("Đã chạy UPDATE MaSP = " + maSP);
                cmd.ExecuteNonQuery();
            }

            // ❗ Không gọi LoadData() ở đây để tránh lỗi reentrant
        }
        private void CapNhatToanBoData()
        {
            try
            {
                MoKetNoi();
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    // CHỈ xử lý dòng mới (IsNewRow) hoặc dòng có MaHienThi trống (tùy cách bạn nhập)
                    // Nếu bạn muốn xử lý mọi dòng, phải đảm bảo điều kiện WHERE cực kỳ chính xác.

                    if (row.IsNewRow) continue;

                    // Lấy MaSP ẩn để định danh chính xác mặt hàng
                    string maSPStr = row.Cells["MaSP"].Value?.ToString();
                    string ten = row.Cells["TenSP"].Value?.ToString();

                    if (string.IsNullOrEmpty(ten)) continue;

                    int soLuongNhap = 0;
                    decimal giaNhap = 0;
                    int.TryParse(row.Cells["SoLuong"].Value?.ToString(), out soLuongNhap);
                    decimal.TryParse(row.Cells["Gia"].Value?.ToString(), out giaNhap);

                    if (soLuongNhap <= 0) continue; // Bỏ qua nếu không nhập số lượng

                    // TRƯỜNG HỢP 1: Dòng đã có MaSP (Cập nhật hàng cũ)
                    if (!string.IsNullOrEmpty(maSPStr))
                    {
                        string updateQuery = "UPDATE SanPham SET SoLuong = SoLuong + @sl WHERE MaSP = @ma";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@sl", soLuongNhap);
                            cmd.Parameters.AddWithValue("@ma", maSPStr);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    // TRƯỜNG HỢP 2: Dòng mới hoàn toàn (Chưa có MaSP)
                    else
                    {
                        // Thực hiện INSERT như code cũ của bạn nhưng hãy kiểm tra trùng tên trước
                        // ... (Logic Insert của bạn)
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
        

        private void btNhapHang_Click(object sender, EventArgs e)
        {
            if (!isNhapHangMode)
            {
                // BẬT CHẾ ĐỘ NHẬP
                isNhapHangMode = true;
                dataGridView.ReadOnly = false;
                dataGridView.AllowUserToAddRows = true;
                btNhapHang.Text = "XÁC NHẬN LƯU";
                MessageBox.Show("Chỉ cần điền: Tên, Giá, Số lượng. Những cột khác có thể để trống!");
            }
            else
            {
                try
                {
                    MoKetNoi();
                    int count = 0;

                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.IsNewRow) continue;

                        // Chỉ xử lý dòng mới (chưa có MaSP)
                        if (row.Cells["MaSP"].Value == null || string.IsNullOrEmpty(row.Cells["MaSP"].Value.ToString()))
                        {
                            // 1. LẤY DỮ LIỆU BẮT BUỘC
                            string ten = row.Cells["TenSP"].Value?.ToString();
                            if (string.IsNullOrEmpty(ten)) continue; // Bỏ qua dòng trống tên

                            if (!decimal.TryParse(row.Cells["Gia"].Value?.ToString(), out decimal giaN) || giaN <= 0 ||
                                !int.TryParse(row.Cells["SoLuong"].Value?.ToString(), out int sl) || sl <= 0)
                            {
                                continue; // Bỏ qua nếu giá hoặc số lượng sai/trống
                            }

                            // 2. TỰ ĐỘNG ĐIỀN DỮ LIỆU CÒN THIẾU
                            // 2. TỰ ĐỘNG ĐIỀN DỮ LIỆU CÒN THIẾU
                            decimal giaX = giaN * 1.3m;
                            string loai = row.Cells["LoaiSP"].Value?.ToString();
                            if (string.IsNullOrEmpty(loai)) loai = "Chưa phân loại"; // Bỏ chữ N ở đây

                            string moTa = row.Cells["MoTa"].Value?.ToString();
                            if (string.IsNullOrEmpty(moTa)) moTa = "Hàng mới nhập nhanh"; // Bỏ chữ N ở đây

                            string trangThai = "Còn hàng (Mới về)"; // Bỏ chữ N ở đây

                            // 3. LỆNH SQL INSERT
                            string sqlInsert = @"INSERT INTO SanPham (TenSP, LoaiSP, Gia, GiaXuat, SoLuong, TrangThai, NgayNhap, MoTa) 
                                       VALUES (@ten, @loai, @gia, @gx, @sl, @tt, GETDATE(), @mt)";

                            using (SqlCommand cmd = new SqlCommand(sqlInsert, conn))
                            {
                                cmd.Parameters.AddWithValue("@ten", ten);
                                cmd.Parameters.AddWithValue("@loai", loai);
                                cmd.Parameters.AddWithValue("@gia", giaN);
                                cmd.Parameters.AddWithValue("@gx", giaX);
                                cmd.Parameters.AddWithValue("@sl", sl);
                                cmd.Parameters.AddWithValue("@tt", trangThai);
                                cmd.Parameters.AddWithValue("@mt", moTa);
                                cmd.ExecuteNonQuery();
                                count++;
                            }
                        }
                    }
                    if (count > 0) MessageBox.Show($"Đã nhập nhanh {count} sản phẩm thành công!");
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
                finally
                {
                    isNhapHangMode = false;
                    dataGridView.AllowUserToAddRows = false;
                    btNhapHang.Text = "NHẬP HÀNG";
                    LoadData();
                }
            }
        }
        private void btXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!");
                return;
            }

            string maSP = dataGridView.CurrentRow.Cells["MaSP"].Value.ToString();

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn ngừng bán sản phẩm này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.No)
                return;

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = @"UPDATE SanPham
                         SET TrangThai = N'Ngừng bán'
                         WHERE MaSP = @ma";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ma", maSP);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Đã ngừng bán sản phẩm!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                // 👉 Bật sửa controls
                tbSoLuong.Enabled = true;
                tbGiaNhap.Enabled = true;
                tbGiaXuat.Enabled = true;
                tbTrangThai.Enabled = true;

                // 👉 Mở DataGridView cho LoaiSP và MoTa
                dataGridView.ReadOnly = false;
                foreach (DataGridViewColumn col in dataGridView.Columns)
                {
                    col.ReadOnly = true;
                }
                dataGridView.Columns["MoTa"].ReadOnly = false;
                dataGridView.Columns["LoaiSP"].ReadOnly = false;
                dataGridView.Columns["LoaiSP"].DefaultCellStyle.BackColor = Color.LightYellow;
                dataGridView.Columns["MoTa"].DefaultCellStyle.BackColor = Color.LightYellow;

                btSua.Text = "Lưu";
                isEditing = true;
            }
            else
            {
                // 👉 Validate dữ liệu
                if (!int.TryParse(tbSoLuong.Text, out int soLuong) ||
                    !decimal.TryParse(tbGiaNhap.Text, out decimal gia) ||
                    !decimal.TryParse(tbGiaXuat.Text, out decimal giaXuat))
                {
                    MessageBox.Show("Dữ liệu nhập không hợp lệ!");
                    return;
                }

                // 👉 Tính toán trạng thái
                string trangThai = "";
                if (soLuong == 0) trangThai = "Hết hàng";
                else if (soLuong < 20) trangThai = "Sắp hết";
                else trangThai = "Còn hàng";

                try
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    // Lấy dòng đang chọn hiện tại để lấy LoaiSP và MoTa mới nhất từ Grid
                    string loaiSPMoi = dataGridView.CurrentRow.Cells["LoaiSP"].Value?.ToString() ?? "";
                    string moTaMoi = dataGridView.CurrentRow.Cells["MoTa"].Value?.ToString() ?? "";

                    // 👉 CẬP NHẬT TẤT CẢ TRONG 1 CÂU LỆNH (Gọn và tránh lỗi biến)
                    string sqlUpdate = @"UPDATE SanPham 
                                SET SoLuong = @sl, Gia = @gia, GiaXuat = @gx, 
                                    TrangThai = @tt, LoaiSP = @loai, MoTa = @mt 
                                WHERE MaSP = @ma";

                    using (SqlCommand cmd = new SqlCommand(sqlUpdate, conn))
                    {
                        cmd.Parameters.AddWithValue("@sl", soLuong);
                        cmd.Parameters.AddWithValue("@gia", gia);
                        cmd.Parameters.AddWithValue("@gx", giaXuat);
                        cmd.Parameters.AddWithValue("@tt", trangThai);
                        cmd.Parameters.AddWithValue("@loai", loaiSPMoi);
                        cmd.Parameters.AddWithValue("@mt", moTaMoi);
                        cmd.Parameters.AddWithValue("@ma", maSPDangChon);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Đã lưu thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    // 👉 Khóa lại giao diện
                    tbSoLuong.Enabled = false;
                    tbGiaNhap.Enabled = false;
                    tbGiaXuat.Enabled = false;
                    tbTrangThai.Enabled = false;

                    dataGridView.Columns["LoaiSP"].DefaultCellStyle.BackColor = Color.White;
                    dataGridView.Columns["MoTa"].DefaultCellStyle.BackColor = Color.White;
                    dataGridView.ReadOnly = true;

                    btSua.Text = "Sửa";
                    isEditing = false;

                    LoadData();
                    LoadComboBox();
                }
            }
        }
        // ================== CLEAR INPUT ==================
        void ClearInput()
        {
            tbSoLuong.Clear();
            tbGiaNhap.Clear();
            tbGiaXuat.Clear();
            tbTrangThai.Clear();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView.Rows[e.RowIndex];

            maSPDangChon = row.Cells["MaSP"].Value?.ToString();

            tbSoLuong.Text = row.Cells["SoLuong"].Value?.ToString();
            tbGiaNhap.Text = row.Cells["Gia"].Value?.ToString();
            tbGiaXuat.Text = row.Cells["GiaXuat"].Value?.ToString();
            tbTrangThai.Text = row.Cells["TrangThai"].Value?.ToString();
        }

        private void tbSoLuong_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void cbTen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTen.SelectedIndex == -1)
            {
                LoadData();
                return;
            }

            string loai = cbTen.Text;
            LoadDataTheoLoai(loai);
        }
        Button btnThem, btnSua, btnXoa, btnNhapHang;
        private readonly object col;

    }
}    

