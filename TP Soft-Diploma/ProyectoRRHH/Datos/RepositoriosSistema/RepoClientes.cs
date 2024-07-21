using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Datos
{
    public class RepoClientes : RepositorioMaestro
    {
        private string connectionString;

        public RepoClientes()
        {
            // Obtener la cadena de conexión desde la configuración
            connectionString = ConfigurationManager.ConnectionStrings["Modelo"].ConnectionString;
        }

        public List<Clientes> GetClientes()
        {
            var clientes = new List<Clientes>();

            using (var connection = new SqlConnection(connectionString))
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

        public Clientes ObtenerClienteById(int id)
        {
            Clientes cliente = null;

            using (var connection = new SqlConnection(connectionString))
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

        public void AgregarCliente(Clientes cliente)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("INSERT INTO Clientes (id, nombre, mail) VALUES (@id, @nombre, @mail)", connection);
                command.Parameters.AddWithValue("@id", cliente.id);
                command.Parameters.AddWithValue("@nombre", cliente.nombre);
                command.Parameters.AddWithValue("@mail", cliente.mail);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void ActualizarCliente(Clientes cliente)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("UPDATE Clientes SET nombre = @nombre, mail = @mail WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", cliente.id);
                command.Parameters.AddWithValue("@nombre", cliente.nombre);
                command.Parameters.AddWithValue("@mail", cliente.mail);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public int EliminarCliente(int id)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    conexion.Open();
                    transaction = conexion.BeginTransaction();

                    // Eliminar los teléfonos del cliente
                    string consultaEliminarTelefonos = "DELETE FROM Clientes_Telefonos WHERE id_cliente = @id_cliente";
                    using (SqlCommand comandoEliminarTelefonos = new SqlCommand(consultaEliminarTelefonos, conexion, transaction))
                    {
                        comandoEliminarTelefonos.Parameters.AddWithValue("@id_cliente", id);
                        comandoEliminarTelefonos.ExecuteNonQuery();
                    }

                    // Eliminar el cliente
                    string consultaEliminarCliente = "DELETE FROM Clientes WHERE id = @id";
                    using (SqlCommand comandoEliminarCliente = new SqlCommand(consultaEliminarCliente, conexion, transaction))
                    {
                        comandoEliminarCliente.Parameters.AddWithValue("@id", id);
                        comandoEliminarCliente.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return 1;
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                    throw new Exception("Error al eliminar el cliente", ex);
                }
            }
        }

        public int ObtenerTotalClientes()
        {
            int totalClientes = 0;

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT COUNT(*) FROM Clientes", connection);
                connection.Open();
                totalClientes = (int)command.ExecuteScalar();
            }

            return totalClientes;
        }

        public int ObtenerUltimoId()
        {
            string consultaSQL = "SELECT ISNULL(MAX(id), 0) FROM Clientes";
            try
            {
                DataTable result = ExecuteReader(consultaSQL);
                if (result.Rows.Count > 0)
                {
                    return Convert.ToInt32(result.Rows[0][0]);
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el último id del cliente", ex);
            }
        }
    }
}
