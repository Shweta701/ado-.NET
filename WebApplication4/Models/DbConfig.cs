using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebApplication4.Models
{
    public class DbConfig
    {
  
        public SqlConnection Sql { get; }

        public DbConfig()
        {
            string cnn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
             Sql = new SqlConnection(cnn);
        }
    }
}