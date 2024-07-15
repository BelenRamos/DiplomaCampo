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
        private readonly string _connectionString;

        public RepoPermisos()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Modelo"].ConnectionString;
        }

        public IEnumerable<Permisos> ObtenerTodos()
        {
            var permisos = new List<Permisos>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
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

            using (SqlConnection connection = new SqlConnection(_connectionString))
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
            using (SqlConnection connection = new SqlConnection(_connectionString))
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
            using (SqlConnection connection = new SqlConnection(_connectionString))
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
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Permisos WHERE idPermiso = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }
    }
}
