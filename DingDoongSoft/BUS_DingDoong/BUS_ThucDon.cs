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
    public class BUS_ThucDon
    {
        DAL_ThucDon dalThucDon = new DAL_ThucDon();

        public bool insertThucDon(DTO_ThucDon td)
        {
            return dalThucDon.ThemThucDon(td);
        }

        public DataTable DanhSachThucDonBan()
        {
            return dalThucDon.DanhSachThucDonBan();
        }
    }
}
