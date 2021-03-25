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
    [Route("bus")]
    public class BusController : ControllerBase
    {
        private readonly Bus busModel = new Bus();
        private readonly BusContainer busContainer = new BusContainer();

        [Route("read"), HttpGet]
        public async Task<IActionResult> Read(int busID)
        {

            return Ok(busContainer.Read(busID)); //Not implemented code
        }

        [Route("readall"), HttpGet]
        public async Task<IActionResult> ReadAll()
        {
            return Ok(busContainer.ReadAll()); //Not implemented code
        }

        [Route("create"), HttpPost]
        public async Task<IActionResult> Create(Bus bus)
        {
            if (busContainer.Create(bus))
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
        public async Task<IActionResult> Delete(int busID)
        {
            if (busContainer.Delete(busID))
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
        public async Task<IActionResult> Update(Bus bus)
        {
            if (busModel.Update(bus))
            {
                return Ok();
            }
            else
            {
                //Error in code
                return StatusCode(501);
            }
        }
    }
}
