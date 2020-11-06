using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuestStore.Core.Interfaces;

namespace QuestStore.Infrastructure.Data.Repository
{
    public class LinkingRepository<T> : ILinkingRepository<T> where T : class
    {
        protected readonly StoreDbContext Context;
        protected readonly DbSet<T> Entities;
        private readonly IEnumerable<string> _keyPropertiesNames;

        public LinkingRepository(StoreDbContext context)
        {
            Context = context;
            Entities = Context.Set<T>();
            _keyPropertiesNames = Context.Model.FindEntityType(typeof(T))
                .FindPrimaryKey()
                .Properties.Select(p => p.Name);

        }
        public virtual async Task<IEnumerable<T>> GetBySingleId(int id, bool useFirstId , int includeDepth = 0)
        {
            var (conditionExpression, parameterExpression) = CreateSingleIdExpressionArguments(id, useFirstId);
            var query = Entities.Where(
                Expression.Lambda<Func<T, bool>>(conditionExpression, parameterExpression));

            if (includeDepth > 0)
            {
                return await  query.Include(Context.GetAllPaths(typeof(T))).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public virtual async Task<T> GetByFullKey(int firstId, int secondId, int includeDepth = 0)
        {
            if (includeDepth > 0)
            {
                return await Entities.Include(Context.GetAllPaths(typeof(T)))
                    .FirstOrDefaultAsync(CreateFullKeyExpression(firstId, secondId));
            }

            return await Entities.FindAsync(firstId, secondId);
        }

        public virtual void Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Entities.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Entities.Remove(entity);
        }

        public virtual void DeleteBySingleId(int id, bool useFirstId)
        {
            var (conditionExpression, parameterExpression) = CreateSingleIdExpressionArguments(id, useFirstId);
            var query = Entities.Where(
                Expression.Lambda<Func<T, bool>>(conditionExpression, parameterExpression));
            Entities.RemoveRange(query);
        }

        private (BinaryExpression, ParameterExpression) CreateSingleIdExpressionArguments(int id, bool useFirstId)
        {
            // Expression <=> entity (function argument)
            var parameterExpression = Expression.Parameter(typeof(T), "entity");
            // Expression <=> entity.KeyName
            var getPropertyExpression = Expression.Property(
                parameterExpression,
                useFirstId ? _keyPropertiesNames.First() : _keyPropertiesNames.Last());
            // Expression <=> id
            var firstIdExpression = Expression.Constant(id, typeof(int));
            // Expression <=> entity.KeyName == id
            var conditionExpression =  Expression.Equal(getPropertyExpression, firstIdExpression);
            return (conditionExpression, parameterExpression);
        }

        private Expression<Func<T, bool>> CreateFullKeyExpression(int firstId, int secondId)
        {
            var (firstConditionExpression, parameterExpression) = CreateSingleIdExpressionArguments(firstId, true);
            // Expression <=> entity.SecondKeyName
            var getSecondPropertyExpression = Expression.Property(parameterExpression, _keyPropertiesNames.Last());
            // Expression <=> secondId
            var secondIdExpression = Expression.Constant(secondId, typeof(int));
            // Expression <=> entity.secondKeyName == secondId
            var secondConditionExpression = Expression.Equal(
                getSecondPropertyExpression,
                secondIdExpression);
            //Expression <=> entity.firstKeyName == firstId && entity.secondKeyName == secondId
            var fullConditionExpression = Expression.AndAlso(
                firstConditionExpression,
                secondConditionExpression);
            //Expression <=> entity => entity.firstKeyName == firstId && entity.secondKeyName == secondId
            //Lambda expression can be interpreted as creating lambada arrow (=>) node in a expression tree. 
            return Expression.Lambda<Func<T, bool>>(fullConditionExpression, parameterExpression);
        }
    }
}
