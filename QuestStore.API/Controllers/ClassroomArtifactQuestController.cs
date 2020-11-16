using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestStore.API.Dtos.Duplex;
using QuestStore.API.Dtos.OutDtos;
using QuestStore.Core.Entities;
using QuestStore.Core.Enums;
using QuestStore.Core.Interfaces;

namespace QuestStore.API.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    // Attribute changes controller name in the Swagger
    [ApiExplorerSettings(GroupName = "Classrooms")]
    public class ClassroomArtifactQuestController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IUnitOfWork _unitOfWork;

        public ClassroomArtifactQuestController(IStudentService studentService, IUnitOfWork unitOfWork)
        {
            _studentService = studentService;
            _unitOfWork = unitOfWork;
        }

        [Route("classrooms/{id}/artifacts/{id2}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        [HttpPost]
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

        [Route("classrooms/{id}/quests/pending")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        [HttpGet]
        public async Task<ActionResult<List<QuestDetailedDto>>> GetPendingQuests(int id)
        {
            // List of students Ids in the given class.
            var studentsIds = (await _unitOfWork.LinkingRepository<StudentClassroom>()
                .GetBySingleId(id, false))?.Select(sc => sc.StudentId);
            if (studentsIds == null) return NotFound();

            var pendingQuests = new List<Quest>(); 
            foreach (var studentId in studentsIds)
            {
                var studentQuests =
                    (await _unitOfWork.LinkingRepository<StudentQuest>()
                        .GetBySingleId(
                            studentId,
                            true,
                            1,
                            sq => sq.Status == QuestStatus.Pending))
                    ?.Select(sq => sq.Quest);
                pendingQuests.AddRange(studentQuests ?? Array.Empty<Quest>());
            }

            return Ok(pendingQuests);
        }
    }
}
