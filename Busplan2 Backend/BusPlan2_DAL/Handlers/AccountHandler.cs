using BusPlan2_DAL.DTOs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusPlan2_DAL.Handlers
{
    public class AccountHandler
    {
        public void Create()
        {

        }

        public void Read()
        {

        }

        public void Update()
        {

        }

        public void Delete()
        {

        }

        public AccountDTO Login(int loginCode, string password)
        {
            using var connection = Connection.GetConnection();

            try
            {
                using (connection)
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM Account WHERE LoginCode = @LoginCode AND Password = @Password", connection);
                    command.Parameters.AddWithValue("@LoginCode", loginCode);
                    command.Parameters.AddWithValue("@Password", password);
                    var reader = command.ExecuteReader();

                    if(!reader.Read()) throw new Exception("Incorrect username or password.");
                    var accountobj = new AccountDTO()
                    {
                        AccountID = reader.GetInt32("AccountID"),
                        LoginCode = reader.GetInt32("LoginCode"),
                        Name = reader.GetString("Name"),
                        Team = reader.GetInt32("Team")
                    };
                    return accountobj;
                }
            }
            catch (MySqlException)
            {
                connection.Close();
                throw new Exception("An unexpected error occured.");
            }
        }
    }
}
