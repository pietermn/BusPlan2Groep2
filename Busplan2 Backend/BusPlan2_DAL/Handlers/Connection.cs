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
            MySqlConnection GeneralConnection = new MySqlConnection("Server=localhost;Uid=user;Database=busplanDB;Pwd=root;Port=3307;");
            return GeneralConnection;
        }
    }
}
