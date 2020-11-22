using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL_DingDoong
{
    public class DAL_Ban:Dbconnect
    {
        public DataTable DanhSachBan()
        {
            _conn.Open();
            try
            {

                SqlCommand cm = new SqlCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "Sp_DanhSachBan";
                cm.Connection = _conn;
                DataTable dtBan = new DataTable();
                dtBan.Load(cm.ExecuteReader());
                return dtBan;
            }
            finally
            {

                _conn.Close();
            }
        }

    }
}
