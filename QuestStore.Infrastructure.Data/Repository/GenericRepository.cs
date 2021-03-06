﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuestStore.Core.Entities;
using QuestStore.Core.Interfaces;

namespace QuestStore.Infrastructure.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        protected readonly StoreDbContext Context; 
        protected readonly DbSet<T> Entities;

        public GenericRepository(StoreDbContext context)
        {
            Context = context;
            Entities = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll(int includeDepth = 0, Expression<Func<T, bool>> filter = null)
        {
            var query = filter != null ? Entities.Where(filter) : Entities;
            if (includeDepth > 0)
            {
                //Cycles are not allowed in no-tracking queries. Add AsTracking to a dbSet or uncomment FindInverse() in the GetAllPaths
                return await query.Include(Context.GetAllPaths(typeof(T), includeDepth)).ToListAsync(); 
            }

            return await query.ToListAsync();
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

        public virtual async Task<bool> Exists(int id)
        {
            return await Entities.AnyAsync(e => e.Id == id);
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
