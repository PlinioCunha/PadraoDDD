using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1._1_Api.Controllers
{
    [RoutePrefix("api")]
    public class DefaultController : ApiController
    {

        Domain.Interface.Domain.IDomainServiceUsuario _domainServiceUsuario;
        public DefaultController(Domain.Interface.Domain.IDomainServiceUsuario domainServiceUsuario)
        {
            this._domainServiceUsuario = domainServiceUsuario;
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
                user.Nome = "Plínio Cunha";
                user.PublicKeySocial = "pix";
                user.Senha = "pix";
                user.SenhaKey = "pix";

                _domainServiceUsuario.CriarUsuario(user);

                return Request.CreateResponse(HttpStatusCode.OK, "Usuário cadastro com sucesso.");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocorreu uma falha.");
            }
        }

        [HttpGet]
        [Route("usuario/listar")]
        public HttpResponseMessage ListarUsuarios()
        {
            try
            {

                var retorno = new ArrayList();
                foreach (var item in _domainServiceUsuario.Listar())
                {
                    retorno.Add(new
                    {
                        Id = item.IdUsuario,
                        Nome = item.Nome,
                    });
                }

                return Request.CreateResponse(HttpStatusCode.OK, retorno);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocorreu uma falha.");
            }
        }

    }
}
