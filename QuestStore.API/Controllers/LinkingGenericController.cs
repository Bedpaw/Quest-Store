using System;
using System.Collections.Generic;
using System.Data.Common;
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
        protected readonly ILinkingRepository<T> Repository;
        protected readonly IMapper Mapper;
        private readonly string _errorMessage;

        public LinkingGenericController(ILinkingRepository<T> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
            _errorMessage = "Database error";
        }

        [HttpGet]
        public virtual async Task<ActionResult<List<TOut>>> GetAllResources(int id)
        {
            try
            {
                var useFirstId = !ControllersTypes
                    .LinkingControllers[(typeof(T), typeof(TOut), typeof(TPost))]
                    .ReverseKeyOrder;
                var result = await Repository.GetBySingleId(id, useFirstId,1);
                return Ok(Mapper.Map<List<TOut>>(result.ToList()));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _errorMessage);
            }
        }

        [HttpGet("{id2}")]
        public virtual async Task<ActionResult<TOut>> GetResource(int id, int id2)
        {
            try
            {
                var result = ControllersTypes.LinkingControllers[(typeof(T), typeof(TOut), typeof(TPost))]
                    .ReverseKeyOrder
                    ? await Repository.GetByFullKey(id2, id, 1)
                    : await Repository.GetByFullKey(id, id2, 1);

                if (result == null) return NotFound();

                return Ok(Mapper.Map<TOut>(result));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _errorMessage);
            }
        }

        [HttpPost("{id2}")]
        public virtual async Task<ActionResult<TPost>> CreateResource(int id, int id2)
        {
            try
            {
                if (ControllersTypes.LinkingControllers[(typeof(T), typeof(TOut), typeof(TPost))].ReverseKeyOrder)
                {
                    (id, id2) = (id2, id);
                }

                var resource = Mapper.Map<T>(new LinkingDto {Id1 = id, Id2 = id2});
                await Repository.Add(resource);

                return CreatedAtAction(
                    nameof(GetResource),
                    new { id = id, id2 = id2 }, Mapper.Map<TPost>(resource));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _errorMessage);
            }
        }

        [HttpDelete("{id2}")]
        public virtual async Task<IActionResult> DeleteResource(int id, int id2)
        {
            try
            {
                var resource = ControllersTypes.LinkingControllers[(typeof(T), typeof(TOut), typeof(TPost))]
                    .ReverseKeyOrder
                    ? await Repository.GetByFullKey(id2, id, 1)
                    : await Repository.GetByFullKey(id, id2, 1);

                if (resource == null) return NotFound();

                await Repository.Delete(resource);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _errorMessage);
            }
        }

        //[HttpDelete]
        //public virtual async Task<IActionResult> DeleteAllResources(int id)
        //{
        //    try
        //    {
        //        var useFirstId = !ControllersTypes
        //            .LinkingControllers[(typeof(T), typeof(TOut), typeof(TPost))]
        //            .ReverseKeyOrder;

        //        var resources = await Repository.GetBySingleId(id, useFirstId);

        //        if (resources == null) return NotFound();

        //        await Repository.DeleteBySingleId(id, useFirstId);
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, _errorMessage);
        //    }
        //}
    }
}
