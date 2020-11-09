using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestStore.API.Dtos.OutDtos;
using QuestStore.Core.Interfaces;

namespace QuestStore.API.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("classrooms/{id}/artifacts")]
    // Attribute changes controller name in the Swagger
    [ApiExplorerSettings(GroupName = "Classrooms")]
    public class ClassroomArtifactController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public ClassroomArtifactController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("{id2}")]
        public async Task<IActionResult> CreateClassPurchase(int id, int id2)
        {
            try
            {
                if (await _studentService.ClassBuyArtifact(id, id2))
                {
                    return StatusCode(StatusCodes.Status201Created);
                }

                return StatusCode(StatusCodes.Status409Conflict, "Not enough coins.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }
        }
    }
}
