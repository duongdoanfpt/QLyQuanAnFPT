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
        private string _SDT;
        private DateTime _NgaySinh;
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
        public string SDT
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
        public DateTime NgaySinh
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

        public DTO_Khach(string TenKH, string SDT, DateTime NgaySinh, string Email, int GioiTinh)
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
