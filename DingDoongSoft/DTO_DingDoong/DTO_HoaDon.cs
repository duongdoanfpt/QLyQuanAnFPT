using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_DingDoong
{
    public class DTO_HoaDon
    {
        private string _MaHD;
        private string _MaNV;
        private string _SDT;
        private int _IdBan;
        private int _TrangThai;
        private float _KhuyenMai;
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

        public string MaNV
        {
            get
            {
                return _MaNV;
            }
            set
            {
                _MaNV = value;
            }
        }
        public string SDT_KH
        {
            get
            {
                return _SDT;
            }
            set
            {
                _SDT = value;
            }
        }

        public int IdBan
        {
            get
            {
                return _IdBan;
            }
            set
            {
                _IdBan = value;
            }
        }

        public int TrangThai
        {
            get
            {
                return _TrangThai;
            }
            set
            {
                _TrangThai = value;
            }
        }

        public float KhuyenMai
        {
            get
            {
                return _KhuyenMai;
            }
            set
            {
                _KhuyenMai = value;
            }
        }

        public DTO_HoaDon (string MaHD, string MaNV, int MaBan,float KhuyenMai, string SDT_KH = null)
        {
            this._MaHD = MaHD;
            this._MaNV = MaNV;
            this._SDT = SDT_KH;
            this._IdBan = MaBan;
            this._TrangThai = TrangThai;
            this._KhuyenMai = KhuyenMai;
            
        }

        public DTO_HoaDon(string MaHD, string MaNV, string SDT_KH, int MaBan, int TrangThai)
        {
            this._MaHD = MaHD;
            this._MaNV = MaNV;
            this._SDT = SDT_KH;
            this._IdBan = MaBan;
            this._TrangThai = TrangThai;
            this._KhuyenMai = 0;
        }

        public DTO_HoaDon(string MaHD, int MaBan, int TrangThai)
        {
            this._MaHD = MaHD;
            this._IdBan = MaBan;
            this._TrangThai = TrangThai;

        }
        public DTO_HoaDon()
        { }

    }
}
