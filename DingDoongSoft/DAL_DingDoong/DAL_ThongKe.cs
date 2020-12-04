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
    }
}
