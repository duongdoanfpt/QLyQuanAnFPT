using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_DingDoong;

namespace BUS_DingDoong
{
    public class BUS_Ban
    {
        DAL_Ban dalBan = new DAL_Ban();
        public DataTable dtBan()
        {
            return dalBan.DanhSachBan();
        }
    }
}
