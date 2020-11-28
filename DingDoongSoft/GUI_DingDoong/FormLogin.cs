using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_DingDoong;
using BUS_DingDoong;

namespace GUI_DingDoong
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        BUS_NhanVien busnhanvien = new BUS_NhanVien();
        private void btLogin_Click(object sender, EventArgs e)
        {
            DTO_NhanVien nv = new DTO_NhanVien();
            nv.Email = txtEmail.Text;
            nv.MatKhau = busnhanvien.Encryption(txtPassword.Text);

            if (busnhanvien.NhanVienDangNhap(nv))
            {
                
                MessageBox.Show("Đăng nhập thành công");
                
                //this.Close();
                //CheckDangNhap = 1;
                //Visible = false;
                //ShowInTaskbar = false;
                //FormMain frmMainN = new FormMain(CheckDangNhap);
                //frmMainN.Activate();
                //frmMainN.Show();

            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu sai");
                txtEmail.Text = null;
                txtPassword.Text = null;
                txtEmail.Focus();
            }
        }
    }
}

