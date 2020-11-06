using System;

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
    //Add attribute [ApiExplorerSettings(GroupName = "name")] to controller to change its name in the Swagger
    public class StudentArtifactsController : LinkingGenericController<StudentArtifact, ArtifactDetailedDto, StudentArtifactBrief>
    {
        private readonly IStudentService _studentService;

        public StudentArtifactsController(IUnitOfWork unitOfWork, IMapper mapper, IStudentService studentService)
            : base(unitOfWork, mapper)
        {
            _studentService = studentService;
        }

        public override async Task<ActionResult<StudentArtifactBrief>> CreateResource(int id, int id2)
        {
            try
            {
                if (await _studentService.BuyArtifact(id, id2))
                {
                    return await base.CreateResource(id, id2);
                }

                return StatusCode(StatusCodes.Status409Conflict, "Not enough coins.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessage);
            }
        }
    }
}
