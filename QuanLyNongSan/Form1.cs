using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Collections;

namespace QuanLyNongSan
{
    public partial class Form1 : Form
    {
        String pathNhanVien = "NhanVien.xml";
        public XDocument doc;


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public XDocument open(string url)
        {
            try
            {
                return XDocument.Load(url);
            }
            catch
            {
                return null;
            }
        }

        public XElement find(string tenDN, string matKhau, string path)
        {
            XDocument doc = open(path);

            var list = doc.Root.Nodes();

            foreach (XElement el in list)
            {
                if (el.Attribute("tenDN").Value == tenDN && el.Attribute("matKhau").Value == matKhau)
                {
                    return el;

                }
            }
            return null;
        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            string tenDN = this.txtTenDN.Text;
            string matKhau = this.txtMatKhau.Text;

            if(find(tenDN, matKhau, pathNhanVien) != null)
            {
                Form2 form2 = new Form2();
                this.Hide();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không hợp lệ !!!");
            }


            
        }
    }
}
