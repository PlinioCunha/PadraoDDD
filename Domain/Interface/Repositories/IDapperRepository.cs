using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repositories
{
    public interface IDapperRepository 
    {
        IList<T> GetAll<T>(string query, object[] parameter, bool procedure = false);
        T FirstOrDefault<T>(string query, object[] parameter, bool procedure = false);
        void Execute<T>(string query, T model, bool procedure = false);
    }
}
