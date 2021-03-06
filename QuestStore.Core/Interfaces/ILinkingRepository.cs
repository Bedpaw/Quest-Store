﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QuestStore.Core.Interfaces
{
    public interface ILinkingRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetBySingleId(int id, bool useFirstId, int includeDepth = 0, Expression<Func<T, bool>> filter = null);
        Task<T> GetByFullKey(int firstId, int secondId, int includeDepth = 0);
        Task<bool> Exists(int firstId, int secondId);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity); 
        void DeleteBySingleId(int id, bool useFirstId);
    }
}
