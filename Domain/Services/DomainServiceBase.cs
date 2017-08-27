using Domain.Interface.Domain;
using Domain.Interface.Infrastructure;
using Domain.Interface.Repositories;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Services
{
    public class DomainServiceBase<T> : IDomainServiceBase<T> where T : class
    {
        protected readonly ILog _logger;        
        private readonly IUnitOfWork _uow;
        private readonly IGenericRepository<T> _repository;        
        private readonly IDapperRepository _dapper;

        public DomainServiceBase(IGenericRepository<T> repository, IDapperRepository dapper, IUnitOfWork uow)
        {
            this._repository = repository;
            this._dapper = dapper;
            this._uow = uow;
            
            _logger = LogManager.GetLogger("LogInFile");
        }

        public ICollection<T> dapperGetAll(string sql, object[] parameter, bool procecure = false)
        {
            return _dapper.GetAll<T>(sql, parameter, procecure);
        }

        public T Detalhe(int Id)
        {
            return _repository.First(Id);
        }

        public T Detalhe(Expression<Func<T, bool>> predicate)
        {
            return _repository.First(predicate);
        }

        public ICollection<T> entityGetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
                return _repository.GetAll().Where(predicate).ToList();
            else
                return _repository.GetAll().ToList();
        }

        public void Inserir(T model)
        {
            _repository.Add(model);
            _uow.Commit();
        }

        public void Remover(int Id)
        {
            _repository.Delete(Detalhe(Id));
            _uow.Commit();
        }

        public void Remover(T model)
        {
            _repository.Delete(model);
            _uow.Commit();
        }

        public void Salvar(T model)
        {
            _repository.Edit(model);
            _uow.Commit();
        }
    }
}
