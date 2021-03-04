using BusPlan2_Logic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusPlan2_Logic.Models
{
    public class Account
    {
        private int AccountID;
        private int LoginCode;
        private string Password;
        private string Name;
        private TeamsEnum Team;

        public Account(int accountID, int loginCode, string password, string name, TeamsEnum team)
        {
            AccountID = accountID;
            LoginCode = loginCode;
            Password = password;
            Name = name;
            Team = team;
        }

        public void Update()
        {

        }
    }
}
