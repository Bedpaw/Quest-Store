using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestStore.API.Dtos.InDtos;
using QuestStore.API.GenericControllersFactory;
using QuestStore.Core.Interfaces;

namespace QuestStore.API.Controllers
{
    [Route("api/[ParentController]/{id}/[ChildController]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class LinkingGenericController<T, TOut, TPost> : ControllerBase
    where T : class
    {
        protected ILinkingRepository<T> Repository { get; }
        protected IUnitOfWork UnitOfWork { get; }
        protected IMapper Mapper { get; }
        protected string ErrorMessage { get; set; } = "Database error";
        protected virtual bool ReverseKeyOrder { get; } = ControllersTypes
            .LinkingControllers[(typeof(T), typeof(TOut), typeof(TPost))]
            .ReverseKeyOrder;

        public LinkingGenericController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Repository = UnitOfWork.LinkingRepository<T>();
            Mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<ActionResult<List<TOut>>> GetAllResources(int id)
        {
            try
            {
                var useFirstId = !ReverseKeyOrder;
                var result = await Repository.GetBySingleId(id, useFirstId,1);
                return Ok(Mapper.Map<List<TOut>>(result.ToList()));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessage);
            }
        }

        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        [HttpGet("{id2}")]
        public virtual async Task<ActionResult<TOut>> GetResource(int id, int id2)
        {
            try
            {
                var result = ReverseKeyOrder
                    ? await Repository.GetByFullKey(id2, id, 1)
                    : await Repository.GetByFullKey(id, id2, 1);

                if (result == null) return NotFound();

                return Ok(Mapper.Map<TOut>(result));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessage);
            }
        }

        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        [HttpPost("{id2}")]
        public virtual async Task<ActionResult<TPost>> CreateResource(int id, int id2)
        {
            try
            {
                if (ReverseKeyOrder)
                {
                    (id, id2) = (id2, id);
                }

                var resource = Mapper.Map<T>(new LinkingDto {Id1 = id, Id2 = id2});
                Repository.Add(resource);
                await UnitOfWork.Save();

                return CreatedAtAction(
                    nameof(GetResource),
                    new {id, id2},
                    Mapper.Map<TPost>(resource));
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Resource already exists");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessage);
            }
        }

        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        [HttpDelete("{id2}")]
        public virtual async Task<IActionResult> DeleteResource(int id, int id2)
        {
            try
            {
                var resource = ReverseKeyOrder
                    ? await Repository.GetByFullKey(id2, id)
                    : await Repository.GetByFullKey(id, id2);

                if (resource == null) return NotFound();

                Repository.Delete(resource);
                await UnitOfWork.Save();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessage);
            }
        }

        //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        //[HttpDelete]
        //public virtual async Task<IActionResult> DeleteAllResources(int id)
        //{
        //    try
        //    {
        //        var useFirstId = !ReverseKeyOrder;

        //        var resources = await GetRepository.GetBySingleId(id, useFirstId);

        //        if (resources == null) return NotFound();

        //        await GetRepository.DeleteBySingleId(id, useFirstId);
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, _errorMessage);
        //    }
        //}
    }
}
