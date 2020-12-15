using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_DingDoong
{
    public partial class FrmReconnectDataBase : Form
    {
        public FrmReconnectDataBase()
        {
            InitializeComponent();
        }


        private void saveConnectString(string key, string value)
        {
            Configuration config;
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
            config.ConnectionStrings.ConnectionStrings[key].ProviderName = "System.Data.SqlClient";
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }
        static string serverstring;
        public bool checkconnect(string connect)
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
        private void cmbAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAuthentication.SelectedIndex == 1)
            {
                txtUserNam.Enabled = true;
                txtPassword.Enabled = true;

            }
            else
            {
                txtUserNam.Enabled = false;
                txtPassword.Enabled = false;
            }
        }

        private void bttest_Click(object sender, EventArgs e)
        {
            if (cmbAuthentication.SelectedIndex == 0)
            {
                serverstring = "Data Source = " + txtServer.Text + "; Integrated Security = True;Connect Timeout=10;";
                
            }
            else
            {
                serverstring = "Data Source=" + txtServer.Text + ";User ID=" + txtUserNam.Text + ";Password=" + txtPassword.Text + ";Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
               
            }
            if(checkconnect(serverstring))
            {
                MessageBox.Show("Connect successful");
                btok.Enabled = true;
            }  
            else
            {
                MessageBox.Show("Connect Fail");
                btok.Enabled = false;
            }    
        }

        private void btok_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder connect = new SqlConnectionStringBuilder();
            connect.DataSource = txtServer.Text;
            connect.AttachDBFilename = @"|DataDirectory|\QLyQuanAn.mdf";
            if (cmbAuthentication.SelectedIndex == 0)
            {
                
                connect.IntegratedSecurity = true;
                connect.ConnectTimeout = 10;
            }
            else
            {
                connect.UserID = txtUserNam.Text;
                connect.Password = txtPassword.Text;
                connect.TrustServerCertificate = false;
                connect.ConnectTimeout = 30;
                connect.Encrypt = false;
                connect.ApplicationIntent = ApplicationIntent.ReadWrite;
                connect.MultiSubnetFailover = false;
            }

            try
            {

                

                saveConnectString("ConnectionString", connect.ToString());


                Thread th;
                this.Close();
                th = new Thread(opennewapp);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();


            }





            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void opennewapp()
        {
            FormLogin lg = new FormLogin();
            Application.Run(lg);
        }

        private void FrmReconnectDataBase_Load(object sender, EventArgs e)
        {
            cmbAuthentication.SelectedIndex = 0;
        }
    }
}
