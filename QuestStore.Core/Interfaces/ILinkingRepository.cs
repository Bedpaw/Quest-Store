using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuestStore.Core.Interfaces
{
    public interface ILinkingRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetBySingleId(int id, bool useFirstId, int includeDepth = 0);
        Task<T> GetByFullKey(int firstId, int secondId, int includeDepth = 0);
        void Add(T entity);
        void Delete(T entity); 
        void DeleteBySingleId(int id, bool useFirstId);
    }
}
