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

        private void lbThucDonBest_Click(object sender, EventArgs e)
        {
            //chkbTime.Enabled = true;
            //if(chkbTime.Checked == true)
            //{
            //    DgvThongKe.DataSource = busTK.dtSLTD(tuNgayDate.Value, DenNgay.Value);
            //}
            //else
            //{
            //    DgvThongKe.DataSource = busTK.dtSLTD(null, null);
            //}    

        }

        private void DataThongKe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chlkbTime_CheckedChanged(object sender, EventArgs e)
        {
            //if(chkbTime.Checked == true)
            //{
            //    tuNgayDate.Enabled = true;
            //    DenNgay.Enabled = true;
            //}    
            //else
            //{
            //    tuNgayDate.Enabled = false;
            //    DenNgay.Enabled = false;
            //}                

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

      

        private void FormThongKe_Load(object sender, EventArgs e)
        {
            chkboxTime.Visible = false;
            dtpkStartDate.Visible = false;
            dtpkEndDate.Visible = false;
            lbarrow.Visible = false;
            btThongKe.Visible = false;
            btThongKe.Enabled = false;
            
          
          

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(chkboxTime.Checked == true)
            {
                dtpkStartDate.Enabled = true;
                dtpkEndDate.Enabled = true;
                btThongKe.Enabled = true;
            }
            else
            {
                dtpkStartDate.Enabled = false;
                dtpkEndDate.Enabled = false;
                btThongKe.Enabled = false;
            }    

        }

        private void rdTDSL_CheckedChanged(object sender, EventArgs e)
        {
            if(rdTDSL.Checked == true)
            {
                flowLayoutPanel1.Controls.Clear();
                chkboxTime.Visible = true;
                dtpkStartDate.Visible = true;
                dtpkEndDate.Visible = true;
                lbarrow.Visible = true;
                btThongKe.Visible = true;
                DataGridView dgvThucDon = new DataGridView();
                dgvThucDon.Width = 1050;
                dgvThucDon.Height = 560;
                dgvThucDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvThucDon.BackgroundColor = Color.White;
                dgvThucDon.DataSource = busTK.dtSLTD(null, null);
                flowLayoutPanel1.Controls.Add(dgvThucDon);

            }
            else
            {
                chkboxTime.Visible = false;
                dtpkStartDate.Visible = false;
                dtpkEndDate.Visible = false;
                lbarrow.Visible = false;
                btThongKe.Visible = false;
            }    
        }

        private void radioThucDonTheoNhom_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btThongKe_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            
            DataGridView dgvThucDon = new DataGridView();
            dgvThucDon.Width = 1050;
            dgvThucDon.Height = 560;
            dgvThucDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThucDon.BackgroundColor = Color.White;
            dgvThucDon.DataSource = busTK.dtSLTD(null, null);
            flowLayoutPanel1.Controls.Add(dgvThucDon);
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ADDFLP(string Ten,string GiaTri)
        {
            FlowLayoutPanel flpDoanhThuNgay = new FlowLayoutPanel();

            Label lbDoanhThuNgay = new Label();
            Label DoanhThu = new Label();
            lbDoanhThuNgay.Text = Ten;
            
            DoanhThu.Text = GiaTri;
            flpDoanhThuNgay.Width = 500;
            flpDoanhThuNgay.Height = 250;
            flpDoanhThuNgay.BorderStyle = BorderStyle.Fixed3D;
            flpDoanhThuNgay.FlowDirection = FlowDirection.TopDown;

            flpDoanhThuNgay.Controls.Add(lbDoanhThuNgay);
            flpDoanhThuNgay.Controls.Add(DoanhThu);
            flowLayoutPanel1.Controls.Add(flpDoanhThuNgay);

        }

        private void label4_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            ADDFLP("DOANH THU TRONG NGÀY", "1000000");
           
        }
    }
}
