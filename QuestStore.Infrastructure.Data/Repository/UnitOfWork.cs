using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuestStore.Core.Entities;
using QuestStore.Core.Enums;
using QuestStore.Core.Interfaces;

namespace QuestStore.Infrastructure.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        protected StoreDbContext Context { get; }
        private readonly Dictionary<Type, object> _genericRepositories = new Dictionary<Type, object>();
        private readonly Dictionary<Type, object> _linkingRepositories = new Dictionary<Type, object>();

        public UnitOfWork(StoreDbContext context)
        {
            Context = context;
        }
        public virtual async Task<int> Save() => await Context.SaveChangesAsync();

        public virtual TrackingBehavior TrackingBehavior
        {
            get => (TrackingBehavior) Context.ChangeTracker.QueryTrackingBehavior;
            set => Context.ChangeTracker.QueryTrackingBehavior = (QueryTrackingBehavior) value;
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
    }
}
