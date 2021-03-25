using System;
using System.Collections.Generic;
using System.Text;

namespace BusPlan2_DAL.DTOs
{
    public class AccountDTO
    {
        public int AccountID { get; set; }
        public int LoginCode { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Team { get; set; }


        public AccountDTO()
        {

        }

        public AccountDTO(int accountID, int loginCode, string name, int team)
        {
            AccountID = accountID;
            LoginCode = loginCode;
            Name = name;
            Team = team;
        }

        public AccountDTO(int accountID, int loginCode, string name, string password, int team)
        {
            AccountID = accountID;
            LoginCode = loginCode;
            Name = name;
            Password = password;
            Team = team;
        }
    }
}
