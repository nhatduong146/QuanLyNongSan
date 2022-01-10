using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Collections;

namespace QuanLyNongSan
{
    public partial class Form4 : Form
    {
        String pathKhachHang = "KhachHang.xml";
        String pathNongSan = "ChiTietNongSan.xml";
        String pathChiTietHoaDon = "ChiTietHD.xml";
        String pathHoaDonNhapXuat = "HoaDonNhapXuat.xml";

        public XDocument doc;

        public int maxRow = 0;
        public string gr = "All";
        public Form4()
        {
            InitializeComponent();
            initGrid(gr);
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
        public void initGrid(string gr)
        {
            this.dataGridView1.ColumnCount = 6;
            this.dataGridView1.Columns[0].Name = "Mã Nông Sản";
            this.dataGridView1.Columns[1].Name = "Tên Nông Sản";
            this.dataGridView1.Columns[2].Name = "Số Lượng";
            this.dataGridView1.Columns[3].Name = "Chi Tiết";
            this.dataGridView1.Columns[4].Name = "Tên Danh Mục";
            this.dataGridView1.Columns[5].Name = "Giá";
            doc = open(pathNongSan);
            var list = doc.Descendants("ChiTietNongSan");
            string group, maNS, tenNS, chiTiet, tenDM, soLuong, gia = "";
            this.dataGridView1.Rows.Clear();
            foreach (XElement node in list)
            {
                group = node.Attribute("tenDM").Value;
                if (gr == group || gr == "All")
                {
                    maNS = node.Attribute("maNS").Value;
                    tenNS = node.Attribute("tenNS").Value;
                    soLuong = node.Attribute("soLuong").Value;
                    chiTiet = node.Attribute("chiTiet").Value;
                    tenDM = node.Attribute("tenDM").Value;
                    gia = node.Attribute("gia").Value;
                    this.dataGridView1.Rows.Add(maNS, tenNS, soLuong, chiTiet, tenDM, gia);
                }
            }
            maxRow = this.dataGridView1.RowCount - 1;
        }

        public void initGridTK(string gr, string code)
        {
            this.dataGridView1.ColumnCount = 6;
            this.dataGridView1.Columns[0].Name = "Mã Nông Sản";
            this.dataGridView1.Columns[1].Name = "Tên Nông Sản";
            this.dataGridView1.Columns[2].Name = "Số Lượng";
            this.dataGridView1.Columns[3].Name = "Chi Tiết";
            this.dataGridView1.Columns[4].Name = "Tên Danh Mục";
            this.dataGridView1.Columns[5].Name = "Giá";
            doc = open(pathNongSan);
            var list = doc.Descendants("ChiTietNongSan");
            string group, maNS, tenNS, chiTiet, tenDM, soLuong, gia = "", scode;
            this.dataGridView1.Rows.Clear();
            foreach (XElement node in list)
            {
                group = node.Attribute("tenDM").Value;
                scode = node.Attribute("tenNS").Value.ToLower().Trim();
                if (gr == group || gr == "All" && scode.Contains(code))
                {
                    maNS = node.Attribute("maNS").Value;
                    tenNS = node.Attribute("tenNS").Value;
                    soLuong = node.Attribute("soLuong").Value;
                    chiTiet = node.Attribute("chiTiet").Value;
                    tenDM = node.Attribute("tenDM").Value;
                    gia = node.Attribute("gia").Value;
                    this.dataGridView1.Rows.Add(maNS, tenNS, soLuong, chiTiet, tenDM, gia);
                }
            }
            maxRow = this.dataGridView1.RowCount - 1;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void Form4_Load(object sender, EventArgs e)
        {



        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            string text = labelDanhSachNS.Text;
            if (textBoxSoLuong.Text == "")
                MessageBox.Show("Vui lòng nhập số lượng mua", "Thông Báo");
            else
            {
                try
                {
                    int soLuongMua = int.Parse(textBoxSoLuong.Text);
                    int r = this.dataGridView1.CurrentCell.RowIndex;
                    if (soLuongMua > 0 && int.Parse(textBoxSoLuong.Text) <= int.Parse(dataGridView1.Rows[r].Cells[2].FormattedValue.ToString()))
                    {
                        dataGridView2.ColumnCount = 5;
                        this.dataGridView2.Columns[0].Name = "Mã Nông Sản";
                        this.dataGridView2.Columns[1].Name = "Tên Nông Sản";
                        this.dataGridView2.Columns[2].Name = "Số Lượng";
                        this.dataGridView2.Columns[3].Name = "Giá";
                        this.dataGridView2.Columns[4].Name = "Thành tiền";
                        this.dataGridView2.Rows.Add(
                            dataGridView1.Rows[r].Cells[0].FormattedValue.ToString(),
                            dataGridView1.Rows[r].Cells[1].FormattedValue.ToString(),
                            soLuongMua,
                            dataGridView1.Rows[r].Cells[5].FormattedValue.ToString(),
                            (soLuongMua * int.Parse(dataGridView1.Rows[r].Cells[5].FormattedValue.ToString()))
                            );
                        text = text + dataGridView1.Rows[r].Cells[1].FormattedValue.ToString() + " " + soLuongMua.ToString() + " " + (soLuongMua * int.Parse(dataGridView1.Rows[r].Cells[5].FormattedValue.ToString())) + "\n";
                    }
                    else
                        MessageBox.Show("Đầu Vào Sai", "Thông Báo");
                }
                catch { }
                capNhatTongTien();
                labelDanhSachNS.Text = text;
                textBoxSoLuong.Text = "";
            }
        }
        void capNhatTongTien()
        {
            int tongTien = 0;
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                tongTien += int.Parse(dataGridView2.Rows[i].Cells[4].Value.ToString());
            }
            labelTongTien.Text = tongTien.ToString();

        }
        public XElement findNS(string scode, string path)
        {
            XDocument doc = open(path);

            var list = doc.Root.Nodes();

            foreach (XElement el in list)
            {
                string code = el.Attribute("tenNS").Value.ToLower().Trim();
                if (code.Contains(scode))
                {
                    return el;
                }

            }
            return null;
        }
        public XElement findKH(string scode, string path)
        {
            XDocument doc = open(path);

            var list = doc.Root.Nodes();

            foreach (XElement el in list)
            {
                string code = el.Attribute("maKH").Value.ToLower().Trim();
                if (code.Contains(scode))
                {
                    return el;

                }

            }
            return null;
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            String str = "";
            DialogResult dlr = MessageBox.Show("Bạn xóa sản phẩm này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                try
                {
                    dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
                    for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                    {
                        str = str + dataGridView2.Rows[i].Cells[1].FormattedValue.ToString() + " " + dataGridView2.Rows[i].Cells[2].FormattedValue.ToString() + " " + dataGridView2.Rows[i].Cells[4].FormattedValue.ToString() + "\n";
                    }
                    labelDanhSachNS.Text = str;
                }
                catch { }
                capNhatTongTien();
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_MouseCaptureChanged(object sender, EventArgs e)
        {
            

        }
        private void textBoxMaKhachHang_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView2.CurrentRow.Cells[5].Value = (int.Parse(dataGridView2.CurrentRow.Cells[3].Value.ToString()) * int.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString())).ToString();
                capNhatTongTien();
            }
            catch { }

        }
        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        public String findTH(string maKH, string path)
        {
            string str = "";

            XDocument doc = open(path);
            var list = doc.Root.Nodes();
            foreach (XElement dt in list)
            {
                string code = dt.Attribute("maKH").Value.ToLower().Trim();
                if (code.Contains(maKH))
                {
                    str = dt.Attribute("tenKH").Value;

                }
            }
            return str;
        }
        private void buttonThanhToan_Click(object sender, EventArgs e)
        {
            




        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void labelDanhSachNS_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
           
                
        }

        private void buttonTimKiem_Click_1(object sender, EventArgs e)
        {
            String search = textBoxTimKiem.Text.ToLower().Trim();
            XElement node = findNS(search, pathNongSan);
            if (node == null)
            {
                MessageBox.Show("Node not found or Student Code is empty");
            }
            else
            {
                initGridTK(gr, search);
            }
        }

        private void buttonThanhToan_Click_1(object sender, EventArgs e)
        {
            String maKH = TxTMaKH.Text;
            if (maKH == "")
                MessageBox.Show("Chua nhap maKH");
            else
            {
                String tenkh = findTH(maKH, pathKhachHang);
                string mans = "";
                List<XElement> elements = new List<XElement>();
                XDocument docCT = open(pathChiTietHoaDon);
                XDocument docHD = open(pathHoaDonNhapXuat);
                XDocument docKH = open(pathKhachHang);
                XDocument docNS = open(pathNongSan);
                XElement node = findKH(maKH, pathKhachHang);
                int tiendamua = 0;
                if (node == null || dataGridView2.Rows.Count == 0)
                    MessageBox.Show("MaKH không đúng hoặc chưa được đăng ký!");
                else
                {
                    docHD.Element("ute").Add(
                        new XElement("HoaDonNhapXuat",
                            new XAttribute("maHD", "HD005"),
                            new XAttribute("tenNV", "Nguyễn Văn A"),
                            new XAttribute("tenKH", tenkh),
                            new XAttribute("loaiHD", "Loại 2")
                            ));
                    docHD.Save(pathHoaDonNhapXuat);
                    for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                    {
                        docCT.Element("ute").Add(
                            new XElement("ChiTietHoaDon",
                                new XAttribute("maHD", "HD005"),
                                new XAttribute("tenNS", dataGridView2.Rows[i].Cells[1].FormattedValue.ToString()),
                                new XAttribute("soLuong", dataGridView2.Rows[i].Cells[2].FormattedValue.ToString()),
                                new XAttribute("gia", dataGridView2.Rows[i].Cells[3].FormattedValue.ToString())
                            ));
                        foreach (XElement dt in docNS.Descendants("ChiTietNongSan"))
                        {
                            if (dt.Attribute("maNS").Value.Equals(dataGridView2.Rows[i].Cells[0].FormattedValue.ToString()))
                            {
                                int soluong = int.Parse(dt.Attribute("soLuong").Value.ToString()) - int.Parse(dataGridView2.Rows[i].Cells[2].FormattedValue.ToString());
                                dt.Attribute("soLuong").Value = soluong.ToString();
                            }
                        }
                        docNS.Save(pathNongSan);
                        docCT.Save(pathChiTietHoaDon);
                    }
                    foreach (XElement dt in docKH.Descendants("KhachHang"))
                    {
                        if (dt.Attribute("maKH").Value.Equals(maKH))
                        {
                            tiendamua = int.Parse(dt.Attribute("tienDaMua").Value.ToString()) + int.Parse(labelTongTien.Text);
                            dt.Attribute("tienDaMua").Value = tiendamua.ToString();
                        }
                    }
                    docKH.Save(pathKhachHang);

                    docNS.Save(pathNongSan);
                    TxTMaKH.Text = "";
                    dataGridView2.Rows.Clear();
                    initGrid(gr);
                    labelDanhSachNS.Text = "";
                    labelTongTien.Text = "";
                }

            }
        }

        private void btn_LamLmoi_Click(object sender, EventArgs e)
        {
            initGrid(gr);
            textBoxTimKiem.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxSoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count <= 1)
            {
                DialogResult dlr = MessageBox.Show("Bạn chưa hoàn tất việc thành toán! \n Bạn có chắc muốn thoát khỏi chức năng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    this.Hide();
                    new Form2().Show();
                }
            }
            else
            {
                this.Hide();
                new Form2().Show();

            }
        }
    }
}
