using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO_DingDoong;
namespace DAL_DingDoong
{
    public class DAL_ThucDon : Dbconnect
    {
        public bool ThemThucDon(DTO_ThucDon td)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_InsertTD";
                cmd.Parameters.AddWithValue("TenTD", td.TenTD);
                cmd.Parameters.AddWithValue("GiaBan", td.GiaBan);
                cmd.Parameters.AddWithValue("Nhom", td.Nhom);
                cmd.Parameters.AddWithValue("Mota", td.MoTa);
                cmd.Parameters.AddWithValue("HinhTD", td.Hinh);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }                

                
            }
            catch(Exception ex)
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
