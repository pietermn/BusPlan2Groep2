using System;
using System.Collections.Generic;
using BusPlan2_DAL.Handlers;
using BusPlan2_DAL.DTOs;
using BusPlan2_Logic.Models;
using BusPlan2_Logic.Enums;


namespace BusPlan2_Logic.Containers
{
    public class AccountContainer
    {

        private readonly AccountHandler handler = new AccountHandler();

        public bool Create(Account account)
        {
            AccountDTO accountDTO = new AccountDTO(account.AccountID, account.LoginCode, account.Name, account.Password, (int)account.Team);
            return handler.Create(accountDTO);
        }

        public Account Read(int accountID)
        {
            AccountDTO accountDTO = handler.Read(accountID);
            if (accountDTO.AccountID == 0) { return null; }
            Account account = new Account(accountDTO.AccountID, accountDTO.LoginCode, accountDTO.Name, (TeamsEnum)accountDTO.Team);
            return account;
        }

        public List<Account> ReadAll()
        {
            List<AccountDTO> accountsDTOList = handler.ReadAll();
            List<Account> accountsList = new List<Account>();
            foreach (AccountDTO accountDTO in accountsDTOList)
            {
                accountsList.Add(new Account(accountDTO.AccountID, accountDTO.LoginCode, accountDTO.Name, (TeamsEnum)accountDTO.Team));
            }
            return accountsList;
        }

        public bool Delete(int accountID)
        {
            return handler.Delete(accountID);
        }

        public string Login(int loginCode, string password)
        {
            string token = handler.Login(loginCode, password);
            return token;
        }
    }
}