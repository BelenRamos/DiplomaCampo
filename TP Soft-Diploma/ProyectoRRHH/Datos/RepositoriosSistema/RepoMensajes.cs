using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Datos
{
    public class RepoMensajes : RepositorioMaestro
    {
        private string connectionString;

        public RepoMensajes()
        {
            // Obtener la cadena de conexión desde la configuración
            connectionString = ConfigurationManager.ConnectionStrings["Modelo"].ConnectionString;
        }

        public List<Mensajes> GetMensajes()
        {
            var mensajes = new List<Mensajes>();

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT numero, asunto, contenido, emisor, receptor FROM Mensajes", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var mensaje = new Mensajes
                        {
                            numero = reader.GetInt32(0),
                            asunto = reader.IsDBNull(1) ? null : reader.GetString(1),
                            contenido = reader.IsDBNull(2) ? null : reader.GetString(2),
                            emisor = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                            receptor = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4)
                        };
                        mensajes.Add(mensaje);
                    }
                }
            }

            return mensajes;
        }

        public Mensajes ObtenerMensajePorNumero(int numero)
        {
            Mensajes mensaje = null;

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT numero, asunto, contenido, emisor, receptor FROM Mensajes WHERE numero = @numero", connection);
                command.Parameters.AddWithValue("@numero", numero);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        mensaje = new Mensajes
                        {
                            numero = reader.GetInt32(0),
                            asunto = reader.IsDBNull(1) ? null : reader.GetString(1),
                            contenido = reader.IsDBNull(2) ? null : reader.GetString(2),
                            emisor = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                            receptor = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4)
                        };
                    }
                }
            }

            return mensaje;
        }

        public List<Mensajes> ObtenerMensajesPorCliente(int clienteId)
        {
            var mensajes = new List<Mensajes>();

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT numero, asunto, contenido, emisor, receptor FROM Mensajes WHERE emisor = @clienteId OR receptor = @clienteId", connection);
                command.Parameters.AddWithValue("@clienteId", clienteId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var mensaje = new Mensajes
                        {
                            numero = reader.GetInt32(0),
                            asunto = reader.IsDBNull(1) ? null : reader.GetString(1),
                            contenido = reader.IsDBNull(2) ? null : reader.GetString(2),
                            emisor = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                            receptor = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4)
                        };
                        mensajes.Add(mensaje);
                    }
                }
            }

            return mensajes;
        }
    }
}
