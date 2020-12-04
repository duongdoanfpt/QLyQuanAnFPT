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
        public static int quyen;

        public FormMain()
        {
            InitializeComponent();
            this.CenterToScreen();
            lblEmailMain.Text = FormLogin.NvMain.Email;
            quyen = FormLogin.NvMain.Quyen;

        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void phanquyen()
        {
            pbNhanVien.Enabled = false;
            pnlNhanVien.BackColor = Color.Gray;
            pnlNhanVien.Enabled = false;

            pbMenu.Enabled = false;
            pnlMenu.Enabled = false;
            pnlMenu.BackColor = Color.Gray;

            pbThongKe.Enabled = false;
            pnlThongKe.Enabled = false;
            pnlThongKe.BackColor = Color.Gray;

            pbKhuyenMai.Enabled = false;
            pnlKhuyenMai.BackColor = Color.Gray;
            pnlKhuyenMai.Enabled = false;


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
            FormKhuVucBan kv = new FormKhuVucBan(-1);
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

        private void lblLogo_Click(object sender, EventArgs e)
        {
                    }

        private void timer1_Tick(object sender, EventArgs e)
        {

            lbTime.Text = (DateTime.Now.Hour < 10 ? "0" + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString()) + ":" + (DateTime.Now.Minute < 10 ? "0" + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString()) + ":" + (DateTime.Now.Second < 10 ? "0" + DateTime.Now.Second.ToString() : DateTime.Now.Second.ToString());
            lbDate.Text = DateTime.Now.Day < 10 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString();
            lbMonth.Text = DateTime.Now.ToString("MMM");
            LbYear.Text = DateTime.Now.ToString("yyyy");
            lbDayofweek.Text = DateTime.Now.ToString("ddd");
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lbTime.Text = (DateTime.Now.Hour < 10 ? "0" + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString()) + ":" + (DateTime.Now.Minute < 10 ? "0" + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString()) + ":" + (DateTime.Now.Second < 10 ? "0" + DateTime.Now.Second.ToString() : DateTime.Now.Second.ToString());
            lbDate.Text = DateTime.Now.Day < 10 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString();
            lbMonth.Text = DateTime.Now.ToString("MMM");
            LbYear.Text = DateTime.Now.ToString("yyyy");
            lbDayofweek.Text = DateTime.Now.ToString("ddd");
            if(quyen == 0)
            {
                
                phanquyen();
            }    
        }

        private void pnlThongKe_Click(object sender, EventArgs e)
        {
            FormThongKe thongKe = new FormThongKe();
            this.Hide();

            thongKe.Closed += (s, args) => this.Close();
            thongKe.Show();
        }

        private void pnlQuanLyBan_Click(object sender, EventArgs e)
        {
            FormKhuVucBan kv = new FormKhuVucBan(-1);
            this.Hide();

            kv.Closed += (s, args) => this.Close();
            kv.Show();
        }

        private void pnlQuanLyBan_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
