using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace DTO_DingDoong
    {
        public class DTO_ThucDon
        {
           
            private string _TenTD;
            private float _GiaBan;
            private string _MoTa;
            private string _Nhom;
            private byte[] _Hinh;


            
            public string TenTD
            {
                get
                {
                    return _TenTD;
                }
                set
                {
                    _TenTD = value;
                }
            }
            public float GiaBan
            {
                get
                {
                    return _GiaBan;
                }
                set
                {
                    _GiaBan = value;
                }
            }
            public string MoTa
            {
                get
                {
                    return _MoTa;
                }
                set
                {
                    _MoTa = value;
                }
            }
            public string Nhom
            {
                get
                {
                    return _Nhom;
                }
                set
                {
                    _Nhom = value;
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

            public DTO_ThucDon(string TenTD, float GiaBan, string MoTa, string Nhom, byte[] HInh)
            {
               
                this._TenTD = TenTD;
                this._GiaBan = GiaBan;
                this._MoTa = MoTa;
                this._Nhom = Nhom;
                this._Hinh = Hinh;
            }

            public DTO_ThucDon()
            {

            }

        }
    }

