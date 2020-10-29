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
        public virtual async Task<IEnumerable<T>> GetByFirstId(int firstId, int includeDepth)
        {
            var (conditionExpression, parameterExpression) = CreateFirstIdExpressionArguments(firstId);
            var query = Entities.Where(
                Expression.Lambda<Func<T, bool>>(conditionExpression, parameterExpression));

            if (includeDepth > 0)
            {
                return await  query.Include(Context.GetAllPaths(typeof(T))).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public virtual async Task<T> GetByFullKey(int firstId, int secondId, int includeDepth)
        {
            if (includeDepth > 0)
            {
                return await Entities.Include(Context.GetAllPaths(typeof(T)))
                    .FirstOrDefaultAsync(CreateFullKeyExpression(firstId, secondId));
            }

            return await Entities.FindAsync(firstId, secondId);
        }

        public virtual async Task Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Entities.Add(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteByFirstId(int firstId)
        {
            var (conditionExpression, parameterExpression) = CreateFirstIdExpressionArguments(firstId);
            var query = Entities.Where(
                Expression.Lambda<Func<T, bool>>(conditionExpression, parameterExpression)).ToList();
            Entities.RemoveRange(query);
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteByFullKey(int firstId, int secondId)
        {
            var entity = await Entities.FindAsync(firstId, secondId);

            if (entity == null) throw new ArgumentException("Wrong primary key");

            Entities.Remove(entity);
            await Context.SaveChangesAsync();
        }

        private (BinaryExpression, ParameterExpression) CreateFirstIdExpressionArguments(int firstId)
        {
            // Expression <=> entity (function argument)
            var parameterExpression = Expression.Parameter(typeof(T), "entity");
            // Expression <=> entity.firstKeyName
            var getPropertyExpression = Expression.Property(parameterExpression, _keyPropertiesNames.First());
            // Expression <=> firstId
            var firstIdExpression = Expression.Constant(firstId, typeof(int));
            // Expression <=> entity.firstKeyName == firstId
            var conditionExpression =  Expression.Equal(getPropertyExpression, firstIdExpression);
            return (conditionExpression, parameterExpression);
        }

        private Expression<Func<T, bool>> CreateFullKeyExpression(int firstId, int secondId)
        {
            var (firstConditionExpression, parameterExpression) = CreateFirstIdExpressionArguments(firstId);
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
