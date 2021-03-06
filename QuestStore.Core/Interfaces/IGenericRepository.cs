﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using QuestStore.Core.Entities;

namespace QuestStore.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        Task<IEnumerable<T>> GetAll(int includeDepth = 0, Expression<Func<T, bool>> filter = null);
        Task<T> GetById(int id, int includeDepth = 0);
        Task<bool> Exists(int id);
        void Add(T entity);
        void Update(T entity);
        void DeleteById(int id);
    }
}
