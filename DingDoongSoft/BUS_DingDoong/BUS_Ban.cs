using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_DingDoong;
using DTO_DingDoong;

namespace BUS_DingDoong
{
    public class BUS_Ban
    {
        DAL_Ban dalBan = new DAL_Ban();
        public DataTable dtBan()
        {
            return dalBan.DanhSachBan();
        }

        public List<DTO_Ban> DanhSachBan(DataTable dsBan)
        {
            List<DTO_Ban> listBan = new List<DTO_Ban>();
            listBan = (from DataRow dr in dsBan.Rows
                       select new DTO_Ban(int.Parse(dr["ID"].ToString()), dr["TenBan"].ToString(), int.Parse(dr["TrangThai"].ToString()))).ToList();

            return listBan;
        }

        public DTO_Ban curBan (string ViTriBan)
        {
            DTO_Ban curBan = (from DataRow dr in dtBan().Rows
                                 where string.Compare(dr[1].ToString(), ViTriBan, true) == 0
                                 select new DTO_Ban
                                 {
                                     IdBan = int.Parse(dr[0].ToString()),
                                     TenBan = dr[1].ToString(),
                                     TrangThai = int.Parse(dr[2].ToString())

                                 }).FirstOrDefault();
            return curBan;
        }
    }
}
