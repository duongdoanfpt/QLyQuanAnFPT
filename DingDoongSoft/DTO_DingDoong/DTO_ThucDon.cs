using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace DTO_DingDoong
    {
        public class DTO_ThucDon
        {
           
            private string tentd;
            private float giaban;
            private string mota;
            private string nhom;
            private string hinh;


            
            public string TenTD
            {
                get
                {
                    return tentd;
                }
                set
                {
                    tentd = value;
                }
            }
            public float GiaBan
            {
                get
                {
                    return giaban;
                }
                set
                {
                    giaban = value;
                }
            }
            public string MoTa
            {
                get
                {
                    return mota;
                }
                set
                {
                    mota = value;
                }
            }
            public string Nhom
            {
                get
                {
                    return nhom;
                }
                set
                {
                    nhom = value;
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

            public DTO_ThucDon(string TenTD, float GiaBan, string MoTa, string Nhom, string HInh)
            {
               
                this.tentd = TenTD;
                this.giaban = GiaBan;
                this.mota = MoTa;
                this.nhom = Nhom;
                this.hinh = Hinh;
            }

            public DTO_ThucDon()
            {

            }

        }
    }

