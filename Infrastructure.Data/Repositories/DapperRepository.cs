using Dapper;
using Domain.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Infrastructure.Data.Repositories
{
    public class DapperRepository : IDapperRepository
    {

        private string GetConnectionString
        {
            get
            {
                return Convert.ToString(ConfigurationManager.ConnectionStrings["conexao"]);
            }
        }

        private string pathFileSQL = Convert.ToString(HttpContext.Current.Request.ServerVariables["appl_physical_path"]) + "\\Domain\\SQL";
        public string LoadFileSQL(string pathSql)
        {
            pathSql = pathFileSQL + "\\" + pathSql;
            if (File.Exists(pathSql))
            {
                string sqlFile = File.ReadAllText(pathSql);
                return sqlFile;
            }

            return string.Empty;
        }

        public void Execute<T>(string query, T model, bool procedure = false)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString))
            {
                sqlConnection.Execute(query, model, commandType: (procedure ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text));                
            }
        }

        public T FirstOrDefault<T>(string query, object[] parameter, bool procedure = false)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString))
            {
                var retorno = sqlConnection.QueryFirstOrDefault<T>(query, parameter, commandType: (procedure ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text));
                return retorno;
            }
        }

        public IList<T> GetAll<T>(string query, object[] parameter, bool procedure = false)
        {         
            using (var sqlConnection = new SqlConnection(GetConnectionString))
            {         
                var retorno = sqlConnection.Query<T>(query, parameter, commandType: (procedure ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text));                
                return retorno.ToList();
            }
        }
    }
}
