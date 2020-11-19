using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_DingDoong
{
    public class DTO_Khach
    {
        private string _TenKH;
        private int _SDT;
        private string _NgaySinh;
        private string _Email;
        private int _GioiTinh;

        public string TenKH
        {
            get
            {
                return _TenKH;
            }
            set
            {
                _TenKH = value;
            }
        }
        public int SDT
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
        public string NgaySinh
        {
            get
            {
                return _NgaySinh;
            }
            set
            {
                _NgaySinh = value;
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
        public int GioiTinh
        {
            get
            {
                return _GioiTinh;
            }
            set
            {
                _GioiTinh = value;
            }
        }

        public DTO_Khach(string TenKH, int SDT, string NgaySinh, string Email, int GioiTinh)
        {
            this._TenKH = TenKH;
            this._SDT = SDT;
            this._NgaySinh = NgaySinh;
            this._Email = Email;
            this._GioiTinh = GioiTinh;
        }
        public DTO_Khach()
        {

        }

    }
}
