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
    public class DAL_Khach:Dbconnect
    {
        public DataTable getKhach()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[DanhSachKhach]";
                cmd.Connection = _conn;
                DataTable dtKhach = new DataTable();
                dtKhach.Load(cmd.ExecuteReader());
                return dtKhach;
            }
            finally
            {
                _conn.Close();
            }
        }
        public bool insertKhach(DTO_Khach khach)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[InsertDataIntoTblKhach]";
                cmd.Parameters.AddWithValue("_TenKH", khach.TenKH);
                cmd.Parameters.AddWithValue("_SDT", khach.SDT);
                cmd.Parameters.AddWithValue("_NgaySinh", khach.NgaySinh);
                cmd.Parameters.AddWithValue("_Email", khach.Email);
                cmd.Parameters.AddWithValue("_GioiTinh", khach.GioiTinh);

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
