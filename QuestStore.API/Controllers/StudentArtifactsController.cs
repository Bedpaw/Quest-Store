using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuestStore.API.Dtos.OutDtos;
using QuestStore.Core.Entities;
using QuestStore.Core.Interfaces;

namespace QuestStore.API.Controllers
{
    public class StudentArtifactsController : LinkingGenericController<StudentArtifact, PurchasedArtifactDetailedDto, StudentArtifactBriefDto>
    {
        private readonly IPurchaseService _purchaseService;
        protected override bool ReverseKeyOrder { get; } = false;

        public StudentArtifactsController(IUnitOfWork unitOfWork, IMapper mapper, IPurchaseService purchaseService)
            : base(unitOfWork, mapper)
        {
            _purchaseService = purchaseService;
        }

        public override async Task<ActionResult<StudentArtifactBriefDto>> CreateResource(int id, int id2)
        {
            StudentArtifact studentArtifact;
            try
            {
                studentArtifact = await _purchaseService.StudentBuyArtifact(id, id2);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            if (studentArtifact != null)
            {
                return CreatedAtAction(
                    nameof(GetAllResources),
                    new {id}, Mapper.Map<StudentArtifactBriefDto>(studentArtifact));
            }

            return BadRequest("The artifact cannot be purchased.");
        }

        public override async Task<IActionResult> DeleteResource(int id, int id2)
        {
            try
            {
                await _purchaseService.StudentReturnArtifact(id, id2);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }

            return Ok();
        }
    }
}
