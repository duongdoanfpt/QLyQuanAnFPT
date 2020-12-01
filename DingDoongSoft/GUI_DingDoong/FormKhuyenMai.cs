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
    public partial class FormKhuyenMai : Form
    {
        BUS_KhuyenMai busKM = new BUS_KhuyenMai();

        public FormKhuyenMai()
        {
            InitializeComponent();
        }

        private void FormKhuyenMai_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadGridview_KM();
            ResetValues();
        }

        private void LoadGridview_KM()
        {
            dataGridView1.DataSource = busKM.GetDanhSachKM();
            dataGridView1.Columns[0].HeaderText = "Mã khuyến mãi";
            dataGridView1.Columns[1].HeaderText = "Tên khuyến mãi";
            dataGridView1.Columns[2].HeaderText = "Ngày bắt đầu";
            dataGridView1.Columns[3].HeaderText = "Ngày kết thúc";
            dataGridView1.Columns[4].HeaderText = "Chiết khấu";
        }

        public void ResetValues()
        {
            txtMaKM.Text = null;
            txtTenKM.Text = null;
            txtChietKhau.Text = null;
            
            btLuu.Enabled = false;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            txtMaKM.Text = null;
            txtTenKM.Text = null;
            txtChietKhau.Text = null;

            btLuu.Enabled = true;
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            

            DTO_KhuyenMai km = new DTO_KhuyenMai(txtMaKM.Text ,txtTenKM.Text, float.Parse(txtChietKhau.Text), dtpNgBD.Value, dtpNgKT.Value);
            if (busKM.insertKM(km))
            {
                MessageBox.Show("Thêm thành công");
                LoadGridview_KM();
            }
            else
            {
                MessageBox.Show("Thêm không thành công");

            }
        }

        private void dgvkm_Click(object sender, EventArgs e)
        {
            DTO_KhuyenMai km = busKM.curKM(dataGridView1.CurrentRow.Cells["TenKM"].Value.ToString());

            txtMaKM.Text = km.MaKM;
            txtTenKM.Text = km.TenKM;
            txtChietKhau.Text = km.ChietKhau.ToString();

            dtpNgBD.Text = km.NgayBD.ToString();
            dtpNgKT.Text = km.NgayKT.ToString();
        }
    }
}
