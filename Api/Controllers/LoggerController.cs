using Domain.Interface.Domain.Log;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api")]
    public class LoggerController : ApiController
    {

        private readonly IDomainServiceLogger _logger;
        public LoggerController(IDomainServiceLogger logger)
        {
            this._logger = logger;
        }

        [HttpGet]
        [Route("log/getall")]
        //[Route("tecnicos/{id_tecnico:guid}/agendamentos/{data:datetime?}/{coluna?}/{orderdesc:bool?}/{page:int?}/{size:int?")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                // where

                return Request.CreateResponse(HttpStatusCode.OK, _logger.dapperGetAll());
            }
            catch (Exception ex)
            {
                _logger.GravarLog(ex, true);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
