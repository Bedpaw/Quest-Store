using System;
using System.Data;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuestStore.API.Dtos.Duplex;
using QuestStore.API.Dtos.OutDtos;
using QuestStore.Core.Entities;
using QuestStore.Core.Interfaces;

namespace QuestStore.API.Controllers
{
    public class StudentArtifactsController : LinkingGenericController<StudentArtifact, ArtifactDetailedDto, StudentArtifactBriefDto>
    {
        private readonly IStudentService _studentService;
        protected override bool ReverseKeyOrder { get; } = false;

        public StudentArtifactsController(IUnitOfWork unitOfWork, IMapper mapper, IStudentService studentService)
            : base(unitOfWork, mapper)
        {
            _studentService = studentService;
        }

        public override async Task<ActionResult<StudentArtifactBriefDto>> CreateResource(int id, int id2)
        {
            try
            {
                if (await _studentService.BuyArtifact(id, id2))
                {
                    return CreatedAtAction(
                        nameof(GetResource),
                        new { id, id2 },
                        new StudentArtifactBriefDto { StudentId = id, ArtifactId = id2 });
                }
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DataException)
            {
                return BadRequest("The artifact has already been purchased");
            }

            return BadRequest("The artifact cannot be purchased.");
        }
    }
}
