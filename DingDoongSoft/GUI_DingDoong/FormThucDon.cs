using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_DingDoong;
using BUS_DingDoong;

namespace GUI_DingDoong
{
    public partial class FormThucDon : Form
    {
        public FormThucDon()
        {
            InitializeComponent();
        }
        private string imagePath;
        BUS_ThucDon busThucDon = new BUS_ThucDon();

        //Disable textbox & button
        public void Disable_Textbox_Button()
        {
            //Disable
            txtTenMon.Enabled = false;
            txtDonGia.Enabled = false;
            txtMoTa.Enabled = false;
            txtNhom.Enabled = false;
            btLuu.Enabled = false;
            btXoa.Enabled = false;
            btCapNhat.Enabled = false;
            btBoQua.Enabled = false;

            //Set null
            txtTenMon.Text = null;
            txtDonGia.Text = null;
            txtNhom.Text = null;
            txtMoTa.Text = null;
        }
        

        private void FormThucDon_Load(object sender, EventArgs e)
        {
            DgvThucDon.DataSource = busThucDon.DanhSachThucDon_1();
            DgvThucDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Disable_Textbox_Button();
        }

        //Change Value Image
        private void ChangeImage(ref string Path)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "C:\\";
                openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog1.FileName;
                    FileInfo fi = new FileInfo(filePath);
                    Image img = Image.FromFile(filePath);
                    ptbThucDon.BackgroundImage = Image.FromFile(filePath);
                    ptbThucDon.BackgroundImageLayout = ImageLayout.Stretch;
                    Path = filePath;
                }
                else Path = "";


            }
            catch
            {

            }
        }


        private void btOpenDialog_Click(object sender, EventArgs e)
        {
            ChangeImage(ref imagePath);
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            Image img = ptbThucDon.BackgroundImage;
            byte[] arr;
            ImageConverter converter = new ImageConverter();
            arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            DTO_ThucDon curTD = new DTO_ThucDon(txtTenMon.Text, float.Parse(txtDonGia.Text), txtMoTa.Text, txtNhom.Text, arr);
            MessageBox.Show(curTD.Hinh.ToString());

            if (busThucDon.insertThucDon(curTD))
            {
                MessageBox.Show("Thêm món vào thực đơn thành công");
                DgvThucDon.DataSource = busThucDon.DanhSachThucDon_1();
                DgvThucDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            }
            else
            {
                MessageBox.Show("Thêm món vào thực đơn thất bại");

            }
        }
        public void Enable_Textbox()
        {
            txtTenMon.Enabled = true;
            txtDonGia.Enabled = true;
            txtMoTa.Enabled = true;
            txtNhom.Enabled = true;
            btLuu.Enabled = true;
            btXoa.Enabled = true;
            btCapNhat.Enabled = true;
            btBoQua.Enabled = true;
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            Enable_Textbox();
        }

        private void btBoQua_Click(object sender, EventArgs e)
        {
            Disable_Textbox_Button();
        }
        private void LoadDanhSachThucDon(DataTable dt)
        {
            DgvThucDon.DataSource = dt;
        }
        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string tenTD = txtTimKiem.Text;
            DataTable ds = busThucDon.TimKiemThucDon(tenTD);
            if (ds.Rows.Count > 0)
            {
                LoadDanhSachThucDon(ds);
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtTimKiem.Text = "Nhập tên món để tìm kiếm";

        }

        private void DgvThucDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(DgvThucDon.Rows.Count > 1)
            {
                if(DgvThucDon.CurrentRow.Index < DgvThucDon.Rows.Count - 1)
                {
                    btOpenDialog.Enabled = true;
                    btLuu.Enabled = true;
                    btXoa.Enabled = true;
                    btCapNhat.Enabled = true;
                    btBoQua.Enabled = true;
                    txtTenMon.Enabled = true;
                    txtDonGia.Enabled = true;
                    txtNhom.Enabled = true;
                    txtMoTa.Enabled = true;
                    txtTenMon.Focus();

                    DTO_ThucDon td = busThucDon.curTD(DgvThucDon.CurrentRow.Cells["TenTD"].Value.ToString());
                    txtTenMon.Text = td.TenTD;
                    txtDonGia.Text = td.GiaBan.ToString();
                    txtNhom.Text = td.Nhom;
                    txtMoTa.Text = td.MoTa;

                    
                    MemoryStream mem = new MemoryStream(busThucDon.getHinhTD(td.MaTD));
                    ptbThucDon.BackgroundImage = Image.FromStream(mem);
                    ptbThucDon.BackgroundImageLayout = ImageLayout.Stretch;


                }
            }
        }
    }
}
