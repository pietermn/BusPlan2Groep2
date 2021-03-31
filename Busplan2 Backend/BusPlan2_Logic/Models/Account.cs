using System;
using System.Collections.Generic;
using BusPlan2_Logic.Enums;
using BusPlan2_DAL.DTOs;
using BusPlan2_DAL.Handlers;


namespace BusPlan2_Logic.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public int LoginCode { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public TeamsEnum Team { get; set; }

        private readonly AccountHandler handler = new AccountHandler();

        public Account()
        {

        }

        public Account(int accountID, int loginCode, string name, TeamsEnum team)
        {
            AccountID = accountID;
            LoginCode = loginCode;
            Name = name;
            Team = team;
        }

        public Account(int accountID, int loginCode, string name, string password, TeamsEnum team)
        {
            AccountID = accountID;
            LoginCode = loginCode;
            Name = name;
            Password = password;
            Team = team;
        }

        public bool Update(Account account)
        {
            AccountDTO accountDTO = new AccountDTO(account.AccountID, account.LoginCode, account.Name, account.Password, (int)account.Team);
            return handler.Update(accountDTO);
        }
    }
}
