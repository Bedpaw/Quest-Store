using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuestStore.Core.Entities;
using QuestStore.Core.Interfaces;

namespace QuestStore.Infrastructure.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        protected readonly StoreDbContext Context; 
        protected readonly DbSet<T> Entities;

        public Repository(StoreDbContext context)
        {
            Context = context;
            Entities = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll(int includeDepth = 0)
        {
            if (includeDepth > 0)
            {
                //Cycles are not allowed in no-tracking queries. Add AsTracking to a dbSet or uncomment FindInverse() in the GetAllPaths
                return await Entities.Include(Context.GetAllPaths(typeof(T), includeDepth)).ToListAsync(); 
            }

            return await Entities.ToListAsync();
        }

        public virtual async Task<T> GetById(int id, int includeDepth = 0)
        {
            if (includeDepth > 0)
            {
                return await Entities.Include(Context.GetAllPaths(typeof(T), includeDepth))
                    .FirstOrDefaultAsync(e => e.Id == id);
            }

            return await Entities.FindAsync(id);
        }

        public virtual void Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Entities.Add(entity);
        }

        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Entities.Update(entity);
        }

        public virtual void DeleteById(int id)
        {
            Entities.Remove(new T {Id = id});
        }
    }
}
