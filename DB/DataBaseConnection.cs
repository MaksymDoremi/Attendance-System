using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS_Final.DB
{
    public class DataBaseConnection
    {
        public SqlConnection connection;

        public DataBaseConnection()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
        }
    }
}
