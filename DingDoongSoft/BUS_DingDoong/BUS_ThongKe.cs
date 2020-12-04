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
    public class BUS_ThongKe
    {
        DAL_ThongKe dalThongke = new DAL_ThongKe();
        public DataTable dtSLTD(Nullable<DateTime> NgayBD, Nullable<DateTime> NgayKT)
        {
            return dalThongke.ThongKeSLTD(NgayBD, NgayKT);
        }
    }
}
