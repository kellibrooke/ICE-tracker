using System;
using MySql.Data.MySqlClient;
using IceTracker;

namespace IceTracker.Models
{
    public class DB
    {
        public static MySqlConnection Connection()
        {
            MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
            return conn;
        }
    }
}
