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
                cmd.CommandText = "Sp_DanhSachKhach";
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
                cmd.CommandText = "Sp_InsertKhach";
                cmd.Parameters.AddWithValue("@tenKhach", khach.TenKH);
                cmd.Parameters.AddWithValue("@dienthoai", khach.SDT);
                cmd.Parameters.AddWithValue("@ngsinh", khach.NgaySinh);
                cmd.Parameters.AddWithValue("@email", khach.Email);
                cmd.Parameters.AddWithValue("@gt", khach.GioiTinh);

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
        public bool UpdateKhach(DTO_Khach khach)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_UpdateKhach";
                cmd.Parameters.AddWithValue("@dienThoai", khach.SDT);
                cmd.Parameters.AddWithValue("@tenKhach", khach.TenKH);
                cmd.Parameters.AddWithValue("@email", khach.Email);
                cmd.Parameters.AddWithValue("@gt", khach.GioiTinh);
                cmd.Parameters.AddWithValue("@ngsinh", khach.NgaySinh);

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
        public DataTable SearchKhach(string sdt)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_SearchKhach";
                cmd.Parameters.AddWithValue("@dienthoai", sdt);
                cmd.Connection = _conn;
                DataTable dtkhach = new DataTable();
                dtkhach.Load(cmd.ExecuteReader());
                return dtkhach;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
