using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuestStore.Core.Entities;
using QuestStore.Core.Enums;


namespace QuestStore.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public Task<int> Save();
        public TrackingBehavior TrackingBehavior { get; set; }

        public IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : BaseEntity, new();

        public ILinkingRepository<TEntity> LinkingRepository<TEntity>() where TEntity : class;

    }
}
