using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuestStore.Core.Entities;

namespace QuestStore.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task DeleteById(int id);

    }
}
