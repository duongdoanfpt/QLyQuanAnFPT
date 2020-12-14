using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_DingDoong
{
    public class Dbconnect
    {
        static string connectstring()
        {
            var connection =
            System.Configuration.ConfigurationManager.
            ConnectionStrings["ConnectionString"].ConnectionString;
            
            return connection;

        }
        
        protected SqlConnection _conn = new SqlConnection(connectstring());

        //protected SqlConnection _conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\QLyQuanAn.mdf;Integrated Security=True");
    }
}
