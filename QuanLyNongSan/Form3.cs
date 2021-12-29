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
    public partial class Form3 : Form
    {

        String pathDanhMuc = "DanhMucNongSan.xml";
        String pathNongSan = "ChiTietNongSan.xml";
        public XDocument doc;
        public string gr = "All";
        public int current = 0;
        public int maxRow = 0;
        public Form3()
        {
            InitializeComponent();
            initGrid(gr);
            grid2textbox(0);

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
        public XElement find(string scode, string path)
        {
            XDocument doc = open(path);

            var list = doc.Root.Nodes();

            foreach (XElement el in list)
            {
                if (scode == el.Attribute("tenNS").Value)
                {
                    return el;

                }

            }
            return null;
        }
        public void insert(string maNS, string tenNS, string soLuong, string chiTiet, string tenDM, string gia, string path)
        {
            XDocument doc = open(path);
            doc.Descendants("ute").Elements("ChiTietNongSan").Last().AddAfterSelf(new XElement("ChiTietNongSan",
            new XAttribute("maNS", maNS),
            new XAttribute("tenNS", tenNS),
            new XAttribute("soLuong", soLuong),
            new XAttribute("chiTiet", chiTiet),
            new XAttribute("tenDM", tenDM),
            new XAttribute("gia", gia)
            ));
            doc.Save(path);
        }
        public void update(string maNS, string tenNS, string soLuong, string chiTiet, string tenDM, string gia, string path)
        {
            XDocument doc = open(path);
            if (doc.Descendants("ChiTietNongSan").Where(x => x.Attribute("maNS").Value.Equals(maNS)).Count() == 1)
            {
                //Nếu đã tồn tại sản phẩm có ID này rồi thì thực hiện cập nhật
                XElement ele = doc.Descendants("ChiTietNongSan").Where(x => x.Attribute("maNS").Value.Equals(maNS)).First();
                ele.SetAttributeValue("tenNS", tenNS);
                ele.SetAttributeValue("soLuong", soLuong);
                ele.SetAttributeValue("chiTiet", chiTiet);
                ele.SetAttributeValue("maDM", tenDM);
                ele.SetAttributeValue("gia", gia);

            }
            doc.Save(path);
        }
        public bool delete(string maNS, string path)
        {
            XDocument doc = open(path);
            var list = doc.Root.Nodes();
            foreach (XElement el in list)
            {
                if (maNS == el.Attribute("maNS").Value)
                {
                    el.Remove();
                    doc.Save(path);
                    return true;
                }

            }
            return false;
        }
//--------------------------------------------------------------------------------------
        public void initCombo()
        {
            doc = open(pathDanhMuc);
            var list = doc.Descendants("DanhMucNongSan");
            string tmp = "All";
            this.cboDanhMuc.Items.Clear();
            this.cboDanhMuc.Items.Add("All");
            string group;
            ArrayList myClass = new ArrayList();
            foreach (XElement node in list)
            {
                group = node.Attribute("tenDM").Value;
                if (!tmp.Contains(group))
                {
                    tmp = tmp + "," + group;
                    myClass.Add(group);
                }
            }
            myClass.Sort();
            for (int i = 0; i < myClass.Count; i++)
            {
                this.cboDanhMuc.Items.Add(myClass[i]);
            }
        }
        public void initGrid(string gr)
        {
            this.dgvData.ColumnCount = 6;
            this.dgvData.Columns[0].Name = "Mã Nông Sản";
            this.dgvData.Columns[1].Name = "Tên Nông Sản";
            this.dgvData.Columns[2].Name = "Số Lượng";
            this.dgvData.Columns[3].Name = "Chi Tiết";
            this.dgvData.Columns[4].Name = "Tên Danh Mục";
            this.dgvData.Columns[5].Name = "Giá";
            doc = open(pathNongSan);
            var list = doc.Descendants("ChiTietNongSan");
            string group, maNS, tenNS, chiTiet, tenDM, soLuong, gia = "";
            this.dgvData.Rows.Clear();
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
                    this.dgvData.Rows.Add(maNS, tenNS, soLuong, chiTiet, tenDM, gia);
                }
            }
            maxRow = this.dgvData.RowCount -1 ;
            initCombo();
        }
        public void grid2textbox(int cur)
        {
            this.txtMaNS.Text =
            this.dgvData.Rows[cur].Cells[0].Value.ToString();
            this.txtTenNS.Text =
            this.dgvData.Rows[cur].Cells[1].Value.ToString();
            this.txtSoLuong.Text =
            this.dgvData.Rows[cur].Cells[2].Value.ToString();
            this.txtGia.Text =
            this.dgvData.Rows[cur].Cells[5].Value.ToString();
            this.cboDanhMuc.SelectedItem = this.dgvData.Rows[cur].Cells[4].Value.ToString();
        }
        public void emptyTextBox(bool ok)
         {
             if (ok)
             {
                this.txtTenNS.Text = "";
             }
                 this.txtSoLuong.Text = "";
                 this.txtGia.Text = "";
                 this.cboDanhMuc.Text = "All"; 
         }


        

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtMaNS.Text =
                this.dgvData.CurrentRow.Cells[0].Value.ToString();
            this.txtTenNS.Text =
                this.dgvData.CurrentRow.Cells[1].Value.ToString();
            this.txtSoLuong.Text =
                this.dgvData.CurrentRow.Cells[2].Value.ToString();
            this.txtGia.Text =
                this.dgvData.CurrentRow.Cells[5].Value.ToString();
            this.cboDanhMuc.Text =
                this.dgvData.CurrentRow.Cells[4].Value.ToString();
        }

        private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenNS = this.txtTimKiem.Text;
            XElement node = find(tenNS, pathNongSan);
            emptyTextBox(true);
            if (node == null)
            {
                MessageBox.Show("Node not found or Student Code is empty");
            }
            else
            {
                this.txtMaNS.Text = node.Attribute("maNS").Value;
                this.txtTenNS.Text = tenNS;
                this.txtSoLuong.Text = node.Attribute("soLuong").Value;
                this.txtGia.Text = node.Attribute("gia").Value;
                this.cboDanhMuc.Text = node.Attribute("tenDM").Value;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (txtMaNS.Text != "" && txtTenNS.Text != "" && txtSoLuong.Text != "" &&
                    txtGia.Text != "" && cboDanhMuc.Text != "")
            {
                insert(this.txtMaNS.Text, this.txtTenNS.Text,
                    this.txtSoLuong.Text, "nông sản tươi", this.cboDanhMuc.Text, this.txtGia.Text, pathNongSan);
                initGrid(gr);
            }
            else
            {
                MessageBox.Show("Không để trống mọi fiels");
                this.txtTenNS.Focus();
            }
        }

        private void txtSua_Click(object sender, EventArgs e)
        {
            if (this.btnSua.Text == "Sửa")
            {
                this.txtTenNS.Focus();
                this.btnSua.Text = "Lưu";
                this.btnSua.ForeColor = Color.Red;
                this.txtMaNS.Enabled = false;
            }
            else if (this.txtTenNS.Text != "" &&
                 this.txtSoLuong.Text != "" &&
                 this.txtGia.Text != "")
            {
                update(this.txtMaNS.Text, this.txtTenNS.Text,
                    this.txtSoLuong.Text, "nông sản tươi", this.cboDanhMuc.Text, this.txtGia.Text, pathNongSan);
                this.txtMaNS.Enabled = true;
                this.btnSua.ForeColor = Color.Black;
                this.btnSua.Text = "Sửa"; 
                initGrid(gr); grid2textbox(0);
            }
            else
            {
                MessageBox.Show("Không để trống các field",
                "Thông báo",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
                this.txtTenNS.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool ok = false;
            string maNS = this.txtMaNS.Text;
            DialogResult result =
            MessageBox.Show("You are sure to delete this node?",
            "Important Question",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (result == DialogResult.Yes && maNS.Trim() != "")
            {
                ok = delete(maNS, pathNongSan);
            }
            emptyTextBox(true);
            initGrid(gr);
            MessageBox.Show((ok == true ? "Removed!" :
            "Don't remove or Node not found"));

        }


    }
}
