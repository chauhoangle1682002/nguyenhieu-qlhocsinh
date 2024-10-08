using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace QuanLyHocSinhApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private SqlConnection GetConnection()
        {
            // Lấy chuỗi kết nối từ App.config
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            return new SqlConnection(connectionString);
        }

        // Phương thức để tải dữ liệu từ cơ sở dữ liệu và hiển thị lên DataGridView
        private void LoadData()
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open(); // Mở kết nối

                    // Câu truy vấn để lấy dữ liệu từ bảng HocSinh
                    string query = "SELECT ID, Ten, NgaySinh, LopHoc, SoDienThoai, DiaChi FROM HocSinh";

                    // Sử dụng SqlDataAdapter để điền dữ liệu vào DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu lên DataGridView
                    dataGridViewHocSinh.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi nếu có
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
    }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    // Bắt đầu giao dịch
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        // Xóa học sinh
                        string queryDelete = "DELETE FROM HocSinh WHERE ID = @ID";
                        SqlCommand cmdDelete = new SqlCommand(queryDelete, conn, transaction);
                        cmdDelete.Parameters.AddWithValue("@ID", txtID.Text);
                        cmdDelete.ExecuteNonQuery();

                        // Lưu ID đã xóa vào DeletedIDs
                        string queryInsertDeletedID = "INSERT INTO DeletedIDs (ID) VALUES (@ID)";
                        SqlCommand cmdInsertDeletedID = new SqlCommand(queryInsertDeletedID, conn, transaction);
                        cmdInsertDeletedID.Parameters.AddWithValue("@ID", txtID.Text);
                        cmdInsertDeletedID.ExecuteNonQuery();

                        transaction.Commit(); // Cam kết giao dịch
                        MessageBox.Show("Xóa học sinh thành công.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa học sinh: " + ex.Message);
                }
                finally
                {
                    LoadData(); // Tải lại dữ liệu sau khi xóa
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                using (SqlConnection conn = GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = "UPDATE HocSinh SET Ten = @Ten, NgaySinh = @NgaySinh, LopHoc = @LopHoc, SoDienThoai = @SoDienThoai, DiaChi = @DiaChi WHERE ID = @ID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", txtID.Text);
                        cmd.Parameters.AddWithValue("@Ten", txtTen.Text);
                        cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                        cmd.Parameters.AddWithValue("@LopHoc", txtLopHoc.Text);
                        cmd.Parameters.AddWithValue("@SoDienThoai", txtSoDienThoai.Text);
                        cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật thông tin học sinh thành công.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật học sinh: " + ex.Message);
                    }
                    finally
                    {
                        LoadData(); // Tải lại dữ liệu sau khi cập nhật
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();

                    // Kiểm tra DeletedIDs để lấy ID đã xóa
                    string queryCheckDeletedIDs = "SELECT TOP 1 ID FROM DeletedIDs ORDER BY ID";
                    SqlCommand cmdCheckDeletedIDs = new SqlCommand(queryCheckDeletedIDs, conn);
                    object result = cmdCheckDeletedIDs.ExecuteScalar();
                    int newID;

                    if (result != null)
                    {
                        newID = Convert.ToInt32(result);

                        // Xóa ID đã sử dụng từ DeletedIDs
                        string queryDeleteFromDeletedIDs = "DELETE FROM DeletedIDs WHERE ID = @ID";
                        SqlCommand cmdDeleteFromDeletedIDs = new SqlCommand(queryDeleteFromDeletedIDs, conn);
                        cmdDeleteFromDeletedIDs.Parameters.AddWithValue("@ID", newID);
                        cmdDeleteFromDeletedIDs.ExecuteNonQuery();

                        // Cho phép IDENTITY_INSERT để thêm ID
                        string querySetIdentityInsertOn = "SET IDENTITY_INSERT HocSinh ON";
                        SqlCommand cmdSetIdentityInsertOn = new SqlCommand(querySetIdentityInsertOn, conn);
                        cmdSetIdentityInsertOn.ExecuteNonQuery();

                        // Thêm học sinh mới với ID cụ thể
                        string queryInsert = "INSERT INTO HocSinh (ID, Ten, NgaySinh, LopHoc, SoDienThoai, DiaChi) VALUES (@ID, @Ten, @NgaySinh, @LopHoc, @SoDienThoai, @DiaChi)";
                        SqlCommand cmdInsert = new SqlCommand(queryInsert, conn);
                        cmdInsert.Parameters.AddWithValue("@ID", newID);
                        cmdInsert.Parameters.AddWithValue("@Ten", txtTen.Text);
                        cmdInsert.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                        cmdInsert.Parameters.AddWithValue("@LopHoc", txtLopHoc.Text);
                        cmdInsert.Parameters.AddWithValue("@SoDienThoai", txtSoDienThoai.Text);
                        cmdInsert.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                        cmdInsert.ExecuteNonQuery();

                        // Tắt IDENTITY_INSERT
                        string querySetIdentityInsertOff = "SET IDENTITY_INSERT HocSinh OFF";
                        SqlCommand cmdSetIdentityInsertOff = new SqlCommand(querySetIdentityInsertOff, conn);
                        cmdSetIdentityInsertOff.ExecuteNonQuery();
                    }
                    else
                    {
                        // Tạo ID mới
                        string queryMaxID = "SELECT ISNULL(MAX(ID), 0) + 1 FROM HocSinh";
                        SqlCommand cmdMaxID = new SqlCommand(queryMaxID, conn);
                        newID = Convert.ToInt32(cmdMaxID.ExecuteScalar());

                        // Thêm học sinh mới với ID mới
                        string queryInsert = "INSERT INTO HocSinh (Ten, NgaySinh, LopHoc, SoDienThoai, DiaChi) VALUES (@Ten, @NgaySinh, @LopHoc, @SoDienThoai, @DiaChi)";
                        SqlCommand cmdInsert = new SqlCommand(queryInsert, conn);
                        cmdInsert.Parameters.AddWithValue("@Ten", txtTen.Text);
                        cmdInsert.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                        cmdInsert.Parameters.AddWithValue("@LopHoc", txtLopHoc.Text);
                        cmdInsert.Parameters.AddWithValue("@SoDienThoai", txtSoDienThoai.Text);
                        cmdInsert.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                        cmdInsert.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thêm học sinh thành công.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm học sinh: " + ex.Message);
                }
                finally
                {
                    LoadData(); // Tải lại dữ liệu sau khi thêm mới
                }
            }
        }

        private void dataGridViewHocSinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewHocSinh.Rows[e.RowIndex];
                txtID.Text = row.Cells["ID"].Value.ToString();
                txtTen.Text = row.Cells["Ten"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                txtLopHoc.Text = row.Cells["LopHoc"].Value.ToString();
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
            }
        }


        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTaiDuLieu_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();

                    // Tạo câu lệnh SQL để lấy dữ liệu từ bảng HocSinh
                    string query = "SELECT * FROM HocSinh";

                    // Dùng SqlDataAdapter để thực hiện truy vấn và đổ dữ liệu vào DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Liên kết DataTable với DataGridView
                    dataGridViewHocSinh.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu: " + ex.Message);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Lấy ID từ TextBox
            string timKiemID = txtTimKiemID.Text.Trim();

            // Kiểm tra xem ID có phải là số hợp lệ không
            if (string.IsNullOrEmpty(timKiemID) || !int.TryParse(timKiemID, out int id))
            {
                MessageBox.Show("Vui lòng nhập ID hợp lệ.");
                return;
            }

            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();

                    // Tạo câu lệnh SQL để tìm kiếm sinh viên theo ID
                    string query = "SELECT * FROM HocSinh WHERE ID = @ID";

                    // Tạo đối tượng SqlCommand và thêm tham số @ID
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Dùng SqlDataAdapter để thực hiện truy vấn và đổ dữ liệu vào DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Kiểm tra nếu không có dữ liệu trả về
                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy sinh viên với ID này.");
                    }
                    else
                    {
                        // Liên kết DataTable với DataGridView
                        dataGridViewHocSinh.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi tìm kiếm dữ liệu: " + ex.Message);
                }
            }
        }
        private void button1_Click_3(object sender, EventArgs e)
        {
            if (dataGridViewHocSinh.CurrentRow != null)
            {
                int ID = Convert.ToInt32(dataGridViewHocSinh.CurrentRow.Cells["ID"].Value);  // Lấy ID của học sinh đang chọn

                // Mở form điểm danh và truyền studentID
                DiemDanh DiemDanh = new DiemDanh(ID);  // Truyền studentID sang FormDiemDanh
                DiemDanh.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn học sinh để điểm danh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Khởi tạo lại LoginForm
            LoginForm loginForm = new LoginForm();
            loginForm.Show(); // Hiển thị LoginForm
            this.Close(); // Đóng Form1
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Xác nhận trước khi thoát
            var result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Thoát ứng dụng
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            FormDiem formDiem = new FormDiem();
            formDiem.ShowDialog();
        }
    }
}
