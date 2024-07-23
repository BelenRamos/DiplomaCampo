using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public abstract class RepositorioMaestro
    {
        protected static List<SqlParameter> parametros;

        protected RepositorioMaestro()
        {
            if (parametros == null)
            {
                parametros = new List<SqlParameter>(); // Solo se inicializa si es la primera instancia
            }
        }

        protected int ExecuteNonQuery(string transaccionSQL)
        {
            using (var connection = new SqlConnection("data source=.;initial catalog=db_RRHH;integrated security=True;encrypt=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework" ))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = transaccionSQL;
                    command.CommandType = CommandType.Text;
                    foreach (SqlParameter item in parametros)
                    {
                        command.Parameters.Add(item);
                    }
                    int result = command.ExecuteNonQuery();
                    parametros.Clear();
                    return result;
                }
            }
        }

        protected DataTable ExecuteReader(string transaccionSQL)
        {
            using (var connection = new SqlConnection("data source=.;initial catalog=db_RRHH;integrated security=True;encrypt=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework"))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = transaccionSQL;
                    command.CommandType = CommandType.Text;
                    foreach (SqlParameter item in parametros)
                    {
                        command.Parameters.Add(item);
                    }
                    SqlDataReader reader = command.ExecuteReader();
                    using (var table = new DataTable())
                    {
                        table.Load(reader);
                        reader.Dispose();
                        parametros.Clear(); // Limpiar la lista de parámetros
                        return table;
                    }
                }
            }
        }



        protected int ExecuteNonQuery(string query, SqlTransaction transaction)
        {
            using (SqlCommand comando = new SqlCommand(query, transaction.Connection, transaction))
            {
                foreach (var parametro in parametros)
                {
                    comando.Parameters.Add(parametro);
                }
                return comando.ExecuteNonQuery();
            }
        }

        private SqlConnection ObtenerConexion()
        {
            throw new NotImplementedException();
        }


    }
}
