using Domain.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class AdoRepository : IAdoRepository
    {

        private static List<T> ToListaDataReader<T>(IDataReader dataReader)
        {
            List<T> list = new List<T>();
            T instance = default(T);
            while (dataReader.Read())
            {
                instance = Activator.CreateInstance<T>();
                foreach (PropertyInfo property in instance.GetType().GetProperties())
                {
                    try
                    {
                        if (!object.Equals(dataReader[property.Name], DBNull.Value))
                        {
                            property.SetValue(instance, dataReader[property.Name], null);
                        }
                    }
                    catch { }
                }
                list.Add(instance);
            }
            return list;
        }

        public IList<T> GetDataGeneric<T>(SqlParameter[] parameters, string sql, bool procedure = false, string conexao = "conexao")
        {
            List<T> items = new List<T>();

            using (SqlConnection conn = new SqlConnection(GetConnectingString(conexao)))
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.CommandType = (procedure == true ? CommandType.StoredProcedure : CommandType.Text);
                    if (parameters != null)
                    {
                        command.Parameters.Clear();
                        //command.Parameters.AddRange(parameters);
                        foreach (var param in parameters)
                        {
                            command.Parameters.Add(param);
                        }
                    }

                    conn.Open();
                    var reader = command.ExecuteReader();
                    items = ToListaDataReader<T>(reader);
                    conn.Close();
                }
            }


            return items;
        }

        public int ExecuteSQL(SqlParameter[] parameters, string sql, bool procedure = false, string conexao = "conexao")
        {
            int retorno = 0;
            using (SqlConnection conn = new SqlConnection(GetConnectingString(conexao)))
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.CommandType = (procedure == true ? CommandType.StoredProcedure : CommandType.Text);
                    if (parameters != null)
                    {
                        command.Parameters.Clear();
                        foreach (var param in parameters)
                        {
                            command.Parameters.Add(param);
                        }
                    }

                    conn.Open();
                    retorno = Convert.ToInt32(command.ExecuteScalar());
                    conn.Close();
                }
            }

            return retorno;
        }

        public string ExecuteSQLString(SqlParameter[] parameters, string sql, bool procedure = false, string conexao = "conexao")
        {
            string retorno = string.Empty;
            using (SqlConnection conn = new SqlConnection(GetConnectingString(conexao)))
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.CommandType = (procedure == true ? CommandType.StoredProcedure : CommandType.Text);
                    if (parameters != null)
                    {
                        command.Parameters.Clear();
                        foreach (var param in parameters)
                        {
                            command.Parameters.Add(param);
                        }
                    }

                    conn.Open();
                    retorno = Convert.ToString(command.ExecuteScalar());
                    conn.Close();
                }
            }

            return retorno;
        }


        public DataTable GetDataTable(SqlParameter[] parameters, string sql, bool procedure = false, string conexao = "conexao")
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(GetConnectingString(conexao)))
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.CommandType = (procedure == true ? CommandType.StoredProcedure : CommandType.Text);
                    if (parameters != null)
                    {
                        command.Parameters.Clear();
                        //command.Parameters.AddRange(parameters);
                        foreach (var param in parameters)
                        {
                            command.Parameters.Add(param);
                        }
                    }

                    conn.Open();
                    var reader = command.ExecuteReader();
                    dt.Load(reader);
                    conn.Close();
                }
            }

            return dt;
        }

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        private string GetConnectingString(string conexao = "conexao")
        {
            return ConfigurationManager.ConnectionStrings[conexao].ToString();
        }
       
    }
}
