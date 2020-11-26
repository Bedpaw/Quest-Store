using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public GenericController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Repository = UnitOfWork.GenericRepository<T>();
            Mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<ActionResult<List<TOut>>> GetAllResources()
        {
            var result = await Repository.GetAll(2);
            return Ok(Mapper.Map<List<TOut>>(result.ToList()));
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TOut>> GetResource(int id)
        {

            var result = await Repository.GetById(id, 2);
            if (result == null) return NotFound();

            return Ok(Mapper.Map<TOut>(result));
        }

        [HttpPost]
        public virtual async Task<ActionResult<T>> CreateResource(TIn resourceDto)
        {
            var resource = Mapper.Map<T>(resourceDto);
            Repository.Add(resource);
            await UnitOfWork.Save();
            return CreatedAtAction(
                nameof(GetResource),
                new {id = resource.Id},
                Mapper.Map<TOut>(resource));
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> UpdateResource(int id, TIn resourceDto)
        {
            if (id != resourceDto.Id) return BadRequest();

            var resource = await Repository.GetById(id);
            if (resource == null) return NotFound();

            resource = Mapper.Map(resourceDto, resource);
            Repository.Update(resource);
            await UnitOfWork.Save();
            return NoContent(); //The operation was successful
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteResource(int id)
        {
            if (!await Repository.Exists(id)) return NotFound();

            Repository.DeleteById(id);
            await UnitOfWork.Save();
            return Ok();
        }
    }
}
