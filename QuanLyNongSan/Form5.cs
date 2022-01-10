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
    public partial class Form5 : Form
    {
        String pathKhachHang = "KhachHang.xml";
        public XDocument doc;
        public string gr = "All";
        public int current = 0;
        public int maxRow = 0;

        public Form5()
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

        public void insert(string maKH, string tenKH, string namSinh, string tienDaMua, string path)
        {
            XDocument doc = open(path);
            doc.Descendants("ute").Elements("KhachHang").Last().AddAfterSelf(new XElement("KhachHang",
            new XAttribute("maKH", maKH),
            new XAttribute("tenKH", tenKH),
            new XAttribute("namSinh", namSinh),
            new XAttribute("tienDaMua", tienDaMua)
            ));
            doc.Save(path);
        }

        public void update(string maKH, string tenKH, string namSinh, string tienDaMua, string path)
        {
            XDocument doc = open(path);
            if (doc.Descendants("KhachHang").Where(x => x.Attribute("maKH").Value.Equals(maKH)).Count() == 1)
            {
                //Nếu đã tồn tại sản phẩm có ID này rồi thì thực hiện cập nhật
                XElement ele = doc.Descendants("KhachHang").Where(x => x.Attribute("maKH").Value.Equals(maKH)).First();
                ele.SetAttributeValue("maKH", maKH);
                ele.SetAttributeValue("tenKH", tenKH);
                ele.SetAttributeValue("namSinh", namSinh);
                ele.SetAttributeValue("tienDaMua", tienDaMua);
            }
            doc.Save(path);
        }

        public bool delete(string maKH, string path)
        {
            XDocument doc = open(path);
            var list = doc.Root.Nodes();
            foreach (XElement el in list)
            {
                if (maKH == el.Attribute("maKH").Value)
                {
                    el.Remove();
                    doc.Save(path);
                    return true;
                }

            }
            return false;
        }



        public void initGrid(string gr)
        {
            this.dgvData.ColumnCount = 4;
            this.dgvData.Columns[0].Width = 120;
            this.dgvData.Columns[0].Name = "Mã khách hàng";
            this.dgvData.Columns[1].Width = 220;
            this.dgvData.Columns[1].Name = "Tên khách hàng";
            this.dgvData.Columns[2].Width = 100;
            this.dgvData.Columns[2].Name = "Năm sinh";
            this.dgvData.Columns[3].Width = 150;
            this.dgvData.Columns[3].Name = "Tiền đã sử dụng";
            doc = open(pathKhachHang);
            var list = doc.Descendants("KhachHang");
            string group, maKH, tenKH, namSinh, tienDaMua;
            this.dgvData.Rows.Clear();
            foreach (XElement node in list)
            {
                group = node.Attribute("tenKH").Value;
                if (gr == group || gr == "All")
                {
                    maKH = node.Attribute("maKH").Value;
                    tenKH = node.Attribute("tenKH").Value;
                    namSinh = node.Attribute("namSinh").Value;
                    tienDaMua = node.Attribute("tienDaMua").Value;
                    this.dgvData.Rows.Add(maKH, tenKH, namSinh, tienDaMua);
                }
            }
            maxRow = this.dgvData.RowCount - 1;
        }

        public void grid2textbox(int cur)
        {
            this.txtMaKH.Text =
            this.dgvData.Rows[cur].Cells[0].Value.ToString();
            this.txtTenKH.Text =
            this.dgvData.Rows[cur].Cells[1].Value.ToString();
            this.txtNamSinh.Text =
            this.dgvData.Rows[cur].Cells[2].Value.ToString();
            this.txtTienDaMua.Text =
            this.dgvData.Rows[cur].Cells[3].Value.ToString();
        }

        public XElement find(string tenKH, string path)//list
        {
            doc = open(path);
            var list = doc.Descendants("KhachHang");
            this.dgvData.Rows.Clear();
            string maKH, namSinh, tienDaMua, ten;

            foreach (XElement node in list)
            {
                if (node.Attribute("tenKH").Value.ToLower().Trim().Contains(tenKH))
                {
                    maKH = node.Attribute("maKH").Value;
                    ten = node.Attribute("tenKH").Value;
                    namSinh = node.Attribute("namSinh").Value;
                    tienDaMua = node.Attribute("tienDaMua").Value;
                    this.dgvData.Rows.Add(maKH, ten, namSinh, tienDaMua);
                }
            }

            if(list != null)
            {
                foreach (XElement node in list)
                    if (node.Attribute("tenKH").Value.ToLower().Contains(tenKH.ToLower()))
                        return node;
            }
            return null;

        }

        public void emptyTextBox(bool ok)
        {
            if (ok)
            {
                this.txtMaKH.Text = "";
                this.txtTenKH.Text = "";
                this.txtNamSinh.Text = "";
                this.txtTienDaMua.Text = "";
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtMaKH.Text =
                this.dgvData.CurrentRow.Cells[0].Value.ToString();
            this.txtTenKH.Text =
                this.dgvData.CurrentRow.Cells[1].Value.ToString();
            this.txtNamSinh.Text =
                this.dgvData.CurrentRow.Cells[2].Value.ToString();
            this.txtTienDaMua.Text =
                this.dgvData.CurrentRow.Cells[3].Value.ToString();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            string tenKH = this.txtSearch.Text;
            XElement node = find(tenKH, pathKhachHang);
            emptyTextBox(true);
            if (node == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng nào có tên như bạn cung cấp");
            }
            else
            {
                this.txtMaKH.Text = node.Attribute("maKH").Value;
                this.txtTenKH.Text = node.Attribute("tenKH").Value; 
                this.txtNamSinh.Text = node.Attribute("namSinh").Value;
                this.txtTienDaMua.Text = node.Attribute("tienDaMua").Value;
            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (txtMaKH.Text != "" && txtTenKH.Text != "" && txtNamSinh.Text != "" &&
                    txtTienDaMua.Text != "")
            {
                insert(this.txtMaKH.Text, this.txtTenKH.Text,
                    this.txtNamSinh.Text,this.txtTienDaMua.Text, pathKhachHang);
                initGrid(gr);
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                this.txtTenKH.Focus();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (this.btnSua.Text == "Sửa")
            {
                this.txtTenKH.Focus();
                this.btnSua.Text = "Lưu";
                this.btnSua.ForeColor = Color.Red;
                this.btnThem.Enabled = false;
                this.btnXoa.Enabled = false;
                this.btnLamMoi.Enabled = false;
                this.txtMaKH.Enabled = false;
            }
            else if (this.txtTenKH.Text != "" &&
                 this.txtNamSinh.Text != "" &&
                 this.txtTienDaMua.Text != "")
            {
                update(this.txtMaKH.Text, this.txtTenKH.Text,
                    this.txtNamSinh.Text, this.txtTienDaMua.Text, pathKhachHang);
                this.txtMaKH.Enabled = true;
                this.btnSua.ForeColor = Color.Black;
                this.btnThem.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnLamMoi.Enabled = true;
                //this.btnXoa.Enabled = true;
                this.btnSua.Text = "Sửa";
                initGrid(gr); grid2textbox(0);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin",
                "Thông báo",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
                this.txtTenKH.Focus();
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            bool ok = false;
            string maKH = this.txtMaKH.Text;
            DialogResult result =
            MessageBox.Show("Bạn có chắc chắn xóa khách hàng này?",
            "Important Question",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (result == DialogResult.Yes && maKH.Trim() != "")
            {
                ok = delete(maKH, pathKhachHang);
            }
            emptyTextBox(true);
            initGrid(gr);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            emptyTextBox(true);
            initGrid(gr);
            txtSearch.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form2().Show();
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
