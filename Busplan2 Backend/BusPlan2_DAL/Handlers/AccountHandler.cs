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
    }
}