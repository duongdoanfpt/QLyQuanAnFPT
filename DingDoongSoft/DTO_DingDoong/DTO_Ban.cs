using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_DingDoong
{
    public class DTO_Ban
    {
        private string tenban;
        private int trangthai;

        public string TenBan
        {
            get
            {
                return tenban;
            }
            set
            {
                tenban = value;
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

        public DTO_Ban(int TrangThai)
        {
            
            this.trangthai = TrangThai;
        }

        public DTO_Ban(string tenBan,int TrangThai)
        {
            this.tenban = tenBan;
            this.trangthai = TrangThai;
        }
        public DTO_Ban()
        {

        }
    }
}
