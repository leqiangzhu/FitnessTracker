using System;
using MySql.Data.MySqlClient;
using FitnessTracker;
 
namespace FitnessTracker.Models
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
