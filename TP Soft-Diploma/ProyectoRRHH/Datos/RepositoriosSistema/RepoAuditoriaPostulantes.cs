using Modelo.Sistema;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.RepositoriosSistema
{
    public class RepoAuditoriaPostulantes : RepositorioMaestro
    {
        private string connectionString;
        public RepoAuditoriaPostulantes()
        {

            connectionString = ConfigurationManager.ConnectionStrings["Modelo"].ConnectionString;
        }

        public string ObtenerValoresOriginales(int numeroPostulante)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return ObtenerValoresOriginales(numeroPostulante, connection); 
            }
        }

        //Al dar de alta un postulante
        public void Insertar(AuditoriaPostulantes auditoria)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "INSERT INTO AuditoriaPostulantes (accion, usuario, valoresOriginales, valoresNuevos) " +
                            "VALUES (@accion, @usuario, @valoresOriginales, @valoresNuevos)";
                //No se guarda el ID del postulante, ya que si se va de la empresa, 
                //se le remueve el numero y se le otorga a otro. 
                //En caso de volver, tendra un ID nuevo
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@accion", "Creacion");
                command.Parameters.AddWithValue("@usuario", auditoria.usuario);
                command.Parameters.AddWithValue("@valoresOriginales", (object)auditoria.valoresOriginales ?? DBNull.Value);
                command.Parameters.AddWithValue("@valoresNuevos", (object)auditoria.valoresNuevos ?? DBNull.Value);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Actualizar(AuditoriaPostulantes auditoria)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "INSERT INTO AuditoriaPostulantes (accion, usuario, valoresOriginales, valoresNuevos) " +
                            "VALUES (@accion, @usuario, @valoresOriginales, @valoresNuevos)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idAuditoria", auditoria.idAuditoria);
                    command.Parameters.AddWithValue("@accion", "Actualización");
                    command.Parameters.AddWithValue("@usuario", auditoria.usuario);
                    command.Parameters.AddWithValue("@valoresOriginales", (object)auditoria.valoresOriginales ?? DBNull.Value);
                    command.Parameters.AddWithValue("@valoresNuevos", (object)auditoria.valoresNuevos ?? DBNull.Value);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        //Cuando se elimine, se guarda la accion con los ultimos datos registardos
        public void Eliminar(int numeroPostulante, string usuario)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Obtener los valores originales del postulante
                string valoresOriginales = ObtenerValoresOriginales(numeroPostulante, connection);

                if (string.IsNullOrEmpty(valoresOriginales))
                {
                    throw new Exception($"No se encontró el postulante con el número {numeroPostulante}.");
                }

                // Registrar la acción de eliminación en la auditoría
                RegistrarAuditoriaEliminacion(numeroPostulante, usuario, valoresOriginales, connection);
            }
        }

        private string ObtenerValoresOriginales(int numeroPostulante, SqlConnection connection)
        {
            var query = "SELECT nombre, apellido, mail FROM Postulantes WHERE numero = @numero";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@numero", numeroPostulante);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return $"Nombre: {reader["nombre"]}, Apellido: {reader["apellido"]}, Email: {reader["mail"]}";
                    }
                }
            }

            return null;
        }

        private void RegistrarAuditoriaEliminacion(int numeroPostulante, string usuario, string valoresOriginales, SqlConnection connection)
        {
            var query = "INSERT INTO AuditoriaPostulantes (accion, usuario, valoresOriginales, valoresNuevos) " +
                        "VALUES (@accion, @usuario, @valoresOriginales, NULL)";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@accion", "Eliminación");
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@valoresOriginales", valoresOriginales);

                command.ExecuteNonQuery();
            }
        }


    }
}
