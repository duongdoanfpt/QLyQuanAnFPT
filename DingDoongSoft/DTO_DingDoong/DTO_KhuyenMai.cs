using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DTO_DingDoong
{
    public class DTO_KhuyenMai
    {
       
        private string _TenKM;
        private float _ChietKhau;
        private string _NgayBD;
        private string _NgayKT;

     
        public string TenKM
        {
            get
            {
                return _TenKM;
            }
            set
            {
                _TenKM = value;
            }
        }
        public float ChietKhau
        {
            get
            {
                return _ChietKhau;
            }
            set
            {
                _ChietKhau = value;
            }
        }
        public string NgayBD
        {
            get
            {
                return _NgayBD;
            }
            set
            {
                _NgayBD = value;
            }
        }
        public string NgayKT
        {
            get
            {
                return _NgayKT;
            }
            set
            {
                _NgayKT = value;
            }
        }

        public DTO_KhuyenMai( string TenKM, float ChietKhau, string NgayBD, string NgayKT)
        {
           
            this._TenKM = TenKM;
            this._ChietKhau = ChietKhau;
            this._NgayBD = NgayBD;
            this._NgayKT = NgayKT;
        }

        public DTO_KhuyenMai()
        {

        }

    }
}