using BusPlan2_DAL.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusPlan2_Logic.Containers
{
    public class AccountContainer
    {

        private readonly AccountHandler accountHandler = new AccountHandler();
        public void Create()
        {

        }

        public void Read()
        {

        }

        public void Delete()
        {

        }

        public string Login(int loginCode, string password)
        {
            string token = accountHandler.Login(loginCode, password);
            return token;
        }
    }
}