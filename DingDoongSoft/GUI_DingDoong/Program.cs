using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_DingDoong
{
    static class Program
    {
        static bool checkconnect(string connect)
        {

            using (SqlConnection conn = new SqlConnection(connect))
            {
                try
                {

                    conn.Open();
                    conn.Close();
                    return true;
                }
                catch (SqlException )
                {
                    
                    return false;
                }
                finally
                {

                }
            }


        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (checkconnect(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                //Application.Run(new FormMain());
                //Application.Run(new FormLogin());
                Application.Run(new FormLogin());
            }
            else
            {
                MessageBox.Show("Không có kết nối với cơ sở dữ liệu vui lòng chọn lại server");
                Application.Run(new FrmReconnectDataBase());
            }
        }
    }
}
