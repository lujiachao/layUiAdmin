using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace layUiAdmin.SQL
{
    public class DataBaseConfig
    {
        private static string DefaultSqlConnectionString = @"server=localhost;database=testmysql;uid=root;pwd=Aa82078542;SslMode=none";
        public static MySqlConnection GetSqlConnection(string sqlConnectionString = null)
        {
            if (string .IsNullOrWhiteSpace(sqlConnectionString))
            {
                sqlConnectionString = DefaultSqlConnectionString; 
            }
            MySqlConnection conn = new MySqlConnection(sqlConnectionString);
            conn.Open();
            return conn;
        }
    }
}
