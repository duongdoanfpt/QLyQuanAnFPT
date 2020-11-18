using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_DingDoong
{
    public class DTO_Khach
    {
        private string tenkh;
        private int sdt;
        private string ngaysinh;
        private string email;
        private int gioitinh;

        public string TenKH
        {
            get
            {
                return tenkh;
            }
            set
            {
                tenkh = value;
            }
        }
        public int SDT
        {
            get
            {
                return sdt;
            }
            set
            {
                sdt = value;
            }
        }
        public string NgaySinh
        {
            get
            {
                return ngaysinh;
            }
            set
            {
                ngaysinh = value;
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
        public int GioiTinh
        {
            get
            {
                return gioitinh;
            }
            set
            {
                gioitinh = value;
            }
        }

        public DTO_Khach(string TenKH, int SDT, string NgaySinh, string Email, int GioiTinh)
        {
            this.tenkh = TenKH;
            this.sdt = SDT;
            this.ngaysinh = NgaySinh;
            this.email = Email;
            this.gioitinh = GioiTinh;
        }
        public DTO_Khach()
        {

        }

    }
}
