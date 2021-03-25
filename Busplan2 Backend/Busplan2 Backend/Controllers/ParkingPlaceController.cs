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
    [Route("parkingplace")]
    public class ParkingPlaceController : ControllerBase
    {
        private readonly ParkingSpace parkingspaceModel = new ParkingSpace();
        private readonly ParkingSpaceContainer parkingspaceContainer = new ParkingSpaceContainer();

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
        public IActionResult Update(ParkingSpace parkingSpace)
        {
            return Ok(parkingspaceModel.Update(parkingSpace)); //Not implemented code
        }
    }
}
