using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_DingDoong
{
    public class DTO_CTHD
    {
        private string _MaHD;
        private string _MaTD;
        private int _SoLuong;
        private string _GhiChu;
        private float _Gia;



        

        public string MaHD
        {
            get
            {
                return _MaHD;
            }
            set
            {
                _MaHD = value;
            }
        }
        public string MaTD
        {
            get
            {
                return _MaTD;
            }
            set
            {
                _MaTD = value;
            }
        }
        public int SoLuong
        {
            get
            {
                return _SoLuong;
            }
            set
            {
                _SoLuong = value;
            }
        }
        public string GhiChu
        {
            get
            {
                return _GhiChu;
            }
            set
            {
                _GhiChu = value;
            }
        }

        public float Gia
        {
            get
            {
                return _Gia;
            }
            set
            {
                _Gia = value;
            }
        }

        public float ThanhTien ()
        {
            return (_Gia * _SoLuong);
        }

        public DTO_CTHD(string MaHD, string MaTD, int SoLuong, string GhiChu)
        {
            this._MaHD = MaHD;
            this._MaTD = MaTD;
            this._SoLuong = SoLuong;
            this._GhiChu = GhiChu;
        }

        public DTO_CTHD()
        {

        }
    }
}
