using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_DingDoong;
using BUS_DingDoong;

namespace GUI_DingDoong
{
    public partial class FormGuiMail : Form
    {
        List<DTO_Khach> LisMail;

        public void SendMail(string email)
        {

            SmtpClient client = new SmtpClient("smtp.gmail.com", 25);

            NetworkCredential cred = new NetworkCredential("bellben7777@gmail.com", "Baoduong666@@@@");
            MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress("bellben7777@gmail.com");
            Msg.To.Add(email);
            Msg.Subject = txtChuDe.Text;
            Msg.Body =txtNoiDung.Text;
            client.Credentials = cred;
            client.EnableSsl = true;
            client.Send(Msg);


        }
        public FormGuiMail(List<DTO_Khach> listKH)
        {
            InitializeComponent();
            LisMail = listKH;
            foreach (DTO_Khach kh in listKH)
            {
                SendMail(kh.Email);
            }
        }
        BUS_Khach busKhach = new BUS_Khach();
        private void Load_KH()
        {
            BUS_Khach busKhach = new BUS_Khach();
            dgvKHMail.DataSource = busKhach.getKhachMail();
        }
        private void btGetMail_Click(object sender, EventArgs e)
        {


        }

        private void FormGuiMail_Load(object sender, EventArgs e)
        {

        }

        private void btGuiMail_Click(object sender, EventArgs e)
        {
            foreach (DTO_Khach kh in LisMail)
            {
                SendMail(kh.Email);
            }
        }

        private void btTaoND_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
