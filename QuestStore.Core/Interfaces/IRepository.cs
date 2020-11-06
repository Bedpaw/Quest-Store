using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuestStore.Core.Entities;

namespace QuestStore.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        Task<IEnumerable<T>> GetAll(int includeDepth = 0);
        Task<T> GetById(int id, int includeDepth = 0);
        void Add(T entity);
        void Update(T entity);
        void DeleteById(int id);
    }
}
