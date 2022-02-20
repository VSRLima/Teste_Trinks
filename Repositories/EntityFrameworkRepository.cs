using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Teste_Trinks.DAL;

namespace Teste_Trinks.Repositories
{
    public class EntityFrameworkRepository<T> : IEntityFrameworkRepository<T> where T : class, new ()
    {
        protected readonly ProcessContext context;
        protected readonly DbSet<T> entities;

        public EntityFrameworkRepository(ProcessContext aContext)
        {
            context = aContext;
        }

        public EntityFrameworkRepository(ProcessContext aContext, DbSet<T> entSet)
        {
            context = aContext;
            entities = entSet;
        }

        protected virtual IEnumerable<T> Find<I>(Expression<Func<I, bool>> predicate, int skip = 0, int take = 0)
        {
            if (entities == null)
                return Enumerable.Empty<T>();

            var exppar = predicate.Parameters.First();
            var exp = Expression.Lambda<Func<T, bool>>(predicate.Body, exppar);

            var result = entities.Where(exp).Skip(skip);

            if (take > 0) result = result.Take(take);

            return result;
        }

        protected virtual int Count<I>(Expression<Func<I, bool>> predicate)
        {
            if (entities == null)
                return 0;

            var exppar = predicate.Parameters.First();
            var exp = Expression.Lambda<Func<T, bool>>(predicate.Body, exppar);

            return entities.Count(exp);
        }

        protected virtual bool Exists<I>(Expression<Func<I, bool>> predicate)
        {
            if (entities == null)
                return false;

            var exppar = predicate.Parameters.First();
            var exp = Expression.Lambda<Func<T, bool>>(predicate.Body, exppar);

            return entities.Any(exp);
        }

        public virtual T CreateNew()
        {
            return new T();
        }

        public virtual void Delete(T entity)
        {
            context.Remove(entity);
        }

        public virtual void DeleteById(int id)
        {
            var result = CreateNew();

            Delete(result);
        }

        public virtual T GetById(int id)
        {
            return context.Find<T>(id);
        }

        public virtual void Insert(T entity)
        {
            context.Add(entity);
        }

        public virtual void Update(T entity)
        {
            context.Update(entity);
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate, int skip = 0, int take = 0)
        {
            if (entities == null)
                return Enumerable.Empty<T>();

            var result = entities.Where(predicate).Skip(skip);

            if (take > 0)
                result = result.Take(take);

            return result;
        }

        public virtual int Count(Expression<Func<T, bool>> predicate)
        {
            if (entities == null) return 0;

            return entities.Count(predicate);
        }

        public virtual bool Exists(Expression<Func<T, bool>> predicate)
        {
            if (entities == null) return false;

            return entities.Any(predicate);
        }

    }
}


