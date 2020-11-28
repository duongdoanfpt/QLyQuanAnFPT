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

        public DTO_Ban curBan(string ViTriBan)
        {
            DTO_Ban curBan = (from DataRow dr in dtBan().Rows
                              where string.Compare(dr[1].ToString(), ViTriBan, true) == 0
                              select new DTO_Ban
                              {
                                  IdBan = int.Parse(dr[0].ToString()),
                                  TenBan = dr[1].ToString(),
                                  TrangThai = int.Parse(dr[2].ToString()),
                                  
                                  

                              }).FirstOrDefault();
            return curBan;
        }

        public DTO_HoaDon curhd(DTO_Ban ban)
        {
            DTO_HoaDon hd = (from DataRow dr in dtHoaDonTam(ban).Rows
                             where int.Parse(dr[1].ToString()) == ban.IdBan
                             select new DTO_HoaDon
                             {
                                 MaHD = dr[0].ToString(),
                                 IdBan = (int)dr[1],
                                 TrangThai = (int)dr[2],
                                 KhuyenMai = float.Parse(dr[4].ToString())

                             }).FirstOrDefault();
            return hd;
        }

        public bool UpdateTrangThaiBan(DTO_Ban ban, int TrangThai)
        {
            return dalBan.UpdateTrangThaiBan(ban.IdBan, TrangThai);
        }

        public bool ThemHoaDonTam(DTO_HoaDon hd)
        {
            return dalBan.ThemHoaDonTam(hd);
        }

        public DataTable dtHoaDonTam(DTO_Ban ban)
        {
            return dalBan.HoaDonTam(ban.IdBan);
        }

        public bool ThemCTHDTam (DTO_CTHD cthd)
        {
            return dalBan.ThemChiTietHoaDonTam(cthd);
        }
        public DataTable dtHDCTTam(string MaHD)
        {
            return dalBan.DanhSachHDCTTam(MaHD);
        }

        public float TongTienHDTamKM(DTO_HoaDon hd)
        {
            return dalBan.TongTienHDTam(hd.MaHD);
        }
    }
}
