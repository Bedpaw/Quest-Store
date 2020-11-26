using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuestStore.API.Dtos.Duplex;
using QuestStore.API.Dtos.OutDtos;
using QuestStore.Core.Entities;
using QuestStore.Core.Enums;
using QuestStore.Core.Interfaces;

namespace QuestStore.API.Controllers
{
    public class StudentQuestController : LinkingGenericController<StudentQuest, QuestDetailedDto, StudentQuestBriefDto>
    {
        public StudentQuestController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet("pending")]
        public async Task<ActionResult<List<QuestDetailedDto>>> GetAllPendingQuests(int id) =>
            await GetQuests(id, QuestStatus.Pending);

        [HttpGet("completed")]
        public async Task<ActionResult<List<QuestDetailedDto>>> GetAllCompletedQuests(int id) =>
            await GetQuests(id, QuestStatus.Completed);

        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        [HttpPost("pending/{id2}")]
        public async Task<ActionResult<StudentQuestBriefDto>> CreatePendingQuest(int id, int id2) =>
            await CreateQuest(id, id2, QuestStatus.Pending);

        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        [HttpPost("completed/{id2}")]
        public async Task<ActionResult<StudentQuestBriefDto>> CreateCompletedQuest(int id, int id2) =>
            await CreateQuest(id, id2, QuestStatus.Completed);

        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        [HttpPut("{id2}")]
        public async Task<IActionResult> UpdateQuest(int id, int id2, [FromBody] QuestStatus status)
        {
            if (!await Repository.Exists(id, id2)) return NotFound();

            var studentQuest = new StudentQuest {StudentId = id, QuestId = id2, Status = status};
            Repository.Update(studentQuest);
            await UnitOfWork.Save();
            return NoContent(); //The operation was successful
        }

        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<List<QuestDetailedDto>>> GetAllResources(int id)
        {
            return base.GetAllResources(id);
        }

        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<StudentQuestBriefDto>> CreateResource(int id, int id2)
        {
            return base.CreateResource(id, id2);
        }

        private async Task<ActionResult<List<QuestDetailedDto>>> GetQuests(int id, QuestStatus status)
        {
            var result = await Repository.GetBySingleId(
                id,
                true,
                1,
                sq => sq.Status == status);
            if (result == null) return NotFound();

            return Ok(Mapper.Map<List<QuestDetailedDto>>(result.ToList()));
        }

        private async Task<ActionResult<StudentQuestBriefDto>> CreateQuest(int id, int id2, QuestStatus status)
        {
            var studentQuest = await Repository.GetByFullKey(id, id2);
            if (studentQuest != null)
            {
                if (status == QuestStatus.Completed && studentQuest.Status == QuestStatus.Pending)
                {
                    studentQuest.Status = QuestStatus.Completed;
                    Repository.Update(studentQuest);
                    await UnitOfWork.Save();
                    return CreatedAtAction(
                        nameof(GetAllResources),
                        new { id },
                        Mapper.Map<StudentQuestBriefDto>(studentQuest));
                }

                return BadRequest("Quest already exists");
            }

            studentQuest = new StudentQuest {StudentId = id, QuestId = id2, Status = status};
            Repository.Add(studentQuest);
            try
            {
                await UnitOfWork.Save();
            }
            catch (ConstraintException)
            {
                return BadRequest("Wrong primary key. Check if its components exist");
            }
            
            return CreatedAtAction(
                nameof(GetAllResources),
                new {id},
                Mapper.Map<StudentQuestBriefDto>(studentQuest));
        }
    }
}