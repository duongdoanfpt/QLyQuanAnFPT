using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_DingDoong
{
    public partial class FormMain : Form
    {
        public static int session = 0;
        public static int profile = 0;
        public FormMain()
        {
            InitializeComponent();
            this.CenterToScreen();
            lblEmailMain.Text = FormLogin.emailGET;
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbAccounts_Click(object sender, EventArgs e)
        {
            FormChangePass formChangePass = new FormChangePass(lblEmailMain.Text);
            this.Hide();

            formChangePass.Closed += (s, args) => this.Close();
            formChangePass.Show();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pbNhanVien_Click(object sender, EventArgs e)
        {
            FormNhanVien nv = new FormNhanVien();
            this.Hide();

            nv.Closed += (s, args) => this.Close();
            nv.Show();
        }

        private void pbKhachHang_Click(object sender, EventArgs e)
        {
            FormKhachHang kh = new FormKhachHang();
            this.Hide();

            kh.Closed += (s, args) => this.Close();
            kh.Show();
        }

        private void pbQuanLyBan_Click(object sender, EventArgs e)
        {
            FormKhuVucBan kv = new FormKhuVucBan();
            this.Hide();

            kv.Closed += (s, args) => this.Close();
            kv.Show();
        }

        private void pbMenu_Click(object sender, EventArgs e)
        {
            FormThucDon thucdon = new FormThucDon();
            this.Hide();

            thucdon.Closed += (s, args) => this.Close();
            thucdon.Show();
        }

        private void pbKhuyenMai_Click(object sender, EventArgs e)
        {
            FormKhuyenMai khuyenmai = new FormKhuyenMai();
            this.Hide();

            khuyenmai.Closed += (s, args) => this.Close();
            khuyenmai.Show();
        }

        private void pbThongKe_Click(object sender, EventArgs e)
        {
            FormThongKe thongKe = new FormThongKe();
            this.Hide();

            thongKe.Closed += (s, args) => this.Close();
            thongKe.Show();
        }
    }
}
