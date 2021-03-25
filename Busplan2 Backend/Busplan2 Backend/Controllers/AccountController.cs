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
        private readonly Account account = new Account();
        private readonly AccountContainer accountContainer = new AccountContainer();

        [Route("read"), HttpGet]
        public async Task<IActionResult> Read()
        {
            return StatusCode(512); //Not implemented code
        }

        [Route("create"), HttpPost]
        public async Task<IActionResult> Create()
        {
            return StatusCode(512); //Not implemented code
        }

        [Route("delete"), HttpPost]
        public async Task<IActionResult> Delete()
        {
            return StatusCode(512); //Not implemented code
        }

        [Route("update"), HttpPost]
        public async Task<IActionResult> Update()
        {
            return StatusCode(512); //Not implemented code
        }

        //[Route("login"), HttpPost]
        //public async Task<IActionResult> Login(Account account)
        //{
        //    int loginCode = account.LoginCode;
        //    string password = account.Password;

        //    return Ok(accountContainer.Login(loginCode, password)); //Not implemented code
        //}
    }
}
