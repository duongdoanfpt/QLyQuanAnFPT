using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_DingDoong;

namespace GUI_DingDoong
{
    public partial class FormChangePass : Form
    {
        Thread th;
        public FormChangePass(string email)
        {
            InitializeComponent();
            this.CenterToScreen();
            txtEmail.Text = email;
        }
       
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
        public void opennewapp()
        {
            FormLogin login = new FormLogin();


            Application.Run(login);
        }
        private void FrmLoad()
        {
            foreach (var bt in GetAll(this, typeof(Button)))
            {


                (bt as Button).Paint += Bt_Paint;

                (bt as Button).FlatStyle = FlatStyle.Flat;

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

        private void FormChangePass_Load(object sender, EventArgs e)
        {
            FrmLoad();

        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text ) || string.IsNullOrWhiteSpace(txtOldPass.Text) || string.IsNullOrWhiteSpace(txtNewPass.Text))
            {
                MessageBox.Show("Bạn phải nhập đầy đủ dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOldPass.Focus();
                return;
            }
            BUS_NhanVien busNhanVien = new BUS_NhanVien();
            string matkhaumoi = busNhanVien.Encryption(txtNewPass.Text);
            string matkhaucu = busNhanVien.Encryption(txtOldPass.Text);

            if (string.Compare(txtNewPass.Text,txtNewPassAgain.Text,false) ==0)
            {
                if (busNhanVien.doiMatKhau(txtEmail.Text, matkhaucu, matkhaumoi))
                {
                    //FormMain.profile = 1; //Cập nhật pass thành công
                    //FormMain.session = 0; //Đưa về tình trạng chưa đăng nhập

                    MessageBox.Show("Cập nhật mật khẩu thành công, bạn cần phải đăng nhập lại");
                    //FormLogin frmlogin = new FormLogin();
                    //this.Hide();

                    //frmlogin.Closed += (s, args) => this.Close();
                    //frmlogin.Show();


                    this.Close();
                    th = new Thread(opennewapp);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();

                }
                else
                {
                    MessageBox.Show("Cập nhật mật khẩu thất bại");
                }
            }
            else
            {
                MessageBox.Show("Xác nhận mật khẩu không đúng");
            }
            
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
