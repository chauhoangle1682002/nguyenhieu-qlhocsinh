using System.Data;

namespace QuanLyHocSinhApp
{
    partial class DiemDanh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            // Đóng kết nối cơ sở dữ liệu nếu mở
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.dtpNgayDiemDanh = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnCoMat = new System.Windows.Forms.RadioButton();
            this.rbtnVangMat = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.dgvAttendanceHistory = new System.Windows.Forms.DataGridView();
            this.txtSearchID = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudents
            // 
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(12, 12);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.Size = new System.Drawing.Size(402, 211);
            this.dgvStudents.TabIndex = 0;
            this.dgvStudents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudents_CellContentClick);
            // 
            // dtpNgayDiemDanh
            // 
            this.dtpNgayDiemDanh.Location = new System.Drawing.Point(12, 468);
            this.dtpNgayDiemDanh.Name = "dtpNgayDiemDanh";
            this.dtpNgayDiemDanh.Size = new System.Drawing.Size(200, 20);
            this.dtpNgayDiemDanh.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Aqua;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ngày Điểm Danh";
            // 
            // rbtnCoMat
            // 
            this.rbtnCoMat.AutoSize = true;
            this.rbtnCoMat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnCoMat.Location = new System.Drawing.Point(500, 465);
            this.rbtnCoMat.Name = "rbtnCoMat";
            this.rbtnCoMat.Size = new System.Drawing.Size(83, 23);
            this.rbtnCoMat.TabIndex = 3;
            this.rbtnCoMat.TabStop = true;
            this.rbtnCoMat.Text = "Có Mặt ";
            this.rbtnCoMat.UseVisualStyleBackColor = true;
            // 
            // rbtnVangMat
            // 
            this.rbtnVangMat.AutoSize = true;
            this.rbtnVangMat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnVangMat.Location = new System.Drawing.Point(663, 465);
            this.rbtnVangMat.Name = "rbtnVangMat";
            this.rbtnVangMat.Size = new System.Drawing.Size(99, 23);
            this.rbtnVangMat.TabIndex = 4;
            this.rbtnVangMat.TabStop = true;
            this.rbtnVangMat.Text = "Vắng Mặt ";
            this.rbtnVangMat.UseVisualStyleBackColor = true;
            this.rbtnVangMat.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Aqua;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(587, 421);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Trạng Thái ";
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(12, 528);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(90, 35);
            this.btnLuu.TabIndex = 6;
            this.btnLuu.Text = "Lưu ";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDong
            // 
            this.btnDong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.Location = new System.Drawing.Point(697, 528);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(91, 35);
            this.btnDong.TabIndex = 7;
            this.btnDong.Text = "Đóng ";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiLai.Location = new System.Drawing.Point(367, 528);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(87, 35);
            this.btnTaiLai.TabIndex = 8;
            this.btnTaiLai.Text = "Tải Lại";
            this.btnTaiLai.UseVisualStyleBackColor = true;
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);
            // 
            // dgvAttendanceHistory
            // 
            this.dgvAttendanceHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendanceHistory.Location = new System.Drawing.Point(500, 12);
            this.dgvAttendanceHistory.Name = "dgvAttendanceHistory";
            this.dgvAttendanceHistory.Size = new System.Drawing.Size(288, 210);
            this.dgvAttendanceHistory.TabIndex = 9;
            this.dgvAttendanceHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgvAttendanceHistory.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvAttendanceHistory_DataError_1);
            // 
            // txtSearchID
            // 
            this.txtSearchID.Location = new System.Drawing.Point(16, 291);
            this.txtSearchID.Name = "txtSearchID";
            this.txtSearchID.Size = new System.Drawing.Size(196, 20);
            this.txtSearchID.TabIndex = 10;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(247, 281);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(93, 30);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Tìm Kiếm ";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // DiemDanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 575);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchID);
            this.Controls.Add(this.dgvAttendanceHistory);
            this.Controls.Add(this.btnTaiLai);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbtnVangMat);
            this.Controls.Add(this.rbtnCoMat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpNgayDiemDanh);
            this.Controls.Add(this.dgvStudents);
            this.Name = "DiemDanh";
            this.Text = "DiemDanh";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.DateTimePicker dtpNgayDiemDanh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtnCoMat;
        private System.Windows.Forms.RadioButton rbtnVangMat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.DataGridView dgvAttendanceHistory;
        private System.Windows.Forms.TextBox txtSearchID;
        private System.Windows.Forms.Button btnSearch;
    }
}