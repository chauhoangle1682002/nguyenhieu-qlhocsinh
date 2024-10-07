using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Generic;

namespace QuanLyHocSinhApp
{
    public partial class DiemDanh : Form
    {
        private SqlConnection connection;
        private int ID;  // ID của học sinh được chọn

        public DiemDanh(int ID)
        {
            InitializeComponent();
            this.ID = ID;
            InitializeDatabaseConnection();

            // Đăng ký sự kiện CellClick
            dgvStudents.CellClick += new DataGridViewCellEventHandler(dgvStudents_CellClick);
        }

        // Khởi tạo kết nối với cơ sở dữ liệu
        private void InitializeDatabaseConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        // Khi form được tải, hiển thị danh sách học sinh và lịch sử điểm danh
        private void DiemDanh_Load(object sender, EventArgs e)
        {
            LoadStudents();  // Tải danh sách học sinh
            DisplayAttendanceHistory();  // Hiển thị lịch sử điểm danh
            // Liên kết sự kiện DataError với hàm xử lý
            this.dgvAttendanceHistory.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvAttendanceHistory_DataError);
            txtSearchID.KeyPress += new KeyPressEventHandler(txtSearchID_KeyPress);
        }

        private void txtSearchID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và các phím điều khiển (như Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho nhập ký tự không hợp lệ
            }
        }

        // Tải danh sách học sinh từ cơ sở dữ liệu và hiển thị trong DataGridView
        private void LoadStudents()
        {
            string query = "SELECT ID, Ten, LopHoc FROM HocSinh";
            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvStudents.DataSource = dt;  // Hiển thị danh sách học sinh lên DataGridView
        }

        // Hiển thị tất cả các ngày điểm danh và trạng thái trong DataGridView
        private void DisplayAttendanceHistory()
        {
            // Sử dụng DISTINCT để loại bỏ các ngày trùng lặp
            string query = "SELECT DISTINCT NgayDiemDanh, TrangThai FROM Attendance WHERE ID = @ID ORDER BY NgayDiemDanh DESC";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", ID);  // Sử dụng ID của học sinh được chọn

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Hiển thị lịch sử điểm danh vào DataGridView
            dgvAttendanceHistory.DataSource = dt;

            // Đặt tên cột hiển thị
            dgvAttendanceHistory.Columns["NgayDiemDanh"].HeaderText = "Ngày Điểm Danh";
            dgvAttendanceHistory.Columns["TrangThai"].HeaderText = "Trạng Thái";

            // Định dạng ngày cho cột NgayDiemDanh
            dgvAttendanceHistory.Columns["NgayDiemDanh"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // Duyệt qua từng hàng trong DataGridView và chuyển đổi trạng thái bit thành chuỗi
            foreach (DataGridViewRow row in dgvAttendanceHistory.Rows)
            {
                var trangThaiValue = row.Cells["TrangThai"].Value;

                if (trangThaiValue != null && int.TryParse(trangThaiValue.ToString(), out int trangThaiInt))
                {
                    // Chuyển đổi bit sang chuỗi "Có mặt" hoặc "Vắng mặt"
                    row.Cells["TrangThai"].Value = trangThaiInt == 1 ? "Có mặt" : "Vắng mặt";
                }
                else
                {
                    row.Cells["TrangThai"].Value = "Dữ liệu không hợp lệ";
                }
            }
        }


        // Lưu điểm danh vào cơ sở dữ liệu
        private void SaveAttendance(int ID, DateTime ngayDiemDanh, bool trangThai)
        {
            string checkQuery = "SELECT COUNT(*) FROM Attendance WHERE ID = @ID AND NgayDiemDanh = @NgayDiemDanh";
            SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
            checkCmd.Parameters.AddWithValue("@ID", ID);
            checkCmd.Parameters.AddWithValue("@NgayDiemDanh", ngayDiemDanh);

            int count = (int)checkCmd.ExecuteScalar();

            if (count > 0)
            {
                // Cập nhật trạng thái nếu bản ghi đã tồn tại
                string updateQuery = "UPDATE Attendance SET TrangThai = @TrangThai WHERE ID = @ID AND NgayDiemDanh = @NgayDiemDanh";
                SqlCommand updateCmd = new SqlCommand(updateQuery, connection);
                updateCmd.Parameters.AddWithValue("@TrangThai", trangThai ? 1 : 0);  // Lưu 1 nếu 'Có mặt', 0 nếu 'Vắng mặt'
                updateCmd.Parameters.AddWithValue("@ID", ID);
                updateCmd.Parameters.AddWithValue("@NgayDiemDanh", ngayDiemDanh);
                updateCmd.ExecuteNonQuery();

                MessageBox.Show("Cập nhật điểm danh thành công!");
            }
            else
            {
                // Thêm bản ghi mới nếu không tồn tại
                string insertQuery = "INSERT INTO Attendance (ID, NgayDiemDanh, TrangThai) VALUES (@ID, @NgayDiemDanh, @TrangThai)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
                insertCmd.Parameters.AddWithValue("@ID", ID);
                insertCmd.Parameters.AddWithValue("@NgayDiemDanh", ngayDiemDanh);
                insertCmd.Parameters.AddWithValue("@TrangThai", trangThai ? 1 : 0);  // Lưu 1 nếu 'Có mặt', 0 nếu 'Vắng mặt'
                insertCmd.ExecuteNonQuery();

                MessageBox.Show("Lưu điểm danh thành công!");
            }
        }
        private void dgvAttendanceHistory_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Bỏ qua lỗi dữ liệu không hợp lệ
            e.ThrowException = false;
            MessageBox.Show("Dữ liệu không hợp lệ, vui lòng kiểm tra lại!", "Lỗi");
        }




        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();  // Đóng form`
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có nhấn vào cột ID không
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvStudents.Columns["ID"].Index)
            {
                // Lấy ID của học sinh được chọn
                int studentId = Convert.ToInt32(dgvStudents.Rows[e.RowIndex].Cells["ID"].Value);

                // Gọi phương thức để hiển thị ngày điểm danh và trạng thái
                DisplayStudentAttendance(studentId);
            }
        }

        private void DisplayStudentAttendance(int studentId)
        {
            // Sử dụng HashSet để đảm bảo không có ngày trùng lặp
            HashSet<string> attendanceRecords = new HashSet<string>();

            // Thêm DISTINCT vào câu lệnh SQL để lấy ngày điểm danh duy nhất
            string query = "SELECT DISTINCT NgayDiemDanh, TrangThai FROM Attendance WHERE ID = @ID ORDER BY NgayDiemDanh DESC";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", studentId);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DateTime ngayDiemDanh = Convert.ToDateTime(reader["NgayDiemDanh"]);
                string trangThai = (bool)reader["TrangThai"] ? "Có mặt" : "Vắng mặt";

                // Tạo chuỗi chứa ngày và trạng thái
                string record = $"{ngayDiemDanh.ToString("dd/MM/yyyy")} - {trangThai}";

                // Thêm bản ghi vào HashSet để đảm bảo không có ngày trùng lặp
                attendanceRecords.Add(record);
            }
            reader.Close();

            // Hiển thị thông tin điểm danh trong MessageBox
            string message = "Ngày Điểm Danh - Trạng Thái:\n";
            foreach (string record in attendanceRecords)
            {
                message += record + "\n";
            }

            MessageBox.Show(message, "Thông Tin Điểm Danh");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvStudents.CurrentRow.Cells["ID"].Value);  // Lấy ID của học sinh được chọn
            DateTime ngayDiemDanh = dtpNgayDiemDanh.Value.Date;  // Lấy ngày điểm danh từ DateTimePicker
            bool trangThai = rbtnCoMat.Checked;  // Kiểm tra xem có phải trạng thái "Có mặt" được chọn không

            // Gọi phương thức SaveAttendance để lưu hoặc cập nhật trạng thái điểm danh
            SaveAttendance(ID, ngayDiemDanh, trangThai);

            // Làm mới hiển thị sau khi lưu
            DisplayAttendanceHistory();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadStudents();  // Tải lại danh sách học sinh
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvAttendanceHistory_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        private void dgvAttendanceHistory_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAttendanceHistory.Rows[e.RowIndex];

                DateTime newNgayDiemDanh = Convert.ToDateTime(row.Cells["NgayDiemDanh"].Value);
                bool newTrangThai = row.Cells["TrangThai"].Value.ToString() == "Có mặt";

                // Gọi phương thức cập nhật cơ sở dữ liệu
                UpdateAttendanceRecord(ID, newNgayDiemDanh, newTrangThai);
            }
        }

        // Cập nhật cơ sở dữ liệu với giá trị mới
        private void UpdateAttendanceRecord(int Id, DateTime ngayDiemDanh, bool trangThai)
        {
            string query = "UPDATE Attendance SET NgayDiemDanh = @NgayDiemDanh, TrangThai = @TrangThai WHERE ID = @ID AND NgayDiemDanh = @NgayDiemDanhOld";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", Id);
            cmd.Parameters.AddWithValue("@NgayDiemDanh", ngayDiemDanh);
            cmd.Parameters.AddWithValue("@TrangThai", trangThai ? 1 : 0); // Lưu 1 nếu 'Có mặt', 0 nếu 'Vắng mặt'

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật điểm danh thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật điểm danh: " + ex.Message);
            }
        }

        private void ShowAttendanceInfo(int ID)
        {
            // Sử dụng HashSet để đảm bảo không có ngày trùng lặp
            HashSet<string> attendanceRecords = new HashSet<string>();

            string query = "SELECT DISTINCT NgayDiemDanh, TrangThai FROM Attendance WHERE ID = @ID ORDER BY NgayDiemDanh DESC";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", ID);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DateTime ngayDiemDanh = Convert.ToDateTime(reader["NgayDiemDanh"]);
                string trangThai = (bool)reader["TrangThai"] ? "Có mặt" : "Vắng mặt";

                // Thêm chuỗi ngày điểm danh và trạng thái vào HashSet
                string record = $"{ngayDiemDanh.ToString("dd/MM/yyyy")} - {trangThai}";

                attendanceRecords.Add(record);
            }
            reader.Close();

            // Hiển thị thông tin điểm danh trong MessageBox hoặc ListBox
            string message = "Ngày Điểm Danh - Trạng Thái:\n";
            foreach (string record in attendanceRecords)
            {
                message += record + "\n";
            }

            MessageBox.Show(message, "Thông Tin Điểm Danh");
        }
        // Phương thức kiểm tra xem ngày điểm danh đã tồn tại cho học sinh chưa
        private bool IsAttendanceExist(int ID, DateTime ngayDiemDanh)
        {
            // Truy vấn kiểm tra xem ngày điểm danh đã có trong cơ sở dữ liệu không
            string query = "SELECT COUNT(*) FROM Attendance WHERE ID = @ID AND NgayDiemDanh = @NgayDiemDanh";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@NgayDiemDanh", ngayDiemDanh.Date);

            connection.Open();
            int count = (int)cmd.ExecuteScalar();  // Lấy kết quả đếm số bản ghi
            connection.Close();

            // Trả về true nếu ngày đã tồn tại, ngược lại false
            return count > 0;
        }
        private void txtSearchID_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Lấy ID từ TextBox và kiểm tra xem có hợp lệ không
            if (int.TryParse(txtSearchID.Text, out int searchID))
            {
                // Gọi phương thức tìm kiếm
                SearchAttendanceByID(searchID);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập ID hợp lệ!", "Thông báo");
            }
        }

        private void SearchAttendanceByID(int searchID)
        {
            // Truy vấn cơ sở dữ liệu để lấy thông tin điểm danh theo ID
            string query = "SELECT NgayDiemDanh, TrangThai FROM Attendance WHERE ID = @ID ORDER BY NgayDiemDanh DESC";
            SqlCommand cmd = new SqlCommand(query, connection);

            // Thay thế ID bằng searchID
            cmd.Parameters.AddWithValue("@ID", searchID);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                // Hiển thị kết quả trong DataGridView
                dgvAttendanceHistory.DataSource = dt;

                // Đặt tên cột hiển thị
                dgvAttendanceHistory.Columns["NgayDiemDanh"].HeaderText = "Ngày Điểm Danh";
                dgvAttendanceHistory.Columns["TrangThai"].HeaderText = "Trạng Thái";

                // Định dạng ngày cho cột NgayDiemDanh
                dgvAttendanceHistory.Columns["NgayDiemDanh"].DefaultCellStyle.Format = "dd/MM/yyyy";

                // Duyệt qua từng hàng trong DataGridView và chuyển đổi trạng thái bit thành chuỗi
                foreach (DataGridViewRow row in dgvAttendanceHistory.Rows)
                {
                    var trangThaiValue = row.Cells["TrangThai"].Value;

                    if (trangThaiValue != null && int.TryParse(trangThaiValue.ToString(), out int trangThaiInt))
                    {
                        // Chuyển đổi bit sang chuỗi "Có mặt" hoặc "Vắng mặt"
                        row.Cells["TrangThai"].Value = trangThaiInt == 1 ? "Có mặt" : "Vắng mặt";
                    }
                    else
                    {
                        row.Cells["TrangThai"].Value = "Dữ liệu không hợp lệ";
                    }
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy bản ghi điểm danh cho ID này!", "Thông báo");
            }
        }
    }
}
