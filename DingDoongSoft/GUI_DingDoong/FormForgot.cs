using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_DingDoong;
using DTO_DingDoong;

namespace GUI_DingDoong
{
    public partial class FormForgot : Form
    {
        public FormForgot()
        {
            InitializeComponent();
        }

        BUS_NhanVien busNhanVien = new BUS_NhanVien();

        private void btSendMail_Click(object sender, EventArgs e)
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

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormForgot_Load(object sender, EventArgs e)
        {

        }
    }
}
