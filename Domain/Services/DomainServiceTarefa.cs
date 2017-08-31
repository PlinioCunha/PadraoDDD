using Domain.Entities;
using Domain.Interface.Domain;
using Domain.Interface.Domain.Email;
using Domain.Interface.Infrastructure;
using Domain.Interface.Repositories;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public class DomainServiceTarefa: DomainServiceBase<Tarefa>, IDomainServiceTarefa
    {                
        private readonly IUnitOfWork _uow;
        private readonly GenericRepository<Tarefa> _repository;        
        private readonly IDapperRepository _dapper;
  
        public DomainServiceTarefa(GenericRepository<Tarefa> repository, IDapperRepository dapper, IUnitOfWork uow) : base(repository, dapper, uow)
        {            
            this._repository = repository;
            this._dapper = dapper;
            this._uow = uow;
            
            //_logger.Info("Teste - ModeOn Service Tarefa");
        }

        public void AlterarPrioridadeTarefa(int Id, int IdPrioridade)
        {
            
            throw new NotImplementedException();            
        }

        public void AlterarStatusTarefa(int Id, int IdStatusTarefa)
        {
            throw new NotImplementedException();
            
        }

        public void SalvarTarefa(Tarefa model)
        {
            if (model.IdTarefa == 0)
                _repository.Add(model);
            else
                _repository.Edit(model);

            _uow.Commit();
        }
        

      
    }
}
