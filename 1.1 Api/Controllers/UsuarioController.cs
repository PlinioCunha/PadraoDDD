
using Domain.Interface.Domain;
using Domain.Interface.Domain.Log;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1._1_Api.Controllers
{
    [RoutePrefix("api")]
    public class UsuarioController : ApiController
    {

        private readonly IDomainServiceUsuario _domainServiceUsuario;
        private readonly IDomainServiceLogger _logger;        

        public UsuarioController(
            IDomainServiceUsuario domainServiceUsuario,
            IDomainServiceLogger logger)
        {
            this._domainServiceUsuario = domainServiceUsuario;
            this._logger = logger;
        }

        [HttpGet]
        [Route("usuario/create")]
        public HttpResponseMessage CreateUsuario()
        {
            try
            {
                var user = new Domain.Entities.Usuario();

                user.DataCadastro = DateTime.Now;
                user.Email = "pliniocunha@hotmail.com";
                user.Foto = "pix.jpg";
                user.IdPerfilUsuario = 1;
                user.Nome = "Plínio Cunha 1";
                user.PublicKeySocial = "pix";
                user.Senha = "pix";
                user.SenhaKey = "pix";

                _domainServiceUsuario.CriarUsuario(user);
                
                return Request.CreateResponse(HttpStatusCode.OK, "Usuário cadastro com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.GravarLog(ex, true);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        [Route("usuario/create")]
        public HttpResponseMessage CreateUsuario(Domain.Entities.Usuario model)
        {
            try
            {
               //if (!ModelState.IsValid)
               //     return Request.CreateResponse(HttpStatusCode.InternalServerError, "Favor preencher todos os campos obrigatórios");

                model.DataCadastro = DateTime.Now;
                
                _domainServiceUsuario.CriarUsuario(model);
                return Request.CreateResponse(HttpStatusCode.OK, "Usuário cadastro com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.GravarLog(ex, true);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        [Route("usuario/get/{id:int}")]
        public HttpResponseMessage GetId(int Id)
        {
            try
           {
                var retorno = Id > 0 ? _domainServiceUsuario.Detalhe(Id) : null;

                if (retorno != null)
                    return Request.CreateResponse(HttpStatusCode.OK, retorno);
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                _logger.GravarLog(ex, true);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        [HttpGet]
        [Route("usuario/listar")]
        public HttpResponseMessage ListarUsuarios()
        {
            try
            {
                var retorno = _domainServiceUsuario.ListarUsuarios();                

                _logger.Debug("Rows Count: " + retorno.Count);
                return Request.CreateResponse(HttpStatusCode.OK, retorno);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }

}
