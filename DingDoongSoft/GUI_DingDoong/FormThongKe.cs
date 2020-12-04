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

        public void Disable3Value()
        {
            tuNgay.Visible = false;
            tuNgay2.Visible = false;
            tuNgayDate.Visible = false;
            tuNgayDate2.Visible = false;
            btThongKe.Visible = false;
        }
        private void FormThongKe_Load(object sender, EventArgs e)
        {
            Disable3Value();
            ThongKe.Enabled = false;
            ThongKe.BorderStyle = BorderStyle.Fixed3D;
        }

        private void btThucDon_Click(object sender, EventArgs e)
        {
            DataThongKe.DataSource = busThucDon.DanhSachThucDonAll();
            DataThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadDanhSachThucDon(busThucDon.DanhSachThucDonAll());

        }

        private void LoadDanhSachThucDon(DataTable dt)
        {
            DataThongKe.DataSource = dt;
            DataThongKe.Columns[0].HeaderText = "Mã thực đơn";
            DataThongKe.Columns[1].HeaderText = "Tên thực đơn";
            DataThongKe.Columns[2].HeaderText = "Giá bán";
            DataThongKe.Columns[3].HeaderText = "Nhóm";
            DataThongKe.Columns[4].HeaderText = "Mô tả";
            DataThongKe.Columns[5].HeaderText = "Trạng thái";


        }

        private void LoadDanhSachKhachHang(DataTable dt)
        {
            DataThongKe.DataSource = dt;
            DataThongKe.Columns[0].HeaderText = "Số điện thoại";
            DataThongKe.Columns[1].HeaderText = "Tên khách hàng";
            DataThongKe.Columns[2].HeaderText = "Email";
            DataThongKe.Columns[3].HeaderText = "Giới tính";
            DataThongKe.Columns[4].HeaderText = "Ngày sinh";

        }

        private void btKhachHang_Click(object sender, EventArgs e)
        {
            DataThongKe.DataSource = busKhach.getKhach();
            DataThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadDanhSachKhachHang(busKhach.getKhach());
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
            FormKhuVucBan kv = new FormKhuVucBan();
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

        }
    }
}
