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

namespace GUI_DingDoong
{
    public partial class FormKhuVucBan : Form
    {
        BUS_Ban busBan = new BUS_Ban();
        public FormKhuVucBan()
        {
            InitializeComponent();
        }

        private void FormKhuVucBan_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string startupPath = Environment.CurrentDirectory;

            DataTable dtBan = busBan.dtBan();
            for(int i = 0; i < dtBan.Rows.Count;i++)
            {
                
                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.Width = 70;
                flp.Height = 120;
                PictureBox ptb = new PictureBox();
                ptb.Width = 60;
                ptb.Height = 70;
                flp.Margin = new Padding(15, 15, 15, 15);
                if (int.Parse(dtBan.Rows[i][1].ToString())==1)
                {
                    ptb.Image = Image.FromFile(startupPath+@"\image\banMo.ico");
                   

                } 
                else if(int.Parse(dtBan.Rows[i][1].ToString()) == 0)
                {
                    ptb.Image = Image.FromFile(startupPath+@"\image\banDong.png");

                }
                ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                Label lbBan = new Label();
                lbBan.Text = dtBan.Rows[i][0].ToString();
                lbBan.Font = new Font("Segoe UI", 10);
                lbBan.ForeColor = Color.Black;
                Label lbTrangThai = new Label();
                lbTrangThai.Text = dtBan.Rows[i][1].ToString();
                lbTrangThai.Visible = false;
                //lbBan.TextAlign = ContentAlignment.MiddleCenter;
                lbBan.Margin = new Padding(10, 10, 0, 0);
                flp.Controls.Add(ptb);
                flp.Controls.Add(lbBan);
                flp.Controls.Add(lbTrangThai);
                flpkvBan.Controls.Add(flp);

                
                ptb.Click += Ptb_Click;
               
                
            }    

        }

        private void Ptb_Click(object sender, EventArgs e)
        {
            PictureBox ptb = sender as PictureBox;
           
            PictureBox image = (PictureBox)ptb.Parent.Controls[0];
            Label lbBan = (Label)ptb.Parent.Controls[1];
            lbViTriBan.Text = lbBan.Text;
            Label lbTrangThai = (Label)ptb.Parent.Controls[2];
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
