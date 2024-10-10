using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinhApp
{
    public partial class FormDiem : Form
    {
        private SqlConnection connection;

        public FormDiem()
        {
            InitializeComponent();
        }
        private void FormDiem_Load(object sender, EventArgs e)
        {
            LoadHocSinhToTextBox();
            LoadData();
            LoadDiemData();// Tải danh sách điểm vào DataGridView
            LoadHocSinhToComboBox(); // Tải danh sách học sinh vào ComboBox
            LoadHocSinhWithDiem();
            btnLoadDiem.Click += button1_Click; // Đăng ký sự kiện Click
        }

        private void LoadData()
        {
            // Thiết lập chuỗi kết nối (thay đổi thông tin theo cơ sở dữ liệu của bạn)
            string connectionString = "Data Source=JOEHOANGCHOU;Initial Catalog=QuanLyHocSinh;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); // Mở kết nối

                string query = "SELECT HocSinhID, MonHoc, DiemSo, GhiChu FROM Diem"; // Thay đổi truy vấn theo cấu trúc bảng của bạn

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Đổ dữ liệu vào DataTable

                    dataGridViewDiem.DataSource = dataTable; // Thiết lập DataGridView nguồn dữ liệu
                }
            }
        }

        private void LoadHocSinhToComboBox()
        {
            comboBoxHocSinh.Items.Clear(); // Xóa các mục trước đó

            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ID, Ten FROM HocSinh";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // Thêm tên học sinh vào ComboBox bằng cách sử dụng KeyValuePair
                        comboBoxHocSinh.Items.Add(new KeyValuePair<int, string>((int)reader["ID"], reader["Ten"].ToString()));
                    }

                    // Đặt thuộc tính hiển thị và giá trị cho ComboBox
                    comboBoxHocSinh.DisplayMember = "Value";
                    comboBoxHocSinh.ValueMember = "Key";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách học sinh: " + ex.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadHocSinhToTextBox()
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ID, Ten FROM HocSinh"; // Lấy danh sách ID và tên học sinh
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) // Lấy học sinh đầu tiên từ danh sách
                    {
                        textBoxHocSinh.Text = reader["Ten"].ToString(); // Hiển thị tên học sinh trong TextBox
                    }
                    else
                    {
                        MessageBox.Show("Không có học sinh nào trong cơ sở dữ liệu.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách học sinh: " + ex.Message);
                }
            }
        }
        private void LoadHocSinhWithDiem()
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT HocSinh.ID AS HocSinhID, HocSinh.Ten, Diem.MonHoc, Diem.DiemSo, Diem.GhiChu 
                FROM Diem 
                INNER JOIN HocSinh ON Diem.HocSinhID = HocSinh.ID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị tên các cột để kiểm tra
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        Console.WriteLine(column.ColumnName);
                    }

                    // Liên kết dữ liệu với DataGridView
                    dataGridViewDiem.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách học sinh có điểm: " + ex.Message);
                }
            }
        }

        private SqlConnection GetConnection()
        {
            // Thay chuỗi kết nối bằng thông tin của bạn
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            return new SqlConnection(connectionString);
        }
        private void LoadDiemData()
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Diem.ID, Diem.HocSinhID, HocSinh.Ten, Diem.MonHoc, Diem.DiemSo, Diem.GhiChu FROM Diem INNER JOIN HocSinh ON Diem.HocSinhID = HocSinh.ID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridViewDiem.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }
        // Lấy ID học sinh khi người dùng chọn học sinh từ ComboBox
        private int GetHocSinhIDFromTextBox()
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ID FROM HocSinh WHERE Ten = @TenHocSinh";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenHocSinh", textBoxHocSinh.Text);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        return (int)result;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy học sinh.");
                        return -1; // Trả về -1 nếu không tìm thấy
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm học sinh: " + ex.Message);
                    return -1;
                }
            }
        }
        private void LoadHocSinh()
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    // Truy vấn để lấy ID và tên học sinh
                    string query = "SELECT ID, Ten FROM HocSinh";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách học sinh: " + ex.Message);
                }
            }
        }
        private void btnThemDiem_Click(object sender, EventArgs e)
        {
            int hocSinhID;
            if (int.TryParse(textBoxHocSinh.Text, out hocSinhID)) // Kiểm tra ID học sinh hợp lệ
            {
                string monHoc = txtMonHoc.Text;  // Môn học
                float diemSo;

                // Kiểm tra nếu điểm là số hợp lệ
                if (float.TryParse(txtDiemSo.Text, out diemSo))
                {
                    string ghiChu = txtGhiChu.Text; // Ghi chú (nếu có)

                    using (SqlConnection conn = GetConnection())
                    {
                        try
                        {
                            conn.Open();

                            // Chèn vào bảng Diem mà không chỉ định ID
                            string query = "INSERT INTO Diem (HocSinhID, MonHoc, DiemSo, GhiChu) VALUES (@HocSinhID, @MonHoc, @DiemSo, @GhiChu)";
                            SqlCommand cmd = new SqlCommand(query, conn);

                            cmd.Parameters.AddWithValue("@HocSinhID", hocSinhID);
                            cmd.Parameters.AddWithValue("@MonHoc", monHoc);
                            cmd.Parameters.AddWithValue("@DiemSo", diemSo);
                            cmd.Parameters.AddWithValue("@GhiChu", ghiChu);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Thêm điểm thành công!");
                            LoadDiemData(); // Load lại dữ liệu sau khi thêm
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi thêm điểm: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập điểm hợp lệ.");
                }
            }
            else
            {
                MessageBox.Show("ID học sinh không hợp lệ. Vui lòng nhập lại.");
            }
            LoadData();
        }

        private void btnSuaDiem_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu DataGridView có dữ liệu
            if (dataGridViewDiem.Rows.Count > 0)
            {
                if (dataGridViewDiem.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridViewDiem.SelectedRows[0];

                    // Kiểm tra xem dòng được chọn có hợp lệ
                    if (selectedRow != null)
                    {
                        int hocSinhID = (int)selectedRow.Cells["HocSinhID"].Value;

                        // Tiến hành cập nhật như trước
                        string monHoc = txtMonHoc.Text;
                        float diemSo;
                        string ghiChu = txtGhiChu.Text;

                        if (float.TryParse(txtDiemSo.Text, out diemSo))
                        {
                            using (SqlConnection conn = GetConnection())
                            {
                                try
                                {
                                    conn.Open();
                                    string query = "UPDATE Diem SET MonHoc = @MonHoc, DiemSo = @DiemSo, GhiChu = @GhiChu WHERE HocSinhID = @HocSinhID";
                                    using (SqlCommand cmd = new SqlCommand(query, conn))
                                    {
                                        cmd.Parameters.AddWithValue("@MonHoc", monHoc);
                                        cmd.Parameters.AddWithValue("@DiemSo", diemSo);
                                        cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
                                        cmd.Parameters.AddWithValue("@HocSinhID", hocSinhID);

                                        cmd.ExecuteNonQuery(); // Thực hiện cập nhật
                                        MessageBox.Show("Sửa thành công!");
                                        LoadDiemData(); // Tải lại dữ liệu vào DataGridView
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Lỗi: " + ex.Message);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập điểm hợp lệ.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một dòng để sửa.");
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để sửa.");
            }
        }

        private void btnXoaDiem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn trong DataGridView không
            if (dataGridViewDiem.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dataGridViewDiem.SelectedRows[0];

                // Lấy ID của điểm từ cột ID
                int diemID = (int)selectedRow.Cells["ID"].Value; // Sử dụng tên cột ID từ cơ sở dữ liệu

                // Hiển thị hộp thoại xác nhận
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?",
                                                     "Xác nhận xóa!",
                                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    using (SqlConnection conn = GetConnection())
                    {
                        try
                        {
                            conn.Open();
                            string query = "DELETE FROM Diem WHERE ID = @DiemID";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@DiemID", diemID);
                                cmd.ExecuteNonQuery(); // Thực hiện xóa
                                MessageBox.Show("Xóa thành công!");
                                LoadDiemData(); // Tải lại dữ liệu vào DataGridView
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }

        private void dataGridViewDiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu chỉ số hàng là hợp lệ
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewDiem.Rows.Count)
            {
                DataGridViewRow row = this.dataGridViewDiem.Rows[e.RowIndex];

                // Lấy dữ liệu từ các ô trong dòng đã chọn
                txtDiemID.Text = row.Cells["HocSinhID"].Value.ToString(); // Sử dụng cột HocSinhID
                txtMonHoc.Text = row.Cells["MonHoc"].Value.ToString();
                txtDiemSo.Text = row.Cells["DiemSo"].Value.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();
            }
        }

        private void textBoxHocSinh_TextChanged(object sender, EventArgs e)
        {

        }
        private bool CheckHocSinhIDExists(int hocSinhID)
        {
            using (SqlConnection conn = GetConnection()) // Sử dụng kết nối SQL của bạn
            {
                conn.Open();
                // Truy vấn kiểm tra sự tồn tại của HocSinhID trong bảng HocSinh
                string query = "SELECT COUNT(*) FROM HocSinh WHERE ID = @HocSinhID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HocSinhID", hocSinhID);

                // Thực hiện truy vấn và lấy kết quả
                int count = (int)cmd.ExecuteScalar();

                // Trả về true nếu ID tồn tại, ngược lại false
                return count > 0;
            }
        }

        private void comboBoxHocSinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi người dùng chọn một học sinh, ghi ID vào textBoxHocSinh
            var selectedItem = (KeyValuePair<int, string>)comboBoxHocSinh.SelectedItem;
            if (selectedItem.Key != null)
            {
                textBoxHocSinh.Text = selectedItem.Key.ToString(); // Ghi ID vào TextBox
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadHocSinhWithDiem(); // Gọi hàm tải dữ liệu
        }
    }
}