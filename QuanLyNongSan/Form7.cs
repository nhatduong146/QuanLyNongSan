using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyNongSan
{
    public partial class FormLichSuTT : Form
    {
        String pathHD = "HoaDonNhapXuat.xml";
        String pathChiTietHD = "ChiTietHD.xml";
        public XDocument doc;
        public int maxRow = 0;
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

        public void initGrid()
        {
            this.dgvLichSu1.ColumnCount = 3;
            this.dgvLichSu1.Columns[0].Name = "Mã HD";
            this.dgvLichSu1.Columns[1].Name = "Tên khách hàng";
            this.dgvLichSu1.Columns[2].Name = "Loại Hóa Đơn";
            doc = open(pathHD);
            string tenkh, loaiHD, maHD;
            this.dgvLichSu1.Rows.Clear();
            var list = doc.Descendants("HoaDonNhapXuat");
            foreach (XElement node in list)
            {
                maHD = node.Attribute("maHD").Value;
                tenkh = node.Attribute("tenKH").Value;
                loaiHD = node.Attribute("loaiHD").Value;
                    this.dgvLichSu1.Rows.Add(maHD, tenkh, loaiHD);
                
            }
            maxRow = this.dgvLichSu1.RowCount - 1;
        }

        public void initGrid_CT(string maHD)
        {
            this.dgvChiTiet1.ColumnCount = 3;
            this.dgvChiTiet1.Columns[0].Name = "Tên nông sản";
            this.dgvChiTiet1.Columns[1].Name = "Số lượng";
            this.dgvChiTiet1.Columns[2].Name = "Đơn giá";
            doc = open(pathChiTietHD);
            string tenNS, soLuong, gia;
            this.dgvChiTiet1.Rows.Clear();
            var list = doc.Descendants("ChiTietHD");
            foreach (XElement node in list)
            {
                if (node.Attribute("maHD").Value == maHD)
                {
                    tenNS = node.Attribute("tenNS").Value;
                    soLuong = node.Attribute("soLuong").Value;
                    gia = node.Attribute("gia").Value;
                    this.dgvChiTiet1.Rows.Add(tenNS, soLuong, gia);
                }

            }
            maxRow = this.dgvChiTiet1.RowCount - 1;
        }
        public FormLichSuTT()
        {
            InitializeComponent();
            initGrid();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }

        void capNhatTongTien()
        {
            int tongTien = 0;
            int tien;
            for (int i = 0; i < dgvChiTiet1.Rows.Count - 1; i++)
            {
                tien = int.Parse(dgvChiTiet1.Rows[i].Cells[1].Value.ToString()) * int.Parse(dgvChiTiet1.Rows[i].Cells[2].Value.ToString());
                tongTien += tien;
            }
            thanhtien.Text = tongTien.ToString()+  " VNĐ";
        }

        private void dgvLichSu1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string maHD = this.dgvLichSu1.CurrentRow.Cells[0].Value.ToString();
            initGrid_CT(maHD);
            capNhatTongTien();
        }

        private void dgvLichSu1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public XElement find(string ten, string path)
        {
            doc = open(path);
            string maHD, tenKH, loaiHD;
            this.dgvLichSu1.Rows.Clear();
            var list = doc.Descendants("HoaDonNhapXuat");
            foreach (XElement node in list)
            {
                if (node.Attribute("tenKH").Value.Trim().ToLower().Contains(ten))
                {
                    maHD = node.Attribute("maHD").Value;
                    tenKH = node.Attribute("tenKH").Value;
                    loaiHD = node.Attribute("loaiHD").Value;
                    this.dgvLichSu1.Rows.Add(maHD, tenKH, loaiHD);
                }

            }
            if (list != null)
            {
                foreach (XElement node in list)
                    if (node.Attribute("tenKH").Value.ToLower().Contains(ten.ToLower()))
                        return node;
            }
            return null;
        }
        private void btnTimKiem1_Click(object sender, EventArgs e)
        {
            string tenkh = txtTimKiem1.Text.Trim().ToLower();
            XElement node = find(tenkh, pathHD);
            if(tenkh=="")
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng cần tìm");
            }  
            else
                if (node == null)
                {
                    MessageBox.Show("Khôm tìm thấy tên bạn tìm kiếm");
                    txtTimKiem1.Text = "";
                    initGrid();
                }
        }

        private void Refersh_Click(object sender, EventArgs e)
        {
            initGrid();
        }

        private void txtTimKiem1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
