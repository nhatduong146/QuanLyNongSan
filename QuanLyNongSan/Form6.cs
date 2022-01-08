using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyNongSan
{
    public partial class FormSaoLuuData : Form
    {
        public FormSaoLuuData()
        {
            InitializeComponent();
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
    }
}
