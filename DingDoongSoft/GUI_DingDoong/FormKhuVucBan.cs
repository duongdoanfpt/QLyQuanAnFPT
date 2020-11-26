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

        private List<DTO_Ban> DanhSachBan(DataTable dsBan)
        {
            List<DTO_Ban> listBan = new List<DTO_Ban>();
            listBan = (from DataRow dr in dsBan.Rows
                       select new DTO_Ban(int.Parse(dr["ID"].ToString()), dr["TenBan"].ToString(), int.Parse(dr["TrangThai"].ToString()))).ToList();

            return listBan;
        }

        private DTO_NhanVien curNV(string Email)
        {
            DTO_NhanVien NV = new DTO_NhanVien();
            NV = (from DataRow dr in busNV.getDanhSachNV().Rows
                  where dr[1].ToString() == Email
                  select new DTO_NhanVien
                  {
                      MaNV = dr[0].ToString(),
                      TenNV = dr[2].ToString(),
                      Email = dr[1].ToString()


                  }).FirstOrDefault();
            return NV;

        }

        private void loadThucDonkvBan()
        {
            dgvThucDon.DataSource = busTD.DanhSachThucDonBan();

        }

        private void loadban()
        {
            string startupPath = Environment.CurrentDirectory;

            List<DTO_Ban> dsBan = DanhSachBan(busBan.dtBan());
            foreach(DTO_Ban ban in dsBan)
            {

                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.Width = 70;
                flp.Height = 120;
                PictureBox ptb = new PictureBox();
                ptb.Width = 60;
                ptb.Height = 70;
                flp.Margin = new Padding(15, 15, 15, 15);
                if (ban.TrangThai == 1)
                {
                    ptb.Image = Image.FromFile(startupPath + @"\image\banMo.ico");


                }
                else if (ban.TrangThai == 0)
                {
                    ptb.Image = Image.FromFile(startupPath + @"\image\banDong.png");

                }
                ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                Label lbBan = new Label();
                lbBan.Text = ban.TenBan;
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
            DTO_NhanVien NV = curNV(lbEmailNV.Text);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThucDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThucDon.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            loadban();
            loadThucDonkvBan();
            lbTenNV.Text = NV.TenNV;

           

        }

        private void Ptb_Click(object sender, EventArgs e)
        {
            List<DTO_Ban> dsBan = DanhSachBan(busBan.dtBan());
            PictureBox ptb = sender as PictureBox;
           
            PictureBox image = (PictureBox)ptb.Parent.Controls[0];
            Label lbBan = (Label)ptb.Parent.Controls[1];
            lbViTriBan.Text = lbBan.Text;
            int vitriBan = dsBan.FindIndex(a => a.TenBan == lbBan.Text);

            DTO_Ban ban = dsBan[vitriBan];
            lbBan.BackColor = Color.Transparent;
            var Index = ptb.Parent.Parent.Controls.IndexOf(ptb.Parent);
            for(int i = 0; i < ptb.Parent.Parent.Controls.Count; i++)
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
           


        }

        private void dgvThucDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
