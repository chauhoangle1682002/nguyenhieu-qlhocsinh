namespace DiemDanh
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudents
            // 
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(12, 12);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.Size = new System.Drawing.Size(776, 225);
            this.dgvStudents.TabIndex = 0;
            // 
            // dtpNgayDiemDanh
            // 
            this.dtpNgayDiemDanh.Location = new System.Drawing.Point(12, 319);
            this.dtpNgayDiemDanh.Name = "dtpNgayDiemDanh";
            this.dtpNgayDiemDanh.Size = new System.Drawing.Size(200, 20);
            this.dtpNgayDiemDanh.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Aqua;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ngày Điểm Danh";
            // 
            // rbtnCoMat
            // 
            this.rbtnCoMat.AutoSize = true;
            this.rbtnCoMat.Location = new System.Drawing.Point(522, 323);
            this.rbtnCoMat.Name = "rbtnCoMat";
            this.rbtnCoMat.Size = new System.Drawing.Size(62, 17);
            this.rbtnCoMat.TabIndex = 3;
            this.rbtnCoMat.TabStop = true;
            this.rbtnCoMat.Text = "Có Mặt ";
            this.rbtnCoMat.UseVisualStyleBackColor = true;
            // 
            // rbtnVangMat
            // 
            this.rbtnVangMat.AutoSize = true;
            this.rbtnVangMat.Location = new System.Drawing.Point(618, 322);
            this.rbtnVangMat.Name = "rbtnVangMat";
            this.rbtnVangMat.Size = new System.Drawing.Size(71, 17);
            this.rbtnVangMat.TabIndex = 4;
            this.rbtnVangMat.TabStop = true;
            this.rbtnVangMat.Text = "Vắng Mặt";
            this.rbtnVangMat.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Aqua;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(527, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Trạng Thái Điểm Danh";
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.Aqua;
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(12, 395);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(121, 43);
            this.btnLuu.TabIndex = 6;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.Aqua;
            this.btnDong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.Location = new System.Drawing.Point(351, 395);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(115, 43);
            this.btnDong.TabIndex = 7;
            this.btnDong.Text = "Đóng ";
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.BackColor = System.Drawing.Color.Aqua;
            this.btnTaiLai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiLai.Location = new System.Drawing.Point(665, 395);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(123, 43);
            this.btnTaiLai.TabIndex = 8;
            this.btnTaiLai.Text = "Tải Lại ";
            this.btnTaiLai.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTaiLai);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbtnVangMat);
            this.Controls.Add(this.rbtnCoMat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpNgayDiemDanh);
            this.Controls.Add(this.dgvStudents);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
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
    }
}

