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
using System.Net.Mail;

namespace GUI_DingDoong
{
    public partial class FormKhachHangMini : Form
    {
       
        int isOld = 0;
        BUS_Khach busKH = new BUS_Khach();
        BUS_Ban busBan = new BUS_Ban();
        
        public FormKhachHangMini(DTO_Khach KH,string SDT)
        {
            InitializeComponent();
            
            if(KH is null)
            {
                groupBox1.Enabled = true;
                txtSDT.Text = SDT;
                isOld = 0;
            }
            else
            {
                isOld = 1;
                groupBox1.Enabled = false;
                txtSDT.Text = KH.SDT;
                txtEmail.Text = KH.Email;
                txtTenKH.Text = KH.TenKH;
                if (KH.GioiTinh == 1)
                    rdbNam.Checked = true;
                else
                    rdbNu.Checked = true;

                dtpNgS.Text = KH.NgaySinh.ToString();

            }    
        }
        public bool Isvaild(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;

            }
            catch (FormatException)
            {

                return false;
            }
        }
        private void FormKhachHangMini_Load(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(isOld == 1)
            {
             
                FormKhuVucBan.hd.SDT_KH = txtSDT.Text;
                busBan.UpdateKHvaoHDTam(FormKhuVucBan.hd.MaHD, txtSDT.Text);
                this.Close();
            }
            else
            {
                int gioitinh = 1;
                if (rdbNu.Checked == true)
                    gioitinh = 0;
                DTO_Khach KhachHang = new DTO_Khach(txtTenKH.Text, txtSDT.Text, dtpNgS.Value.Date, txtEmail.Text, gioitinh);
                if (!Isvaild(txtEmail.Text))
                {
                    MessageBox.Show("Email không hợp lệ");
                }
                else if(busKH.insertKhach(KhachHang))
                {
                    MessageBox.Show(txtSDT.Text);
                    FormKhuVucBan.hd.SDT_KH = txtSDT.Text;
                    busBan.UpdateKHvaoHDTam(FormKhuVucBan.hd.MaHD,txtSDT.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi vui lòng kiểm tra lại");
                }    
                

            }    
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
