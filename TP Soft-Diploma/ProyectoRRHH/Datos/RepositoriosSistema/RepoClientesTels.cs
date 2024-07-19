using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Datos
{
    public class RepoClientesTelefonos
    {
        private readonly string _connectionString;

        public RepoClientesTelefonos(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Clientes_Telefonos> GetTelefonosByClienteId(int id_cliente)
        {
            var telefonos = new List<Clientes_Telefonos>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT id_cliente, telefono FROM Clientes_Telefonos WHERE id_cliente = @id_cliente", connection);
                command.Parameters.AddWithValue("@id_cliente", id_cliente);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var telefono = new Clientes_Telefonos
                        {
                            id_cliente = reader.GetInt32(0),
                            telefono = reader.GetString(1)
                        };
                        telefonos.Add(telefono);
                    }
                }
            }

            return telefonos;
        }

        public void AddTelefono(Clientes_Telefonos telefono)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Clientes_Telefonos (id_cliente, telefono) VALUES (@id_cliente, @telefono)", connection);
                command.Parameters.AddWithValue("@id_cliente", telefono.id_cliente);
                command.Parameters.AddWithValue("@telefono", telefono.telefono);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteTelefono(int id_cliente, string telefono)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("DELETE FROM Clientes_Telefonos WHERE id_cliente = @id_cliente AND telefono = @telefono", connection);
                command.Parameters.AddWithValue("@id_cliente", id_cliente);
                command.Parameters.AddWithValue("@telefono", telefono);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
