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

        public virtual async Task<IEnumerable<T>> GetAll(bool includePaths = false)
        {
            if (includePaths)
            {
                //Cycles are not allowed in no-tracking queries. Add AsTracking to a dbSet or uncomment FindInverse() in the GetAllPaths
                return await Entities.Include(Context.GetAllPaths(typeof(T))).ToListAsync(); 
            }
            
            return await Entities.ToListAsync();
        }

        public virtual async Task<T> GetById(int id, bool includePaths = false)
        {
            if (includePaths)
            {
                return await Entities.Include(Context.GetAllPaths(typeof(T)))
                    .FirstOrDefaultAsync(e => e.Id == id);
            }

            return await Entities.FindAsync(id);
        }

        public virtual async Task Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Entities.Add(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Entities.Update(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteById(int id)
        {
            Entities.Remove(new T {Id = id});
            await Context.SaveChangesAsync();
        }
    }
}
