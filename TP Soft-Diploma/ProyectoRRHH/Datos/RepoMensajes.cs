using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Datos
{
    public class RepoMensajes : RepositorioMaestro
    {
        public List<Mensajes> ObtenerTodosLosMensajes()
        {
            List<Mensajes> mensajes = new List<Mensajes>();
            string consultaSQL = "SELECT * FROM Mensajes"; // Ajusta esto según el nombre de tu tabla de mensajes

            DataTable tablaMensajes = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaMensajes.Rows)
            {
                Mensajes mensaje = new Mensajes
                {
                    numero = Convert.ToInt32(fila["numero"]),
                    asunto = fila["asunto"].ToString(),
                    contenido = fila["contenido"].ToString(),
                    emisor = fila["emisor"] != DBNull.Value ? (int?)Convert.ToInt32(fila["emisor"]) : null,
                    receptor = fila["receptor"] != DBNull.Value ? (int?)Convert.ToInt32(fila["receptor"]) : null,
                    // Ajusta el mapeo de propiedades según tu clase Mensajes
                };
                mensajes.Add(mensaje);
            }
            return mensajes;
        }

        public List<Mensajes> ObtenerMensajePorNumero(int numeroMensaje)
        {
            List<Mensajes> mensajes = new List<Mensajes>();
            string consultaSQL = "SELECT * FROM Mensajes WHERE numero = @Numero_Mensaje";
            parametros.Add(new SqlParameter("@Numero_Mensaje", numeroMensaje));
            DataTable tablaMensajes = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaMensajes.Rows)
            {
                Mensajes mensaje = new Mensajes
                {
                    numero = Convert.ToInt32(fila["numero"]),
                    asunto = fila["asunto"].ToString(),
                    contenido = fila["contenido"].ToString(),
                    emisor = fila["emisor"] != DBNull.Value ? (int?)Convert.ToInt32(fila["emisor"]) : null,
                    receptor = fila["receptor"] != DBNull.Value ? (int?)Convert.ToInt32(fila["receptor"]) : null,
                    // Ajusta el mapeo de propiedades según tu clase Mensajes
                };
                mensajes.Add(mensaje);
            }
            return mensajes;
        }
    }
}
