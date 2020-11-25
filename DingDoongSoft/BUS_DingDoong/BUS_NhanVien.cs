using DAL_DingDoong;
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
    }
}
