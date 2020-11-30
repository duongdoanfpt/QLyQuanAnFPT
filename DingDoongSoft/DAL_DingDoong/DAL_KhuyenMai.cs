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

    }
}
