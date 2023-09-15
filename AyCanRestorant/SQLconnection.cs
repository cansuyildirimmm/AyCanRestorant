using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AyCanRestorant
{
    public class SQLConnection
    {
        public static SqlConnection Run()
        {
            SqlConnection conn = new SqlConnection();
            {
                var dataSource = ConfigurationManager.AppSettings["DataSource"].ToString();
                var initialCatalog = ConfigurationManager.AppSettings["InitialCatalog"].ToString();
                var user = ConfigurationManager.AppSettings["User"].ToString();
                var password = ConfigurationManager.AppSettings["Password"].ToString();

                conn.ConnectionString = string.Format("Data Source = {0};Initial Catalog= {1};persist security info=True;Integrated Security=SSPI;", dataSource, initialCatalog);

                if(conn != null)
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                        conn.Open();

                    SqlConnection.ClearPool(conn);
                    SqlConnection.ClearAllPools();
                }

                return conn;
            }
        }
    }
}
