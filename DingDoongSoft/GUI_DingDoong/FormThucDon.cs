using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_DingDoong;
using BUS_DingDoong;

namespace GUI_DingDoong
{
    public partial class FormThucDon : Form
    {
        public FormThucDon()
        {
            InitializeComponent();
        }
        private string imagePath;
        BUS_ThucDon busThucDon = new BUS_ThucDon();


        private void FormThucDon_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        //Change Value Image
        private void ChangeImage(ref string Path)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "C:\\";
                openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog1.FileName;
                    FileInfo fi = new FileInfo(filePath);
                    Image img = Image.FromFile(filePath);
                    ptbThucDon.BackgroundImage = Image.FromFile(filePath);
                    ptbThucDon.BackgroundImageLayout = ImageLayout.Stretch;
                    Path = filePath;
                }
                else Path = "";


            }
            catch
            {

            }
        }


        private void btOpenDialog_Click(object sender, EventArgs e)
        {
            ChangeImage(ref imagePath);
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
           
                Image img = ptbThucDon.BackgroundImage;
                byte[] arr;
                ImageConverter converter = new ImageConverter();
                arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

                DTO_ThucDon td = new DTO_ThucDon(txtTenMon.Text, float.Parse(txtDonGia.Text), txtMoTa.Text, txtNhom.Text, arr);
                if (busThucDon.insertThucDon(td))
                {
                    MessageBox.Show("Thêm món vào thực đơn thành công");

                }
                else
                {
                    MessageBox.Show("Thêm món vào thực đơn thất bại");

                }
                
                
                
                
            }
        }
    }
