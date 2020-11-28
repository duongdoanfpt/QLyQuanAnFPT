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
    }
}
