using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_DingDoong
{
    public class DTO_NhanVien
    {
        private string manv;
        private string tennv;
        private string email;
        private string diachi;
        private string ngayvl;
        private int vaitro;
        private int trangthai;
        private string hinh;
        private string matkhau;

        public string MaNV
        {
            get
            {
                return manv;
            }
            set
            {
                manv = value;
            }
        }
        public string TenNV
        {
            get
            {
                return tennv;
            }
            set
            {
                tennv = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string DiaChi
        {
            get
            {
                return diachi;
            }
            set
            {
                diachi = value;
            }
        }
        public string NgayVL
        {
            get
            {
                return ngayvl;
            }
            set
            {
                ngayvl = value;
            }
        }
        public int VaiTro
        {
            get
            {
                return vaitro;
            }
            set
            {
                vaitro = value;
            }
        }
        public int TrangThai
        {
            get
            {
                return trangthai;
            }
            set
            {
                trangthai = value;
            }
        }
        public string Hinh
        {
            get
            {
                return hinh;
            }
            set
            {
                hinh = value;
            }
        }
        public string MatKhau
        {
            get
            {
                return matkhau;
            }
            set
            {
                matkhau = value;
            }
        }

        public DTO_NhanVien(string MaNV, string TenNV, string Email, string Diachi, string NgayVL, int VaiTro, int TinhTrang, string Hinh, string MatKhau)
        {
            this.manv = MaNV;
            this.tennv = TenNV;
            this.email = Email;
            this.diachi = Diachi;
            this.ngayvl = NgayVL;
            this.vaitro = VaiTro;
            this.trangthai = TinhTrang;
            this.hinh = Hinh;
            this.matkhau = MatKhau;
        }

        public DTO_NhanVien()
        {

        }
    }
}
