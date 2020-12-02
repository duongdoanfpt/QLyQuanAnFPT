using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DTO_DingDoong
{
    public class DTO_KhuyenMai
    {

        private string _MaKM;
        private string _TenKM;
        private float _ChietKhau;
        private DateTime _NgayBD;
        private DateTime _NgayKT;


        public string MaKM
        {
            get
            {
                return _MaKM;
            }
            set
            {
                _MaKM = value;
            }
        }

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
        public DateTime NgayBD
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
        public DateTime NgayKT
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

        public DTO_KhuyenMai(string TenKM, float ChietKhau, DateTime NgayBD, DateTime NgayKT)
        {
            
            this._TenKM = TenKM;
            this._ChietKhau = ChietKhau;
            this._NgayBD = NgayBD;
            this._NgayKT = NgayKT;
        }

        public DTO_KhuyenMai(string MaKM, string TenKM, float ChietKhau, DateTime NgayBD, DateTime NgayKT)
        {
            this.MaKM = MaKM;
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