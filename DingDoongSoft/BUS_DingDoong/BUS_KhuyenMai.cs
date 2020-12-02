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
    public class BUS_KhuyenMai
    {
        DAL_KhuyenMai dalKM = new DAL_KhuyenMai();

        public DataTable GetDanhSachKM()
        {
            return dalKM.GetDanhSachKM();
        }

        public DataTable GetDanhSachKMinTime(DateTime date)
        {
            return dalKM.GetDanhSachKMinTime(date);
        }

        public DTO_KhuyenMai curKM(string TenKM)
        {
            DTO_KhuyenMai km = (from DataRow dr in dalKM.GetDanhSachKM().Rows
                                where string.Compare(dr[1].ToString(), TenKM, true) == 0
                                select new DTO_KhuyenMai
                                {
                                    MaKM = dr[0].ToString(),
                                    TenKM = dr[1].ToString(),
                                    NgayBD = (DateTime)dr[2],
                                    NgayKT = (DateTime)dr[3],
                                    ChietKhau = float.Parse(dr[4].ToString())
                                }).FirstOrDefault();
            return km;
        }

        public bool insertKM(DTO_KhuyenMai km)
        {
            return dalKM.insertKM(km);
        }
        public bool DeleteKM(string makm)
        {
            return dalKM.DeleteKM(makm);
        }
        public bool UpdateKM(DTO_KhuyenMai km)
        {
            return dalKM.UpdateKM(km);
        }
        public DataTable SearchKM(string tenkm)
        {
            return dalKM.SearchKM(tenkm);
        }
    }
}
