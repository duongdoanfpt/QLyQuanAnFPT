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

namespace GUI_DingDoong
{
    public partial class FormChangePass : Form
    {
        public FormChangePass(string email)
        {
            InitializeComponent();
            txtEmail.Text = email;
        }

        private void FormChangePass_Load(object sender, EventArgs e)
        {

        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            if (txtOldPass.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOldPass.Focus();
                return;
            }
            BUS_NhanVien busNhanVien = new BUS_NhanVien();
            string matkhaumoi = busNhanVien.Encryption(txtNewPass.Text);
            string matkhaucu = busNhanVien.Encryption(txtOldPass.Text);
            if (busNhanVien.doiMatKhau(txtEmail.Text, matkhaucu, matkhaumoi))
            {
                FormMain.profile = 1; //Cập nhật pass thành công
                FormMain.session = 0; //Đưa về tình trạng chưa đăng nhập
                MessageBox.Show("Cập nhật mật khẩu thành công, bạn cần phải đăng nhập lại");
                this.Close();
            }
        }
    }
}
