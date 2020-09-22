using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuestStore.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCustomers()
        {
            return Ok("Hello World!");
        }
    }
}