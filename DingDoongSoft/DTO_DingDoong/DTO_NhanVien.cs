using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_DingDoong
{
   
    public class DTO_NhanVien
    {
        private string _MaNV;
        private string _TenNV;
        private string _Email;
        private string _DiaChi;
        private DateTime _NgayVL;
        private int _Quyen;
        private int _TrangThai;
        private Byte[] _Hinh;
        private string _MatKhau;

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

        public string TenNV
        {
            get
            {
                return _TenNV;
            }
            set
            {
                _TenNV = value;
            }
        }
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }
        public string DiaChi
        {
            get
            {
                return _DiaChi;
            }
            set
            {
                _DiaChi = value;
            }
        }
        public DateTime NgayVL
        {
            get
            {
                return _NgayVL;
            }
            set
            {
               _NgayVL = value;
            }
        }
        public int Quyen
        {
            get
            {
                return _Quyen;
            }
            set
            {
                _Quyen = value;
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
        public byte[] Hinh
        {
            get
            {
                return _Hinh;
            }
            set
            {
                _Hinh = value;
            }
        }
        public string MatKhau
        {
            get
            {
                return _MatKhau;
            }
            set
            {
                _MatKhau = value;
            }
        }

        public DTO_NhanVien(string TenNV, string Email, string Diachi, DateTime NgayVL, int Quyen, int TinhTrang, byte[] Hinh, string MatKhau)
        {
            
            this._TenNV = TenNV;
            this._Email = Email;
            this._DiaChi = Diachi;
            this._NgayVL = NgayVL;
            this._Quyen = Quyen;
            this._TrangThai = TinhTrang;
            this._Hinh = Hinh;
            this._MatKhau = MatKhau;
        }

        public DTO_NhanVien(string TenNV, string Email, string DiaChi, DateTime NgayVL, int Quyen, byte[] Hinh)
        {
            this._TenNV = TenNV;
            this._Email = Email;
            this._DiaChi = DiaChi;
            this._NgayVL = NgayVL;
            this._Quyen = Quyen;
            this._Hinh = Hinh;
        }
        public DTO_NhanVien()
        {

        }
    }
}
