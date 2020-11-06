using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using QuestStore.Core.Entities;
using QuestStore.Core.Enums;
using QuestStore.Core.Interfaces;

namespace QuestStore.Infrastructure.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly StoreDbContext Context;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
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

        public virtual TRepo GetRepository<TRepo, TEntity>() where TRepo : IRepository<TEntity> where TEntity : BaseEntity, new()
        {
            if (!_repositories.TryGetValue(typeof(TEntity), out var repository))
            {
                repository = Activator.CreateInstance(typeof(TRepo), Context);
                _repositories[typeof(TEntity)] = repository;
            }

            return (TRepo)repository;
        }

        public virtual TRepo GetLinkingRepository<TRepo, TEntity>() where TRepo : ILinkingRepository<TEntity> where TEntity : class
        {
            if (!_linkingRepositories.TryGetValue(typeof(TEntity), out var repository))
            {
                repository = Activator.CreateInstance(typeof(TRepo), Context);
                _linkingRepositories[typeof(TEntity)] = repository;
            }

            return (TRepo)repository;
        }
    }
}
