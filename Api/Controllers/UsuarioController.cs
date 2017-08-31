using Domain.Interface.Domain;
using Domain.Interface.Domain.Log;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
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

        [Authorize]
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

        [Authorize]
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
