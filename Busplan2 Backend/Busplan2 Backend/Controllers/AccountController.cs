using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using BusPlan2_Logic.Models;
using BusPlan2_Logic.Containers;

namespace Busplan2_Backend.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly Account Account = new Account();
        private readonly AccountContainer accountContainer = new AccountContainer();

        [Route("read"), HttpGet]
        public IActionResult Read(Account account)
        {
            Account newAccount = accountContainer.Read(account.AccountID);
            if (account != null)
            {
                return Ok(newAccount);
            }
            else
            {
                //Error in code
                return StatusCode(501);
            }
        }

        [Route("readall"), HttpGet]
        public IActionResult ReadAll()
        {
            List<Account> accountList = accountContainer.ReadAll();
            if (accountList != null)
            {
                return Ok(accountList);
            }
            else
            {
                //Error in code
                return StatusCode(501);
            }
        }

        [Route("create"), HttpPost]
        public IActionResult Create(Account account)
        {
            if (accountContainer.Create(account))
            {
                return Ok();
            }
            else
            {
                //Error in code
                return StatusCode(501);
            }
        }

        [Route("delete"), HttpPost]
        public IActionResult Delete(Account account)
        {
            if (accountContainer.Delete(account.AccountID))
            {
                return Ok();
            }
            else
            {
                //Error in code
                return StatusCode(501);
            }
        }

        [Route("update"), HttpPost]
        public IActionResult Update(Account account)
        {
            if (Account.Update(account))
            {
                return Ok();
            }
            else
            {
                //Error in code
                return StatusCode(501);
            }
        }

        [Route("login"), HttpPost]
        public IActionResult Login(Account account)
        {
            string token = accountContainer.Login(account.LoginCode, account.Password);
            if (token != null)
            {
                return Ok(token);
            }
            else
            {
                return StatusCode(501);
            }
        }

    }
}
