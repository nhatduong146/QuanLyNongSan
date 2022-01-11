namespace QuanLyNongSan
{
    partial class FormLichSuTT
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvLichSu1 = new System.Windows.Forms.DataGridView();
            this.txtTimKiem1 = new System.Windows.Forms.TextBox();
            this.btnTimKiem1 = new System.Windows.Forms.Button();
            this.dgvChiTiet1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.thanhtien = new System.Windows.Forms.Label();
            this.Refersh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(313, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lịch sử thanh toán";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Turquoise;
            this.button1.Location = new System.Drawing.Point(896, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvLichSu1
            // 
            this.dgvLichSu1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSu1.Location = new System.Drawing.Point(12, 176);
            this.dgvLichSu1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvLichSu1.Name = "dgvLichSu1";
            this.dgvLichSu1.RowHeadersWidth = 51;
            this.dgvLichSu1.RowTemplate.Height = 24;
            this.dgvLichSu1.Size = new System.Drawing.Size(485, 255);
            this.dgvLichSu1.TabIndex = 2;
            this.dgvLichSu1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLichSu1_CellContentClick);
            this.dgvLichSu1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLichSu1_CellMouseClick);
            // 
            // txtTimKiem1
            // 
            this.txtTimKiem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem1.Location = new System.Drawing.Point(231, 129);
            this.txtTimKiem1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTimKiem1.Multiline = true;
            this.txtTimKiem1.Name = "txtTimKiem1";
            this.txtTimKiem1.Size = new System.Drawing.Size(145, 38);
            this.txtTimKiem1.TabIndex = 3;
            this.txtTimKiem1.TextChanged += new System.EventHandler(this.txtTimKiem1_TextChanged);
            // 
            // btnTimKiem1
            // 
            this.btnTimKiem1.BackColor = System.Drawing.Color.Turquoise;
            this.btnTimKiem1.Font = new System.Drawing.Font("Roboto Condensed", 13.91597F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem1.Location = new System.Drawing.Point(387, 129);
            this.btnTimKiem1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimKiem1.Name = "btnTimKiem1";
            this.btnTimKiem1.Size = new System.Drawing.Size(88, 41);
            this.btnTimKiem1.TabIndex = 1;
            this.btnTimKiem1.Text = "Tìm";
            this.btnTimKiem1.UseVisualStyleBackColor = false;
            this.btnTimKiem1.Click += new System.EventHandler(this.btnTimKiem1_Click);
            // 
            // dgvChiTiet1
            // 
            this.dgvChiTiet1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet1.Location = new System.Drawing.Point(503, 176);
            this.dgvChiTiet1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvChiTiet1.Name = "dgvChiTiet1";
            this.dgvChiTiet1.RowHeadersWidth = 51;
            this.dgvChiTiet1.RowTemplate.Height = 24;
            this.dgvChiTiet1.Size = new System.Drawing.Size(468, 255);
            this.dgvChiTiet1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(687, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tổng tiền:";
            // 
            // thanhtien
            // 
            this.thanhtien.AutoSize = true;
            this.thanhtien.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thanhtien.Location = new System.Drawing.Point(836, 130);
            this.thanhtien.Name = "thanhtien";
            this.thanhtien.Size = new System.Drawing.Size(37, 27);
            this.thanhtien.TabIndex = 5;
            this.thanhtien.Text = "0 đ";
            // 
            // Refersh
            // 
            this.Refersh.BackColor = System.Drawing.Color.Turquoise;
            this.Refersh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Refersh.Location = new System.Drawing.Point(12, 127);
            this.Refersh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Refersh.Name = "Refersh";
            this.Refersh.Size = new System.Drawing.Size(101, 41);
            this.Refersh.TabIndex = 1;
            this.Refersh.Text = "Làm mới";
            this.Refersh.UseVisualStyleBackColor = false;
            this.Refersh.Click += new System.EventHandler(this.Refersh_Click);
            // 
            // FormLichSuTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLyNongSan.Properties.Resources.ground;
            this.ClientSize = new System.Drawing.Size(983, 484);
            this.Controls.Add(this.thanhtien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTimKiem1);
            this.Controls.Add(this.dgvChiTiet1);
            this.Controls.Add(this.dgvLichSu1);
            this.Controls.Add(this.Refersh);
            this.Controls.Add(this.btnTimKiem1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormLichSuTT";
            this.Text = "Lịch sử đơn hàng";
            this.Load += new System.EventHandler(this.Form7_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvLichSu1;
        private System.Windows.Forms.TextBox txtTimKiem1;
        private System.Windows.Forms.Button btnTimKiem1;
        private System.Windows.Forms.DataGridView dgvChiTiet1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label thanhtien;
        private System.Windows.Forms.Button Refersh;
    }
}