using DTO_DingDoong;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_DingDoong
{
    public class DAL_KhuyenMai : Dbconnect
    {
        public DataTable GetDanhSachKM()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_DanhSachKMALL";
                cmd.Connection = _conn;
                DataTable dtKM = new DataTable();
                dtKM.Load(cmd.ExecuteReader());
                return dtKM;
            }

            finally
            {
                _conn.Close();
            }
        }

        public DataTable GetDanhSachKMinTime(DateTime Time)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DanhSachKMTime";
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("curdate", Time.Date);
                DataTable dtKM = new DataTable();
                dtKM.Load(cmd.ExecuteReader());
                return dtKM;
            }

            finally
            {
                _conn.Close();
            }
        }

        public bool insertKM(DTO_KhuyenMai km)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_InsertKM";
                cmd.Parameters.AddWithValue("@MaKM", km.MaKM);
                cmd.Parameters.AddWithValue("@tenKM", km.TenKM);
                cmd.Parameters.AddWithValue("@chietkhau", km.ChietKhau);
                cmd.Parameters.AddWithValue("@startDate", km.NgayBD);
                cmd.Parameters.AddWithValue("@endDate", km.NgayKT);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

    }
}
