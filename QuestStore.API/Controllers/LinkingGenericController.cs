using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestStore.API.Dtos.InDtos;
using QuestStore.API.GenericControllersFactory;
using QuestStore.Core.Interfaces;
using QuestStore.Infrastructure.Data.Repository;

namespace QuestStore.API.Controllers
{
    [Route("api/[ParentController]/{id}/[ChildController]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class LinkingGenericController<T, TOut, TPost> : ControllerBase
    where T : class
    {
        private readonly ILinkingRepository<T> _repository;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;
        protected readonly string ErrorMessage;

        public LinkingGenericController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            _repository = UnitOfWork.GetLinkingRepository<LinkingRepository<T>, T>();
            Mapper = mapper;
            ErrorMessage = "Database error";
        }

        [HttpGet]
        public virtual async Task<ActionResult<List<TOut>>> GetAllResources(int id)
        {
            try
            {
                var useFirstId = !ControllersTypes
                    .LinkingControllers[(typeof(T), typeof(TOut), typeof(TPost))]
                    .ReverseKeyOrder;
                var result = await _repository.GetBySingleId(id, useFirstId,1);
                return Ok(Mapper.Map<List<TOut>>(result.ToList()));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessage);
            }
        }

        [HttpGet("{id2}")]
        public virtual async Task<ActionResult<TOut>> GetResource(int id, int id2)
        {
            try
            {
                var result = ControllersTypes.LinkingControllers[(typeof(T), typeof(TOut), typeof(TPost))]
                    .ReverseKeyOrder
                    ? await _repository.GetByFullKey(id2, id, 1)
                    : await _repository.GetByFullKey(id, id2, 1);

                if (result == null) return NotFound();

                return Ok(Mapper.Map<TOut>(result));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessage);
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
                _repository.Add(resource);
                await UnitOfWork.Save();

                return CreatedAtAction(
                    nameof(GetResource),
                    new { id = id, id2 = id2 }, Mapper.Map<TPost>(resource));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessage);
            }
        }

        [HttpDelete("{id2}")]
        public virtual async Task<IActionResult> DeleteResource(int id, int id2)
        {
            try
            {
                var resource = ControllersTypes.LinkingControllers[(typeof(T), typeof(TOut), typeof(TPost))]
                    .ReverseKeyOrder
                    ? await _repository.GetByFullKey(id2, id)
                    : await _repository.GetByFullKey(id, id2);

                if (resource == null) return NotFound();

                _repository.Delete(resource);
                await UnitOfWork.Save();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessage);
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
