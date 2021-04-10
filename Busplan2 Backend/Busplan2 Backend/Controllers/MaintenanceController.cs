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
    [Route("maintenance")]
    public class MaintenanceController : ControllerBase
    {
        private readonly Maintenance Maintenance = new();
        private readonly MaintenanceContainer maintenanceContainer = new();

        [Route("read"), HttpGet]
        public IActionResult Read(Maintenance maintain)
        {
            Maintenance newMaintain = maintenanceContainer.Read(maintain.MaintenanceID);
            if (newMaintain != null)
            {
                return Ok(newMaintain);
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
            List<Maintenance> maintainList = maintenanceContainer.ReadAll();
            if (maintainList != null)
            {
                return Ok(maintainList);
            }
            else
            {
                //Error in code
                return StatusCode(501);
            }
        }

        [Route("create"), HttpPost]
        public IActionResult Create(Maintenance maintain)
        {
            if (maintenanceContainer.Create(maintain))
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
        public IActionResult Delete(Maintenance maintain)
        {
            if (maintenanceContainer.Delete(maintain.MaintenanceID))
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
        public IActionResult Update(Maintenance maintain)
        {
            if (Maintenance.Update(maintain))
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
