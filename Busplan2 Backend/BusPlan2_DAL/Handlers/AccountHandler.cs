using Backend_DAL;
using BusPlan2_DAL.DTOs;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusPlan2_DAL.Handlers
{
    public class AccountHandler
    {


        public bool Create(AccountDTO accountDTO)
        {
            using var connection = Connection.GetConnection();
            {
                if (!IsLoginCodeunique(accountDTO.LoginCode)) { return false; }
                try
                {
                    using var command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO Account(LoginCode, Password, Name, Team) VALUES(@loginCode, @password, @name, @team);";
                    command.Parameters.AddWithValue("@loginCode", accountDTO.LoginCode);
                    command.Parameters.AddWithValue("@password", accountDTO.Password);
                    command.Parameters.AddWithValue("@name", accountDTO.Name);
                    command.Parameters.AddWithValue("@team", accountDTO.Team);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch { connection.Close(); return false; }
            }
        }


        public AccountDTO Read(int accountID)
        {
            AccountDTO Account = new AccountDTO();
            using var connection = Connection.GetConnection();
            {
                using var command = connection.CreateCommand();

                command.CommandText = "SELECT AccountID, LoginCode, Name, Team FROM Account WHERE  AccountID = @accountID";
                command.Parameters.AddWithValue("@accountID", accountID);

                connection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Account = new AccountDTO(
                            reader.GetInt32("AccountID"),
                            reader.GetInt32("LoginCode"),
                            reader.GetString("Name"),
                            reader.GetInt32("Team")
                            );
                    }
                }

                connection.Close();
                return Account;
            }
        }


        public List<AccountDTO> ReadAll()
        {
            List<AccountDTO> AccountList = new List<AccountDTO>();

            using var connection = Connection.GetConnection();
            {
                using var command = connection.CreateCommand();

                command.CommandText = "SELECT AccountID, LoginCode, Name, Team FROM Account";

                connection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AccountList.Add(new AccountDTO(
                            reader.GetInt32("AccountID"),
                            reader.GetInt32("LoginCode"),
                            reader.GetString("Name"),
                            reader.GetInt32("Team")
                            ));
                    }
                }

                connection.Close();
                return AccountList;
            }
        }


        public bool Update(AccountDTO accountDTO)
        {
            using var connection = Connection.GetConnection();
            {
                try
                {
                    using var command = connection.CreateCommand();

                    command.CommandText = "UPDATE Account Set LoginCode = @loginCode, Password = @password, Name = @name, Team = @team WHERE AccountID = @accountID;";
                    command.Parameters.AddWithValue("@accountID", accountDTO.AccountID);
                    command.Parameters.AddWithValue("@loginCode", accountDTO.LoginCode);
                    command.Parameters.AddWithValue("@name", accountDTO.Name);
                    command.Parameters.AddWithValue("@password", accountDTO.Password);
                    command.Parameters.AddWithValue("@team", accountDTO.Team);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    return true;
                }
                catch { connection.Close(); return false; }
            }
        }


        public bool Delete(int accountID)
        {
            using var connection = Connection.GetConnection();
            {
                try
                {
                    using var command = connection.CreateCommand();

                    command.CommandText = "DELETE FROM Account WHERE AccountID = @accountID;";
                    command.Parameters.AddWithValue("@accountID", accountID);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    return true;
                }
                catch { connection.Close(); return false; }
            }
        }


        public string Login(int loginCode, string password)
        {
            string AccountID;
            int LoginCode;
            using var connection = Connection.GetConnection();
            try
            {
                using (connection)
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("SELECT AccountID, LoginCode FROM Account WHERE LoginCode = @LoginCode AND Password = @Password", connection);
                    command.Parameters.AddWithValue("@LoginCode", loginCode);
                    command.Parameters.AddWithValue("@Password", password);
                    DataSet ds = new DataSet();
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    da.Fill(ds);
                    connection.Close();

                    if (ds.Tables[0].Rows.Count < 1) return null;
                    DataRow row = ds.Tables[0].Rows[0];
                    AccountID = Convert.ToString(row["AccountID"]);
                    LoginCode = Convert.ToInt32(row["LoginCode"]);
                }
            }
            catch (MySqlException)
            {
                connection.Close();
                throw new Exception("An unexpected error occured.");
            }

            AppSettings _appSettings = new AppSettings() { Key = "kprlcvattbtitafgjawqyjjwjsxhzqvxsrzfnlpvxpdcdzwfsh" }; // A random string to encrypt the token

            // Generate JWT with these credentials
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Name, AccountID),
                        new Claim(ClaimTypes.Email,Convert.ToString(LoginCode)),
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var result = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(result);

            // Return the found account in the form of a jwt token
            return token;
        }


        private bool IsLoginCodeunique(int loginCode)
        {
            using var connection = Connection.GetConnection();
            {
                using var command = connection.CreateCommand();

                command.CommandText = "SELECT LoginCode FROM Account WHERE LoginCode=@loginCode";
                command.Parameters.AddWithValue("@loginCode", loginCode);

                connection.Open();

                var reader = command.ExecuteReader();
                if (reader.HasRows) { return false; }
                return true;
            }
        }


    }
}