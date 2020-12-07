using DAL_DingDoong;
using DTO_DingDoong;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_DingDoong
{
    public class BUS_Khach
    {
        DAL_Khach dalKhach = new DAL_Khach();

        public DataTable getKhach()
        {
            return dalKhach.getKhach();
        }
        public bool insertKhach(DTO_Khach khach)
        {
            return dalKhach.insertKhach(khach);
        }

        public DTO_Khach curKhach(string SDT_KH)
        {
            DTO_Khach khach = (from DataRow dr in dalKhach.getKhach().Rows
                               where string.Compare(dr[0].ToString(), SDT_KH, true) == 0
                               select new DTO_Khach
                               {
                                   SDT = dr[0].ToString(),
                                   TenKH = dr[1].ToString(),
                                   Email = dr[2].ToString(),
                                   GioiTinh = string.Compare(dr[3].ToString(), "Nam", true) == 0 ? 1 : 0,
                                   NgaySinh = (DateTime)dr[4]
                               }).FirstOrDefault();
            return khach;
        }

        public bool UpdateKhach(DTO_Khach khach)
        {
            return dalKhach.UpdateKhach(khach);
        }
        public DataTable SearchKhach(string sdt)
        {
            return dalKhach.SearchKhach(sdt);
        }
    }
}
