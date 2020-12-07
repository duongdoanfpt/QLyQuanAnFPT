using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_DingDoong;
using BUS_DingDoong;

namespace GUI_DingDoong
{
    public partial class FormThongTin : Form
    {
        public FormThongTin()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        
        
        private void FormThongTin_Load(object sender, EventArgs e)
        {
            txtEmail1.Text = FormLogin.NvMain.Email;
            txtDiaChi1.Text = FormLogin.NvMain.DiaChi;
            txtHoten1.Text = FormLogin.NvMain.TenNV;
            //txtVaiTro1.Text = FormLogin.NvMain.Quyen.ToString();
            dateNgayVl1.Text = FormLogin.NvMain.NgayVL.ToString();

            if(FormLogin.NvMain.Quyen ==1)
            {
                txtVaiTro1.Text = "Quản Lý";
            }
            else
            {
                txtVaiTro1.Text = "Nhân Viên";
            }
            BUS_NhanVien busnhanvien = new BUS_NhanVien();
            DTO_NhanVien td = new DTO_NhanVien();
            MemoryStream mem = new MemoryStream(busnhanvien.getHinhNV(FormLogin.NvMain.MaNV));
            pbLogo.BackgroundImage = Image.FromStream(mem);
            pbLogo.BackgroundImageLayout = ImageLayout.Stretch;

            //DTO_NhanVien td = busnhanvien.curNV(); 
        }
    }
}
