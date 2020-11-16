using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

            var useFirstId = !ReverseKeyOrder;
            var result = await Repository.GetBySingleId(id, useFirstId, 1);
            if (result == null) return NotFound();

            return Ok(Mapper.Map<List<TOut>>(result.ToList()));
        }

        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        [HttpGet("{id2}")]
        public virtual async Task<ActionResult<TOut>> GetResource(int id, int id2)
        {

            var result = ReverseKeyOrder
                ? await Repository.GetByFullKey(id2, id, 1)
                : await Repository.GetByFullKey(id, id2, 1);
            if (result == null) return NotFound();

            return Ok(Mapper.Map<TOut>(result));
        }

        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        [HttpPost("{id2}")]
        public virtual async Task<ActionResult<TPost>> CreateResource(int id, int id2)
        {
            if (ReverseKeyOrder) (id, id2) = (id2, id);

            if (await Repository.Exists(id, id2)) return BadRequest("Resource already exists");

            var resource = Mapper.Map<T>(new LinkingDto {Id1 = id, Id2 = id2});
            Repository.Add(resource);
            try
            {
                await UnitOfWork.Save();
            }
            catch (ConstraintException)
            {
                return BadRequest("Wrong primary key. Check if its components exist");
            }

            return CreatedAtAction(
                nameof(GetResource),
                new {id, id2},
                Mapper.Map<TPost>(resource));
        }

        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        [HttpDelete("{id2}")]
        public virtual async Task<IActionResult> DeleteResource(int id, int id2)
        {

            var resource = ReverseKeyOrder
                ? await Repository.GetByFullKey(id2, id)
                : await Repository.GetByFullKey(id, id2);
            if (resource == null) return NotFound();

            Repository.Delete(resource);
            await UnitOfWork.Save();
            return Ok();
        }

        //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        //[HttpDelete]
        //public virtual async Task<IActionResult> DeleteAllResources(int id)
        //{
        //    var useFirstId = !ReverseKeyOrder;
        //    if (await Repository.GetBySingleId(id, useFirstId) == null) return NotFound();

        //    Repository.DeleteBySingleId(id, useFirstId);
        //    await UnitOfWork.Save();
        //    return Ok();
        //}
    }
}
