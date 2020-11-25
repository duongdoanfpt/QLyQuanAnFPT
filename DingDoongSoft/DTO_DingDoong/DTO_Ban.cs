using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_DingDoong
{
    public class DTO_Ban
    {
        private int _IdBan;
        private string _TenBan;
        private int _TrangThai;
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

        public string TenBan
        {
            get
            {
                return _TenBan;
            }
            set
            {
                _TenBan = value;
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

        public DTO_Ban(int TrangThai)
        {
            
            this._TrangThai = TrangThai;
        }

        public DTO_Ban(string tenBan,int TrangThai)
        {
            this._TenBan = tenBan;
            this._TrangThai = TrangThai;
        }

        public DTO_Ban(int IdBan, string TenBan,int TrangThai)
        {
            this._IdBan = IdBan;
            this._TenBan = TenBan;
            this._TrangThai = TrangThai;

        }
        public DTO_Ban()
        {

        }
    }
}
