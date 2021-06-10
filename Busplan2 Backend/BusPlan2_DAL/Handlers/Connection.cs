using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace BusPlan2_DAL.Handlers
{
    public class Connection
    {
        public static MySqlConnection GetConnection()
        {
            MySqlConnection GeneralConnection = new MySqlConnection($"Server={Environment.GetEnvironmentVariable("DBName")};Uid=user;Database=busplanDB;Pwd=root;Port={Environment.GetEnvironmentVariable("Port")};");
            return GeneralConnection;
        }
    }
}