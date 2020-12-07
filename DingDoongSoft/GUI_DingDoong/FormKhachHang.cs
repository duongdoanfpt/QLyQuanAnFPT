﻿using BUS_DingDoong;
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

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
        private void bt3d()
        {
            foreach (var bt in GetAll(this, typeof(Button)))
            {
                (bt as Button).Paint += Bt_Paint;
                (bt as Button).FlatStyle = FlatStyle.Standard;
            }
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

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            bt3d();
            pbKhachHang.Enabled = false;
            pbKhachHang.BorderStyle = BorderStyle.Fixed3D;
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

            txtTen.Enabled = true;
            txtSDT.Enabled = true;
            txtEmail.Enabled = true;
            dtpNgaySinh.Enabled = true;
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

  

        private void pbThucDon_Click(object sender, EventArgs e)
        {
            FormThucDon td = new FormThucDon();
            this.Hide();

            td.Closed += (s, args) => this.Close();
            td.Show();
        }

        private void pbHome_MouseEnter(object sender, EventArgs e)
        {
            pbHome.BorderStyle = BorderStyle.Fixed3D;
            pbHome.Cursor = Cursors.Hand;
        }

        private void pbHome_MouseLeave(object sender, EventArgs e)
        {
            pbHome.BorderStyle = BorderStyle.None;
            pbHome.Cursor = Cursors.Default;


        }

        private void pbNhanVien_MouseEnter(object sender, EventArgs e)
        {
            pbNhanVien.BorderStyle = BorderStyle.Fixed3D;
            pbNhanVien.Cursor = Cursors.Hand;
        }

        private void pbNhanVien_MouseLeave(object sender, EventArgs e)
        {
            pbNhanVien.BorderStyle = BorderStyle.None;
            pbNhanVien.Cursor = Cursors.Default;
        }

        private void pbKhachHang_MouseEnter(object sender, EventArgs e)
        {
            pbKhachHang.BorderStyle = BorderStyle.Fixed3D;
            pbKhachHang.Cursor = Cursors.Hand;
        }

        private void pbKhachHang_MouseLeave(object sender, EventArgs e)
        {
            pbKhachHang.BorderStyle = BorderStyle.None;
            pbKhachHang.Cursor = Cursors.Default;
        }

        private void pbBan_MouseEnter(object sender, EventArgs e)
        {
            pbBan.BorderStyle = BorderStyle.Fixed3D;
            pbBan.Cursor = Cursors.Hand;
        }

        private void pbBan_MouseLeave(object sender, EventArgs e)
        {
            pbBan.BorderStyle = BorderStyle.None;
            pbBan.Cursor = Cursors.Default;
        }

        private void pbThongKe_MouseEnter(object sender, EventArgs e)
        {
            pbThongKe.BorderStyle = BorderStyle.Fixed3D;
            pbThongKe.Cursor = Cursors.Hand;
        }

        private void pbThongKe_MouseLeave(object sender, EventArgs e)
        {
            pbThongKe.BorderStyle = BorderStyle.None;
            pbThongKe.Cursor = Cursors.Default;
        }

        private void pbThucDon_MouseEnter(object sender, EventArgs e)
        {
            pbThucDon.BorderStyle = BorderStyle.Fixed3D;
            pbThucDon.Cursor = Cursors.Hand;
        }

        private void pbThucDon_MouseLeave(object sender, EventArgs e)
        {
            pbThucDon.BorderStyle = BorderStyle.None;
            pbThucDon.Cursor = Cursors.Default;
        }
    }
    
}
