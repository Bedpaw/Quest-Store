using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestStore.Core.Entities;
using QuestStore.Core.Interfaces;

namespace QuestStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class GenericController<T, TOut, TIn> : ControllerBase 
        where T : BaseEntity, new()
        where TIn : BaseEntity, new()
    {
        protected IGenericRepository<T> Repository { get; }
        protected IUnitOfWork UnitOfWork { get; }
        protected IMapper Mapper { get; }
        protected string ErrorMessage { get; set; } = "Database error";

        public GenericController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Repository = UnitOfWork.GenericRepository<T>();
            Mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<ActionResult<List<TOut>>> GetAllResources()
        {
            try
            {
                var result = await Repository.GetAll(2);
                return Ok(Mapper.Map<List<TOut>>(result.ToList()));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessage);
            }
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TOut>> GetResource(int id)
        {
            try
            {
                var result = await Repository.GetById(id, 2);

                if (result == null) return NotFound();

                return Ok(Mapper.Map<TOut>(result));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessage);
            }
        }

        [HttpPost]
        public virtual async Task<ActionResult<T>> CreateResource(TIn resourceDto)
        {
            try
            {
                var resource = Mapper.Map<T>(resourceDto);
                Repository.Add(resource);
                await UnitOfWork.Save();
                return CreatedAtAction(
                    nameof(GetResource),
                    new {id = resource.Id},
                    Mapper.Map<TOut>(resource));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessage);
            }
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> UpdateResource(int id, TIn resourceDto)
        {
            try
            {
                if (id != resourceDto.Id) return BadRequest();

                Repository.Update(Mapper.Map<T>(resourceDto));
                await UnitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await Repository.GetById(id) == null)
                {
                    return NotFound();
                }

                throw;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessage);
            }

            return NoContent(); //The operation was successful
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteResource(int id)
        {
            try
            {
                var resource = await Repository.GetById(id);

                if (resource == null) return NotFound();

                Repository.DeleteById(id);
                await UnitOfWork.Save();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessage);
            }
        }
    }
}
