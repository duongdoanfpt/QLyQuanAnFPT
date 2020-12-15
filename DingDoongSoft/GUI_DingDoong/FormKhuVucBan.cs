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
using System.Text.RegularExpressions;
using CrystalDecisions.Windows.Forms;



namespace GUI_DingDoong
{

    public partial class FormKhuVucBan : Form
    {
        // Khởi tạo ban đầu
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
        static int quyen = FormMain.quyen;
        // 

        string startupPath = Environment.CurrentDirectory;
        // Disable tất cả nút trên frm
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
        // tạo sourch gợi ý cho textbox tim kiem
        private AutoCompleteStringCollection GetAutoSourceFromTable(DataTable table)
        {
            AutoCompleteStringCollection autoSourceCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in table.Rows)
            {
                autoSourceCollection.Add(row[0].ToString()); 
            }

            return autoSourceCollection;
        }

        //Kiểm tra tồn tại bàn đóng hoặc mở
        private bool checkBan(BUS_Ban busBan, int trangthai)
        {
            foreach(DataRow dr in busBan.dtBan().Rows)
            {
                if ((int)dr[2] == trangthai && string.Compare(dr[1].ToString(), lbViTriBan.Text, true) != 0)
                {
                    return true;
                }
                
            }
            return false;
        }

        private void bt3d()
        {
            foreach (var bt in GetAll(this, typeof(Button)))
            {

                (bt as Button).Enabled = false;
               

                bt.EnabledChanged += Bt_EnabledChanged;
                


                bt.Paint += Bt_Paint;


            }
            ChkBKhachHang.Enabled = false;
        }

        private void Bt_EnabledChanged(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            var g = bt.CreateGraphics();
            
            
            if(bt.Enabled == true)
            {

                ControlPaint.DrawBorder(g, bt.ClientRectangle,
                SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset);

                bt.BackColor = Color.White;

            }    
            else
            {
                bt.BackColor = Color.LightGray;

                ControlPaint.DrawBorder(g, bt.ClientRectangle,
                SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset);
                bt.BackColor = Color.LightGray;
            }
           
        }

        // làm nút 3d
        private void Bt_Paint(object sender, PaintEventArgs e)
        {
            Button bt = sender as Button;
            if(bt.Enabled == true)
            {
                ControlPaint.DrawBorder(e.Graphics, bt.ClientRectangle,
                SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset);
            } 
            else
            {
                ControlPaint.DrawBorder(e.Graphics, bt.ClientRectangle,
               SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
               SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
               SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
               SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset);
            }    
           
        }
        // ẩn button cell cuối hdct
        public static void DataGridViewCellVisibility(DataGridViewCell cell, bool visible)
        {
            cell.Style = visible ?
                  new DataGridViewCellStyle { Padding = new Padding(0, 0, 0, 0) } :
                  new DataGridViewCellStyle { Padding = new Padding(cell.OwningColumn.Width, 0, 0, 0) };

            cell.ReadOnly = !visible;
        }

        // Check SDT Hợp  lệ
        public bool isvailphone(string phone)
        {
            string strRegex = @"((09|03|07|08|05)+([0-9]{8})\b)";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(phone)) return true;
            else return false;
        }


        // chọn một bàn ở vị trí indexBan
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
                DateTime StartHD = (DateTime)drhd[2];
                lbMaHD.Text = drhd[0].ToString();
                dgvThucDon.Enabled = true;
                dgvHDCT.Enabled = true;
                btChuyenBan.Enabled = true;
                btGopBan.Enabled = true;
                btTimKiem.Enabled = true;
                btThem.Enabled = true;
                ChkBKhachHang.Enabled = true;
                ChkBKhachHang.Checked = false;
                btThemKhach.Enabled = false;
                txtSDTKH.Enabled = false;
                if (string.IsNullOrWhiteSpace(hd.SDT_KH))
                {
                    
                  
                    txtSDTKH.Text = null;
                   
                }
                else
                {
                   
                   
                    txtSDTKH.Text = hd.SDT_KH;
                }

                lbKhuyenMai.Text = hd.KhuyenMai.ToString() + "%";
                lbTongTien.Text = (busBan.TongTienHDTam(hd) - busBan.TongTienHDTam(hd) * hd.KhuyenMai / 100).ToString();
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
                dgvThucDon.Enabled = false;
                dgvHDCT.Enabled = false;
                btChuyenBan.Enabled = false;
                btGopBan.Enabled = false;
             
                btAdd1.Enabled = false;
                btRemove1.Enabled = false;
                btThem.Enabled = false;


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

        //Hien cthd ở bàn đã chọn
        private void LoadCTHD()
        {

            dgvHDCT.DataSource = busBan.dtHDCTTam(lbMaHD.Text);

            if (busBan.dtHDCTTam(lbMaHD.Text).Rows.Count > 0)
            {
                btBill.Enabled = true;
                btKhuyenMai.Enabled = true;
                if (dgvHDCT.Columns["Delete"] is null)
                {
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.Name = "Delete";
                    buttonColumn.Text = "Xoá";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dgvHDCT.Columns.Add(buttonColumn);
                   
                }
                DataGridViewCellVisibility(dgvHDCT.Rows[dgvHDCT.Rows.Count - 1].Cells["Delete"], false);
            }
            else
            {
                btBill.Enabled = false;
                btKhuyenMai.Enabled = false;





            }


        }

        // Tạo báo cáo crystal khi xuất hoá đơn
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
            txtkh.Text = txtSDTKH.Text;
            TextObject txtkm = (TextObject)cb.ReportDefinition.Sections["Section4"].ReportObjects["TextKM"];
            txtkm.Text = hd.KhuyenMai.ToString() + "%";
            TextObject txttongtien = (TextObject)cb.ReportDefinition.Sections["Section5"].ReportObjects["TxtTongTien"];
            txttongtien.Text = busBan.TongTienHDTam(hd).ToString();
            TextObject txtThanhTien = (TextObject)cb.ReportDefinition.Sections["Section5"].ReportObjects["txtThanhtien"];
            txtThanhTien.Text = (busBan.TongTienHDTam(hd) - busBan.TongTienHDTam(hd) * hd.KhuyenMai / 100).ToString();


            cb.Database.Tables["CTHD"].SetDataSource(dtHDCT);
            var path = startupPath + @"\HoaDon\" + lbMaHD.Text + ".pdf";
           
            cb.ExportToDisk(ExportFormatType.PortableDocFormat, path);


            FrmBill frm = new FrmBill(cb);
            frm.Show();
        }


        // load thưc đơn ở frmkhuvucBan
        private void loadThucDonkvBan()
        {
            dgvThucDon.DataSource = busTD.DanhSachThucDonBan();

        }

        // lấy danh sách bàn và add toàn bộ bàn lên form
        private void loadban()
        {
            string startupPath = Environment.CurrentDirectory;
            flpkvBan.Controls.Clear();


            foreach (DataRow dr in busBan.dtBan().Rows)
            {

                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.Width = 70;
                flp.Height = 120;
                PictureBox ptb = new PictureBox();
                ptb.Width = 60;
                ptb.Height = 60;
                ptb.Cursor = Cursors.Hand;
                flp.Margin = new Padding(15, 15, 15, 15);
                if (int.Parse(dr[2].ToString()) == 1)
                {
                    ptb.Image = Image.FromFile(startupPath + @"\image\banMo.png");


                }
                else if (int.Parse(dr[2].ToString()) == 0)
                {
                    ptb.Image = Image.FromFile(startupPath + @"\image\banDong.png");

                }
                ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                ptb.BackColor = Color.Transparent;
                Label lbBan = new Label();
                lbBan.Text = dr[1].ToString();
                lbBan.Font = new Font("Segoe UI", 10);
                lbBan.ForeColor = Color.Black;



                lbBan.Margin = new Padding(6, 0, 0, 0);
                flp.Controls.Add(ptb);
                flp.Controls.Add(lbBan);

                flpkvBan.Controls.Add(flp);
                lbBan.Click += LbBan_Click;
                lbBan.MouseDown += LbBan_MouseDown;


                ptb.Click += Ptb_Click;
                ptb.MouseDown += Ptb_MouseDown;


            }
        }

        private void LbBan_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Label lb = sender as Label;
                var Index = lb.Parent.Parent.Controls.IndexOf(lb.Parent);
                IndexBan = Index;

                SelectBan(IndexBan);


                menuBan.Show(lb, 10, 20);
                if (busBan.curBan(lbViTriBan.Text).TrangThai == 0)
                {
                    menuBan.Items[0].Enabled = true;
                    menuBan.Items[1].Enabled = false;
                    menuBan.Items[2].Enabled = false;
                    menuBan.Items[3].Enabled = false;
                }
                else
                {
                    menuBan.Items[0].Enabled = false;
                    menuBan.Items[1].Enabled = true;
                    menuBan.Items[2].Enabled = true;
                    menuBan.Items[3].Enabled = true;
                }
                if (FormLogin.NvMain.Quyen == 0)
                {
                    menuBan.Items[3].Enabled = false;

                }
            }
        }

        private void LbBan_Click(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            var Index = lb.Parent.Parent.Controls.IndexOf(lb.Parent);
            IndexBan = Index;

            SelectBan(IndexBan);
        }

        private void Ptb_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PictureBox ptb = sender as PictureBox;
                var Index = ptb.Parent.Parent.Controls.IndexOf(ptb.Parent);
                IndexBan = Index;

                SelectBan(IndexBan);


                menuBan.Show(ptb, 10, 50);
                if (busBan.curBan(lbViTriBan.Text).TrangThai == 0)
                {
                    menuBan.Items[0].Enabled = true;
                    menuBan.Items[1].Enabled = false;
                    menuBan.Items[2].Enabled = false;
                    menuBan.Items[3].Enabled = false;
                }
                else
                {
                    menuBan.Items[0].Enabled = false;
                    menuBan.Items[1].Enabled = true;
                    menuBan.Items[2].Enabled = true;
                    menuBan.Items[3].Enabled = true;
                } 
                if(FormLogin.NvMain.Quyen ==0)
                {
                    menuBan.Items[3].Enabled = false;

                }    
            }    
               
        }

       
        
       

    
        public FormKhuVucBan(int number)
        {
            InitializeComponent();
            IndexBan = number;
        }

        private void FormKhuVucBan_Load(object sender, EventArgs e)
        {
            bt3d();
            NV = busNV.curNV(lbEmailNV.Text);
            dgvHDCT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHDCT.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvHDCT.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvThucDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHDCT.RowHeadersVisible = false;
            dgvThucDon.RowHeadersVisible = false;
            dgvThucDon.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvThucDon.Enabled = false;
            dgvHDCT.Enabled = false;
            dgvHDCT.ReadOnly = true;
            dgvThucDon.ReadOnly = true;
            cbNhom.SelectedIndex = 0;
            txtTenTD.AutoCompleteCustomSource = GetAutoSourceFromTable(busTD.DanhSachThucDonBan());
            txtTenTD.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtTenTD.AutoCompleteSource = AutoCompleteSource.CustomSource;
            pbBan.Enabled = false;
            pbBan.BorderStyle = BorderStyle.Fixed3D;

            bt3d();
            btLamMoi.Enabled = true;
            loadThucDonkvBan();
            lbTenNV.Text = FormLogin.NvMain.TenNV;
            if (IndexBan < 0)
            {
                loadban();
            }
            else
            {

                SelectBan(IndexBan);
                
            }

            lbEmailNV.Text = FormLogin.NvMain.Email;
            if (FormMain.quyen == 0)
            {

                phanquyen();
            }
            


        }

        private void Ptb_Click(object sender, EventArgs e)
        {

            PictureBox ptb = sender as PictureBox;
            var Index = ptb.Parent.Parent.Controls.IndexOf(ptb.Parent);
            IndexBan = Index;

            SelectBan(IndexBan);
            





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
                    (flpkvBan.Controls[IndexBan].Controls[0] as PictureBox).Image = Image.FromFile(startupPath + @"\image\banMo.png");
                    hd = new DTO_HoaDon(lbMaHD.Text, Ban.IdBan);
                    busBan.ThemHoaDonTam(hd);
                    dgvThucDon.Enabled = true;
                    btChuyenBan.Enabled = true;
                    ChkBKhachHang.Enabled = true;
                    btGopBan.Enabled = true;
                    btTimKiem.Enabled = true;
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
            DTO_CTHD curCTHD = new DTO_CTHD(lbMaHD.Text, TD.MaTD, (int)nudSoLuong.Value);

           
                busBan.ThemCTHDTam(curCTHD);
                LoadCTHD();


            

            lbTongTien.Text = (busBan.TongTienHDTam(hd) - busBan.TongTienHDTam(hd) * hd.KhuyenMai / 100).ToString(); 
        }

       
        private void CloseFrm(object sender, FormClosedEventArgs e)
        {

            this.Refresh();
            loadban();
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
            if (!string.IsNullOrWhiteSpace(txtSDTKH.Text))
            {
                if (!isvailphone(txtSDTKH.Text))
                {
                    errorSDTKH.SetError(txtSDTKH, "Số điện thoại không hợp lệ");
                    MessageBox.Show("Định dạng số điện thoại không đúng");

                }
                else
                {
                    errorSDTKH.SetError(txtSDTKH, null);
                    KH = busKH.curKhach(txtSDTKH.Text);
                    FormKhachHangMini frmKHMN = new FormKhachHangMini(KH, txtSDTKH.Text);

                    frmKHMN.Show();
                    frmKHMN.FormClosed += new FormClosedEventHandler(CloseFrm);
                }
            }
            else
            {
                KH = busKH.curKhach(txtSDTKH.Text);
                FormKhachHangMini frmKHMN = new FormKhachHangMini(KH, txtSDTKH.Text);

                frmKHMN.Show();
                frmKHMN.FormClosed += new FormClosedEventHandler(CloseFrm);
            }    
            
        }

        private void btBill_Click(object sender, EventArgs e)
        {

            DTO_HoaDon HoaDonFinal = (from DataRow dr in busBan.dtHoaDonTam(busBan.curBan(lbViTriBan.Text)).Rows
                                      where string.Compare(dr[0].ToString(), hd.MaHD, true) == 0
                                      select new DTO_HoaDon(dr[0].ToString(), NV.MaNV, (int)dr[1], float.Parse(dr[3].ToString()), dr[4].ToString())).FirstOrDefault();
            HoaDonFinal.ThanhTien = (busBan.TongTienHDTam(hd) - busBan.TongTienHDTam(hd) * hd.KhuyenMai / 100);
            if (string.IsNullOrWhiteSpace(HoaDonFinal.SDT_KH))
            {
                busBan.ThemHDFinalNoneKH(HoaDonFinal);
            }
            else
            {
                busBan.ThemHoaDonFinal(HoaDonFinal);
            }

            foreach (DataRow dr in busBan.dtHDCTFinal(hd.MaHD).Rows)
            {
                DTO_CTHD cthd = new DTO_CTHD(dr[0].ToString(), dr[1].ToString(), int.Parse(dr[2].ToString()));

                DTO_Ban Ban = busBan.curBan(lbViTriBan.Text);
                if (busBan.ThemCTHDFinal(cthd))
                {
                    busBan.UpdateTrangThaiBan(Ban, 0);
                    (flpkvBan.Controls[IndexBan].Controls[0] as PictureBox).Image = Image.FromFile(startupPath + @"\image\banDong.png");

                }


            }
            crtBaoCao();
            busBan.ClearTemp(hd.MaHD);
            txtSDTKH.Text = null;
            FormKhuVucBan_Load(sender, e);
        }

        private void dgvThucDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvThucDon.Rows.Count > 1)
            {
                if (dgvThucDon.CurrentRow.Index < dgvThucDon.Rows.Count - 1)
                {

                    TD = busTD.curTD(dgvThucDon.CurrentRow.Cells[0].FormattedValue.ToString());

                    lbTenMon.Text = TD.TenTD;
                    btThem.Enabled = true;
                    btAdd1.Enabled = true;
                    btRemove1.Enabled = true;
                    dgvHDCT.Enabled = true;
                }
            }
        }

        private void btAdd1_Click(object sender, EventArgs e)
        {

            DTO_CTHD curCTHD = new DTO_CTHD(lbMaHD.Text, TD.MaTD, 1);


            busBan.ThemCTHDTam(curCTHD);
            LoadCTHD();


           

            lbTongTien.Text = (busBan.TongTienHDTam(hd) - busBan.TongTienHDTam(hd) * hd.KhuyenMai / 100).ToString();
        }

        private void dgvHDCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvHDCT.CurrentRow.Selected = true;
            btRemove1.Enabled = true;
           
          
           
            
            
        }

        private void btRemove1_Click(object sender, EventArgs e)
        {

            if (dgvHDCT.Rows.Count > 1)
            {


                dgvHDCT.CurrentRow.Selected = true;
                int rowindex = dgvHDCT.SelectedRows[0].Index;

                DTO_ThucDon selectTD = busTD.curTD(dgvHDCT.Rows[rowindex].Cells["Column1"].FormattedValue.ToString());
                if (busBan.DeleteCTHDSoluong(lbMaHD.Text, selectTD.MaTD, 1))
                {
                    try
                    {
                        DTO_CTHD curCTHD = busBan.curCTHD(lbMaHD.Text, selectTD.MaTD);
                        if(!(curCTHD is null))
                        {
                            dgvHDCT.ReadOnly = false;
                            dgvHDCT.SelectedRows[0].Cells["Column2"].Value = curCTHD.SoLuong;
                            dgvHDCT.ReadOnly = true;
                        }
                        else
                        {
                            
                            LoadCTHD();
                            if(dgvHDCT.Rows.Count>1)
                            {
                                dgvHDCT.CurrentRow.Selected = true;
                                selectTD = busTD.curTD(dgvHDCT.SelectedRows[0].Cells[0].FormattedValue.ToString());
                            }    
                            
                            

                              
                               
                           
                        }    
                       
                    }
                    catch (Exception)
                    {
                        
                    }
                    finally
                    {
                       
                    }
                    
                   



                }
               
            }
            lbTongTien.Text = (busBan.TongTienHDTam(hd) - busBan.TongTienHDTam(hd) * hd.KhuyenMai / 100).ToString();

            DataGridViewCellVisibility(dgvHDCT.Rows[dgvHDCT.Rows.Count - 1].Cells["Delete"], false);

        }

     

        private void btChuyenBan_Click(object sender, EventArgs e)
        {
            if(checkBan(busBan,0))
            {
                DTO_Ban curBan = busBan.curBan(lbViTriBan.Text);
                FormChuyenBan frmcb = new FormChuyenBan(curBan, hd.MaHD);
                frmcb.Show();
                frmcb.FormClosed += new FormClosedEventHandler(CloseFrm);
            }
            else
            {
                MessageBox.Show("Không có bàn trống để chuyển bàn");
            }    
           

        }

        private void btGopBan_Click(object sender, EventArgs e)
        {
            if(checkBan(busBan,1))
            {
                DTO_Ban curBan = busBan.curBan(lbViTriBan.Text);
                FormGopBan frmgb = new FormGopBan(curBan);
                frmgb.Show();
                frmgb.FormClosed += new FormClosedEventHandler(CloseFrm);
            }
            else
            {
                MessageBox.Show("Không bàn nào đang mở để gộp bàn vui long kiểm tra lại!");
            }    
           
        }

        // Phân Quyền
        private void phanquyen()
        {
            pbNhanVien.Enabled = false;
            pbNhanVien.BackColor = Color.Gray;


            pbThongKe.Visible = false;


        }

        private void pbHome_Click(object sender, EventArgs e)
        {
            FormMain frmMain = new FormMain();
            this.Hide();

            frmMain.Closed += (s, args) => this.Close();
            frmMain.Show();
        }

        private void pbNhanVien_Click(object sender, EventArgs e)
        {
            FormNhanVien nv = new FormNhanVien();
            this.Hide();

            nv.Closed += (s, args) => this.Close();
            nv.Show();
        }

        private void pbKhachHang_Click(object sender, EventArgs e)
        {
            ; FormKhachHang kh = new FormKhachHang();
            this.Hide();

            kh.Closed += (s, args) => this.Close();
            kh.Show();
        }

        private void pbBan_Click(object sender, EventArgs e)
        {
            FormKhuVucBan kv = new FormKhuVucBan(-1);
            this.Hide();

            kv.Closed += (s, args) => this.Close();
            kv.Show();
        }

        private void pbThongKe_Click(object sender, EventArgs e)
        {
            FormThongKe thongKe = new FormThongKe();
            this.Hide();

            thongKe.Closed += (s, args) => this.Close();
            thongKe.Show();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            dgvThucDon.DataSource = busTD.dtsearchTDBan(txtTenTD.Text);
        }

        private void cbNhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbNhom.SelectedIndex!=0)
            {
                dgvThucDon.DataSource = busTD.dtsearchTDNhom(cbNhom.Text);
            }
            else
            {
                dgvThucDon.DataSource = busTD.DanhSachThucDonBan();
            }    
        }

        private void txtTenTD_KeyDown(object sender, KeyEventArgs e)
        {if(e.KeyCode == Keys.Enter)
            {
                dgvThucDon.DataSource = busTD.dtsearchTDBan(txtTenTD.Text);
            }    

        }

      

        private void txtTenTD_Enter(object sender, EventArgs e)
        {
            txtTenTD.Text = null;
        }

        private void btLamMoi_Click(object sender, EventArgs e)
        {

            dgvThucDon.DataSource = busTD.DanhSachThucDonBan();
            cbNhom.SelectedIndex = 0;
            txtTenTD.Text = "Nhập tên món để tìm kiếm";
        }

        private void cmsReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Reset dữ liệu bàn đã chọn?", "Confirm",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                if (busBan.ResetBan(lbViTriBan.Text, lbMaHD.Text)) 
                {
                    loadban();
                    lbStartTime.Visible = false;
                    lbEndTime.Visible = false;
                    lbMaHD.Text = "";
                    lbTongTien.Text = "0";
                    lbKhuyenMai.Text = "0%";
                    btKhuyenMai.Enabled = false;
                    ChkBKhachHang.Enabled = false;
                    dgvThucDon.Enabled = false;
                    dgvHDCT.Enabled = false;
                    btChuyenBan.Enabled = false;
                    btGopBan.Enabled = false;
                 
                    btAdd1.Enabled = false;
                    btRemove1.Enabled = false;
                    btBill.Enabled = false;

                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra vui lòng kiểm tra lại");
                }    
            }
        }

        private void pbHome_MouseEnter(object sender, EventArgs e)
        {
            pbHome.Cursor = Cursors.Hand;
            pbHome.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void pbHome_MouseLeave(object sender, EventArgs e)
        {
            pbHome.Cursor = Cursors.Default;
            pbHome.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void pbNhanVien_MouseEnter(object sender, EventArgs e)
        {
            pbNhanVien.Cursor = Cursors.Hand;
            pbNhanVien.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void pbNhanVien_MouseLeave(object sender, EventArgs e)
        {
            pbNhanVien.Cursor = Cursors.Default;
            pbNhanVien.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void pbKhachHang_MouseEnter(object sender, EventArgs e)
        {
            pbKhachHang.Cursor = Cursors.Hand;
            pbKhachHang.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void pbKhachHang_MouseLeave(object sender, EventArgs e)
        {
            pbKhachHang.Cursor = Cursors.Default;
            pbKhachHang.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void pbBan_MouseEnter(object sender, EventArgs e)
        {
            pbBan.Cursor = Cursors.Hand;
            pbBan.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void pbBan_MouseLeave(object sender, EventArgs e)
        {
            pbBan.Cursor = Cursors.Default;
            pbBan.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void pbThongKe_MouseEnter(object sender, EventArgs e)
        {
            pbThongKe.Cursor = Cursors.Hand;
            pbThongKe.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void pbThongKe_MouseLeave(object sender, EventArgs e)
        {
            pbThongKe.Cursor = Cursors.Default;
            pbThongKe.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void pbThucDon_Click(object sender, EventArgs e)
        {
            FormThucDon td = new FormThucDon();
            this.Hide();

            td.Closed += (s, args) => this.Close();
            td.Show();
        }

        private void pbThucDon_MouseEnter(object sender, EventArgs e)
        {
            pbThucDon.Cursor = Cursors.Hand;
            pbThucDon.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void pbThucDon_MouseLeave(object sender, EventArgs e)
        {
            pbThucDon.Cursor = Cursors.Default;
            pbThucDon.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void dgvHDCT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvHDCT.Columns["Delete"].Index && e.RowIndex >= 0 && e.RowIndex < dgvHDCT.Rows.Count - 1)
            {

                
                    DTO_ThucDon selectTD = busTD.curTD(dgvHDCT.CurrentRow.Cells["Column1"].FormattedValue.ToString());
                    DTO_CTHD curCTHD = busBan.curCTHD(lbMaHD.Text, selectTD.MaTD);


                    if (busBan.DeleteCTHDSoluong(lbMaHD.Text, selectTD.MaTD, curCTHD.SoLuong))
                    {
                        LoadCTHD();


                    }

                
                lbTongTien.Text = (busBan.TongTienHDTam(hd) - busBan.TongTienHDTam(hd) * hd.KhuyenMai / 100).ToString();
                DataGridViewCellVisibility(dgvHDCT.Rows[dgvHDCT.Rows.Count - 1].Cells["Delete"], false);

            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
 }
 

