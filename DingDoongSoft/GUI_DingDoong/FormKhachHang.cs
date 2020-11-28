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
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadGridview_Khach();
            ResetValues();
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
            rdNam.Enabled = false;
            rdNu.Enabled = false;
            btLuu.Enabled = false;
            btThem.Enabled = true;
            btCapNhat.Enabled = false;
            btXoa.Enabled = false;
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
            rdNam.Enabled = true;
            rdNu.Enabled = true;
            btLuu.Enabled = true;
            btThem.Enabled = true;
            btCapNhat.Enabled = true;
            btXoa.Enabled = true;
        }
    }
}
