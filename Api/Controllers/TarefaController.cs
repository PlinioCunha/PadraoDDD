using Domain.Interface.Domain;
using Domain.Interface.Domain.Log;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api")]
    public class TarefaController : ApiController
    {
        private readonly IDomainServiceLogger _logger;
        private readonly IDomainServiceTarefa _seriveTarefa;

        public TarefaController(IDomainServiceLogger logger, IDomainServiceTarefa serviceTarefa)
        {
            this._logger = logger;
            this._seriveTarefa = serviceTarefa;
        }

        [HttpGet]
        [Route("tarefa/getall")]
        //[Route("tecnicos/{id_tecnico:guid}/agendamentos/{data:datetime?}/{coluna?}/{orderdesc:bool?}/{page:int?}/{size:int?")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _seriveTarefa.entityGetAll());
            }
            catch (Exception ex)
            {
                _logger.GravarLog(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
