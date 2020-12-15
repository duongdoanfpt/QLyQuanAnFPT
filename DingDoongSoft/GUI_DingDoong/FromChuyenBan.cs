using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_DingDoong;
using BUS_DingDoong;

namespace GUI_DingDoong
{
    
    public partial class FormChuyenBan : Form
    {
        BUS_Ban busBan = new BUS_Ban();
        DTO_Ban BanOld;
        DTO_Ban BanNew;
        string MaHoaDon;
        public FormChuyenBan(DTO_Ban Ban,string MaHD)
        {
            InitializeComponent();
            lbOld.Text = Ban.TenBan;
            BanOld = Ban;
            MaHoaDon = MaHD;



        }

        private void LoadBanDong()
        {
            foreach(DataRow dr in busBan.dtBan().Rows)
            {
                if((int)dr[2] == 0)
                {
                    cbBan.Items.Add(dr[1].ToString());
                }    

            }
            cbBan.SelectedIndex = 0;
        }

        private void FromChuyenBan_Load(object sender, EventArgs e)
        {
            LoadBanDong();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Chuyển " + BanOld.TenBan + " sang " + cbBan.Text + "?", "Confirm",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BanNew = busBan.curBan(cbBan.Text);
                FormKhuVucBan.IndexBan = BanNew.IdBan - 1;
                busBan.ChuyenBan(BanOld.IdBan, BanNew.IdBan, MaHoaDon);
                this.Close();
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
