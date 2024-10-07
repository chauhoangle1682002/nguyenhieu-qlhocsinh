using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace QuanLyHocSinhApp
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem mật khẩu và mật khẩu xác nhận có khớp không
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.");
                return;
            }

            // 2. Kiểm tra xem tên đăng nhập và mật khẩu không được để trống
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống.");
                return;
            }

            // 3. Lấy chuỗi kết nối đến cơ sở dữ liệu từ file App.config
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // 4. Kiểm tra xem tên đăng nhập đã tồn tại hay chưa
                string checkQuery = "SELECT COUNT(1) FROM Users WHERE Username=@Username";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (userCount > 0)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.");
                    return;
                }

                // 5. Chèn thông tin tài khoản mới vào bảng Users
                string query = "INSERT INTO Users (Username, Password, Role, CreatedDate) VALUES (@Username, @Password, @Role, @CreatedDate)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", HashPassword(txtPassword.Text));  // Mã hóa mật khẩu trước khi lưu
                cmd.Parameters.AddWithValue("@Role", "HocSinh");  // Vai trò mặc định là học sinh
                cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);  // Lưu ngày tạo tài khoản

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đăng ký thành công!");
                    this.Close();  // Đóng form đăng ký sau khi thành công
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi đăng ký: " + ex.Message);
                }
            }
        }
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));  // Mã hóa mật khẩu thành chuỗi dạng hexa
                }
                return builder.ToString();
            }
        }

        private void btnLoginNow_Click(object sender, EventArgs e)
        {
            // Ẩn form đăng ký hiện tại
            this.Hide();

            // Hiển thị form đăng nhập
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
