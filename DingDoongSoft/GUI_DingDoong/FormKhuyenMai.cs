using BUS_DingDoong;
using DTO_DingDoong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            txtMaKM.Enabled = false;
            txtTenKM.Enabled = false;
            txtChietKhau.Enabled = false;
            dtpNgBD.Enabled = false;
            dtpNgKT.Enabled = false;
            btLuu.Enabled = false;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            txtMaKM.Text = null;
            txtTenKM.Text = null;
            txtChietKhau.Text = null;
            txtMaKM.Enabled = true;
            txtTenKM.Enabled = true;
            txtChietKhau.Enabled = true;
            dtpNgBD.Enabled = true;
            dtpNgKT.Enabled = true;
            btLuu.Enabled = true;
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            float chietkhau;
            bool isInt = float.TryParse(txtChietKhau.Text.Trim().ToString(), out chietkhau);

            if (txtMaKM.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKM.Focus();
                return;
            }
            else if (txtTenKM.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKM.Focus();
                return;
            }
            if (!isInt || float.Parse(txtChietKhau.Text) < 0)
            {
                MessageBox.Show("Bạn phải nhập chiết khấu > 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChietKhau.Focus();
                return;
            }

            if (dtpNgBD.Value > dtpNgKT.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpNgBD.Focus();
                return;
            }

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

        private void btXoa_Click(object sender, EventArgs e)
        {
            string makm = txtMaKM.Text;
            if (MessageBox.Show("Bạn có chắc muốn xóa dữ liệu", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busKM.DeleteKM(makm))
                {
                    MessageBox.Show("Xóa dữ liệu thành công");
                    ResetValues();
                    LoadGridview_KM();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
            else
            {
                ResetValues();
            }
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            float chietkhau;
            bool isInt = float.TryParse(txtChietKhau.Text.Trim().ToString(), out chietkhau);

            if (txtMaKM.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKM.Focus();
                return;
            }
            else if (txtTenKM.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKM.Focus();
                return;
            }
            if (!isInt || float.Parse(txtChietKhau.Text) < 0)
            {
                MessageBox.Show("Bạn phải nhập chiết khấu > 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChietKhau.Focus();
                return;
            }

            if (dtpNgBD.Value > dtpNgKT.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpNgBD.Focus();
                return;
            }

            DTO_KhuyenMai km = new DTO_KhuyenMai(txtMaKM.Text, txtTenKM.Text, float.Parse(txtChietKhau.Text), dtpNgBD.Value, dtpNgKT.Value);
            if (busKM.UpdateKM(km))
            {
                MessageBox.Show("Cập nhật thành công");
                LoadGridview_KM();
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công");

            }
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string tenkm = txtTimKiem.Text;
            DataTable dtKM = busKM.SearchKM(tenkm);
            if (dtKM.Rows.Count > 0)
            {
                dataGridView1.DataSource = dtKM;
                dataGridView1.Columns[0].HeaderText = "Mã khuyến mãi";
                dataGridView1.Columns[1].HeaderText = "Tên khuyến mãi";
                dataGridView1.Columns[2].HeaderText = "Ngày bắt đầu";
                dataGridView1.Columns[3].HeaderText = "Ngày kết thúc";
                dataGridView1.Columns[4].HeaderText = "Chiết khấu";
            }
            else
            {
                MessageBox.Show("Không tìm thấy chương trình khuyến mãi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ResetValues();
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = null;
            txtTimKiem.BackColor = Color.White;
        }

        private void btBoQua_Click(object sender, EventArgs e)
        {
            txtMaKM.Text = null;
            txtTenKM.Text = null;
            txtChietKhau.Text = null;

            LoadGridview_KM();
        }

        private void cbhienThi_CheckedChanged(object sender, EventArgs e)
        {
            LoadGridview_KM();
        }

        private void txtChietKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
