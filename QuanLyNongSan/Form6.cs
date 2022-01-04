using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

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
            string strCon = "Server=DESKTOP-FS2IFVK\\SQLEXPRESS;Database=QuanLyNongSan;Integrated Security=True;";
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
            con.Open(); SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery(); con.Close();
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
                MessageBox.Show("Chuyển dữ liệu thành công");
            }
            catch (Exception ex) { MessageBox.Show("" + ex); }
        }
    }
}
