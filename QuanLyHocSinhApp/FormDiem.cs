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
        private void LoadHocSinhToComboBox()
        {
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
                        // Thêm tên học sinh vào ComboBox
                        comboBoxHocSinh.Items.Add(new
                        {
                            ID = reader["ID"],
                            Ten = reader["Ten"]
                        });
                    }

                    // Đặt tên hiển thị cho ComboBox
                    comboBoxHocSinh.DisplayMember = "Ten";
                    comboBoxHocSinh.ValueMember = "ID";
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
            if (int.TryParse(textBoxHocSinh.Text, out hocSinhID)) // Kiểm tra ID hợp lệ
            {
                // Lấy các thông tin khác
                string monHoc = txtMonHoc.Text;
                float diemSo;

                if (float.TryParse(txtDiemSo.Text, out diemSo)) // Kiểm tra điểm có phải là số
                {
                    string ghiChu = txtGhiChu.Text;

                    using (SqlConnection conn = GetConnection())
                    {
                        try
                        {
                            conn.Open();

                            // Thêm điểm vào cơ sở dữ liệu
                            string insertDiemQuery = "INSERT INTO Diem (HocSinhID, MonHoc, DiemSo, GhiChu) VALUES (@HocSinhID, @MonHoc, @DiemSo, @GhiChu)";
                            SqlCommand insertDiemCmd = new SqlCommand(insertDiemQuery, conn);
                            insertDiemCmd.Parameters.AddWithValue("@HocSinhID", hocSinhID);
                            insertDiemCmd.Parameters.AddWithValue("@MonHoc", monHoc);
                            insertDiemCmd.Parameters.AddWithValue("@DiemSo", diemSo);
                            insertDiemCmd.Parameters.AddWithValue("@GhiChu", ghiChu);

                            insertDiemCmd.ExecuteNonQuery();
                            MessageBox.Show("Thêm điểm thành công!");
                            LoadHocSinhWithDiem(); // Cập nhật lại DataGridView sau khi thêm điểm
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
        }

        private void LoadData()
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();

                    // Câu truy vấn lấy điểm từ bảng Diem, kèm theo tên học sinh từ bảng HocSinh
                    string query = "SELECT Diem.ID, HocSinh.Ten, Diem.MonHoc, Diem.DiemSo, Diem.GhiChu FROM Diem INNER JOIN HocSinh ON Diem.HocSinhID = HocSinh.ID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Liên kết dữ liệu với DataGridView
                    dataGridViewDiem.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }

        private void btnSuaDiem_Click(object sender, EventArgs e)
        {
            if (dataGridViewDiem.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewDiem.SelectedRows[0];

                // Lấy ID điểm từ cột "ID" (hoặc tên cột khác nếu bạn đã đổi)
                int diemID = int.Parse(row.Cells["ID"].Value.ToString()); // Đảm bảo cột này tồn tại
                int hocSinhID = int.Parse(row.Cells["HocSinhID"].Value.ToString()); // Lấy HocSinhID từ dòng đã chọn

                // Lấy thông tin từ các ô nhập liệu
                string monHoc = txtMonHoc.Text;
                float diemSo;

                if (float.TryParse(txtDiemSo.Text, out diemSo))
                {
                    string ghiChu = txtGhiChu.Text;

                    using (SqlConnection conn = GetConnection())
                    {
                        try
                        {
                            conn.Open();
                            string updateDiemQuery = "UPDATE Diem SET MonHoc = @MonHoc, DiemSo = @DiemSo, GhiChu = @GhiChu WHERE ID = @DiemID";
                            SqlCommand updateDiemCmd = new SqlCommand(updateDiemQuery, conn);
                            updateDiemCmd.Parameters.AddWithValue("@DiemID", diemID);
                            updateDiemCmd.Parameters.AddWithValue("@MonHoc", monHoc);
                            updateDiemCmd.Parameters.AddWithValue("@DiemSo", diemSo);
                            updateDiemCmd.Parameters.AddWithValue("@GhiChu", ghiChu);

                            updateDiemCmd.ExecuteNonQuery();
                            MessageBox.Show("Sửa điểm thành công!");
                            LoadDiemData(); // Tải lại dữ liệu sau khi sửa
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi sửa điểm: " + ex.Message);
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
                MessageBox.Show("Vui lòng chọn một dòng để sửa.");
            }
        }
        private void btnXoaDiem_Click(object sender, EventArgs e)
        {
            if (dataGridViewDiem.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewDiem.SelectedRows[0];

                // Lấy ID điểm từ cột "ID" (hoặc tên cột khác nếu bạn đã đổi)
                int diemID = int.Parse(row.Cells["ID"].Value.ToString()); // Đảm bảo cột này tồn tại
                int hocSinhID = int.Parse(row.Cells["HocSinhID"].Value.ToString()); // Lấy HocSinhID từ dòng đã chọn

                using (SqlConnection conn = GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string deleteDiemQuery = "DELETE FROM Diem WHERE ID = @DiemID";
                        SqlCommand deleteDiemCmd = new SqlCommand(deleteDiemQuery, conn);
                        deleteDiemCmd.Parameters.AddWithValue("@DiemID", diemID);

                        deleteDiemCmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa điểm thành công!");
                        LoadDiemData(); // Tải lại dữ liệu sau khi xóa
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa điểm: " + ex.Message);
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
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewDiem.Rows[e.RowIndex];

                // Cập nhật các ô nhập liệu với dữ liệu từ dòng đã chọn
                txtDiemSo.Text = row.Cells["DiemSo"].Value.ToString();
                textBoxHocSinh.Text = row.Cells["HocSinhID"].Value.ToString(); // Hiển thị HocSinhID
                txtMonHoc.Text = row.Cells["MonHoc"].Value.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();
            }
            LoadDiemData(); // Cập nhật lại DataGridView sau khi sửa hoặc xóa thành công
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
            var selectedItem = comboBoxHocSinh.SelectedItem;
            if (selectedItem != null)
            {
                textBoxHocSinh.Text = ((dynamic)selectedItem).ID.ToString(); // Ghi ID vào TextBox
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadHocSinhWithDiem(); // Gọi hàm tải dữ liệu
        }
    }
}