using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Interface.Domain.Log
{
    public interface IDomainServiceLogger
    {
        void GravarLog(Exception ex, bool sendEmail = false);

        void Error(string message);        
        void Debug(string message);
        void Info(string message);
        void Fatal(string message);
        void Warning(string message);

        ICollection<LogSystem> entityGetAll();
        ICollection<LogSystem> dapperGetAll();
    }
}
