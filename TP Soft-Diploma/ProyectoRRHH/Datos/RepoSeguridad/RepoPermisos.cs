using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Datos
{
    public class RepoPermisos
    {
        private readonly string connectionString;

        public RepoPermisos()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Modelo"].ConnectionString;
        }

        public IEnumerable<Permisos> ObtenerTodos()
        {
            var permisos = new List<Permisos>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Permisos", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var permiso = new Permisos
                    {
                        idPermiso = (int)reader["idPermiso"],
                        nombrePermiso = reader["nombrePermiso"].ToString(),
                        idForm = reader["idForm"] as int?
                    };

                    permisos.Add(permiso);
                }
            }

            return permisos;
        }

        public Permisos ObtenerPorId(int id)
        {
            Permisos permiso = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Permisos WHERE idPermiso = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    permiso = new Permisos
                    {
                        idPermiso = (int)reader["idPermiso"],
                        nombrePermiso = reader["nombrePermiso"].ToString(),
                        idForm = reader["idForm"] as int?
                    };
                }
            }

            return permiso;
        }

        public void Agregar(Permisos permiso)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "INSERT INTO Permisos (idPermiso, nombrePermiso, idForm) VALUES (@idPermiso, @nombrePermiso, @idForm)", connection);

                command.Parameters.AddWithValue("@idPermiso", permiso.idPermiso);
                command.Parameters.AddWithValue("@nombrePermiso", permiso.nombrePermiso);
                command.Parameters.AddWithValue("@idForm", permiso.idForm);

                command.ExecuteNonQuery();
            }
        }

        public void Actualizar(Permisos permiso)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "UPDATE Permisos SET nombrePermiso = @nombrePermiso, idForm = @idForm WHERE idPermiso = @idPermiso", connection);

                command.Parameters.AddWithValue("@idPermiso", permiso.idPermiso);
                command.Parameters.AddWithValue("@nombrePermiso", permiso.nombrePermiso);
                command.Parameters.AddWithValue("@idForm", permiso.idForm);

                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Permisos WHERE idPermiso = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }

        public List<int> ObtenerPermisosPorUsuario(int idUsuario)
        {
            List<int> permisos = new List<int>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT idPermiso 
                             FROM Usuarios_Permisos 
                             WHERE idUsuario = @idUsuario";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idUsuario", idUsuario);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    permisos.Add(reader.GetInt32(0));
                }
            }

            return permisos;
        }

        public List<int> ObtenerPermisosPorGrupo(int idGrupo)
        {
            List<int> permisos = new List<int>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT idPermiso 
                             FROM Permisos_Grupos 
                             WHERE idGrupo = @idGrupo";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idGrupo", idGrupo);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    permisos.Add(reader.GetInt32(0));
                }
            }

            return permisos;
        }
    }
}
