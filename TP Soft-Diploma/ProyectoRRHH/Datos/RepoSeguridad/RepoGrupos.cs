using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Datos
{
    public class RepoGrupos
    {
        private readonly string _connectionString;

        public RepoGrupos()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Modelo"].ConnectionString;
        }

        public IEnumerable<Grupos> ObtenerTodos()
        {
            var Grupos = new List<Grupos>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Grupos", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var grupos = new Grupos
                    {
                        idGrupo = (int)reader["idGrupo"],
                        nombreGrupo = reader["nombreGrupo"].ToString(),
                        habilitado = (byte?)reader["habilitado"]
                    };

                    Grupos.Add(grupos);
                }
            }

            return Grupos;
        }

        public Grupos ObtenerPorId(int id)
        {
            Grupos Grupos = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Grupos WHERE idGrupo = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Grupos = new Grupos
                    {
                        idGrupo = (int)reader["idGrupo"],
                        nombreGrupo = reader["nombreGrupo"].ToString(),
                        habilitado = (byte?)reader["habilitado"]
                    };
                }
            }

            return Grupos;
        }

        public void Agregar(Grupos Grupos)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "INSERT INTO Grupos (idGrupo, nombreGrupo, habilitado) VALUES (@idGrupo, @nombreGrupo, @habilitado)", connection);

                command.Parameters.AddWithValue("@idGrupo", Grupos.idGrupo);
                command.Parameters.AddWithValue("@nombreGrupo", Grupos.nombreGrupo);
                command.Parameters.AddWithValue("@habilitado", Grupos.habilitado);

                command.ExecuteNonQuery();
            }
        }

        public void Actualizar(Grupos Grupos)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "UPDATE Grupos SET nombreGrupo = @nombreGrupo, habilitado = @habilitado WHERE idGrupo = @idGrupo", connection);

                command.Parameters.AddWithValue("@idGrupo", Grupos.idGrupo);
                command.Parameters.AddWithValue("@nombreGrupo", Grupos.nombreGrupo);
                command.Parameters.AddWithValue("@habilitado", Grupos.habilitado);

                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Grupos WHERE idGrupo = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }
    }
}

