using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Domain
{
    public interface IDomainServiceTarefa : IDomainServiceBase<Tarefa>
    {       
        void AlterarStatusTarefa(int Id, int IdStatusTarefa);
        void AlterarPrioridadeTarefa(int Id, int IdPrioridade);
    }
}
