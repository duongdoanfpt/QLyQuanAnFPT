﻿using System;
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
using System.Data.Odbc;
using Office_12 = Microsoft.Office.Core;
using Excel_12 = Microsoft.Office.Interop.Excel;


namespace GUI_DingDoong
{
    public partial class FormThongKe : Form
    {
        public FormThongKe()
        {
            InitializeComponent();
        }
        BUS_ThucDon busThucDon = new BUS_ThucDon();
        BUS_Khach busKhach = new BUS_Khach();
        BUS_ThongKe busTK = new BUS_ThongKe();

       

        private void Home_MouseEnter(object sender, EventArgs e)
        {
            Home.SizeMode = PictureBoxSizeMode.CenterImage;
            Home.Cursor = Cursors.Hand;
        }

        private void Home_MouseLeave(object sender, EventArgs e)
        {
            Home.SizeMode = PictureBoxSizeMode.Zoom;
            Home.Cursor = Cursors.Default;
        }

        private void NhanVien_MouseEnter(object sender, EventArgs e)
        {
            NhanVien.SizeMode = PictureBoxSizeMode.CenterImage;
            NhanVien.Cursor = Cursors.Hand;
        }

        private void NhanVien_MouseLeave(object sender, EventArgs e)
        {
            NhanVien.SizeMode = PictureBoxSizeMode.Zoom;
            NhanVien.Cursor = Cursors.Default;
        }

        private void KhachHang_MouseEnter(object sender, EventArgs e)
        {
            KhachHang.SizeMode = PictureBoxSizeMode.CenterImage;
            KhachHang.Cursor = Cursors.Hand;
        }

        private void KhachHang_MouseLeave(object sender, EventArgs e)
        {
            KhachHang.SizeMode = PictureBoxSizeMode.Zoom;
            KhachHang.Cursor = Cursors.Default;
        }

        private void Ban_MouseEnter(object sender, EventArgs e)
        {
            Ban.SizeMode = PictureBoxSizeMode.CenterImage;
            Ban.Cursor = Cursors.Hand;
        }

        private void Ban_MouseLeave(object sender, EventArgs e)
        {
            Ban.SizeMode = PictureBoxSizeMode.Zoom;
            Ban.Cursor = Cursors.Default;
        }

        private void ThongKe_MouseEnter(object sender, EventArgs e)
        {
            ThongKe.SizeMode = PictureBoxSizeMode.CenterImage;
            ThongKe.Cursor = Cursors.Hand;
        }

        private void ThongKe_MouseLeave(object sender, EventArgs e)
        {
            ThongKe.SizeMode = PictureBoxSizeMode.Zoom;
            ThongKe.Cursor = Cursors.Default;
        }

        private void ptbMenuThucDon_MouseEnter(object sender, EventArgs e)
        {
            ptbMenuThucDon.SizeMode = PictureBoxSizeMode.CenterImage;
            ptbMenuThucDon.Cursor = Cursors.Hand;
        }

        private void ptbMenuThucDon_MouseLeave(object sender, EventArgs e)
        {
            ptbMenuThucDon.SizeMode = PictureBoxSizeMode.Zoom;
            ptbMenuThucDon.Cursor = Cursors.Default;
        }

        private void Home_Click(object sender, EventArgs e)
        {
            FormMain main = new FormMain();
            this.Hide();

            main.Closed += (s, args) => this.Close();
            main.Show();
        }

        private void NhanVien_Click(object sender, EventArgs e)
        {
            FormNhanVien nv = new FormNhanVien();
            this.Hide();

            nv.Closed += (s, args) => this.Close();
            nv.Show();
        }

        private void KhachHang_Click(object sender, EventArgs e)
        {
            FormKhachHang kh = new FormKhachHang();
            this.Hide();

            kh.Closed += (s, args) => this.Close();
            kh.Show();
        }

        private void Ban_Click(object sender, EventArgs e)
        {
            FormKhuVucBan kv = new FormKhuVucBan(-1);
            this.Hide();

            kv.Closed += (s, args) => this.Close();
            kv.Show();
        }

        private void ThongKe_Click(object sender, EventArgs e)
        {
            FormThongKe thongKe = new FormThongKe();
            this.Hide();

            thongKe.Closed += (s, args) => this.Close();
            thongKe.Show();
        }

        private void ptbMenuThucDon_Click(object sender, EventArgs e)
        {
            FormThucDon thucdon = new FormThucDon();
            this.Hide();

            thucdon.Closed += (s, args) => this.Close();
            thucdon.Show();
        }

        

        

      

        private void FormThongKe_Load(object sender, EventArgs e)
        {
            ThongKe.Enabled = false;
            ThongKe.BorderStyle = BorderStyle.Fixed3D;
            txtTuNgay.Visible = false;
            txtDenNgay.Visible = false;
            ptbNext.Visible = false;
            ngayBatDau.Visible = false;
            ngayKetThuc.Visible = false;
            btnThongKe.Visible = false;
            lblUsers.Text = FormLogin.NvMain.Email;


        }
        private void LoadNameThucDon(DataTable dt)
        {
            DgvData.DataSource = dt;
            DgvData.Columns[0].HeaderText = "Tên món";
            DgvData.Columns[1].HeaderText = "Số lượng";
            
        }
        private void ThongKeSLThucDon_CheckedChanged(object sender, EventArgs e)
        {
            if(cbThucDon.Checked == true)
            {
                
                cbKhachHang.Checked = false;
                cbDoanhThu.Checked = false;
                cbDTThang.Checked = false;
                cbDTNam.Checked = false;
                DgvData.DataSource = busTK.dtSLTD(ngayBatDau.Value, ngayKetThuc.Value);
                DgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                LoadNameThucDon(busTK.dtSLTD(ngayBatDau.Value,ngayKetThuc.Value));

            }
            else
            {
                DgvData.DataSource = null;

            }
        }

        private void cbBaoCaoDT_CheckedChanged(object sender, EventArgs e)
        {
            if(cbDoanhThu.Checked == true)
            {
                txtTuNgay.Visible = true;
                txtDenNgay.Visible = true;
                ptbNext.Visible = true;
                ngayBatDau.Visible = true;
                ngayKetThuc.Visible = true;
                btnThongKe.Visible = true;
                cbThucDon.Checked = false;
                cbKhachHang.Checked = false;
                cbDTThang.Checked = false;
                cbDTNam.Checked = false;
                
                
            }
            else
            {
                DgvData.DataSource = null;
                txtTuNgay.Visible = false;
                txtDenNgay.Visible = false;
                ptbNext.Visible = false;
                ngayBatDau.Visible = false;
                ngayKetThuc.Visible = false;
                btnThongKe.Visible = false;
            }
        }
        
        private void LoadNameThongKeTime(DataTable dt)
        {
            DgvData.DataSource = dt;
            DgvData.Columns[0].HeaderText = "Doanh thu";
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DgvData.DataSource = busTK.doanhThuTheoTime(ngayBatDau.Value, ngayKetThuc.Value);
            DgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadNameThongKeTime(busTK.doanhThuTheoTime(ngayBatDau.Value, ngayKetThuc.Value));
        }


        private void LoadNameDTThang(DataTable dt) 
        {
            DgvData.DataSource = dt;
            DgvData.Columns[0].HeaderText = "Doanh thu tháng";
        }
        private void cbDTThang_CheckedChanged(object sender, EventArgs e)
        {
            if(cbDTThang.Checked == true)
            {
                cbThucDon.Checked = false;
                cbKhachHang.Checked = false;
                cbDoanhThu.Checked = false;
                cbDTNam.Checked = false;
                DgvData.DataSource = busTK.doanhThuTrongThang();
                DgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                LoadNameDTThang(busTK.doanhThuTrongThang());
            }
            else
            {
                DgvData.DataSource = null;
            }
        }

        private void cbDTNam_CheckedChanged(object sender, EventArgs e)
        {
            if(cbDTNam.Checked == true)
            {
                cbThucDon.Checked = false;
                cbKhachHang.Checked = false;
                cbDoanhThu.Checked = false;
                cbDTThang.Checked = false;
                DgvData.DataSource = busTK.doanhThuTheoNam();
                DgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                DgvData.DataSource = null;
            }
        }

        //Xuat File Excel
        public static void ExportDataGridView_Excel(DataGridView myData)
        {
            Excel_12.Application oExcel_12 = null; 
            Excel_12.Workbook oBook = null; 
            Excel_12.Sheets oSheetsColl = null; 
            Excel_12.Worksheet oSheet = null; 
            Excel_12.Range oRange = null; 

            Object oMissing = System.Reflection.Missing.Value;


            oExcel_12 = new Excel_12.Application();

            oExcel_12.Visible = true;

            oExcel_12.UserControl = true;

            oBook = oExcel_12.Workbooks.Add(oMissing);
            
            oSheetsColl = oExcel_12.Worksheets;

            oSheet = (Excel_12.Worksheet)oSheetsColl.get_Item("Sheet1");
            oSheet.Name = "ThongKe";

            for (int j = 0; j < myData.Columns.Count; j++)
            {

                oRange = (Excel_12.Range)oSheet.Cells[1, j + 1];

                oRange.Value2 = myData.Columns[j].HeaderText;

            }

            for (int i = 0; i < myData.Rows.Count; i++)
            {

                for (int j = 0; j < myData.Columns.Count; j++)
                {
                    oRange = (Excel_12.Range)oSheet.Cells[i + 2, j + 1];

                    oRange.Value2 = myData[j, i].Value;

                }

            }
            oBook = null;
            oExcel_12.Quit();
            oExcel_12 = null;
            GC.Collect();

        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ExportDataGridView_Excel(DgvData);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
