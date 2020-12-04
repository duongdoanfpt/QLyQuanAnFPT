﻿using System;
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
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        public FormLogin()
        {
            InitializeComponent();
            this.CenterToScreen();
            txtEmail.Text = "duydtps11681@fpt.edu.vn";
        }

        public static string emailGET;

        BUS_NhanVien busnhanvien = new BUS_NhanVien();
        private void btLogin_Click(object sender, EventArgs e)
        {
            DTO_NhanVien nv = new DTO_NhanVien();
            nv.Email = txtEmail.Text;
            nv.MatKhau = busnhanvien.Encryption(txtPassword.Text);

            if (busnhanvien.NhanVienDangNhap(nv))
            {
                
                MessageBox.Show("Đăng nhập thành công");
                emailGET = nv.Email;
                FormMain frmMain = new FormMain();
                this.Hide();

                frmMain.Closed += (s, args) => this.Close();
                frmMain.Show();
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

        private void lblForgotPass_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "")
            {
                if (busNhanVien.NhanVienQuenMatKhau(txtEmail.Text))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(busNhanVien.RandomString(4, true));
                    builder.Append(busNhanVien.RandomNumber(1000, 9999));
                    builder.Append(busNhanVien.RandomString(2, false));
                    

                    DTO_NhanVien nv = new DTO_NhanVien();
                    nv.Email = txtEmail.Text;
                    nv.MatKhau = busNhanVien.Encryption(builder.ToString());

                    if (busNhanVien.updateMK(nv))
                    {
                        MessageBox.Show("Thành công");
                    }
                    else
                    {
                        MessageBox.Show("Không thành công");
                    }
                    busNhanVien.SendMail(txtEmail.Text, builder.ToString());
                    MessageBox.Show("Gửi thành công");
                }

            }
            else
            {
                MessageBox.Show("Email Không tồn tại");
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DTO_NhanVien nv = new DTO_NhanVien();
                nv.Email = txtEmail.Text;
                nv.MatKhau = busnhanvien.Encryption(txtPassword.Text);

                if (busnhanvien.NhanVienDangNhap(nv))
                {

                    MessageBox.Show("Đăng nhập thành công");
                    emailGET = nv.Email;
                    FormMain frmMain = new FormMain();
                    this.Hide();

                    frmMain.Closed += (s, args) => this.Close();
                    frmMain.Show();
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
}

