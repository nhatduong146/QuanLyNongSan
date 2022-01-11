using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;

namespace QuanLyNongSan
{
    public partial class FormSaoLuuData : Form
    {
        SqlConnection con;
        string sql;
        SqlDataAdapter adapter;
        string pathChiTietHD = "ChiTietHD.xml";
        string pathChiTietNS = "ChiTietNongSan.xml";
        string pathDanhMuc = "DanhMucNongSan.xml";
        string pathHoaDonNX = "HoaDonNhapXuat.xml";
        string pathKhachHang = "KhachHang.xml";
        string pathNhanVien = "NhanVien.xml";

        public FormSaoLuuData()
        {
            InitializeComponent();
            
        }
        private void connect(){
            string strCon = "Server=DESKTOP-4GDE4UA\\SQLEXPRESS;Database=QuanLyNongSan;Integrated Security=True;";
            con = new SqlConnection(strCon);
        }


        public DataTable HienThi(string file)
        {
            DataTable dt = new DataTable();
            string FilePath = Application.StartupPath + "\\" + file;
            if (File.Exists(FilePath))
            {
                DataSet ds = new DataSet();
                System.IO.FileStream fsReadXML = new System.IO.FileStream(FilePath, System.IO.FileMode.Open);
                ds.ReadXml(fsReadXML);
                DataView dv = new DataView(ds.Tables[0]); dt = dv.Table; fsReadXML.Close();
            }
            else
            {
                MessageBox.Show("File XML '" + file + "' không tồn tại");
            } return dt;
        }
        public void InsertOrUpDateSQL(string sql)
        {
            connect();
            con.Open(); 
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery(); 
        }
        void CapNhapTungBang(string tenBang)
        {
            string duongDan = @"" + tenBang + ".xml";
            DataTable table = HienThi(duongDan);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string sql = "insert into " + tenBang + " values(";
                for (int j = 0; j < table.Columns.Count - 1; j++)
                {
                    sql += "N'" + table.Rows[i][j].ToString().Trim() + "',";
                }
                sql += "N'" + table.Rows[i][table.Columns.Count - 1].ToString().Trim() + "'";
                sql += ")";
                InsertOrUpDateSQL(sql);
            }
        }

        private void buttonXML_SQL_Click(object sender, EventArgs e)
        {
            try
            {
                InsertOrUpDateSQL("delete from NhanVien");
                InsertOrUpDateSQL("delete from KhachHang");
                InsertOrUpDateSQL("delete from DanhMucNongSan");
                InsertOrUpDateSQL("delete from HoaDonNhapXuat");
                InsertOrUpDateSQL("delete from ChiTietNongSan");
                InsertOrUpDateSQL("delete from ChiTietHD");

                CapNhapTungBang("KhachHang");
                CapNhapTungBang("DanhMucNongSan");                
                CapNhapTungBang("HoaDonNhapXuat");                
                CapNhapTungBang("NhanVien");                
                CapNhapTungBang("ChiTietNongSan");                
                CapNhapTungBang("ChiTietHD");

                MessageBox.Show("Chuyển dữ liệu từ xml sang sql thành công");
            }
            catch (Exception ex) { MessageBox.Show("" + ex); }
        }

        public DataTable getData(string file, String path)
        {
            DataTable dt = new DataTable();
            string FilePath = path + file + ".xml";

            if (File.Exists(FilePath))
            {
                DataSet ds = new DataSet();
                System.IO.FileStream fsReadXML = new System.IO.FileStream(FilePath,
                System.IO.FileMode.Open);
                ds.ReadXml(fsReadXML);
                DataView dv = new DataView(ds.Tables[0]);
                dt = dv.Table;
                fsReadXML.Close();
            }
            else
            {
                throw new InvalidOperationException("Fiel không tồn tại !!!");
            }

            return dt;
        }

        public void SaoLuu(string file)
        {
            String path = Application.StartupPath + "\\";
            DataTable dt = getData(file, path);
            dt.WriteXml("D:\\" + file + ".xml", true);
        }

        public void KhoiPhuc(string file)
        {
            String path = "D:\\";
            DataTable dt = getData(file, path);
            dt.WriteXml(Application.StartupPath + "\\" + file + ".xml", true);
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form2().Show();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            SaoLuu("NhanVien");
            SaoLuu("ChiTietHD");
            SaoLuu("ChiTietNongSan");
            SaoLuu("DanhMucNongSan");
            SaoLuu("HoaDonNhapXuat");
            SaoLuu("KhachHang");
            MessageBox.Show("Sao lưu dữ liệu thành công");
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                KhoiPhuc("NhanVien");
                KhoiPhuc("ChiTietHD");
                KhoiPhuc("ChiTietNongSan");
                KhoiPhuc("DanhMucNongSan");
                KhoiPhuc("HoaDonNhapXuat");
                KhoiPhuc("KhachHang");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Chưa có bản sao lưu nào !!!");
                return;
            }
            
            MessageBox.Show("Khôi phục dữ liệu thành công");
        }

        public void TaoXML(string bang)
        {
            connect();
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
            MessageBox.Show("Chuyển đồi dữ liệu từ sql sang xml thành công");
        }
    }
}
