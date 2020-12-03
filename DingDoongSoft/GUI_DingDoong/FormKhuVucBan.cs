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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace GUI_DingDoong
{

    public partial class FormKhuVucBan : Form
    {
        public static BindingSource bdsKhachHang = new BindingSource();
        public static BindingSource bdsKhuyenMai = new BindingSource();
        BUS_Ban busBan = new BUS_Ban();
        BUS_ThucDon busTD = new BUS_ThucDon();
        BUS_NhanVien busNV = new BUS_NhanVien();
        BUS_Khach busKH = new BUS_Khach();
        public static int IndexBan = -1;
        public static DTO_ThucDon TD;
        public static DTO_HoaDon hd;
        public static DTO_Khach KH;
        public static DTO_NhanVien NV;

        string startupPath = Environment.CurrentDirectory;
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
        private void FrmLoad()
        {
            foreach (var bt in GetAll(this, typeof(Button)))
            {

                (bt as Button).Enabled = false;
                (bt as Button).FlatStyle = FlatStyle.Standard;
                bt.Paint += Bt_Paint;


            }
            ChkBKhachHang.Enabled = false;




        }

        private void Bt_Paint(object sender, PaintEventArgs e)
        {
          Button bt = sender as Button;
          ControlPaint.DrawBorder(e.Graphics, bt.ClientRectangle,
          SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset,
          SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset,
          SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset,
          SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset);
        }

        private void SelectBan(int indexBan)
        {
            FlowLayoutPanel flp = (FlowLayoutPanel)flpkvBan.Controls[indexBan];
            PictureBox image = (PictureBox)flp.Controls[0];
            Label lbBan = (Label)flp.Controls[1];
            lbViTriBan.Text = lbBan.Text;

            DTO_Ban Ban = busBan.curBan(lbViTriBan.Text);
            hd = busBan.curhd(Ban);

            if (Ban.TrangThai == 1)
            {
                DataTable curHd = busBan.dtHoaDonTam(Ban);
                DataRow drhd = curHd.Rows[0];
                lbStartTime.Visible = true;
                lbEndTime.Visible = true;
                DateTime StartHD = (DateTime)drhd[3];
                lbMaHD.Text = drhd[0].ToString();
                
                if(string.IsNullOrWhiteSpace(hd.SDT_KH))
                {
                    ChkBKhachHang.Enabled = true;
                    btThemKhach.Enabled = false;
                    txtSDTKH.Enabled = false;
                    txtSDTKH.Text = null;
                    ChkBKhachHang.Checked = false;
                }
                else
                {
                    ChkBKhachHang.Enabled = false;
                    ChkBKhachHang.Checked = false;
                    btThemKhach.Enabled = false;
                    txtSDTKH.Enabled = false;
                    txtSDTKH.Text = hd.SDT_KH;
                }    

                lbKhuyenMai.Text = hd.KhuyenMai.ToString() + "%";
                lbTongTien.Text = busBan.TongTienHDTamKM(hd).ToString();
                btKhuyenMai.Enabled = true;
                
                lbStartTime.Text = (StartHD.Hour < 10 ? "0" + StartHD.Hour.ToString() : StartHD.Hour.ToString()) + ":" + (StartHD.Minute < 10 ? "0" + StartHD.Minute.ToString() : StartHD.Minute.ToString()) + ":" + (StartHD.Second < 10 ? "0" + StartHD.Second.ToString() : StartHD.Second.ToString());
            }
            else
            {
                lbStartTime.Visible = false;
                lbEndTime.Visible = false;
                lbMaHD.Text = "";
                lbTongTien.Text = "0";
                lbKhuyenMai.Text = "0%";
                btKhuyenMai.Enabled = false;
                ChkBKhachHang.Enabled = false;
                

            }
            LoadCTHD();




            lbBan.BackColor = Color.Transparent;

            for (int i = 0; i < flp.Parent.Controls.Count; i++)
            {

                if (flp.Parent.Controls[i] == flp.Parent.Controls[indexBan])
                {
                    flp.Parent.Controls[i].BackColor = Color.FromArgb(128, 72, 145, 220);

                }
                else
                {
                    flp.Parent.Controls[i].BackColor = Color.White;
                }
            }
            if (Ban.TrangThai == 0)
            {
                btBatDau.Enabled = true;

            }
            else
            {
                btBatDau.Enabled = false;
            }




        }
        private void LoadCTHD()
        {

            dgvHDCT.DataSource = busBan.dtHDCTTam(lbMaHD.Text);

            if (busBan.dtHDCTTam(lbMaHD.Text).Rows.Count > 0)
            {
                btBill.Enabled = true;
                btKhuyenMai.Enabled = true;
            }
            else
            {
                btBill.Enabled = false;
                btKhuyenMai.Enabled = false;





            }


        }
        private void crtBaoCao()
        {

            
            DataTable dtHDCT = busBan.dtHDCT(hd.MaHD);
            CrystalReport.crpBill cb = new CrystalReport.crpBill();
            TextObject txtnv = (TextObject)cb.ReportDefinition.Sections["Section1"].ReportObjects["txtTenNV"];
            txtnv.Text = NV.TenNV;
            TextObject txthd = (TextObject)cb.ReportDefinition.Sections["Section2"].ReportObjects["txtMaHD"];
            txthd.Text = hd.MaHD;
            TextObject txtvt = (TextObject)cb.ReportDefinition.Sections["Section2"].ReportObjects["txtViTri"];
            txtvt.Text = lbViTriBan.Text;
            TextObject txtkh = (TextObject)cb.ReportDefinition.Sections["Section2"].ReportObjects["txtKH"];
            txtkh.Text = hd.SDT_KH;
            TextObject txtkm = (TextObject)cb.ReportDefinition.Sections["Section4"].ReportObjects["TextKM"];
            txtkm.Text = hd.KhuyenMai.ToString();
            TextObject txttongtien = (TextObject)cb.ReportDefinition.Sections["Section5"].ReportObjects["TxtTongTien"];
           txttongtien.Text = busBan.TongTienHDTamKM(hd).ToString();


            cb.Database.Tables["CTHD"].SetDataSource(dtHDCT);
           
            FrmBill frm = new FrmBill(cb);
            frm.Show();
        }



        private void loadThucDonkvBan()
        {
            dgvThucDon.DataSource = busTD.DanhSachThucDonBan();

        }

        private void loadban()
        {
            string startupPath = Environment.CurrentDirectory;


            foreach (DataRow dr in busBan.dtBan().Rows)
            {

                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.Width = 70;
                flp.Height = 120;
                PictureBox ptb = new PictureBox();
                ptb.Width = 60;
                ptb.Height = 70;
                flp.Margin = new Padding(15, 15, 15, 15);
                if (int.Parse(dr[2].ToString()) == 1)
                {
                    ptb.Image = Image.FromFile(startupPath + @"\image\banMo.ico");


                }
                else if (int.Parse(dr[2].ToString()) == 0)
                {
                    ptb.Image = Image.FromFile(startupPath + @"\image\banDong.png");

                }
                ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                Label lbBan = new Label();
                lbBan.Text = dr[1].ToString();
                lbBan.Font = new Font("Segoe UI", 10);
                lbBan.ForeColor = Color.Black;



                lbBan.Margin = new Padding(10, 10, 0, 0);
                flp.Controls.Add(ptb);
                flp.Controls.Add(lbBan);

                flpkvBan.Controls.Add(flp);


                ptb.Click += Ptb_Click;


            }
        }

        private void exportPDF()
        {

        }
        public FormKhuVucBan()
        {
            InitializeComponent();
        }

        private void FormKhuVucBan_Load(object sender, EventArgs e)
        {
            NV = busNV.curNV(lbEmailNV.Text);
            dgvHDCT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHDCT.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvHDCT.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvThucDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHDCT.RowHeadersVisible = false;
            dgvThucDon.RowHeadersVisible = false;
            dgvThucDon.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            FrmLoad();
            loadThucDonkvBan();
            lbTenNV.Text = NV.TenNV;
            if (IndexBan < 0)
            {
                loadban();
            }
            else
            {

                SelectBan(IndexBan);
                
            }




        }

        private void Ptb_Click(object sender, EventArgs e)
        {

            PictureBox ptb = sender as PictureBox;
            var Index = ptb.Parent.Parent.Controls.IndexOf(ptb.Parent);
            IndexBan = Index;

            SelectBan(IndexBan);





        }

        private void dgvThucDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvThucDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvThucDon.Rows.Count > 1)
            {
                if (dgvThucDon.CurrentRow.Index < dgvThucDon.Rows.Count - 1)
                {

                    TD = busTD.curTD(dgvThucDon.CurrentRow.Cells[0].FormattedValue.ToString());

                    lbTenMon.Text = TD.TenTD;
                    btThem.Enabled = true;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void btBatDau_Click(object sender, EventArgs e)
        {
            DTO_Ban Ban = busBan.curBan(lbViTriBan.Text);


            if (MessageBox.Show("Mở bàn đã chọn?", "Confirm",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (busBan.UpdateTrangThaiBan(Ban, 1))
                {

                    lbStartTime.Visible = true;
                    lbStartTime.Text = (DateTime.Now.Hour < 10 ? "0" + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString()) + ":" + (DateTime.Now.Minute < 10 ? "0" + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString()) + ":" + (DateTime.Now.Second < 10 ? "0" + DateTime.Now.Second.ToString() : DateTime.Now.Second.ToString());
                    lbEndTime.Visible = true;
                    lbMaHD.Text = "HD" + DateTime.Now.ToString("ddMMyyyy_") + (DateTime.Now.Hour < 10 ? "0" + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString()) + (DateTime.Now.Minute < 10 ? "0" + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString()) + (DateTime.Now.Second < 10 ? "0" + DateTime.Now.Second.ToString() : DateTime.Now.Second.ToString()); ;
                    btBatDau.Enabled = false;
                    (flpkvBan.Controls[IndexBan].Controls[0] as PictureBox).Image = Image.FromFile(startupPath + @"\image\banMo.ico");
                    hd = new DTO_HoaDon(lbMaHD.Text, Ban.IdBan, 0);
                    busBan.ThemHoaDonTam(hd);
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra vui lòng kiểm tra lại");
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbEndTime.Text = (DateTime.Now.Hour < 10 ? "0" + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString()) + ":" + (DateTime.Now.Minute < 10 ? "0" + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString()) + ":" + (DateTime.Now.Second < 10 ? "0" + DateTime.Now.Second.ToString() : DateTime.Now.Second.ToString());
        }

        private void flpkvBan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ChkBKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBKhachHang.Checked == true)
            {
                txtSDTKH.Enabled = true;
                btThemKhach.Enabled = true;
            }
            else
            {
                txtSDTKH.Enabled = false;
                btThemKhach.Enabled = false;
            }


        }

        private void btThem_Click(object sender, EventArgs e)
        {
            DTO_CTHD curCTHD = new DTO_CTHD(lbMaHD.Text, TD.MaTD, (int)nudSoLuong.Value, txtGhiChuhdct.Text);

            if (MessageBox.Show("Thêm " + TD.TenTD + " vào hoá đơn " + curCTHD.MaHD + "?", "Confirm",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                busBan.ThemCTHDTam(curCTHD);
                LoadCTHD();


            }

            lbTongTien.Text = busBan.TongTienHDTamKM(hd).ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void CloseFrm(object sender, FormClosedEventArgs e)
        {

            this.Refresh();
            FormKhuVucBan_Load(sender, e);



        }
        private void btKhuyenMai_Click(object sender, EventArgs e)
        {
            FormKhuyenMaiMini KM = new FormKhuyenMaiMini(hd.MaHD);
            KM.Show();
            KM.FormClosed += new FormClosedEventHandler(CloseFrm);
        }

        private void btThemKhach_Click(object sender, EventArgs e)
        {
            KH = busKH.curKhach(txtSDTKH.Text);
            FormKhachHangMini frmKHMN = new FormKhachHangMini(KH,txtSDTKH.Text);
           
            frmKHMN.Show();
            frmKHMN.FormClosed += new FormClosedEventHandler(CloseFrm);
        }

        private void btBill_Click(object sender, EventArgs e)
        {

            //DTO_HoaDon HoaDonFinal = (from DataRow dr in busBan.dtHoaDonTam(busBan.curBan(lbViTriBan.Text)).Rows
            //                          where string.Compare(dr[0].ToString(), hd.MaHD, true) == 0
            //                          select new DTO_HoaDon(dr[0].ToString(), NV.MaNV, (int)dr[1], float.Parse(dr[4].ToString()), dr[5].ToString())).FirstOrDefault();

            //if (string.IsNullOrWhiteSpace(HoaDonFinal.SDT_KH))
            //{
            //    busBan.ThemHDFinalNoneKH(HoaDonFinal);
            //}
            //else
            //{
            //    busBan.ThemHoaDonFinal(HoaDonFinal);
            //}

            //foreach (DataRow dr in busBan.dtHDCTFinal(hd.MaHD).Rows)
            //{
            //    DTO_CTHD cthd = new DTO_CTHD(dr[0].ToString(), dr[1].ToString(), int.Parse(dr[2].ToString()), dr[3].ToString());

            //    DTO_Ban Ban = busBan.curBan(lbViTriBan.Text);
            //    if (busBan.ThemCTHDFinal(cthd))
            //    {
            //        busBan.UpdateTrangThaiBan(Ban, 0);
            //        (flpkvBan.Controls[IndexBan].Controls[0] as PictureBox).Image = Image.FromFile(startupPath + @"\image\banDong.png");

            //    }


            //}
            crtBaoCao();
            //busBan.ClearTemp(hd.MaHD);
        }
    }
}
