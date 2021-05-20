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
    [Route("adhoc")]
    public class AdHocController : ControllerBase
    {
        private readonly AdHoc adHoc = new();
        private readonly AdHocContainer adHocContainer = new();

        [Route("read"), HttpGet]
        public IActionResult Read(AdHoc adhoc)
        {
            AdHoc newAdHoc = adHocContainer.Read(adhoc.AdHocID);
            if (newAdHoc != null)
            {
                return Ok(newAdHoc);
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
            List<AdHoc> adhocList = adHocContainer.ReadAll();
            if (adhocList != null)
            {
                return Ok(adhocList);
            }
            else
            {
                //Error in code
                return StatusCode(501);
            }
        }

        [Route("ReadallCleaning"), HttpGet]
        public IActionResult ReadAllCleaning()
        {
            List<AdHoc> adhocList = adHocContainer.ReadAllCleaning();
            if (adhocList != null)
            {
                return Ok(adhocList);
            }
            else
            {
                //Error in code
                return StatusCode(501);
            }
        }

        [Route("ReadallMaintenance"), HttpGet]
        public IActionResult ReadAllMaintenance()
        {
            List<AdHoc> adhocList = adHocContainer.ReadAllMaintenance();
            if (adhocList != null)
            {
                return Ok(adhocList);
            }
            else
            {
                //Error in code
                return StatusCode(501);
            }
        }

        [Route("ReadallPlanning"), HttpGet]
        public IActionResult ReadallPlanning()
        {
            List<AdHoc> adhocList = adHocContainer.ReadAllPlanning();
            if (adhocList != null)
            {
                return Ok(adhocList);
            }
            else
            {
                //Error in code
                return StatusCode(501);
            }
        }

        [Route("create"), HttpPost]
        public IActionResult Create(AdHoc adhoc)
        {
            if (adHocContainer.Create(adhoc))
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
        public IActionResult Delete(AdHoc adhoc)
        {
            if (adHocContainer.Delete(adhoc.AdHocID))
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
        public IActionResult Update(AdHoc adhoc)
        {
            if (adHoc.Update(adhoc))
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
