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
   public class BUS_NhanVien
    {
        DAL_NhanVien dALNhanVien = new DAL_NhanVien();
        public DataTable getDanhSachNV()
        {
            return dALNhanVien.getDanhSachNV();
        }

        public DTO_NhanVien curNV(string Email)
        {
            DTO_NhanVien NV = new DTO_NhanVien();
            NV = (from DataRow dr in getDanhSachNV().Rows
                  where string.Compare(dr[1].ToString(), Email, true) == 0
                  select new DTO_NhanVien
                  {
                      MaNV = dr[0].ToString(),
                      TenNV = dr[2].ToString(),
                      Email = dr[1].ToString()


                  }).FirstOrDefault();
            return NV;

        }

    }
}
