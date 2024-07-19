using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Datos
{
    public class RepoClientes
    {
        private readonly string _connectionString;

        public RepoClientes(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Clientes> GetClientes()
        {
            var clientes = new List<Clientes>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT id, nombre, mail FROM Clientes", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cliente = new Clientes
                        {
                            id = reader.GetInt32(0),
                            nombre = reader.GetString(1),
                            mail = reader.GetString(2)
                        };
                        clientes.Add(cliente);
                    }
                }
            }

            return clientes;
        }

        public Clientes GetClienteById(int id)
        {
            Clientes cliente = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT id, nombre, mail FROM Clientes WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cliente = new Clientes
                        {
                            id = reader.GetInt32(0),
                            nombre = reader.GetString(1),
                            mail = reader.GetString(2)
                        };
                    }
                }
            }

            return cliente;
        }

        public void AddCliente(Clientes cliente)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Clientes (id, nombre, mail) VALUES (@id, @nombre, @mail)", connection);
                command.Parameters.AddWithValue("@id", cliente.id);
                command.Parameters.AddWithValue("@nombre", cliente.nombre);
                command.Parameters.AddWithValue("@mail", cliente.mail);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateCliente(Clientes cliente)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("UPDATE Clientes SET nombre = @nombre, mail = @mail WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", cliente.id);
                command.Parameters.AddWithValue("@nombre", cliente.nombre);
                command.Parameters.AddWithValue("@mail", cliente.mail);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCliente(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("DELETE FROM Clientes WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}

