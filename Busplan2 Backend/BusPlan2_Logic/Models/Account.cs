using BusPlan2_Logic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusPlan2_Logic.Models
{
    public class Account
    {
        public int AccountID { get; private set; }
        public int LoginCode { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public TeamsEnum Team { get; private set; }

        public Account() { }

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
