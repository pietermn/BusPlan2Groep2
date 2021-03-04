using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Busplan2_Backend.Controllers
{
    [ApiController]
    [Route("cleaning")]
    public class CleaningController : ControllerBase
    {
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
    }
}
