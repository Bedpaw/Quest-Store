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
using QuestStore.Infrastructure.Data.Repository;

namespace QuestStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class GenericController<T, TOut, TIn> : ControllerBase 
        where T : BaseEntity, new()
        where TIn : BaseEntity, new()
    {
        private readonly IRepository<T> _repository;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;
        protected readonly string ErrorMessage = "Database error";

        public GenericController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            _repository = UnitOfWork.GetRepository<Repository<T>, T>();
            Mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<ActionResult<List<TOut>>> GetAllResources()
        {
            try
            {
                var result = await _repository.GetAll(2);
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
                var result = await _repository.GetById(id, 2);

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
                _repository.Add(resource);
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
        public virtual async Task<ActionResult<T>> UpdateResource(int id, TIn resourceDto)
        {
            try
            {
                if (id != resourceDto.Id) return BadRequest();

                _repository.Update(Mapper.Map<T>(resourceDto));
                await UnitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _repository.GetById(id) == null)
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
                var resource = await _repository.GetById(id);

                if (resource == null) return NotFound();

                _repository.DeleteById(id);
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
