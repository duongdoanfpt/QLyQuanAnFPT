﻿using System;
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
        string startupPath = Environment.CurrentDirectory;

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
        private void FrmLoad()
        {
            foreach (var bt in GetAll(this, typeof(Button)))
            {


                (bt as Button).Paint += Bt_Paint;

                (bt as Button).FlatStyle = FlatStyle.Standard;
               

            }





        }

        private void Bt_Paint(object sender, PaintEventArgs e)
        {
            Button bt = sender as Button;
            ControlPaint.DrawBorder(e.Graphics, bt.ClientRectangle,
            SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset);
        }


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
            FrmLoad();
            DgvThucDon.DataSource = busThucDon.DanhSachThucDon_1();
            ptbMenuThucDon.Enabled = false;
            ptbMenuThucDon.BorderStyle = BorderStyle.Fixed3D;
            DgvThucDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Disable_Textbox_Button();
            lblUsers.Text = FormLogin.NvMain.Email;
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
            if (string.IsNullOrEmpty(txtTenMon.Text) || string.IsNullOrWhiteSpace(txtTenMon.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên món", "Thông báo");
            }
            else if (string.IsNullOrEmpty(txtDonGia.Text) || string.IsNullOrWhiteSpace(txtDonGia.Text))
            {
                MessageBox.Show("Bạn chưa nhập đơn giá", "Thông báo");
            }
            else if (string.IsNullOrEmpty(txtNhom.Text) || string.IsNullOrWhiteSpace(txtNhom.Text)) {
                MessageBox.Show("Bạn chưa nhập nhóm", "Thông báo");
            }
            else
            {   if(ptbThucDon.Image is null)
                {
                    Image setLogo = Image.FromFile(startupPath + @"\image\logo.jpg");
                    byte[] arr1;
                    ImageConverter converter1 = new ImageConverter();
                    arr1 = (byte[])converter1.ConvertTo(setLogo, typeof(byte[]));
                    DTO_ThucDon curTD1 = new DTO_ThucDon(txtTenMon.Text, float.Parse(txtDonGia.Text), txtMoTa.Text, txtNhom.Text, arr1);
                    if (busThucDon.insertThucDon(curTD1))
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
                else
                {
                    Image img = ptbThucDon.BackgroundImage;
                    byte[] arr;
                    ImageConverter converter = new ImageConverter();
                    arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
                    DTO_ThucDon curTD = new DTO_ThucDon(txtTenMon.Text, float.Parse(txtDonGia.Text), txtMoTa.Text, txtNhom.Text, arr);

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
        public void SetNull_Value()
        {
            txtTenMon.Text = null;
            txtDonGia.Text = null;
            txtNhom.Text = null;
            txtMoTa.Text = null;
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            Enable_Textbox();
            SetNull_Value();
            
            txtTenMon.Focus();

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

        private void btXoa_Click(object sender, EventArgs e)
        {
            DTO_ThucDon td = busThucDon.curTD(DgvThucDon.CurrentRow.Cells["TenTD"].Value.ToString());
            if (busThucDon.XoaThucDon(td.MaTD))
            {
                MessageBox.Show("Xóa món thành công","Thông báo");
                DgvThucDon.DataSource = busThucDon.DanhSachThucDon_1();
                DgvThucDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            else
            {
                MessageBox.Show("Xóa món thất bại", "Thông báo");
            }
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenMon.Text) || string.IsNullOrWhiteSpace(txtTenMon.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên món", "Thông báo");
            }
            else if (string.IsNullOrEmpty(txtDonGia.Text) || string.IsNullOrWhiteSpace(txtDonGia.Text))
            {
                MessageBox.Show("Bạn chưa nhập đơn giá", "Thông báo");
            }
            else if (string.IsNullOrEmpty(txtNhom.Text) || string.IsNullOrWhiteSpace(txtNhom.Text))
            {
                MessageBox.Show("Bạn chưa nhập nhóm", "Thông báo");
            }

            else
            {
                
                Image img = ptbThucDon.BackgroundImage;
                byte[] arr;
                ImageConverter converter = new ImageConverter();
                arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
                DTO_ThucDon td = busThucDon.curTD(DgvThucDon.CurrentRow.Cells["TenTD"].Value.ToString());
                DTO_ThucDon curTD = new DTO_ThucDon(txtTenMon.Text, float.Parse(txtDonGia.Text), txtMoTa.Text, txtNhom.Text, arr);

                if (busThucDon.CapNhatThucDon(td.MaTD, curTD))
                {
                    MessageBox.Show("Cập nhật thành công");
                    DgvThucDon.DataSource = busThucDon.DanhSachThucDon_1();
                    DgvThucDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");

                }
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
            
        }

        private void Home_MouseEnter(object sender, EventArgs e)
        {
            Home.SizeMode = PictureBoxSizeMode.CenterImage;
            Home.Cursor = Cursors.Hand;
        }

        private void Home_MouseLeave(object sender, EventArgs e)
        {
            Home.SizeMode = PictureBoxSizeMode.Zoom;
            Home.Cursor = Cursors.Default;
        }

        

        private void KhachHang_MouseEnter(object sender, EventArgs e)
        {
            KhachHang.SizeMode = PictureBoxSizeMode.CenterImage;
            KhachHang.Cursor = Cursors.Hand;
        }

        private void KhachHang_MouseLeave(object sender, EventArgs e)
        {
            KhachHang.SizeMode = PictureBoxSizeMode.Zoom;
            KhachHang.Cursor = Cursors.Default;
        }

        private void Ban_MouseEnter(object sender, EventArgs e)
        {
            Ban.SizeMode = PictureBoxSizeMode.CenterImage;
            Ban.Cursor = Cursors.Hand;
        }

        private void Ban_MouseLeave(object sender, EventArgs e)
        {
            Ban.SizeMode = PictureBoxSizeMode.Zoom;
            Ban.Cursor = Cursors.Default;
        }

        private void ThongKe_MouseEnter(object sender, EventArgs e)
        {
            ThongKe.SizeMode = PictureBoxSizeMode.CenterImage;
            ThongKe.Cursor = Cursors.Hand;
            
        }

        private void ThongKe_MouseLeave(object sender, EventArgs e)
        {
            ThongKe.SizeMode = PictureBoxSizeMode.Zoom;
            ThongKe.Cursor = Cursors.Default;
        }

        private void CheckBoxDanhSach_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxDanhSach.Checked)
            {
                DgvThucDon.DataSource = busThucDon.DanhSachThucDonAll();
                DgvThucDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                DgvThucDon.DataSource = busThucDon.DanhSachThucDon_1();
                DgvThucDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
        }

        private void Home_Click(object sender, EventArgs e)
        {
            FormMain frmMain = new FormMain();
            this.Hide();

            frmMain.Closed += (s, args) => this.Close();
            frmMain.Show();
        }

        private void FormThucDon_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void NhanVien_Click(object sender, EventArgs e)
        {
            FormNhanVien nv = new FormNhanVien();
            this.Hide();

            nv.Closed += (s, args) => this.Close();
            nv.Show();
        }

        private void NhanVien_MouseEnter_1(object sender, EventArgs e)
        {
            NhanVien.SizeMode = PictureBoxSizeMode.CenterImage;
            NhanVien.Cursor = Cursors.Hand;
        }

        private void NhanVien_MouseLeave(object sender, EventArgs e)
        {
            NhanVien.SizeMode = PictureBoxSizeMode.Zoom;
            NhanVien.Cursor = Cursors.Default;
        }

        private void ptbMenuThucDon_MouseEnter(object sender, EventArgs e)
        {
            ptbMenuThucDon.SizeMode = PictureBoxSizeMode.CenterImage;
            ptbMenuThucDon.Cursor = Cursors.Hand;
        }

        private void ptbMenuThucDon_MouseLeave(object sender, EventArgs e)
        {
            ptbMenuThucDon.SizeMode = PictureBoxSizeMode.Zoom;
            ptbMenuThucDon.Cursor = Cursors.Default; 
        }

        private void KhachHang_Click(object sender, EventArgs e)
        {
            FormKhachHang kh = new FormKhachHang();
            this.Hide();

            kh.Closed += (s, args) => this.Close();
            kh.Show();
        }

        private void Ban_Click(object sender, EventArgs e)
        {
            FormKhuVucBan kv = new FormKhuVucBan();
            this.Hide();

            kv.Closed += (s, args) => this.Close();
            kv.Show();
        }

        private void ThongKe_Click(object sender, EventArgs e)
        {
            FormThongKe thongKe = new FormThongKe();
            this.Hide();

            thongKe.Closed += (s, args) => this.Close();
            thongKe.Show();
        }

        private void ptbMenuThucDon_Click(object sender, EventArgs e)
        {

        }
    }
}
