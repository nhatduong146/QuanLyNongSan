using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;

namespace QuanLyNongSan
{
    public partial class FormSaoLuuData : Form
    {
        string sever = @"TRONG-KHANG\TRANTHITHULUYEN";
        string database = "QuanLyNongSan";
        string user = "sa";
        string pass = "tttl1209ntk0208";
        SqlConnection con;
        public FormSaoLuuData()
        {
            InitializeComponent();
        }
        public void ketnoi()
        {
            string url = @"Data Source=" + sever + ";Initial Catalog=" + database +
               ";Persist Security Info = True; User ID=" + user + ";Password=" + pass;
            con = new SqlConnection(url);
        }

        public void TaoXML(string bang)
        {
            ketnoi();
            con.Open();
            string sql = "Select * from " + bang + " for xml auto";
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            string xml = "<?xml version='1.0'?><ute>";
            xml += dt.Rows[0].ItemArray[0].ToString() + "</ute>";
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.LoadXml(xml); // nạp chuổi XML vào cây XML
            XmlDoc.Save(Application.StartupPath + "\\" + bang + ".xml");
           
        }
        private void buttonSQL_XML_Click(object sender, EventArgs e)
        {
            TaoXML("ChiTietHD");
            TaoXML("ChiTietNongSan");
            TaoXML("DanhMucNongSan");
            TaoXML("HoaDonNhapXuat");
            TaoXML("KhachHang");
            TaoXML("NhanVien");
            MessageBox.Show("Chuyển đồi dữ liệu thành công", "Thong Bao");
        }
    }
}
