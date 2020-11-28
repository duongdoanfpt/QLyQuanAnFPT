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
    }
}
