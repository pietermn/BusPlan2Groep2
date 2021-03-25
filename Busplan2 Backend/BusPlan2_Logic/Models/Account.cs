using BusPlan2_Logic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusPlan2_Logic.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public int LoginCode { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public TeamsEnum Team { get; set; }


        public Account(int accountID, int loginCode, string password, string name, TeamsEnum team)
        {
            AccountID = accountID;
            LoginCode = loginCode;
            Password = password;
            Name = name;
            Team = team;
        }

        public Account(int accountID, int loginCode, string name, TeamsEnum team)
        {
            AccountID = accountID;
            LoginCode = loginCode;
            Name = name;
            Team = team;
        }

        public Account()
        {

        }

        public void Update()
        {

        }
    }
}
