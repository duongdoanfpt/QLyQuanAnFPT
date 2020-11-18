using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DTO_DingDoong
{
    public class DTO_KhuyenMai
    {
       
        private string tenkm;
        private float chietkhau;
        private string ngaybd;
        private string ngaykt;

     
        public string TenKM
        {
            get
            {
                return tenkm;
            }
            set
            {
                tenkm = value;
            }
        }
        public float ChietKhau
        {
            get
            {
                return chietkhau;
            }
            set
            {
                chietkhau = value;
            }
        }
        public string NgayBD
        {
            get
            {
                return ngaybd;
            }
            set
            {
                ngaybd = value;
            }
        }
        public string NgayKT
        {
            get
            {
                return ngaykt;
            }
            set
            {
                ngaykt = value;
            }
        }

        public DTO_KhuyenMai( string TenKM, float ChietKhau, string NgayBD, string NgayKT)
        {
           
            this.tenkm = TenKM;
            this.chietkhau = ChietKhau;
            this.ngaybd = NgayBD;
            this.ngaykt = NgayKT;
        }

        public DTO_KhuyenMai()
        {

        }

    }
}