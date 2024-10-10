namespace QuanLyHocSinhApp
{
    partial class FormDiem
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
            this.dataGridViewDiem = new System.Windows.Forms.DataGridView();
            this.txtMonHoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiemSo = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnThemDiem = new System.Windows.Forms.Button();
            this.btnSuaDiem = new System.Windows.Forms.Button();
            this.btnXoaDiem = new System.Windows.Forms.Button();
            this.textBoxHocSinh = new System.Windows.Forms.TextBox();
            this.comboBoxHocSinh = new System.Windows.Forms.ComboBox();
            this.btnLoadDiem = new System.Windows.Forms.Button();
            this.txtDiemID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiem)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDiem
            // 
            this.dataGridViewDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDiem.Location = new System.Drawing.Point(113, 12);
            this.dataGridViewDiem.Name = "dataGridViewDiem";
            this.dataGridViewDiem.Size = new System.Drawing.Size(558, 206);
            this.dataGridViewDiem.TabIndex = 0;
            this.dataGridViewDiem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDiem_CellContentClick);
            // 
            // txtMonHoc
            // 
            this.txtMonHoc.Location = new System.Drawing.Point(113, 358);
            this.txtMonHoc.Name = "txtMonHoc";
            this.txtMonHoc.Size = new System.Drawing.Size(296, 20);
            this.txtMonHoc.TabIndex = 2;
            this.txtMonHoc.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 359);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Môn Học";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Điểm Số ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 439);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ghi Chú";
            // 
            // txtDiemSo
            // 
            this.txtDiemSo.Location = new System.Drawing.Point(113, 398);
            this.txtDiemSo.Name = "txtDiemSo";
            this.txtDiemSo.Size = new System.Drawing.Size(296, 20);
            this.txtDiemSo.TabIndex = 6;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(113, 438);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(296, 20);
            this.txtGhiChu.TabIndex = 7;
            // 
            // btnThemDiem
            // 
            this.btnThemDiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemDiem.Location = new System.Drawing.Point(534, 302);
            this.btnThemDiem.Name = "btnThemDiem";
            this.btnThemDiem.Size = new System.Drawing.Size(98, 29);
            this.btnThemDiem.TabIndex = 8;
            this.btnThemDiem.Text = "Thêm ";
            this.btnThemDiem.UseVisualStyleBackColor = true;
            this.btnThemDiem.Click += new System.EventHandler(this.btnThemDiem_Click);
            // 
            // btnSuaDiem
            // 
            this.btnSuaDiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaDiem.Location = new System.Drawing.Point(534, 368);
            this.btnSuaDiem.Name = "btnSuaDiem";
            this.btnSuaDiem.Size = new System.Drawing.Size(98, 31);
            this.btnSuaDiem.TabIndex = 9;
            this.btnSuaDiem.Text = "Sửa";
            this.btnSuaDiem.UseVisualStyleBackColor = true;
            this.btnSuaDiem.Click += new System.EventHandler(this.btnSuaDiem_Click);
            // 
            // btnXoaDiem
            // 
            this.btnXoaDiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaDiem.Location = new System.Drawing.Point(534, 427);
            this.btnXoaDiem.Name = "btnXoaDiem";
            this.btnXoaDiem.Size = new System.Drawing.Size(98, 31);
            this.btnXoaDiem.TabIndex = 10;
            this.btnXoaDiem.Text = "Xóa ";
            this.btnXoaDiem.UseVisualStyleBackColor = true;
            this.btnXoaDiem.Click += new System.EventHandler(this.btnXoaDiem_Click);
            // 
            // textBoxHocSinh
            // 
            this.textBoxHocSinh.Location = new System.Drawing.Point(10, 12);
            this.textBoxHocSinh.Name = "textBoxHocSinh";
            this.textBoxHocSinh.Size = new System.Drawing.Size(65, 20);
            this.textBoxHocSinh.TabIndex = 11;
            this.textBoxHocSinh.TextChanged += new System.EventHandler(this.textBoxHocSinh_TextChanged);
            // 
            // comboBoxHocSinh
            // 
            this.comboBoxHocSinh.FormattingEnabled = true;
            this.comboBoxHocSinh.Location = new System.Drawing.Point(10, 62);
            this.comboBoxHocSinh.Name = "comboBoxHocSinh";
            this.comboBoxHocSinh.Size = new System.Drawing.Size(97, 21);
            this.comboBoxHocSinh.TabIndex = 12;
            this.comboBoxHocSinh.SelectedIndexChanged += new System.EventHandler(this.comboBoxHocSinh_SelectedIndexChanged);
            // 
            // btnLoadDiem
            // 
            this.btnLoadDiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDiem.Location = new System.Drawing.Point(113, 224);
            this.btnLoadDiem.Name = "btnLoadDiem";
            this.btnLoadDiem.Size = new System.Drawing.Size(113, 29);
            this.btnLoadDiem.TabIndex = 13;
            this.btnLoadDiem.Text = "Tải Dữ Liệu";
            this.btnLoadDiem.UseVisualStyleBackColor = true;
            this.btnLoadDiem.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDiemID
            // 
            this.txtDiemID.Location = new System.Drawing.Point(113, 310);
            this.txtDiemID.Name = "txtDiemID";
            this.txtDiemID.Size = new System.Drawing.Size(296, 20);
            this.txtDiemID.TabIndex = 14;
            // 
            // FormDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 473);
            this.Controls.Add(this.txtDiemID);
            this.Controls.Add(this.btnLoadDiem);
            this.Controls.Add(this.comboBoxHocSinh);
            this.Controls.Add(this.textBoxHocSinh);
            this.Controls.Add(this.btnXoaDiem);
            this.Controls.Add(this.btnSuaDiem);
            this.Controls.Add(this.btnThemDiem);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtDiemSo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMonHoc);
            this.Controls.Add(this.dataGridViewDiem);
            this.Name = "FormDiem";
            this.Text = "FormDiem";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDiem;
        private System.Windows.Forms.TextBox txtMonHoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiemSo;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThemDiem;
        private System.Windows.Forms.Button btnSuaDiem;
        private System.Windows.Forms.Button btnXoaDiem;
        private System.Windows.Forms.TextBox textBoxHocSinh;
        private System.Windows.Forms.ComboBox comboBoxHocSinh;
        private System.Windows.Forms.Button btnLoadDiem;
        private System.Windows.Forms.TextBox txtDiemID;
    }
}