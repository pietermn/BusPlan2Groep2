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
    [Route("parkingspace")]
    public class ParkingSpaceController : ControllerBase
    {
        private readonly ParkingSpace parkingspace = new ParkingSpace();
        private readonly ParkingSpaceContainer parkingspaceContainer = new ParkingSpaceContainer();

        [Route("read"), HttpGet]
        public IActionResult Read(ParkingSpace pspace)
        {
            ParkingSpace newPspace = parkingspaceContainer.Read(pspace.ParkingSpaceID);
            if (newPspace != null)
            {
                return Ok(newPspace);
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
            List<ParkingSpace> newPspace = parkingspaceContainer.ReadAll();
            if (newPspace != null)
            {
                return Ok(newPspace);
            }
            else
            {
                //Error in code
                return StatusCode(501);
            }
        }

        [Route("readcleaning"), HttpGet]
        public IActionResult ReadCleaning()
        {
            List<ParkingSpace> newpSpace = parkingspaceContainer.ReadCleaning();
            if (newpSpace != null) {
                return Ok(newpSpace);
            }
            return StatusCode(403);
        }

        [Route("readmaintenance"), HttpGet]
        public IActionResult ReadMaintenace()
        {
            List<ParkingSpace> newpSpace = parkingspaceContainer.ReadMaintenance();
            if (newpSpace != null)
            {
                return Ok(newpSpace);
            }
            return StatusCode(403);
        }

        [Route("readavailable"), HttpGet]
        public IActionResult ReadAvailable()
        {
            List<ParkingSpace> newpSpace = parkingspaceContainer.ReadAvailable();
            if (newpSpace != null)
            {
                return Ok(newpSpace);
            }
            return StatusCode(403);
        }


        [Route("create"), HttpPost]
        public IActionResult Create(ParkingSpace pspace)
        {
            if (parkingspaceContainer.Create(pspace))
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
        public IActionResult Delete(ParkingSpace pspace)
        {
            if (parkingspaceContainer.Delete(pspace.ParkingSpaceID))
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
        public IActionResult Update(ParkingSpace pspace)
        {
            if (parkingspace.Update(pspace))
            {
                return Ok();
            }
            else
            {
                //Error in code
                return StatusCode(501);
            }
        }

        [Route("updateoccupied"), HttpPost]
        public IActionResult UpdateOccupied(ParkingSpace pspace)
        {
            if (parkingspace.UpdateOccupied(pspace))
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
