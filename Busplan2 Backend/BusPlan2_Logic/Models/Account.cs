using System;
using System.Collections.Generic;
using System.Text;

namespace BusPlan2_Logic.Models
{
    public class Account
    {
        public enum Teams
        {

        }

        private int AccountID;
        private int LoginCode;
        private string Password;
        private string Name;
        private Teams Team;

        public Account(int accountID, int loginCode, string password, string name, Teams team)
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
