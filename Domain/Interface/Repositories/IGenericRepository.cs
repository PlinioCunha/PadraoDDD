using System;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Interface.Repositories
{
    public interface IGenericRepository<T> where T : class
    {        
        IQueryable<T> GetAll();
        T First(int Id);
        T First(Expression<Func<T, Boolean>> predicate);
        IQueryable<T> Search(Expression<Func<T, Boolean>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
