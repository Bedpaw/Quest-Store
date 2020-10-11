using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuestStore.API.Controllers
{

    [ApiController]
    [Route("/api/[controller]/[action]")]
    [Authorize]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "Admin")]
        public IActionResult WelcomeAdmin()
        {
            return Ok("Hello Admin!");
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "Mentor")]
        public IActionResult WelcomeMentor()
        {
            return Ok("Hello Mentor!");
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "Student")]
        public IActionResult WelcomeStudent()
        {
            return Ok("Hello Student!");
        }
    }
}