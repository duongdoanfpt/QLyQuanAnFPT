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

        private List<DTO_Ban> DanhSachBan(DataTable dsBan)
        {
            List<DTO_Ban> listBan = new List<DTO_Ban>();
            foreach (DataRow dr in dsBan.Rows) 
            {
                DTO_Ban ban = new DTO_Ban(int.Parse(dr["ID"].ToString()),dr["TenBan"].ToString(),int.Parse(dr["TrangThai"].ToString()));
                listBan.Add(ban);
                
            }
            return listBan;
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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThucDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThucDon.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            loadban();
            loadThucDonkvBan();

           

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
            MessageBox.Show(ban.TrangThai.ToString());
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

        
    }
}
