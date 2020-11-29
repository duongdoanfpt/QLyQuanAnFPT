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
        public FormKhuyenMaiMini()
        {
            InitializeComponent();
         
                foreach (DataRow dr in busKM.GetDanhSachKMinTime(DateTime.Now).Rows)
                {
                    cbTenKM.Items.Add(dr[1].ToString());
                    cbTenKM.SelectedIndex = 0;
                }    
             
           


        }

        private void FormKhuyenMaiMini_Load(object sender, EventArgs e)
        {

        }

        private void cbTenKM_SelectedIndexChanged(object sender, EventArgs e)
        {
            DTO_KhuyenMai km = busKM.curKM(cbTenKM.SelectedItem.ToString());

            lbChietKhau.Text = km.ChietKhau.ToString() + "%";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
