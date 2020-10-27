using System;
using System.Collections.Generic;
using System.Data.Common;
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
        protected readonly IRepository<T> Repository;
        protected readonly IMapper Mapper;
        private readonly string _errorMessage = "Database error";

        public GenericController(IRepository<T> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<ActionResult<List<TOut>>> GetAllResources()
        {
            try
            {
                var result = await Repository.GetAll(true);
                return Ok(Mapper.Map<List<TOut>>(result.ToList()));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _errorMessage);
            }
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TOut>> GetResource(int id)
        {
            try
            {
                var result = await Repository.GetById(id, true);

                if (result == null) return NotFound();

                return Ok(Mapper.Map<TOut>(result));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _errorMessage);
            }
        }

        [HttpPost]
        public virtual async Task<ActionResult<T>> CreateResource(TIn resourceDto)
        {
            try
            {
                var resource = Mapper.Map<T>(resourceDto);
                await Repository.Add(resource);
                return CreatedAtAction(
                    nameof(GetResource),
                    new {id = resource.Id},
                    Mapper.Map<TOut>(resource));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _errorMessage);
            }
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<T>> UpdateResource(int id, TIn resourceDto)
        {
            try
            {
                if (id != resourceDto.Id) return BadRequest();

                await Repository.Update(Mapper.Map<T>(resourceDto));
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
                return StatusCode(StatusCodes.Status500InternalServerError, _errorMessage);
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

                await Repository.DeleteById(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _errorMessage);
            }
        }
    }
}
