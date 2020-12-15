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
using System.IO;
using System.Data.SqlClient;

namespace GUI_DingDoong
{
    public partial class FormLogin : Form
    {
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        public FormLogin()
        {
            InitializeComponent();
            this.CenterToScreen();

        }

        public static DTO_NhanVien NvMain;

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
        private void bt3d()
        {
            foreach (var bt in GetAll(this, typeof(Button)))
            {
                (bt as Button).Paint += Bt_Paint;

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



        private void writeUserInfor(DTO_NhanVien nv)
        {

            try
            {
                string startupPath = Environment.CurrentDirectory;

                string file = startupPath + @"\UserInfor.txt";

                if (!File.Exists(file))
                {
                    using (var stream = File.Create(file))
                    {

                    }

                }
                FileInfo fileinfor = new FileInfo(file);
                fileinfor.Attributes = FileAttributes.Normal;
                using (StreamWriter sw = new StreamWriter(file, false))
                {



                    sw.Write(nv.Email);
                }

                fileinfor.Attributes = FileAttributes.Hidden;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        BUS_NhanVien busnhanvien = new BUS_NhanVien();
        private void btLogin_Click(object sender, EventArgs e)
        {
            DTO_NhanVien nv = new DTO_NhanVien();
            nv.Email = txtEmail.Text;
            nv.MatKhau = busnhanvien.Encryption(txtPassword.Text);

            if (busnhanvien.NhanVienDangNhap(nv))
            {
                NvMain = busNhanVien.curNV(nv.Email);
                if (NvMain.TrangThai == 1)
                {
                    MessageBox.Show("Đăng nhập thành công");

                    if (chkbSave.Checked == true) writeUserInfor(nv);
                    if (NvMain.ChangePass == 1)
                    {
                        FormMain frmMain = new FormMain();
                        this.Hide();

                        frmMain.Closed += (s, args) => this.Close();
                        frmMain.Show();
                    }
                    else
                    {
                        MessageBox.Show("Bạn là nhân viên mới vui lòng đổi mật khẩu ở lần đầu đăng nhập");
                        FormChangePass fdmk = new FormChangePass(nv.Email);

                        fdmk.Closed += (s, args) => this.Close();
                        fdmk.Show();


                    }

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
                    MessageBox.Show("Tài khoản này đã ngưng hoạt động vui lòng liên hệ quản lý");
                }
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
            //if (txtEmail.Text != "")
            //{
            //    if (busNhanVien.NhanVienQuenMatKhau(txtEmail.Text))
            //    {
            //        StringBuilder builder = new StringBuilder();
            //        builder.Append(busNhanVien.RandomString(4, true));
            //        builder.Append(busNhanVien.RandomNumber(1000, 9999));
            //        builder.Append(busNhanVien.RandomString(2, false));


            //        DTO_NhanVien nv = new DTO_NhanVien();
            //        nv.Email = txtEmail.Text;
            //        nv.MatKhau = busNhanVien.Encryption(builder.ToString());

            //        if (busNhanVien.updateMK(nv))
            //        {
            //            MessageBox.Show("Thành công");
            //        }
            //        else
            //        {
            //            MessageBox.Show("Không thành công");
            //        }
            //        busNhanVien.SendMail(txtEmail.Text, builder.ToString());
            //        MessageBox.Show("Gửi thành công");
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("Email Không tồn tại");
            //}
            
            FormForgot frmForgot = new FormForgot();
            this.Hide();

            frmForgot.Closed += (s, args) => this.Close();
            frmForgot.Show();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DTO_NhanVien nv = new DTO_NhanVien();
                nv.Email = txtEmail.Text;
                nv.MatKhau = busnhanvien.Encryption(txtPassword.Text);

                if (busnhanvien.NhanVienDangNhap(nv))
                {

                    MessageBox.Show("Đăng nhập thành công");
                    NvMain = busNhanVien.curNV(nv.Email);
                    if (chkbSave.Checked == true) writeUserInfor(nv);
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
       

        private void FormLogin_Load(object sender, EventArgs e)
        {
            bt3d();
            try
            {
                string startupPath = Environment.CurrentDirectory;

                string file = startupPath + @"\UserInfor.txt";

                using (FileStream fsr = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fsr))
                    {
                        txtEmail.Text = sr.ReadToEnd();

                    }
                }




            }
            catch
            {

            }
        }
 
            

          
        

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblForgotPass_MouseEnter(object sender, EventArgs e)
        {
            lblForgotPass.Font = new Font(lblForgotPass.Font.Name, lblForgotPass.Font.SizeInPoints, FontStyle.Underline | FontStyle.Bold);

        }

        private void lblForgotPass_MouseLeave(object sender, EventArgs e)
        {
            lblForgotPass.Font = new Font(lblForgotPass.Font.Name, lblForgotPass.Font.SizeInPoints, FontStyle.Bold);

        }

       
    }
}

