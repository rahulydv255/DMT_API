using DMT.Domain.Core.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMT.Domain.Core.Helper
{
    public class ConnectionRetreiver: IConnectionRetreiver
    {
        public IDbConnection GetDbConnection() 
        { 
          string DBConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection connection = new SqlConnection(DBConnectionString);
            return connection;
        }
    }
}
