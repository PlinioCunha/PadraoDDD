using Domain.Interface.Infrastructure;
using Infrastructure.Data.Context;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configuration
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ContextoBanco _context;
        public void Commit()
        {
            var gerenciador = ServiceLocator.Current.GetInstance<IManagerContext>() as ManagerContext;
            _context = gerenciador.Contexto;

            using (var dbTransaction = _context.Database.BeginTransaction())
            {
                try
                {                    
                    _context.SaveChanges();
                    dbTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                }
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
