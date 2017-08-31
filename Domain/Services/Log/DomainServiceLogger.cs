using Domain.Entities;
using Domain.Interface.Domain.Email;
using Domain.Interface.Domain.Log;
using Domain.Interface.Repositories;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Domain.Services.Log
{
    public class DomainServiceLogger : IDomainServiceLogger

    {
        private readonly ILog _logger;
        private readonly IDomainServiceEmail _emailService;
        private readonly GenericRepository<LogSystem> _repositoryLog;
        private readonly IDapperRepository _dapper;

        public DomainServiceLogger(IDomainServiceEmail emailService, GenericRepository<LogSystem> repositoryLog, IDapperRepository dapper)
        {
            this._emailService = emailService;
            this._repositoryLog = repositoryLog;
            this._dapper = dapper;

            log4net.Config.XmlConfigurator.Configure();
            _logger = LogManager.GetLogger("LogInFile");
        }

        public void GravarLog(System.Exception ex, bool sendEmail = false)
        {
            // add controller/action

            // Grava Log
            _logger.Error(JsonConvert.SerializeObject(ex));

            if (sendEmail)
            {
                try
                {
                    string sistema = Convert.ToString(ConfigurationManager.AppSettings["email_erro_assunto"]);
                    _emailService.EnviarEmailErro("Error: " + sistema, ex.ToString());
                }
                finally { }
            }
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }

        public void Warning(string message)
        {
            _logger.Warn(message);
        }

        public ICollection<LogSystem> dapperGetAll()
        {
            return _repositoryLog.GetAll().OrderByDescending(a => a.Date).ToList();
        }

        public ICollection<LogSystem> entityGetAll()
        {
            return _repositoryLog.GetAll().OrderByDescending(a => a.Date).ToList();
        }
    }
}
