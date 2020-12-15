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
using System.Data.Odbc;
using Office_12 = Microsoft.Office.Core;
using Excel_12 = Microsoft.Office.Interop.Excel;
using CrystalDecisions.CrystalReports.Engine;
using System.Net.Mail;
using System.Net;

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
        BUS_Ban busBan = new BUS_Ban();
        BUS_NhanVien busNv = new BUS_NhanVien();


        public void SendMail(string email)
        {

            SmtpClient client = new SmtpClient("smtp.gmail.com", 25);

            NetworkCredential cred = new NetworkCredential("bellben7777@gmail.com", "Baoduong666@@@@");
            MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress("bellben7777@gmail.com");
            Msg.To.Add(email);
            Msg.Subject = "Chúc Mừng Sinh Nhật";
            Msg.Body = "Chào bạn xin gửi bạn chương trình khuyến mãi nhân dịp chúc mừng sinh nhật bạn";
            client.Credentials = cred;
            client.EnableSsl = true;
            client.Send(Msg);


        }
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
            DgvData.DataSource = null;
            DgvData.Refresh();
            DgvData.DataSource = dt;
            DgvData.Columns[0].HeaderText = "Tên món";
            DgvData.Columns[1].HeaderText = "Số lượng";
            
        }
        private void ThongKeSLThucDon_CheckedChanged(object sender, EventArgs e)
        {
            if(cbThucDon.Checked == true)
            {
                txtTuNgay.Visible = true;
                txtDenNgay.Visible = true;
                cbKhachHang.Checked = false;
                cbDTThang.Checked = false;
                cbDTNam.Checked = false;
                cbHoaDon.Checked = false;
                ngayBatDau.Visible = true;
                ngayKetThuc.Visible = true;
                btnThongKe.Visible = true;
                DgvData.DataSource = null;
                DgvData.Refresh();
                DgvData.DataSource = busTK.dtSLTD(null, null);
                DgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                

            }
            else
            {
                DgvData.DataSource = null;
                txtTuNgay.Visible = false;
                txtDenNgay.Visible = false;
                ngayBatDau.Visible = false;
                ngayKetThuc.Visible = false;
                btnThongKe.Visible = false;


            }
        }

        private void cbBaoCaoDT_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LoadNameThongKeTime(DataTable dt)
        {
            DgvData.DataSource = null;
            DgvData.Refresh();
            DgvData.DataSource = dt;
            DgvData.Columns[0].HeaderText = "Doanh thu";
        }
        //Xoa dong cuoi
        public static void DataGridViewCellVisibility(DataGridViewCell cell, bool visible)
        {
            cell.Style = visible ?
                  new DataGridViewCellStyle { Padding = new Padding(0, 0, 0, 0) } :
                  new DataGridViewCellStyle { Padding = new Padding(cell.OwningColumn.Width, 0, 0, 0) };

            cell.ReadOnly = !visible;
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (cbThucDon.Checked)
            {
                if (cbThucDon.Checked == true)
                {

                    cbKhachHang.Checked = false;
                    cbDTThang.Checked = false;
                    cbDTNam.Checked = false;
                    cbHoaDon.Checked = false;
                    ngayBatDau.Visible = true;
                    ngayKetThuc.Visible = true;
                    btnThongKe.Visible = true;
                    DgvData.DataSource = null;
                    DgvData.Refresh();
                    DgvData.DataSource = busTK.dtSLTD(ngayBatDau.Value, ngayKetThuc.Value);
                    DgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    LoadNameThucDon(busTK.dtSLTD(ngayBatDau.Value, ngayKetThuc.Value));

                }
                else
                {
                    DgvData.DataSource = null;

                }
            }
            
            else if(cbKhachHang.Checked == true)
            {
                DgvData.DataSource = busTK.thongKeKhachHang(ngayBatDau.Value, ngayKetThuc.Value);
                DgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DgvData.Columns[0].HeaderText = "Tên khách hàng";
                DgvData.Columns[1].HeaderText = "Số điện thoại";
                DgvData.Columns[2].HeaderText = "Email";
                DgvData.Columns[3].HeaderText = "Tổng tiền";

                DgvData.Columns[3].DefaultCellStyle.Format = "c";

            }
            else if(cbHoaDon.Checked == true)
            {
                cbThucDon.Checked = false;
                cbKhachHang.Checked = false;
                cbDTThang.Checked = false;
                cbDTNam.Checked = false;

                DgvData.DataSource = busTK.thongKeHoaDon(ngayBatDau.Value, ngayKetThuc.Value);
                DgvData.Columns["ThanhTien"].DefaultCellStyle.Format = "c";
                DgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                txtTuNgay.Visible = true;
                txtDenNgay.Visible = true;
                ngayBatDau.Visible = true;
                ngayKetThuc.Visible = true;
                btnThongKe.Visible = true;
                DataGridViewCellVisibility(DgvData.Rows[DgvData.Rows.Count - 1].Cells["Detail"], false);
                DgvData.Columns[1].HeaderText = "Mã Hoá Đơn";
                DgvData.Columns[2].HeaderText = "Mã nhân viên";
                DgvData.Columns[3].HeaderText = "Số điện thoại KH";
                DgvData.Columns[4].HeaderText = "Id Bàn";
                DgvData.Columns[5].HeaderText = "Ngày";
                DgvData.Columns[6].HeaderText = "Khuyến Mãi";
                DgvData.Columns[7].HeaderText = "Thành Tiền";
                DgvData.Columns[0].HeaderText = "Chi tiết";



                if (DgvData.Columns["Detail"] is null)
                {
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.Name = "Detail";
                    buttonColumn.Text = "Xem chi tiết";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    DgvData.Columns.Add(buttonColumn);
                    DataGridViewCellVisibility(DgvData.Rows[DgvData.Rows.Count - 1].Cells["Detail"], false);

                }

                int tien = DgvData.Rows.Count;
                float thanhtien = 0;
                for (int i = 0; i < tien - 1; i++)
                {
                    thanhtien += float.Parse(DgvData.Rows[i].Cells["ThanhTien"].Value.ToString());

                }

                tongTien.Text = string.Format("{0:n0}", thanhtien).ToString() + " VNĐ";



            }
            else
            {
                DgvData.Columns.Remove("Detail");
                DgvData.DataSource = null;
                tongTien.Text = null;
            }
        }


        


        private void LoadNameDTThang(DataTable dt) 
        {
            DgvData.DataSource = null;
            DgvData.Refresh();
            DgvData.DataSource = dt;
            DgvData.Columns[0].HeaderText = "Doanh thu tháng";
        }

        
        private void cbDTThang_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDTThang.Checked == true)
            {
                cbThucDon.Checked = false;
                cbKhachHang.Checked = false;
                cbDTNam.Checked = false;
                cbHoaDon.Checked = false;
                cbSinhNhat.Checked = false;



                DgvData.DataSource = busTK.doanhThuThang_Main();
                DgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DgvData.Columns["ThanhTien"].DefaultCellStyle.Format = "c";

                txtTuNgay.Visible = false;
                txtDenNgay.Visible = false;
                ngayBatDau.Visible = false;
                ngayKetThuc.Visible = false;
                btnThongKe.Visible = false;
               

                if (DgvData.Columns["Detail"] is null)
                {
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.Name = "Detail";
                    buttonColumn.Text = "Xem chi tiết";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    DgvData.Columns.Add(buttonColumn);
                    DataGridViewCellVisibility(DgvData.Rows[DgvData.Rows.Count - 1].Cells["Detail"], false);
                    DgvData.Columns[0].HeaderText = "Mã Hoá Đơn";
                    DgvData.Columns[1].HeaderText = "Mã nhân viên";
                    DgvData.Columns[2].HeaderText = "Số điện thoại KH";
                    DgvData.Columns[3].HeaderText = "Id Bàn";
                    DgvData.Columns[4].HeaderText = "Ngày";
                    DgvData.Columns[5].HeaderText = "Khuyến Mãi";
                    DgvData.Columns[6].HeaderText = "Thành Tiền";
                    DgvData.Columns[7].HeaderText = "Chi tiết";
                }

                int tien = DgvData.Rows.Count;
                float thanhtien = 0;
                for (int i = 0; i < tien - 1; i++)
                {
                    thanhtien += float.Parse(DgvData.Rows[i].Cells["ThanhTien"].Value.ToString());

                }

                tongTien.Text = string.Format("{0:n0}", thanhtien).ToString() + " VNĐ";

            }
            else
            {
                DgvData.Columns.Remove("Detail");
                DgvData.DataSource = null;
                tongTien.Text = null;

            }
        }

        private void cbDTNam_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDTNam.Checked == true)
            {
                cbThucDon.Checked = false;
                cbKhachHang.Checked = false;
                cbDTThang.Checked = false;
                cbHoaDon.Checked = false;
                cbSinhNhat.Checked = false;



                DgvData.DataSource = busTK.doanhThuNam_Main();
                DgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DgvData.Columns["ThanhTien"].DefaultCellStyle.Format = "c";

                txtTuNgay.Visible = false;
                txtDenNgay.Visible = false;
                ngayBatDau.Visible = false;
                ngayKetThuc.Visible = false;
               

                if (DgvData.Columns["Detail"] is null)
                {
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.Name = "Detail";
                    buttonColumn.Text = "Xem chi tiết";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    DgvData.Columns.Add(buttonColumn);
                    DataGridViewCellVisibility(DgvData.Rows[DgvData.Rows.Count - 1].Cells["Detail"], false);
                    DgvData.Columns[0].HeaderText = "Mã Hoá Đơn";
                    DgvData.Columns[1].HeaderText = "Mã nhân viên";
                    DgvData.Columns[2].HeaderText = "Số điện thoại KH";
                    DgvData.Columns[3].HeaderText = "Id Bàn";
                    DgvData.Columns[4].HeaderText = "Ngày";
                    DgvData.Columns[5].HeaderText = "Khuyến Mãi";
                    DgvData.Columns[6].HeaderText = "Thành Tiền";
                    DgvData.Columns[7].HeaderText = "Chi tiết";
                }

                int tien = DgvData.Rows.Count;
                float thanhtien = 0;
                for (int i = 0; i < tien - 1; i++)
                {
                    thanhtien += float.Parse(DgvData.Rows[i].Cells["ThanhTien"].Value.ToString());

                }

                tongTien.Text = string.Format("{0:n0}", thanhtien).ToString() + " VNĐ";



            }
            else
            {
                DgvData.Columns.Remove("Detail");
                DgvData.DataSource = null;
                tongTien.Text = null;

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

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadNameKhachHang(DataTable dt)
        {
            DgvData.DataSource = dt;
            DgvData.Columns[0].HeaderText = "Tên khách hàng";
            DgvData.Columns[1].HeaderText = "Số điện thoại";
            DgvData.Columns[2].HeaderText = "Email";
            DgvData.Columns[3].HeaderText = "Tổng tiền";

            DgvData.Columns[3].DefaultCellStyle.Format = "c";




        }
        private void cbKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            if (cbKhachHang.Checked == true)
            {
                txtTuNgay.Visible = true;
                txtDenNgay.Visible = true;
                cbThucDon.Checked = false;
                cbDTThang.Checked = false;
                cbDTNam.Checked = false;
                cbHoaDon.Checked = false;
                cbSinhNhat.Checked = false;
                ngayBatDau.Visible = true;
                ngayKetThuc.Visible = true;
                btnThongKe.Visible = true;
                DgvData.DataSource = null;
                DgvData.Refresh();
                DgvData.DataSource = busTK.thongKeKhachHang(null, null);
                DgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DgvData.Columns[0].HeaderText = "Tên khách hàng";
                DgvData.Columns[1].HeaderText = "Số điện thoại";
                DgvData.Columns[2].HeaderText = "Email";
                DgvData.Columns[3].HeaderText = "Tổng tiền";

                DgvData.Columns[3].DefaultCellStyle.Format = "c";



            }
            else
            {
                DgvData.DataSource = null;
                txtTuNgay.Visible = false;
                txtDenNgay.Visible = false;
                ngayBatDau.Visible = false;
                ngayKetThuc.Visible = false;
                btnThongKe.Visible = false;


            }
        }

        private void cbHoaDon_CheckedChanged(object sender, EventArgs e)
        {
            if(cbHoaDon.Checked == true)
            {
                cbThucDon.Checked = false;
                cbKhachHang.Checked = false;
                cbDTThang.Checked = false;
                cbDTNam.Checked = false;
                cbSinhNhat.Checked = false;
                DgvData.DataSource = busTK.thongKeHoaDon(null, null);
                DgvData.Columns["ThanhTien"].DefaultCellStyle.Format = "c";
                DgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                txtTuNgay.Visible = true;
                txtDenNgay.Visible = true;
                ngayBatDau.Visible = true;
                ngayKetThuc.Visible = true;
                btnThongKe.Visible = true;
               
               

                if (DgvData.Columns["Detail"] is null)
                {
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.Name = "Detail";
                    buttonColumn.Text = "Xem chi tiết";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    DgvData.Columns.Add(buttonColumn);
                    DataGridViewCellVisibility(DgvData.Rows[DgvData.Rows.Count - 1].Cells["Detail"], false);
                    DgvData.Columns[0].HeaderText = "Mã Hoá Đơn";
                    DgvData.Columns[1].HeaderText = "Mã nhân viên";
                    DgvData.Columns[2].HeaderText = "Số điện thoại KH";
                    DgvData.Columns[3].HeaderText = "Id Bàn";
                    DgvData.Columns[4].HeaderText = "Ngày";
                    DgvData.Columns[5].HeaderText = "Khuyến Mãi";
                    DgvData.Columns[6].HeaderText = "Thành Tiền";
                    DgvData.Columns[7].HeaderText = "Chi tiết";


                }
                
                int tien = DgvData.Rows.Count;
                float thanhtien = 0;
                for (int i = 0; i < tien - 1; i++)
                {
                    thanhtien += float.Parse(DgvData.Rows[i].Cells["ThanhTien"].Value.ToString());

                }

                tongTien.Text = string.Format("{0:n0}",thanhtien).ToString()+" VNĐ";



            }
            else
            {
                DgvData.Columns.Remove("Detail");
                DgvData.DataSource = null;
                tongTien.Text = null;
            }    
           
           
           
              
            

        }

        private void DgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cbHoaDon.Checked == true || cbDTNam.Checked == true || cbDTThang.Checked == true  )
           if (e.ColumnIndex == DgvData.Columns["Detail"].Index && e.RowIndex >= 0 && e.RowIndex<DgvData.Rows.Count-1)
            {
                
                DTO_HoaDon hd = busTK.curHD(DgvData.CurrentRow.Cells["MaHD"].FormattedValue.ToString());
                
                string TenNV = (from DataRow dr in busNv.DanhSachNhanVienAll().Rows
                                where string.Compare(dr[0].ToString(), hd.MaNV, true) == 0
                                select dr[2].ToString()).FirstOrDefault();
            

                string TenBan = (from DataRow dr in busBan.DanhSachBanALL().Rows
                                 where (int)dr[0] == hd.IdBan
                                 select dr[1].ToString()).FirstOrDefault();


                DataTable dtHDCT = busTK.ThongkeHoaDonChitiet(hd.MaHD);
                CrystalReport.Detail cb = new CrystalReport.Detail();
                TextObject txtnv = (TextObject)cb.ReportDefinition.Sections["Section1"].ReportObjects["txtTenNV"];
                txtnv.Text = TenNV;
                TextObject txtDate = (TextObject)cb.ReportDefinition.Sections["Section1"].ReportObjects["TxtNgayHD"];
                txtDate.Text = hd.NgayHD.ToString("dd/MM/yyyy");
                TextObject txthd = (TextObject)cb.ReportDefinition.Sections["Section2"].ReportObjects["txtMaHD"];
                txthd.Text = hd.MaHD;
                TextObject txtvt = (TextObject)cb.ReportDefinition.Sections["Section2"].ReportObjects["txtViTri"];
                txtvt.Text = TenBan;
                TextObject txtkh = (TextObject)cb.ReportDefinition.Sections["Section2"].ReportObjects["txtKH"];
                txtkh.Text = hd.SDT_KH;
                TextObject txtkm = (TextObject)cb.ReportDefinition.Sections["Section4"].ReportObjects["TextKM"];
                txtkm.Text = hd.KhuyenMai.ToString() + "%";
                TextObject txttongtien = (TextObject)cb.ReportDefinition.Sections["Section5"].ReportObjects["TxtTongTien"];
                txttongtien.Text = (hd.ThanhTien * 100 / (100 - hd.KhuyenMai)).ToString();
                TextObject txtThanhTien = (TextObject)cb.ReportDefinition.Sections["Section5"].ReportObjects["txtThanhtien"];
                txtThanhTien.Text = hd.ThanhTien.ToString();

                TextObject txtname = (TextObject)cb.ReportDefinition.Sections["Section1"].ReportObjects["TextName"];
                txtname.Text = "CHI TIẾT HOÁ ĐƠN";

                cb.Database.Tables["CTHD"].SetDataSource(dtHDCT);

                frmDetail frm = new frmDetail(cb);
                frm.Show();
            }
        }

        private void cbSinhNhat_CheckedChanged(object sender, EventArgs e)
        {
            if(cbSinhNhat.Checked == true)
            {
                btSendMail.Visible = true;
                cbThucDon.Checked = false;
                cbKhachHang.Checked = false;
                cbDTThang.Checked = false;
                cbDTNam.Checked = false;
                cbHoaDon.Checked = false;
                
                DgvData.DataSource = busTK.sinhNhatKhachHang();
                DgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DgvData.Columns[0].HeaderText = "Số điện thoại";
                DgvData.Columns[1].HeaderText = "Tên khách hàng";
                DgvData.Columns[2].HeaderText = "Email";
                DgvData.Columns[3].HeaderText = "Giới tính";
                

            }
            else
            {
                btSendMail.Visible = false;
                DgvData.DataSource = null;
                DgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            }
        }

        private void btSendMail_Click(object sender, EventArgs e)
        {
            List<DTO_Khach> listKH = (from DataRow dr in busTK.sinhNhatKhachHang().Rows
                                      where !string.IsNullOrWhiteSpace(dr[2].ToString())
                                      select new DTO_Khach
                                      {
                                          TenKH = dr[1].ToString(),
                                          Email = dr[2].ToString(),
                                          GioiTinh = string.Compare(dr[3].ToString(),"Nam",true)==0?1:0

                                      }).ToList();
            FormGuiMail fmail = new FormGuiMail(listKH);
            fmail.Show();

           
        }
    }
}
