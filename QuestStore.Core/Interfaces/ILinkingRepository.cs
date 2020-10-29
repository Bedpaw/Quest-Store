using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuestStore.Core.Interfaces
{
    public interface ILinkingRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetByFirstId(int firstId, int includeDepth);
        Task<T> GetByFullKey(int firstId, int secondId, int includeDepth);
        Task Add(T entity);
        Task DeleteByFirstId(int firstIsd);
        Task DeleteByFullKey(int firstId, int secondId);


    }
}
