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
        public DataTable doanhThuTheoTime(Nullable<DateTime> ngayBatDau, Nullable<DateTime> ngayKetThuc)
        {
            return dalThongke.ThongKeTheoThoiGian(ngayBatDau, ngayKetThuc);
        }

        public DataTable doanhThuTrongThang()
        {
            return dalThongke.ThongKeTheoThang();
        }

        public DataTable doanhThuTheoNam()
        {
            return dalThongke.thongKeTheoNam();
        }
        public DataTable thongKeKhachHang(Nullable<DateTime> ngayBatDau, Nullable<DateTime> ngayKetThuc)
        {
            return dalThongke.ThongKeKhachHang(ngayBatDau, ngayKetThuc);
        }


        public DataTable thongKeHoaDon(Nullable<DateTime> ngayBatDau, Nullable<DateTime> ngayKetThuc)
        {
            return dalThongke.ThongKeHoaDon(ngayBatDau, ngayKetThuc);
        }
        public DTO_HoaDon curHD(string MaHD)
        {

            return (from DataRow dr in thongKeHoaDon(null, null).Rows
                    where string.Compare(dr[0].ToString(), MaHD, true) == 0
                    select new DTO_HoaDon
                    {
                        MaHD = dr[0].ToString(),
                        MaNV = dr[1].ToString(),
                        IdBan = (int)dr[3],
                        KhuyenMai = float.Parse(dr[5].ToString()),
                        SDT_KH = dr[2].ToString(),
                        NgayHD = (DateTime)dr[4],
                        ThanhTien = float.Parse(dr[6].ToString())


                    }).FirstOrDefault();

        }

        public DataTable ThongkeHoaDonChitiet(string MaHD)
        {
            return dalThongke.ThongkeHoaDonChitiet(MaHD);
        }

        public DataTable sinhNhatKhachHang()
        {
            return dalThongke.SinhNhatKhachHang();
        }

        public DataTable doanhThuThang_Main()
        {
            return dalThongke.ThongKeTheoThang_Main();
        }

        public DataTable doanhThuNam_Main()
        {
            return dalThongke.ThongKeTheoNam_Main();
        }
    }
}
