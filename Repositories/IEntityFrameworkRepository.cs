using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Teste_Trinks.Repositories
{
    public interface IEntityFrameworkRepository<T>
    {
        int Count(Expression<Func<T, bool>> predicate);
        bool Exists(Expression<Func<T, bool>> predicate);
        T CreateNew();
        void Delete(T entity);
        void DeleteById(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate, int skip = 0, int take = 0);
        void Insert(T entity);
        void Update(T entity);
    }
}
