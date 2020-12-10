using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_DingDoong
{
    public class DAL_ThongKe:Dbconnect
    {
        public DataTable ThongKeSLTD(Nullable<DateTime> NgayBatDau,Nullable<DateTime>  NgayKT)
        {
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "ThongKeSLTD";
                if(string.IsNullOrWhiteSpace(NgayBatDau.ToString())&&string.IsNullOrWhiteSpace(NgayKT.ToString()))
                {
                    cm.Parameters.AddWithValue("NgayBatDau", DBNull.Value);
                    cm.Parameters.AddWithValue("NgayKT", DBNull.Value);

                }
                else
                {
                    cm.Parameters.AddWithValue("NgayBatDau", NgayBatDau);
                    cm.Parameters.AddWithValue("NgayKT", NgayKT);
                }
                cm.Connection = _conn;
                DataTable dtTk = new DataTable();
                dtTk.Load(cm.ExecuteReader());
                return dtTk;


            }
            finally
            {
                _conn.Close();
            }
        }

        public DataTable ThongKeTheoThoiGian(Nullable<DateTime> NgayBatDau,Nullable<DateTime>  NgayKT)
        {
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "TongDoanhThuTime";
                if(string.IsNullOrWhiteSpace(NgayBatDau.ToString())&&string.IsNullOrWhiteSpace(NgayKT.ToString()))
                {
                    cm.Parameters.AddWithValue("Strart", DBNull.Value);
                    cm.Parameters.AddWithValue("End", DBNull.Value);

                }
                else
                {
                    cm.Parameters.AddWithValue("Strart", NgayBatDau);
                    cm.Parameters.AddWithValue("End", NgayKT);
                }
                cm.Connection = _conn;
                DataTable dtDoanhThuTheoTime = new DataTable();
                dtDoanhThuTheoTime.Load(cm.ExecuteReader());
                return dtDoanhThuTheoTime;


            }
            finally
            {
                _conn.Close();
            }
        }

        public DataTable ThongKeTheoThang()
        {
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.Connection = _conn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "TongDoanhThuTrongThang";
                DataTable dtTrongThang = new DataTable();
                dtTrongThang.Load(cm.ExecuteReader());
                return dtTrongThang;
            }
            finally
            {
                _conn.Close();
            }
        }

        public DataTable thongKeTheoNam()
        {
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.Connection = _conn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "TongDoanhThuNam";
                DataTable dtTrongNam = new DataTable();
                dtTrongNam.Load(cm.ExecuteReader());
                return dtTrongNam;
            }
            finally
            {
                _conn.Close();
            }
        }

        public DataTable ThongKeKhachHang(Nullable<DateTime> NgayBatDau, Nullable<DateTime> NgayKT)
        {
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "ChiTieuKh";
                if (string.IsNullOrWhiteSpace(NgayBatDau.ToString()) && string.IsNullOrWhiteSpace(NgayKT.ToString()))
                {
                    cm.Parameters.AddWithValue("ngaybd", DBNull.Value);
                    cm.Parameters.AddWithValue("ngaykt", DBNull.Value);

                }
                else
                {
                    cm.Parameters.AddWithValue("ngaybd", NgayBatDau);
                    cm.Parameters.AddWithValue("ngaykt", NgayKT);
                }
                cm.Connection = _conn;
                DataTable khData = new DataTable();
                khData.Load(cm.ExecuteReader());
                return khData;


            }
            finally
            {
                _conn.Close();
            }
        }


        //Thong ke Hoa Don
        public DataTable ThongKeHoaDon(Nullable<DateTime> NgayBatDau, Nullable<DateTime> NgayKT)
        {
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_ThongkeHD";
                if (string.IsNullOrWhiteSpace(NgayBatDau.ToString()) && string.IsNullOrWhiteSpace(NgayKT.ToString()))
                {
                    cm.Parameters.AddWithValue("ngayBD", DBNull.Value);
                    cm.Parameters.AddWithValue("ngayKT", DBNull.Value);

                }
                else
                {
                    cm.Parameters.AddWithValue("ngayBD", NgayBatDau);
                    cm.Parameters.AddWithValue("ngayKT", NgayKT);
                }
                cm.Connection = _conn;
                DataTable hdData = new DataTable();
                hdData.Load(cm.ExecuteReader());
                return hdData;


            }
            finally
            {
                _conn.Close();
            }
        }
        public DataTable ThongkeHoaDonChitiet(string MaHD)
        {
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "GetListTD";
                cm.Parameters.AddWithValue("MaHD", MaHD);
                cm.Connection = _conn;
                DataTable dtHDCT = new DataTable();
                dtHDCT.Load(cm.ExecuteReader());
                return dtHDCT;
            }
            finally
            {

                _conn.Close();
            }
        }

    }
}
