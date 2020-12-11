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
        public FormGuiMail()
        {
            InitializeComponent();
        }
        BUS_Khach busKhach = new BUS_Khach();
        private void Load_KH()
        {
            BUS_Khach busKhach = new BUS_Khach();
            dgvKHMail.DataSource = busKhach.getKhachMail();
        }
        private void btGetMail_Click(object sender, EventArgs e)
        {
            Load_KH();



        }

        private void FormGuiMail_Load(object sender, EventArgs e)
        {

        }

        private void btGuiMail_Click(object sender, EventArgs e)
        {
            MailMessage msg = new MailMessage();
            msg.Body = FormNoiDungMail.noidungMail;
            
           
            msg.Subject = "CHƯƠNG TRÌNH KHUYẾN MÃI - TRI ÂN KHÁCH HÀNG";
            if (busKhach.SendMail(dgvKHMail.CurrentRow.Cells[2].FormattedValue.ToString(), msg))
            {
                
                MessageBox.Show("Gửi thành công");
            }
            else
            {
                MessageBox.Show("Gửi thất bại");
            }
        }

        private void btTaoND_Click(object sender, EventArgs e)
        {
            FormNoiDungMail frmnoiDungMail = new FormNoiDungMail();
            frmnoiDungMail.Activate();
            frmnoiDungMail.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
