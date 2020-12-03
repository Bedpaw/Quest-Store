using System;
using System.Collections.Generic;
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
        private readonly IQuestService _questService;

        public StudentQuestController(IUnitOfWork unitOfWork, IMapper mapper, IQuestService questService) : base(unitOfWork, mapper)
        {
            _questService = questService;
        }

        [HttpGet("pending")]
        public async Task<ActionResult<List<QuestDetailedDto>>> GetAllPendingQuests(int id) =>
            await GetQuests(id, QuestStatus.Pending);

        [HttpGet("completed")]
        public async Task<ActionResult<List<QuestDetailedDto>>> GetAllCompletedQuests(int id) =>
            await GetQuests(id, QuestStatus.Completed);

        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        [HttpPost("{id2}")]
        public async Task<ActionResult<StudentQuestBriefDto>> CreateQuest(int id, int id2, QuestStatus status)
        {
            if (status == QuestStatus.Pending)
            {
                var result = await base.CreateResource(id, id2);
                if (result.Result is BadRequestObjectResult) return result;

                var resource = (StudentQuestBriefDto) ((CreatedAtActionResult) result.Result).Value;
                return CreatedAtAction(nameof(GetAllPendingQuests), new { id }, resource);
            }

            StudentQuest studentQuest;
            try
            {
                studentQuest = await _questService.FinishQuest(id, id2);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction(
                nameof(GetAllCompletedQuests),
                new { id },
                Mapper.Map<StudentQuestBriefDto>(studentQuest));
        }

        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        [HttpPut("{id2}")]
        public async Task<IActionResult> UpdateQuest(int id, int id2, QuestStatus status)
        {
            var studentQuest = await Repository.GetByFullKey(id, id2);
            if (studentQuest == null) return NotFound();

            try
            {
                switch (studentQuest.Status)
                {
                    case QuestStatus.Pending when status == QuestStatus.Completed:
                        await _questService.FinishQuest(id, id2);
                        break;
                    case QuestStatus.Completed when status == QuestStatus.Pending:
                        await _questService.UndoFinishQuest(id, id2);
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            
            return NoContent(); //The operation was successful
        }

        public override async Task<IActionResult> DeleteResource(int id, int id2)
        {
            var studentQuest = await Repository.GetByFullKey(id, id2);
            if (studentQuest == null) return NotFound();

            if (studentQuest.Status == QuestStatus.Completed) await _questService.UndoFinishQuest(id, id2);

            Repository.Delete(studentQuest);
            await UnitOfWork.Save();
            return Ok();
        }

        private async Task<ActionResult<List<QuestDetailedDto>>> GetQuests(int id, QuestStatus status)
        {
            var result = await Repository
                .GetBySingleId(id, true, 1, sq => sq.Status == status);
            if (result == null) return NotFound();

            return Ok(Mapper.Map<List<QuestDetailedDto>>(result.ToList()));
        }

        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<List<QuestDetailedDto>>> GetAllResources(int id) => base.GetAllResources(id);

        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<StudentQuestBriefDto>> CreateResource(int id, int id2) =>
            base.CreateResource(id, id2);
    }
}