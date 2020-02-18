using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;

namespace DBUtility
{
    public class DapperHelper
    {
        public DapperHelper()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public DapperHelper(string connStr)
        {
            connectionString = connStr;
        }
        private string connectionString;

        public List<T> Query<T>(string sql, object param = null)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<T>(sql, param).ToList();
            }
        }

        public int Execute(string sql, object param = null)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Execute(sql, param);
            }
        }

        public T Execute<T>(string sql, object param = null)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.ExecuteScalar<T>(sql, param);
            }
        }
    }
}
