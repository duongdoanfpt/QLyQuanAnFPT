using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_DingDoong;

namespace DAL_DingDoong
{
    public class DAL_NhanVien:Dbconnect
    {
        public DataTable getDanhSachNV() //GET ALL NHANVIEN
        {
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.Connection = _conn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "Sp_DanhSachNV";
                DataTable dtNhanVien = new DataTable();
                dtNhanVien.Load(cm.ExecuteReader());
                return dtNhanVien;
            }
            finally
            {
                _conn.Close();
            }
        }

        // DANGNHAP
        public bool NhanVienDangNhap(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DangNhap";
                cmd.Parameters.AddWithValue("email", nv.Email);
                cmd.Parameters.AddWithValue("matKhau", nv.MatKhau);

                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                    return true;
            }
            catch (Exception)
            {


            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
    }
}
