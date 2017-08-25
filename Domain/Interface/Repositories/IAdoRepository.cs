using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repositories
{
    public interface IAdoRepository
    {
        IList<T> GetDataGeneric<T>(SqlParameter[] parameters, string sql, bool procedure = false, string conexao = "conexao");
        int ExecuteSQL(SqlParameter[] parameters, string sql, bool procedure = false, string conexao = "conexao");
        string ExecuteSQLString(SqlParameter[] parameters, string sql, bool procedure = false, string conexao = "conexao");
        DataTable GetDataTable(SqlParameter[] parameters, string sql, bool procedure = false, string conexao = "conexao");
        DataTable ConvertToDataTable<T>(IList<T> data);
    }
}
