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
            LoadHocSinhToTextBox(); // Tải danh sách học sinh vào ComboBox

            // Kiểm tra số lượng mục trong ComboBox
            MessageBox.Show("Số lượng mục trong ComboBox: " + comboBoxHocSinh.Items.Count);

            // Duyệt qua các mục trong ComboBox để in ra
            foreach (var item in comboBoxHocSinh.Items)
            {
                MessageBox.Show(item.ToString());
            }

            LoadData();
            LoadDiemData();// Tải danh sách điểm vào DataGridView
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxHocSinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHocSinh.SelectedItem != null)
            {
                // Lấy giá trị ID của học sinh được chọn
                DataRowView selectedRow = comboBoxHocSinh.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    int hocSinhID = (int)selectedRow["ID"];
                    string tenHocSinh = selectedRow["Ten"].ToString();
                    MessageBox.Show("Học sinh được chọn: " + tenHocSinh + " - ID: " + hocSinhID);
                }
            }
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

                    // Liên kết dữ liệu với ComboBox
                    comboBoxHocSinh.DataSource = dataTable;
                    comboBoxHocSinh.DisplayMember = "Ten";  // Hiển thị tên học sinh
                    comboBoxHocSinh.ValueMember = "ID";     // Giá trị là ID của học sinh
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách học sinh: " + ex.Message);
                }
            }
        }

        private void btnThemDiem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxHocSinh.Text) && !string.IsNullOrWhiteSpace(txtMonHoc.Text))
            {
                int hocSinhID;
                if (int.TryParse(textBoxHocSinh.Text, out hocSinhID))
                {
                    string monHoc = txtMonHoc.Text; // Nhập từ TextBox
                    float diemSo;

                    if (float.TryParse(txtDiemSo.Text, out diemSo))
                    {
                        string ghiChu = txtGhiChu.Text;

                        using (SqlConnection conn = GetConnection())
                        {
                            try
                            {
                                conn.Open();

                                // Kiểm tra xem môn học đã tồn tại chưa
                                string checkMonHocQuery = "SELECT COUNT(*) FROM MonHoc WHERE TenMonHoc = @TenMonHoc";
                                SqlCommand checkCmd = new SqlCommand(checkMonHocQuery, conn);
                                checkCmd.Parameters.AddWithValue("@TenMonHoc", monHoc);
                                int count = (int)checkCmd.ExecuteScalar();

                                // Nếu môn học chưa tồn tại, thêm vào bảng MonHoc
                                if (count == 0)
                                {
                                    string insertMonHocQuery = "INSERT INTO MonHoc (TenMonHoc) VALUES (@TenMonHoc)";
                                    SqlCommand insertMonHocCmd = new SqlCommand(insertMonHocQuery, conn);
                                    insertMonHocCmd.Parameters.AddWithValue("@TenMonHoc", monHoc);
                                    insertMonHocCmd.ExecuteNonQuery();
                                }

                                // Thêm điểm vào bảng Diem
                                string insertDiemQuery = "INSERT INTO Diem (HocSinhID, MonHoc, DiemSo, GhiChu) VALUES (@HocSinhID, @MonHoc, @DiemSo, @GhiChu)";
                                SqlCommand insertDiemCmd = new SqlCommand(insertDiemQuery, conn);
                                insertDiemCmd.Parameters.AddWithValue("@HocSinhID", hocSinhID);
                                insertDiemCmd.Parameters.AddWithValue("@MonHoc", monHoc);
                                insertDiemCmd.Parameters.AddWithValue("@DiemSo", diemSo);
                                insertDiemCmd.Parameters.AddWithValue("@GhiChu", ghiChu);

                                insertDiemCmd.ExecuteNonQuery();
                                MessageBox.Show("Thêm điểm thành công!");

                                // Gọi phương thức để tải lại dữ liệu vào DataGridView
                                LoadDiemData();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi khi thêm điểm: " + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập điểm số hợp lệ.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập ID học sinh hợp lệ.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập ID học sinh và tên môn học.");
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
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"
                UPDATE Diem 
                SET MonHoc = @MonHoc, DiemSo = @DiemSo, GhiChu = @GhiChu
                WHERE ID = @DiemID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DiemID", textBoxHocSinh.Text);
                    cmd.Parameters.AddWithValue("@MonHoc", txtMonHoc.Text);
                    cmd.Parameters.AddWithValue("@DiemSo", txtDiemSo.Text);
                    cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật điểm thành công.");
                    LoadDiemData();  // Tải lại dữ liệu sau khi sửa
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật điểm: " + ex.Message);
                }
            }
        }
        private void btnXoaDiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Diem WHERE ID = @DiemID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DiemID", textBoxHocSinh.Text);  // Lấy giá trị từ TextBox

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa điểm thành công.");
                    LoadDiemData();  // Tải lại dữ liệu sau khi xóa
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa điểm: " + ex.Message);
                }
            }
        }

        private void dataGridViewDiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewDiem.Rows[e.RowIndex];

                textBoxHocSinh.Text = row.Cells["ID"].Value.ToString();
                txtMonHoc.Text = row.Cells["MonHoc"].Value.ToString();
                txtDiemSo.Text = row.Cells["DiemSo"].Value.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();
            }
        }

        private void textBoxHocSinh_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
