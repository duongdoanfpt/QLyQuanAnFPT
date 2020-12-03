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
using System.Net.Mail;
using BUS_DingDoong;
using DTO_DingDoong;

namespace GUI_DingDoong
{
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
        }
        private string imagePath;
        string startupPath = Environment.CurrentDirectory;
        BUS_NhanVien busnhanvien = new BUS_NhanVien();

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            pbHinh.BackgroundImage = Image.FromFile(startupPath + @"\image\logo.jpg");
            pbHinh.BackgroundImageLayout = ImageLayout.Stretch;
            LoadGridView_NV();
            Disable_Textbox_Button();
        }

        private void LoadGridView_NV()
        {
            BUS_NhanVien busnhanvien = new BUS_NhanVien();
            dgvNhanVien.DataSource = busnhanvien.getDanhSachNV();
            dgvNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
            dgvNhanVien.Columns[1].HeaderText = "Email Nhân Viên";
            dgvNhanVien.Columns[2].HeaderText = "Tên Nhân Viên";
            dgvNhanVien.Columns[3].HeaderText = "Địa Chỉ";
            dgvNhanVien.Columns[4].HeaderText = "Vai Trò";
            dgvNhanVien.Columns[5].HeaderText = "Trạng Thái";
            dgvNhanVien.Columns[6].HeaderText = "Ngày Vào Làm";
            dgvNhanVien.Columns[5].Visible = false;
        }

    public void Disable_Textbox_Button()
        {
            //Disable
            txtTenNhanVien.Enabled = false;
            txtEmail.Enabled = false;
            txtDiaChi.Enabled = false;
            dateTimeNVL.Enabled = false;
            rdNhanVien.Enabled = false;
            rdQuanLy.Enabled = false;
            btLuu.Enabled = false;
            btXoa.Enabled = false;
            btCapNhat.Enabled = false;
            btBoQua.Enabled = false;

            //Set null
            txtTenNhanVien.Text = null;
            txtEmail.Text = null;
            txtDiaChi.Text = null;
            
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
                    pbHinh.BackgroundImage = Image.FromFile(filePath);
                    pbHinh.BackgroundImageLayout = ImageLayout.Stretch;
                    Path = filePath;
                }
                else Path = "";


            }
            catch
            {

            }
        }

        private void pbHinh_Click(object sender, EventArgs e)
        {
            ChangeImage(ref imagePath);
        }

        // Reset Valus cho button Them
        public void Enable_Textbox()
        {
            txtTenNhanVien.Enabled = true;
            txtEmail.Enabled = true;
            txtDiaChi.Enabled = true;
            dateTimeNVL.Enabled = true;
            rdNhanVien.Enabled = true;
            rdQuanLy.Enabled = true;
            btLuu.Enabled = true;
            btXoa.Enabled = true;
            btCapNhat.Enabled = true;
            btBoQua.Enabled = true;
        }
        public void SetNull_Value()
        {
            txtTenNhanVien.Text = null;
            txtEmail.Text = null;
            txtDiaChi.Text = null;
            
        }

        private void btThem_Click(object sender, EventArgs e) //BtnThem
        {
            Enable_Textbox();
            SetNull_Value();
        }

        private void btBoQua_Click(object sender, EventArgs e)
        {
            Disable_Textbox_Button();
        }

        //Check Rule Email
        public bool Isvaild(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;

            }
            catch (FormatException)
            {

                return false;
            }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            int vaitro = 0;
            if (rdQuanLy.Checked)
            {
                vaitro = 1;
            }

            if (txtEmail.Text.Trim().Length == 0) //Check Email Null
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }
            else if (!Isvaild(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Email bạn nhập sai, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtTenNhanVien.Text) || string.IsNullOrWhiteSpace(txtTenNhanVien.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên", "Thông báo");
            }
            else if (string.IsNullOrEmpty(txtDiaChi.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Bạn chưa nhập đơn giá", "Thông báo");
            }
            
            else
            {
                //if (pbHinh.Image is null)
                //{
                //    Image setLogo = Image.FromFile(startupPath + @"\image\logo.jpg");
                //    byte[] arr1;
                //    ImageConverter converter1 = new ImageConverter();
                //    arr1 = (byte[])converter1.ConvertTo(setLogo, typeof(byte[]));
                //    DTO_NhanVien curNV1 = new DTO_NhanVien(txtTenNhanVien.Text, txtEmail.Text, txtDiaChi.Text, (dateTimeNVL.Value).Date, vaitro, arr1);

                //    if (busnhanvien.inserNhanVien(curNV1))
                //    {
                //        MessageBox.Show("Thêm nhân viên thành công");
                //        dgvNhanVien.DataSource = busnhanvien.getDanhSachNV();
                //        dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //    }
                //    else
                //    {
                //        MessageBox.Show("Thêm nhân viên thất bại");
                //    }
                //}
                //else
                //{
                //    Image img = pbHinh.BackgroundImage;
                //    byte[] arr;
                //    ImageConverter converter = new ImageConverter();
                //    arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
                //    DTO_NhanVien curNV = new DTO_NhanVien(txtTenNhanVien.Text, txtEmail.Text, txtDiaChi.Text, (dateTimeNVL.Value).Date, vaitro, arr);

                //    if (busnhanvien.inserNhanVien(curNV))
                //    {
                //        MessageBox.Show("Thêm món vào thực đơn thành công");
                //        dgvNhanVien.DataSource = busnhanvien.getDanhSachNV();
                //        dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //        //pbHinh.BackgroundImage = Image.FromFile(startupPath + @"\image\logo.jpg");
                //        //pbHinh.BackgroundImageLayout = ImageLayout.Stretch;


                //    }
                //    else
                //    {
                //        MessageBox.Show("Thêm món vào thực đơn thất bại");

                //    }
                //}


                Image img = pbHinh.BackgroundImage;
                byte[] arr;
                ImageConverter converter = new ImageConverter();
                arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
                DTO_NhanVien curNV = new DTO_NhanVien(txtTenNhanVien.Text, txtEmail.Text, txtDiaChi.Text, (dateTimeNVL.Value).Date, vaitro, arr);

                if (busnhanvien.inserNhanVien(curNV))
                {
                    MessageBox.Show("Thêm món vào thực đơn thành công");
                    dgvNhanVien.DataSource = busnhanvien.getDanhSachNV();
                    dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //pbHinh.BackgroundImage = Image.FromFile(startupPath + @"\image\logo.jpg");
                    //pbHinh.BackgroundImageLayout = ImageLayout.Stretch;


                }
                else
                {
                    MessageBox.Show("Thêm món vào thực đơn thất bại");

                }

            }
        }

        private void FormNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNhanVien.Rows.Count > 1)
            {
                if (dgvNhanVien.CurrentRow.Index < dgvNhanVien.Rows.Count - 1)
                {
                    pbHinh.Enabled = true;
                    btLuu.Enabled = true;
                    btXoa.Enabled = true;
                    btCapNhat.Enabled = true;
                    btBoQua.Enabled = true;
                    txtTenNhanVien.Enabled = true;
                    txtEmail.Enabled = true;
                    txtDiaChi.Enabled = true;
                    dateTimeNVL.Enabled = true;
                    rdNhanVien.Enabled = true;
                    rdQuanLy.Enabled = true;

                    DTO_NhanVien td = busnhanvien.curNV(dgvNhanVien.CurrentRow.Cells["Email_NV"].Value.ToString());
                    txtEmail.Text = td.Email;
                    txtTenNhanVien.Text = td.TenNV;
                    txtDiaChi.Text = td.DiaChi;

                    if (td.Quyen == 1)
                        rdQuanLy.Checked = true;
                    else
                        rdNhanVien.Checked = true;

                    dateTimeNVL.Text = td.NgayVL.ToString();


                    MemoryStream mem = new MemoryStream(busnhanvien.getHinhNV(td.Email)); 
                    pbHinh.BackgroundImage = Image.FromStream(mem);
                    pbHinh.BackgroundImageLayout = ImageLayout.Stretch;


                }
            }
        }
    }
}
