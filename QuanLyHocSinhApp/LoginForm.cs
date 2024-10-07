using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace QuanLyHocSinhApp
{
    public partial class LoginForm : Form
    {
            // Lấy chuỗi kết nối từ App.config
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
    public LoginForm()
        {
            InitializeComponent();
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private bool CheckLogin(string username, string password)
        {
            // Mã hóa mật khẩu nhập vào trước khi kiểm tra
            string hashedPassword = HashPassword(password);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Password = @Password";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Thêm tham số vào câu truy vấn
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count == 1; // Trả về true nếu tìm thấy tài khoản
                }
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra thông tin đăng nhập
            if (CheckLogin(username, password))
            {
                // Nếu đăng nhập thành công, mở Form1
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 mainForm = new Form1(); // Mở form chính
                mainForm.Show(); // Hiện form chính
                this.Hide(); // Ẩn LoginForm
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Mở form đăng ký
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog(); // Sử dụng ShowDialog nếu muốn chờ đến khi đóng form
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
