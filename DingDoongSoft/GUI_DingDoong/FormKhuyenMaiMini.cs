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
    public partial class FormKhuyenMaiMini : Form
    {
        BUS_KhuyenMai busKM = new BUS_KhuyenMai();
        BUS_Ban busBan = new BUS_Ban();
        DTO_KhuyenMai km;
        string MaHD;
        public FormKhuyenMaiMini(string MHD)
        {
            InitializeComponent();
            MaHD = MHD;
            foreach (DataRow dr in busKM.GetDanhSachKMinTime(DateTime.Now).Rows)
            {
                cbTenKM.Items.Add(dr[1].ToString());
                cbTenKM.SelectedIndex = 0;
            }
        }

        private void FormKhuyenMaiMini_Load(object sender, EventArgs e)
        {

        }

        private void cbKhuyenMai_SelectedIndexChanged(object sender, EventArgs e)
        {
            km = busKM.curKM(cbTenKM.SelectedItem.ToString());

            lbChietKhau.Text = km.ChietKhau.ToString() + "%";
        }

        
        private void btOK_Click(object sender, EventArgs e)
        {
            if (busBan.ThemKMToHd(MaHD, km.ChietKhau))
            {

                this.Close();

            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra vui lòng kiểm tra lại");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
