using BUS_DingDoong;
using DTO_DingDoong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_DingDoong
{
    public partial class FormKhachHang : Form
    {
        BUS_Khach busKhach = new BUS_Khach();

        public FormKhachHang()
        {
            InitializeComponent();
            FormMain.quyen = FormLogin.NvMain.Quyen;
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            lblUsers.Text = FormLogin.NvMain.Email;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadGridview_Khach();
            ResetValues();

            if (FormMain.quyen == 0)
            {

                phanquyen();
            }
        }

        private void phanquyen()
        {
            pbNhanVien.Enabled = false;
            pbNhanVien.BackColor = Color.Gray;
            

            pbKhachHang.Enabled = false;
            pbKhachHang.BackColor = Color.Gray;

            pbThongKe.Visible = false;


        }

        private void LoadGridview_Khach()
        {
            dataGridView1.DataSource = busKhach.getKhach();
            dataGridView1.Columns[0].HeaderText = "Số điện thoại";
            dataGridView1.Columns[1].HeaderText = "Tên khách hàng";
            dataGridView1.Columns[2].HeaderText = "Email";
            dataGridView1.Columns[3].HeaderText = "Giới tính";
            dataGridView1.Columns[4].HeaderText = "Ngày sinh";
        }

        public void ResetValues()
        {
            txtTen.Text = null;
            txtSDT.Text = null;
            txtEmail.Text = null;
            txtTen.Enabled = false;
            txtSDT.Enabled = false;
            txtEmail.Enabled = false;
            dtpNgaySinh.Enabled = false;
            
            btLuu.Enabled = false;
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            int gioitinh = 1;
            if (rdNu.Checked == true)
                gioitinh = 0;
           


            DTO_Khach khach = new DTO_Khach(txtTen.Text, txtSDT.Text, dtpNgaySinh.Value, txtEmail.Text, gioitinh);
            if (busKhach.insertKhach(khach))
            {
                MessageBox.Show("Thêm thành công");
                LoadGridview_Khach();
            }
            else
            {
                MessageBox.Show("Thêm không thành công");
                
            }


        }

        private void btThem_Click(object sender, EventArgs e)
        {
            txtTen.Text = null;
            txtSDT.Text = null;
            txtEmail.Text = null;
            txtTen.Enabled = true;
            txtSDT.Enabled = true;
            txtEmail.Enabled = true;
            dtpNgaySinh.Enabled = true;
            rdNam.Checked = false;
            rdNu.Checked = false;
            btLuu.Enabled = true;
        }

        private void DgvKhach_Click(object sender, EventArgs e)
        {
            DTO_Khach khach = busKhach.curKhach(dataGridView1.CurrentRow.Cells["SDT_KH"].Value.ToString());
            
            txtSDT.Text = khach.SDT ;
            txtTen.Text = khach.TenKH;
            txtEmail.Text = khach.Email;
            

            if (khach.GioiTinh == 1)
                rdNam.Checked = true;
            else
               rdNu.Checked = true;

            dtpNgaySinh.Text = khach.NgaySinh.ToString();
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            int gioitinh = 1;
            if (rdNu.Checked == true)
                gioitinh = 0;

            DTO_Khach khach = new DTO_Khach(txtTen.Text, txtSDT.Text, dtpNgaySinh.Value, txtEmail.Text, gioitinh);
            if (busKhach.UpdateKhach(khach))
            {
                MessageBox.Show("Sửa thành công");
                LoadGridview_Khach();
            }
            else
            {
                MessageBox.Show("Sửa không thành công");

            }
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = null;
            txtTimKiem.BackColor = Color.White;
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string sdt = txtTimKiem.Text;
            DataTable dtkhach = busKhach.SearchKhach(sdt);
            if (dtkhach.Rows.Count > 0)
            {
                dataGridView1.DataSource = dtkhach;
                dataGridView1.Columns[0].HeaderText = "Số điện thoại";
                dataGridView1.Columns[1].HeaderText = "Tên khách hàng";
                dataGridView1.Columns[2].HeaderText = "Email";
                dataGridView1.Columns[3].HeaderText = "Giới tính";
                dataGridView1.Columns[4].HeaderText = "Ngày sinh";
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ResetValues();
        }

        private void btBoQua_Click(object sender, EventArgs e)
        {
            txtTen.Text = null;
            txtSDT.Text = null;
            txtEmail.Text = null;
            txtTen.Enabled = true;
            txtSDT.Enabled = true;
            txtEmail.Enabled = true;
            dtpNgaySinh.Enabled = true;
            rdNam.Checked = false;
            rdNu.Checked = false;
            btLuu.Enabled = true;
            LoadGridview_Khach();
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
            FormKhachHang kh = new FormKhachHang();
            this.Hide();

            kh.Closed += (s, args) => this.Close();
            kh.Show();
        }

        private void pbBan_Click(object sender, EventArgs e)
        {
            FormKhuVucBan kv = new FormKhuVucBan();
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
    }
}
