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
using QuestStore.Core.Interfaces;
using QuestStore.Infrastructure.Data.Repository;

namespace QuestStore.API.Controllers
{
    //Add attribute [ApiExplorerSettings(GroupName = "name")] to controller to change its name in the Swagger
    public class StudentArtifactsController : LinkingGenericController<StudentArtifact, ArtifactDetailedDto, StudentArtifactBrief>
    {

        public StudentArtifactsController(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
            UnitOfWork.GetRepository<Repository<Student>, Student>();
            UnitOfWork.GetRepository<Repository<Artifact>, Artifact>();
        }

        public override async Task<ActionResult<StudentArtifactBrief>> CreateResource(int id, int id2)
        {
            try
            {
                var student = await UnitOfWork.GetRepository<Repository<Student>, Student>().GetById(id);
                var artifact = await UnitOfWork.GetRepository<Repository<Artifact>, Artifact>().GetById(id2);
                if (student.Coins >= artifact.Cost)
                {
                    student.Coins -= artifact.Cost;
                    UnitOfWork.GetRepository<Repository<Student>, Student>().Update(student);
                    await UnitOfWork.Save();
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
