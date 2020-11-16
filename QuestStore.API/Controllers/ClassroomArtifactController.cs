using System;
using System.Collections.Generic;
using System.Data;
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

        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        [HttpPost("{id2}")]
        public async Task<IActionResult> CreateClassPurchase(int id, int id2)
        {
            try
            {
                if (await _studentService.ClassBuyArtifact(id, id2)) 
                    return StatusCode(StatusCodes.Status201Created);
            }
            catch (ArgumentException ex)
            {
                BadRequest(ex.Message);
            }
            catch (DataException)
            {
                return BadRequest("The artifact has already been purchased");
            }

            return BadRequest("The artifact cannot be purchased.");
        }
    }
}
