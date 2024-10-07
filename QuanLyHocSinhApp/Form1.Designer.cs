namespace QuanLyHocSinhApp
{
    partial class Form1
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewHocSinh = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLopHoc = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTaiDuLieu = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtTimKiemID = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnDiemDanh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHocSinh)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHocSinh
            // 
            this.dataGridViewHocSinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHocSinh.Location = new System.Drawing.Point(12, 110);
            this.dataGridViewHocSinh.Name = "dataGridViewHocSinh";
            this.dataGridViewHocSinh.Size = new System.Drawing.Size(1076, 218);
            this.dataGridViewHocSinh.TabIndex = 0;
            this.dataGridViewHocSinh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHocSinh_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 464);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Họ Và Tên ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(537, 464);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày Sinh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(544, 352);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Lớp Học ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(950, 464);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "SDT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(939, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Địa Chỉ ";
            // 
            // txtLopHoc
            // 
            this.txtLopHoc.Location = new System.Drawing.Point(485, 400);
            this.txtLopHoc.Name = "txtLopHoc";
            this.txtLopHoc.Size = new System.Drawing.Size(197, 20);
            this.txtLopHoc.TabIndex = 6;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(874, 400);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(201, 20);
            this.txtDiaChi.TabIndex = 7;
            this.txtDiaChi.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(12, 510);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(192, 20);
            this.txtTen.TabIndex = 8;
            this.txtTen.TextChanged += new System.EventHandler(this.txtTen_TextChanged);
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(874, 510);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(201, 20);
            this.txtSoDienThoai.TabIndex = 10;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(168, 580);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(95, 29);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "Thêm ";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(417, 580);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(92, 29);
            this.btnSua.TabIndex = 12;
            this.btnSua.Text = "Sửa ";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(638, 580);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(94, 29);
            this.btnXoa.TabIndex = 13;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnTaiDuLieu
            // 
            this.btnTaiDuLieu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiDuLieu.Location = new System.Drawing.Point(854, 580);
            this.btnTaiDuLieu.Name = "btnTaiDuLieu";
            this.btnTaiDuLieu.Size = new System.Drawing.Size(105, 29);
            this.btnTaiDuLieu.TabIndex = 14;
            this.btnTaiDuLieu.Text = "Tải Dữ Liệu";
            this.btnTaiDuLieu.UseVisualStyleBackColor = true;
            this.btnTaiDuLieu.Click += new System.EventHandler(this.btnTaiDuLieu_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(85, 352);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 19);
            this.label6.TabIndex = 16;
            this.label6.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(12, 400);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(192, 20);
            this.txtID.TabIndex = 17;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Location = new System.Drawing.Point(482, 510);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(200, 20);
            this.dtpNgaySinh.TabIndex = 18;
            // 
            // txtTimKiemID
            // 
            this.txtTimKiemID.Location = new System.Drawing.Point(786, 42);
            this.txtTimKiemID.Name = "txtTimKiemID";
            this.txtTimKiemID.Size = new System.Drawing.Size(187, 20);
            this.txtTimKiemID.TabIndex = 19;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(992, 42);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(96, 23);
            this.btnTimKiem.TabIndex = 20;
            this.btnTimKiem.Text = "Tìm Kiếm ";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnDiemDanh
            // 
            this.btnDiemDanh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiemDanh.Location = new System.Drawing.Point(13, 26);
            this.btnDiemDanh.Name = "btnDiemDanh";
            this.btnDiemDanh.Size = new System.Drawing.Size(99, 39);
            this.btnDiemDanh.TabIndex = 21;
            this.btnDiemDanh.Text = "Điểm Danh";
            this.btnDiemDanh.UseVisualStyleBackColor = true;
            this.btnDiemDanh.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 621);
            this.Controls.Add(this.btnDiemDanh);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiemID);
            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnTaiDuLieu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtSoDienThoai);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtLopHoc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewHocSinh);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHocSinh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHocSinh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLopHoc;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTaiDuLieu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.TextBox txtTimKiemID;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnDiemDanh;
    }
}

