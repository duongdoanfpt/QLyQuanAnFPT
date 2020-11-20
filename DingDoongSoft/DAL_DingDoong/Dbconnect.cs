using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_DingDoong
{
    public class Dbconnect
    {
        protected SqlConnection _conn = new SqlConnection("Data Source=DESKTOP-6D7E27J;Initial Catalog=QLyQuanAn;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    }
}
