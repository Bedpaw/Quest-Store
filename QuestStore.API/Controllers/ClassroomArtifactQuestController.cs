using System;
using System.Collections.Generic;
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
        private readonly IPurchaseService _purchaseService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClassroomArtifactQuestController(IPurchaseService purchaseService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _purchaseService = purchaseService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Route("api/Classrooms/{id}/artifacts/{id2}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        [HttpPost]
        public async Task<IActionResult> CreateClassPurchase(int id, int id2)
        {
            try
            {
                if (await _purchaseService.ClassBuyArtifact(id, id2)) 
                    return StatusCode(StatusCodes.Status201Created);
            }
            catch (ArgumentException ex)
            {
                BadRequest(ex.Message);
            }

            return BadRequest("The artifact cannot be purchased.");
        }

        [Route("api/Classrooms/{id}/quests/pending")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        [HttpGet]
        public async Task<ActionResult<List<QuestWithStudentsDto>>> GetPendingQuests(int id)
        {
            var studentQuests =
                await _unitOfWork.ClassroomRepository.GetClassroomStudentsWithQuests(id, QuestStatus.Pending);
            if (studentQuests == null) return NotFound();

            var quests = new List<QuestWithStudentsDto>();
            foreach (var studentQuest in studentQuests)
            {
                var quest = quests.FirstOrDefault(q => q.Id == studentQuest.QuestId);
                if (quest != null)
                {
                   quest.Students.Add(_mapper.Map<StudentBriefDto>(studentQuest.Student));
                }
                else
                {
                    quests.Add(
                        new QuestWithStudentsDto
                        {
                            Id = studentQuest.QuestId,
                            Name = studentQuest.Quest.Name,
                            Students = new List<StudentBriefDto>
                            {
                                _mapper.Map<StudentBriefDto>(studentQuest.Student)
                            }
                        });
                }
            }

            return Ok(quests);
        }
    }
}
