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

        public TRepo GetRepository<TRepo, TEntity>() where TRepo : IRepository<TEntity>
            where TEntity : BaseEntity, new();

        public TRepo GetLinkingRepository<TRepo, TEntity>() where TRepo : ILinkingRepository<TEntity>
            where TEntity : class;

    }
}
