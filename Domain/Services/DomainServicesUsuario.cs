using Domain.Entities;
using Domain.Interface.Domain;
using Domain.Interface.Domain.Email;
using Domain.Interface.Domain.Log;
using Domain.Interface.Infrastructure;
using Domain.Interface.Repositories;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using static Domain.Services.Email.DomainEmailServices;

namespace Domain.Services
{
    public class DomainServicesUsuario : DomainServiceBase<Usuario>, IDomainServiceUsuario
    {
        private readonly IGenericRepository<Usuario> _repository;
        private readonly IDomainServiceEmail _serviceEmail;
        private readonly IUnitOfWork _uow;
<<<<<<< HEAD
        private readonly IDapperRepository _dapper;        
=======
        private readonly IDapperRepository _dapper;
        private readonly ILog _logger;
>>>>>>> bda26d952f67ba685a8e18ac1b7add367b4885ca

        public DomainServicesUsuario(IUnitOfWork uow, IDapperRepository dapper, IGenericRepository<Usuario> repository, IDomainServiceEmail serviceEmail) 
            :base(repository, dapper, uow)
        {
            this._uow = uow;
            this._dapper = dapper;
            this._repository = repository;
<<<<<<< HEAD
            this._serviceEmail = serviceEmail;            
=======
            this._serviceEmail = serviceEmail;   
            
            this._logger = LogManager.GetLogger("LogInFile");            
>>>>>>> bda26d952f67ba685a8e18ac1b7add367b4885ca
        }


        /// <summary>
        /// Esse metódo cria um usuário no bd, disparar e-mail do usuário e grava logsystem.        
        /// </summary>
        /// <param name="model"></param>
        public void CriarUsuario(Usuario model)
        {
            // persiste bd
            _repository.Add(model);
            _uow.Commit();            

            // envia e-mail para usuario            
            _serviceEmail.EnviarEmailTemaplate(
                new string[] { model.Email }, 
                "Template Cadastro Usuário", 
                "Parabéns, seu cadastro foi realizado com sucesso.<br/>Data/Hora Cadastro: " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now), 
                eTemplateEmail.PrimeiroCadastro);

            // grava log
            _logger.Info(JsonConvert.SerializeObject(model));         
        }

        public void RecuperarSenha(string email)
        {
            var usuario = _repository.GetAll().FirstOrDefault(a => a.Email == email);
            if (usuario != null)
            {
                // enviar email
                // criar servico de envio de email nos formatos parameter{acc: recuperarsenha(enum) , primeiro cadastro .... bla bla }             
            }
        }

        public void AlterarSenha(string email, string senhaAntigo, string senhaNova)
        {
            // envial email
            // senha antiga service email            
        }

        public ICollection<Usuario> ListarUsuarios()
        {
<<<<<<< HEAD
            //return dapperGetAll("select * from usuario order by idusuario desc", null);
            return entityGetAll().ToList();
=======
            return dapperGetAll("select * from usuario order by idusuario desc", null);
>>>>>>> bda26d952f67ba685a8e18ac1b7add367b4885ca
        }
   
        public Usuario LogarUsuario(string email, string senha)
        {
            return _repository.First(a => a.Email == email && a.Senha == senha);
        }

        public Usuario RetornarPorEmail(string email)
        {
            return _repository.First(a => a.Email == email);
        }

    }
}
