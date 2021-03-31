using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Busplan2_Backend.Controllers
{
    [ApiController]
    [Route("adhoc")]
    public class AdHocController : ControllerBase
    {
        [Route("read"), HttpGet]
        public IActionResult Read()
        {
            return StatusCode(512); //Not implemented code
        }

        [Route("create"), HttpPost]
        public IActionResult Create()
        {
            return StatusCode(512); //Not implemented code
        }

        [Route("delete"), HttpPost]
        public IActionResult Delete()
        {
            return StatusCode(512); //Not implemented code
        }

        [Route("update"), HttpPost]
        public IActionResult Update()
        {
            return StatusCode(512); //Not implemented code
        }
    }
}
