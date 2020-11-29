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
    public partial class FormKhuVucBan : Form
    {
        BUS_Ban busBan = new BUS_Ban();
        BUS_ThucDon busTD = new BUS_ThucDon();
        BUS_NhanVien busNV = new BUS_NhanVien();
        public static int IndexBan;
        public static DTO_ThucDon TD;
        public static DTO_HoaDon hd;
        
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
           foreach(var bt in GetAll(this,typeof(Button)) )
            {

                (bt as Button).Enabled = false;



            }    
           
        }
        private void LoadCTHD()
        {
            //if(busBan.dtHDCTTam(lbMaHD.Text).Rows.Count>0)
            //{
                dgvHDCT.DataSource = busBan.dtHDCTTam(lbMaHD.Text);
               
            
            //else
            //{
            //    dgvHDCT.DataSource = dt
                
                
                

              
            //}
           

        }

        
       
        private void loadThucDonkvBan()
        {
            dgvThucDon.DataSource = busTD.DanhSachThucDonBan();

        }

        private void loadban()
        {
            string startupPath = Environment.CurrentDirectory;

            
            foreach(DataRow dr  in busBan.dtBan().Rows)
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
        public FormKhuVucBan()
        {
            InitializeComponent();
        }

        private void FormKhuVucBan_Load(object sender, EventArgs e)
        {
            DTO_NhanVien NV = busNV.curNV(lbEmailNV.Text);
            dgvHDCT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThucDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHDCT.RowHeadersVisible = false;
            dgvThucDon.RowHeadersVisible = false;
            dgvThucDon.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            loadban();
            loadThucDonkvBan();
            lbTenNV.Text = NV.TenNV;
            FrmLoad();

           

        }

        private void Ptb_Click(object sender, EventArgs e)
        {
            
            PictureBox ptb = sender as PictureBox;
           
            PictureBox image = (PictureBox)ptb.Parent.Controls[0];
            Label lbBan = (Label)ptb.Parent.Controls[1];
            lbViTriBan.Text = lbBan.Text;
            
            DTO_Ban Ban = busBan.curBan(lbViTriBan.Text);
            hd = busBan.curhd(Ban);
           
            if(Ban.TrangThai == 1)
            {
                DataTable curHd = busBan.dtHoaDonTam(Ban);
                DataRow drhd = curHd.Rows[0];
                lbStartTime.Visible = true;
                lbEndTime.Visible = true;
                DateTime StartHD = (DateTime)drhd[3];
                lbMaHD.Text = drhd[0].ToString();
                lbKhuyenMai.Text = hd.KhuyenMai.ToString()+"%";
                lbTongTien.Text = busBan.TongTienHDTamKM(hd).ToString();
                btKhuyenMai.Enabled = true;
                lbStartTime.Text =  (StartHD.Hour < 10 ? "0" + StartHD.Hour.ToString() : StartHD.Hour.ToString()) + ":" + (StartHD.Minute < 10 ? "0" + StartHD.Minute.ToString() : StartHD.Minute.ToString()) + ":" + (StartHD.Second < 10 ? "0" + StartHD.Second.ToString() : StartHD.Second.ToString());
            }
            else
            {
                lbStartTime.Visible = false;
                lbEndTime.Visible = false;
                lbMaHD.Text = "";
                lbTongTien.Text = "0";
                lbKhuyenMai.Text = "0%";
                btKhuyenMai.Enabled = false;

            }
            LoadCTHD();
            



            lbBan.BackColor = Color.Transparent;
            var Index = ptb.Parent.Parent.Controls.IndexOf(ptb.Parent);
            IndexBan = Index;
            for (int i = 0; i < ptb.Parent.Parent.Controls.Count; i++)
            {

                if (ptb.Parent.Parent.Controls[i] == ptb.Parent.Parent.Controls[Index])
                {
                    ptb.Parent.Parent.Controls[i].BackColor = Color.FromArgb(128, 72, 145, 220);

                }
                else
                {
                    ptb.Parent.Parent.Controls[i].BackColor = Color.White;
                }
            }
            if(Ban.TrangThai ==0)
            {
                btBatDau.Enabled = true;

            }
            else
            {
                btBatDau.Enabled = false;
            }    






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

                if (busBan.UpdateTrangThaiBan(Ban,1))
                {

                    lbStartTime.Visible = true;
                    lbStartTime.Text = (DateTime.Now.Hour < 10 ? "0" + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString()) + ":" + (DateTime.Now.Minute < 10 ? "0" + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString()) + ":" + (DateTime.Now.Second < 10 ? "0" + DateTime.Now.Second.ToString() : DateTime.Now.Second.ToString());
                    lbEndTime.Visible = true;
                    lbMaHD.Text = "HD" + DateTime.Now.ToString("ddMMyyyy_") + (DateTime.Now.Hour < 10 ? "0" + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString()) + (DateTime.Now.Minute < 10 ? "0" + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString()) + (DateTime.Now.Second < 10 ? "0" + DateTime.Now.Second.ToString() : DateTime.Now.Second.ToString()); ;
                    btBatDau.Enabled = false;
                    (flpkvBan.Controls[IndexBan].Controls[0] as PictureBox).Image = Image.FromFile(startupPath + @"\image\banMo.ico");
                    btKhuyenMai.Enabled = true;
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
            if(ChkBKhachHang.Checked  == true)
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

        private void btKhuyenMai_Click(object sender, EventArgs e)
        {
            FormKhuyenMaiMini frmKMMN = new FormKhuyenMaiMini();
            frmKMMN.Show();
        }
    }
}
