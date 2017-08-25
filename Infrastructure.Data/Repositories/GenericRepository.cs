using Domain.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Infrastructure.Data.Context;
using Infrastructure.Data.Configuration;
using Microsoft.Practices.ServiceLocation;
using Domain.Interface.Infrastructure;
using System.Data.Entity;

namespace Infrastructure.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ContextoBanco _context;

        public GenericRepository()
        {
            // Service locator = Gerencia uma instancia do ManagerContext
            var gerenciador = (ManagerContext)ServiceLocator.Current.GetInstance<IManagerContext>();
            _context = gerenciador.Contexto;
        }

        public void Add(T entity)
        {
            //_context.Entry(entity).State = EntityState.Added;
            _context.Set<T>().Add(entity);
        }        

        public void Delete(T entity)
        {
            //_context.Entry(entity).State = EntityState.Deleted;
            _context.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public T First(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).AsQueryable();
        }
    }
}
