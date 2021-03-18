using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using BusPlan2_Logic.Models;
using Microsoft.VisualStudio.Services.DelegatedAuthorization;
using Microsoft.AspNetCore.Authorization;

namespace Busplan2_Backend.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        public class LoginModel
        {
            public int LoginCode { get; set; }
            public string Password { get; set; }
        }

        [Route("read"), HttpGet]
        public async Task<IActionResult> Read()
        {
            return StatusCode(203); //Not implemented code
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

        [Route("login"), HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            return Ok("token"); //Not implemented code
        }
    }
}
