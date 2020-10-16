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
        private readonly StoreDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(StoreDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll() => await _entities.ToListAsync();
        public async Task<T> GetById(int id) => await _entities.FindAsync(id);

        public async Task Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _entities.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            _entities.Remove(new T {Id = id});
            await _context.SaveChangesAsync();
        }
    }
}
