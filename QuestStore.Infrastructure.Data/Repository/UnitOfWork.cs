using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QuestStore.Core.Entities;
using QuestStore.Core.Interfaces;

namespace QuestStore.Infrastructure.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        protected StoreDbContext Context { get; }
        private readonly Dictionary<Type, object> _genericRepositories = new Dictionary<Type, object>();
        private readonly Dictionary<Type, object> _linkingRepositories = new Dictionary<Type, object>();
        private IClassroomRepository _classroomRepository;

        public UnitOfWork(StoreDbContext context)
        {
            Context = context;
        }

        public virtual async Task<int> Save()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                // Detach all tracked entries (including failed one).
                Context.ChangeTracker.Entries().ToList().ForEach(entry => entry.State = EntityState.Detached);
                throw exception switch
                {
                    { } ex when (ex.InnerException as SqlException)?.Number == 547 =>
                    new ConstraintException("Constraint violation.", ex),

                    { } ex when (ex.InnerException as SqlException)?.Number == 2627 =>
                    new DataException("Entry already exists", ex),

                    DbUpdateConcurrencyException ex => new DataException(
                        "Entry does not exist or concurrency exception",
                        ex),

                    _ => new DataException("Other save operation exception", exception)
                };
            }
        }

        public virtual bool NoTracking
        {
            get => Convert.ToBoolean(Context.ChangeTracker.QueryTrackingBehavior);
            set
            {
                Context.ChangeTracker.QueryTrackingBehavior = value switch
                {
                    true => QueryTrackingBehavior.NoTracking,
                    false => QueryTrackingBehavior.TrackAll
                };
            }
        }

        public virtual IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : BaseEntity, new()
        {
            if (!_genericRepositories.TryGetValue(typeof(TEntity), out var repository))
            {
                repository = new GenericRepository<TEntity>(Context);
                _genericRepositories[typeof(TEntity)] = repository;
            }

            return (IGenericRepository<TEntity>)repository;
        }

        public virtual ILinkingRepository<TEntity> LinkingRepository<TEntity>() where TEntity : class
        {
            if (!_linkingRepositories.TryGetValue(typeof(TEntity), out var repository))
            {
                repository = new LinkingRepository<TEntity>(Context);
                _linkingRepositories[typeof(TEntity)] = repository;
            }

            return (ILinkingRepository<TEntity>)repository;
        }

        public virtual IClassroomRepository ClassroomRepository => _classroomRepository ??= new ClassroomRepository(Context);
    }
}
