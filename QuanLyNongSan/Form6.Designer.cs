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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonXML_SQL = new System.Windows.Forms.Button();
            this.buttonSQL_XML = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 62);
            this.panel1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(670, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(79, 43);
            this.button4.TabIndex = 7;
            this.button4.Text = "Thoát";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ CSDL - SAO LƯU";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonXML_SQL
            // 
            this.buttonXML_SQL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonXML_SQL.Location = new System.Drawing.Point(57, 143);
            this.buttonXML_SQL.Name = "buttonXML_SQL";
            this.buttonXML_SQL.Size = new System.Drawing.Size(267, 44);
            this.buttonXML_SQL.TabIndex = 2;
            this.buttonXML_SQL.Text = "Chuyển đổi XML -> mySQL";
            this.buttonXML_SQL.UseVisualStyleBackColor = false;
            this.buttonXML_SQL.Click += new System.EventHandler(this.buttonXML_SQL_Click);
            // 
            // buttonSQL_XML
            // 
            this.buttonSQL_XML.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonSQL_XML.Location = new System.Drawing.Point(57, 230);
            this.buttonSQL_XML.Name = "buttonSQL_XML";
            this.buttonSQL_XML.Size = new System.Drawing.Size(266, 43);
            this.buttonSQL_XML.TabIndex = 3;
            this.buttonSQL_XML.Text = "Chuyển đổi mySQL - XML";
            this.buttonSQL_XML.UseVisualStyleBackColor = false;
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnRestore.Location = new System.Drawing.Point(457, 227);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(229, 46);
            this.btnRestore.TabIndex = 4;
            this.btnRestore.Text = "Khôi phục dữ liệu";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnBackup.Location = new System.Drawing.Point(457, 141);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(229, 46);
            this.btnBackup.TabIndex = 5;
            this.btnBackup.Text = "Sao lưu dữ liệu";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // FormSaoLuuData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLyNongSan.Properties.Resources.bg04;
            this.ClientSize = new System.Drawing.Size(761, 369);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.buttonSQL_XML);
            this.Controls.Add(this.buttonXML_SQL);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormSaoLuuData";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonXML_SQL;
        private System.Windows.Forms.Button buttonSQL_XML;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button button4;
    }
}