using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public class DomainServicesUsuario : Interface.Domain.IDomainServiceUsuario
    {
        private readonly Interface.Repositories.IRepositoryUsuario _repositoryUsuario;
        private readonly Interface.Infrastructure.IUnitOfWork _unitOfWork;


        public DomainServicesUsuario(
            Interface.Repositories.IRepositoryUsuario repositoryUsuario,
            Interface.Infrastructure.IUnitOfWork unitOfWork)
        {
            this._repositoryUsuario = repositoryUsuario;
            this._unitOfWork = unitOfWork;

        }

        public void CriarUsuario(Usuario model)
        {
            _repositoryUsuario.Add(model);
            _unitOfWork.Commit();
        }

        public IList<Usuario> Listar()
        {
            return _repositoryUsuario.GetAll().ToList();
        }

        public Usuario LogarUsuario(string email, string senha)
        {
            // as regras devem estar todas no domain
            // enviar email, mensagem de erro, validação.

            return _repositoryUsuario.LogarUsuario(email, senha);
        }

        public Usuario RetornarPorEmail(string email)
        {
            return _repositoryUsuario.RetornarPorEmail(email);
        }
    }
}
