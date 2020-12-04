﻿using System;
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
namespace GUI_DingDoong
{
    public partial class FormGopBan : Form
    {
        BUS_Ban busBan = new BUS_Ban();
        DTO_Ban OldBan;
       
        public FormGopBan(DTO_Ban Ban)
        {
            InitializeComponent();
            OldBan = Ban;
        }
        private void LoadBanMo()
        {
            foreach (DataRow dr in busBan.dtBan().Rows)
            {
                if ((int)dr[2] == 1)
                {
                    cbBan.Items.Add(dr[1].ToString());
                }

            }
            cbBan.SelectedIndex = 0;
        }
        private void FormGopBan_Load(object sender, EventArgs e)
        {

            LoadBanMo();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            DTO_HoaDon oldHD = busBan.curhd(OldBan);
            DTO_Ban NewBan = busBan.curBan(cbBan.Text);
            DTO_HoaDon newHD = busBan.curhd(NewBan);

            DataTable dtCTHDOld = busBan.CTHDtheoMaHD(oldHD.MaHD);
            foreach (DataRow dr in dtCTHDOld.Rows)
            {

                DTO_CTHD cthd = new DTO_CTHD(newHD.MaHD, dr[1].ToString(), (int)dr[2],dr[3].ToString());
               
                busBan.ThemCTHDTam(cthd).ToString();
                busBan.DeleteCTHDSoluong(dr[0].ToString(), dr[1].ToString(), (int)dr[2]);

            }
            busBan.UpdateTrangThaiBan(OldBan, 0);
            busBan.ClearTemp(oldHD.MaHD);

            this.Close();
            
        }
    }
}
