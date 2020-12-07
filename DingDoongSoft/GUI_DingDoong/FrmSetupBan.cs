using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_DingDoong;
using BUS_DingDoong;

namespace GUI_DingDoong
{
    public partial class FrmSetupBan : Form
    {
        BUS_Ban busBan = new BUS_Ban();
        
        public FrmSetupBan()
        {
            InitializeComponent();
        }

        private void FrmSetupBan_Load(object sender, EventArgs e)
        {
            txtSoLuong.Text = busBan.dtBan().Rows.Count.ToString();

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thiết lập lại số lượng bàn sẽ xoá toàn bộ dữ liệu đang hoạt động và những hoá đơn chưa thanh toán! Bạn có muốn tiếp tục?", "Confirm",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(busBan.setUpBan(int.Parse(txtSoLuong.Text)))
                {
                    this.Close();
                } 
                else
                {
                    MessageBox.Show("Đã có lỗi xẩy ra vui lòng kiểm tra lại");
                }    
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
