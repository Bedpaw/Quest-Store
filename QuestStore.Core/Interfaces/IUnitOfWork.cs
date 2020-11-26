using System.Threading.Tasks;
using QuestStore.Core.Entities;



namespace QuestStore.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public Task<int> Save();
        public bool NoTracking { get; set; }
        public IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : BaseEntity, new();
        public ILinkingRepository<TEntity> LinkingRepository<TEntity>() where TEntity : class;
        public IClassroomRepository ClassroomRepository { get; }
    }
}
