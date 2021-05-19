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
        public IActionResult Read(int busID)
        {

            return Ok(busContainer.Read(busID));
        }

        [Route("readall"), HttpGet]
        public IActionResult ReadAll()
        {
            return Ok(busContainer.ReadAll());
        }

        [Route("readcleaning"), HttpGet]
        public IActionResult ReadCleaning()
        {
            return Ok(busContainer.ReadCleaning());
        }

        [Route("readmaintenance"), HttpGet]
        public IActionResult ReadMaintenance()
        {
            return Ok(busContainer.ReadMaintenance());
        }

        [Route("create"), HttpPost]
        public IActionResult Create(Bus bus)
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
        public IActionResult Delete(int busID)
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
        public IActionResult Update(Bus bus)
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

        [Route("giveparkingspace"), HttpPost]
        public IActionResult GiveParkingSpace(int id)
        {
            ParkingSpace parkingSpace = busContainer.GiveParkingSpace(id);
            if (parkingSpace != null)
            {
                return Ok(parkingSpace);
            }
            else 
            {
                //Error in code
                return StatusCode(501);
            }

        }

    }
}
