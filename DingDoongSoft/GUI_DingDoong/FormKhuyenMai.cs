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

        private void FormKhuyenMai_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadGridview_KM();
            ResetValues();
            lblUsers.Text = FormLogin.NvMain.Email;
            bt3d();
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
            btCapNhat.Enabled = false;

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
            btCapNhat.Enabled = false;
        }
        public bool checktkm(string tkm, BUS_KhuyenMai busKM)
        {
            DataTable gettkm = busKM.GetDanhSachKM();
            foreach (DataRow row in gettkm.Rows)
            {
                if (string.Compare(tkm, row[1].ToString(), true) == 0)
                    return true;

            }
            return false;
        }
        public bool checkmkm(string mkm, BUS_KhuyenMai busKM)
        {
            DataTable getmkm = busKM.GetDanhSachKM();
            foreach (DataRow row in getmkm.Rows)
            {
                if (string.Compare(mkm, row[0].ToString(), true) == 0)
                    return true;

            }
            return false;
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
            else if (checkmkm(txtMaKM.Text, busKM))
            {
                MessageBox.Show("Mã khuyến mãi đã tồn tại, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKM.Focus();
                return;
            }

            if (txtTenKM.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKM.Focus();
                return;
            }
            else if (checktkm(txtTenKM.Text, busKM))
            {
                MessageBox.Show("Tên khuyến mãi đã tồn tại, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            txtMaKM.Enabled = true;
            txtTenKM.Enabled = true;
            txtChietKhau.Enabled = true;
            dtpNgBD.Enabled = true;
            dtpNgKT.Enabled = true;
            btCapNhat.Enabled = true;
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

        private void pbHome_Click_1(object sender, EventArgs e)
        {
            FormMain frmMain = new FormMain();
            this.Hide();

            frmMain.Closed += (s, args) => this.Close();
            frmMain.Show();
        }

        private void pbNhanVien_Click_1(object sender, EventArgs e)
        {
            FormNhanVien nv = new FormNhanVien();
            this.Hide();

            nv.Closed += (s, args) => this.Close();
            nv.Show();
        }

        private void pbKhachHang_Click_1(object sender, EventArgs e)
        {
            FormKhachHang kh = new FormKhachHang();
            this.Hide();

            kh.Closed += (s, args) => this.Close();
            kh.Show();
        }

        private void pbBan_Click_1(object sender, EventArgs e)
        {
            FormKhuVucBan kv = new FormKhuVucBan(-1);
            this.Hide();

            kv.Closed += (s, args) => this.Close();
            kv.Show();
        }

        private void pbThongKe_Click_1(object sender, EventArgs e)
        {
            FormThongKe thongKe = new FormThongKe();
            this.Hide();

            thongKe.Closed += (s, args) => this.Close();
            thongKe.Show();
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

        private void Home_Click(object sender, EventArgs e)
        {
            FormMain main = new FormMain();
            this.Hide();

            main.Closed += (s, args) => this.Close();
            main.Show();
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

        private void NhanVien_Click(object sender, EventArgs e)
        {
            FormNhanVien nv = new FormNhanVien();
            this.Hide();

            nv.Closed += (s, args) => this.Close();
            nv.Show();
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

        private void KhachHang_Click(object sender, EventArgs e)
        {
            FormKhachHang kh = new FormKhachHang();
            this.Hide();

            kh.Closed += (s, args) => this.Close();
            kh.Show();
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

        private void ThongKe_Click(object sender, EventArgs e)
        {
            FormThongKe thongKe = new FormThongKe();
            this.Hide();

            thongKe.Closed += (s, args) => this.Close();
            thongKe.Show();
        }

        private void ptbMenuThucDon_Click(object sender, EventArgs e)
        {
            FormThucDon td = new FormThucDon();
            this.Hide();

            td.Closed += (s, args) => this.Close();
            td.Show();
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

        private void btThoat_Click(object sender, EventArgs e)
        {
            FormMain main = new FormMain();
            this.Hide();

            main.Closed += (s, args) => this.Close();
            main.Show();
        }
    }
}
