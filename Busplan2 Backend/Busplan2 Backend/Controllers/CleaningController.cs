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
    [Route("cleaning")]
    public class CleaningController : ControllerBase
    {
        private readonly Cleaning Cleaning = new();
        private readonly CleaningContainer cleanerContainer = new();

        [Route("read"), HttpGet]
        public IActionResult Read(Cleaning clean)
        {
            Cleaning newClean = cleanerContainer.Read(clean.CleaningID);
            if (newClean != null)
            {
                return Ok(newClean);
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
            List<Cleaning> cleaningList = cleanerContainer.ReadAll();
            if (cleaningList != null)
            {
                return Ok(cleaningList);
            }
            else
            {
                //Error in code
                return StatusCode(501);
            }
        }

        [Route("create"), HttpPost]
        public IActionResult Create(Cleaning cleaning)
        {
            if (cleanerContainer.Create(cleaning))
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
        public IActionResult Delete(Cleaning cleaning)
        {
            if (cleanerContainer.Delete(cleaning.CleaningID))
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
        public IActionResult Update(Cleaning cleaning)
        {
            if (Cleaning.Update(cleaning))
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
