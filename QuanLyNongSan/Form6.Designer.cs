namespace QuanLyNongSan
{
    partial class FormSaoLuuData
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
            this.button4 = new System.Windows.Forms.Button();
            this.buttonXML_SQL = new System.Windows.Forms.Button();
            this.buttonSQL_XML = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Turquoise;
            this.button4.Location = new System.Drawing.Point(726, 1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(79, 43);
            this.button4.TabIndex = 7;
            this.button4.Text = "Thoát";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonXML_SQL
            // 
            this.buttonXML_SQL.BackColor = System.Drawing.Color.Turquoise;
            this.buttonXML_SQL.Location = new System.Drawing.Point(79, 171);
            this.buttonXML_SQL.Name = "buttonXML_SQL";
            this.buttonXML_SQL.Size = new System.Drawing.Size(267, 44);
            this.buttonXML_SQL.TabIndex = 2;
            this.buttonXML_SQL.Text = "Chuyển đổi XML -> SQL";
            this.buttonXML_SQL.UseVisualStyleBackColor = false;
            this.buttonXML_SQL.Click += new System.EventHandler(this.buttonXML_SQL_Click);
            // 
            // buttonSQL_XML
            // 
            this.buttonSQL_XML.BackColor = System.Drawing.Color.Turquoise;
            this.buttonSQL_XML.Location = new System.Drawing.Point(79, 258);
            this.buttonSQL_XML.Name = "buttonSQL_XML";
            this.buttonSQL_XML.Size = new System.Drawing.Size(266, 43);
            this.buttonSQL_XML.TabIndex = 3;
            this.buttonSQL_XML.Text = "Chuyển đổi SQL - XML";
            this.buttonSQL_XML.UseVisualStyleBackColor = false;
            this.buttonSQL_XML.Click += new System.EventHandler(this.buttonSQL_XML_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.Turquoise;
            this.btnRestore.Location = new System.Drawing.Point(479, 255);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(229, 46);
            this.btnRestore.TabIndex = 4;
            this.btnRestore.Text = "Khôi phục dữ liệu";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.Turquoise;
            this.btnBackup.Location = new System.Drawing.Point(479, 169);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(229, 46);
            this.btnBackup.TabIndex = 5;
            this.btnBackup.Text = "Sao lưu dữ liệu";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(172, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(493, 42);
            this.label1.TabIndex = 8;
            this.label1.Text = "QUẢN LÝ CSDL - SAO LƯU";
            // 
            // FormSaoLuuData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLyNongSan.Properties.Resources.ground;
            this.ClientSize = new System.Drawing.Size(808, 415);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.buttonSQL_XML);
            this.Controls.Add(this.buttonXML_SQL);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormSaoLuuData";
            this.Text = "Chuyển dổi - sao lưu dữ liệu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonXML_SQL;
        private System.Windows.Forms.Button buttonSQL_XML;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
    }
}