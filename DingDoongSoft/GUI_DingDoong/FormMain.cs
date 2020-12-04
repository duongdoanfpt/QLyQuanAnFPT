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

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = (DateTime.Now.Hour < 10 ? "0" + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString()) + ":" + (DateTime.Now.Minute < 10 ? "0" + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString()) + ":" + (DateTime.Now.Second < 10 ? "0" + DateTime.Now.Second.ToString() : DateTime.Now.Second.ToString());
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lbTime.Text = (DateTime.Now.Hour < 10 ? "0" + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString()) + ":" + (DateTime.Now.Minute < 10 ? "0" + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString()) + ":" + (DateTime.Now.Second < 10 ? "0" + DateTime.Now.Second.ToString() : DateTime.Now.Second.ToString());
            lbDate.Text = DateTime.Now.Day<10?"0"+DateTime.Now.Day.ToString():DateTime.Now.Day.ToString();
            lbMonth.Text = DateTime.Now.ToString("MMM");
            LbYear.Text = DateTime.Now.ToString("yyyy");
            lbDayofweek.Text = DateTime.Now.ToString("ddd");
            
        }
    }
}
