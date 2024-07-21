using Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class RepoPostulantes : RepositorioMaestro
    {
        private string connectionString;
        public RepoPostulantes()
        {
            // Obtener la cadena de conexión desde la configuración
            connectionString = ConfigurationManager.ConnectionStrings["Modelo"].ConnectionString;
        }
        public List<Postulantes> ObtenerTodosLosPostulantes()
        {
            List<Postulantes> postulantes = new List<Postulantes>();
            string consultaSQL = "SELECT * FROM Postulantes";

            try
            {
                DataTable tablaPostulantes = ExecuteReader(consultaSQL);

                foreach (DataRow fila in tablaPostulantes.Rows)
                {
                    Postulantes postulante = new Postulantes
                    {
                        numero = Convert.ToInt32(fila["numero"]),
                        nombre = fila["nombre"].ToString(),
                        apellido = fila["apellido"].ToString(),
                        mail = fila["mail"].ToString(),
                        telefono = fila["telefono"].ToString(),
                        fechaNacimiento = fila["fechaNacimiento"] != DBNull.Value ? Convert.ToDateTime(fila["fechaNacimiento"]) : (DateTime?)null,
                        esCandidato = fila["esCandidato"] != DBNull.Value ? Convert.ToByte(fila["esCandidato"]) : (byte?)null
                    };
                    postulantes.Add(postulante);
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al obtener los postulantes", ex);
            }

            return postulantes;
        }

        public int AltaPostulante(Postulantes postulante)
        {
            string consultaSQL = @"INSERT INTO Postulantes (numero, nombre, apellido, mail, telefono, fechaNacimiento, esCandidato) 
                                   VALUES (@numero, @nombre, @apellido, @mail, @telefono, @fechaNacimiento, @esCandidato)";

            parametros.Clear();
            parametros.Add(new SqlParameter("@numero", postulante.numero));
            parametros.Add(new SqlParameter("@nombre", postulante.nombre ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@apellido", postulante.apellido ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@mail", postulante.mail ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@telefono", postulante.telefono ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@fechaNacimiento", postulante.fechaNacimiento.HasValue ? (object)postulante.fechaNacimiento.Value : DBNull.Value));
            parametros.Add(new SqlParameter("@esCandidato", postulante.esCandidato.HasValue ? (object)postulante.esCandidato.Value : DBNull.Value));

            try
            {
                return ExecuteNonQuery(consultaSQL);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al dar de alta al postulante", ex);
            }
        }

        public int BajaPostulante(int numero)
        {
            string consultaSQL = "DELETE FROM Postulantes WHERE numero = @numero";

            parametros.Clear();
            parametros.Add(new SqlParameter("@numero", numero));

            try
            {
                return ExecuteNonQuery(consultaSQL);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al dar de baja al postulante", ex);
            }
        }

        public int ModificarPostulante(Postulantes postulante)
        {
            string consultaSQL = @"UPDATE Postulantes 
                                   SET nombre = @nombre, 
                                       apellido = @apellido, 
                                       mail = @mail, 
                                       telefono = @telefono, 
                                       fechaNacimiento = @fechaNacimiento, 
                                       esCandidato = @esCandidato 
                                   WHERE numero = @numero";

            parametros.Clear();
            parametros.Add(new SqlParameter("@numero", postulante.numero));
            parametros.Add(new SqlParameter("@nombre", postulante.nombre ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@apellido", postulante.apellido ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@mail", postulante.mail ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@telefono", postulante.telefono ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@fechaNacimiento", postulante.fechaNacimiento.HasValue ? (object)postulante.fechaNacimiento.Value : DBNull.Value));
            parametros.Add(new SqlParameter("@esCandidato", postulante.esCandidato.HasValue ? (object)postulante.esCandidato.Value : DBNull.Value));

            try
            {
                return ExecuteNonQuery(consultaSQL);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al modificar al postulante", ex);
            }
        }

        public int ObtenerUltimoNumero()
        {
            string consultaSQL = "SELECT ISNULL(MAX(numero), 0) FROM Postulantes";
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
                throw new Exception("Error al obtener el último número de postulante", ex);
            }
        }

        public int ObtenerTotalPostulantes()
        {
            string consultaSQL = "SELECT COUNT(*) FROM Postulantes";
            int totalPostulantes = 0;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(consultaSQL, conexion))
                {
                    conexion.Open();
                    totalPostulantes = (int)comando.ExecuteScalar();
                }
            }

            return totalPostulantes;
        }

        public List<Postulantes> ObtenerPostulantesFiltrados(string filtro)
        {
            List<Postulantes> postulantes = new List<Postulantes>();
            string consultaSQL = "SELECT * FROM Postulantes";

            if (filtro == "Candidatos")
            {
                consultaSQL += " WHERE esCandidato = 1";
            }
            else if (filtro == "No Candidatos")
            {
                consultaSQL += " WHERE esCandidato = 0";
            }

            try
            {
                DataTable tablaPostulantes = ExecuteReader(consultaSQL);

                foreach (DataRow fila in tablaPostulantes.Rows)
                {
                    Postulantes postulante = new Postulantes
                    {
                        numero = Convert.ToInt32(fila["numero"]),
                        nombre = fila["nombre"].ToString(),
                        apellido = fila["apellido"].ToString(),
                        mail = fila["mail"].ToString(),
                        telefono = fila["telefono"].ToString(),
                        fechaNacimiento = fila["fechaNacimiento"] != DBNull.Value ? Convert.ToDateTime(fila["fechaNacimiento"]) : (DateTime?)null,
                        esCandidato = fila["esCandidato"] != DBNull.Value ? Convert.ToByte(fila["esCandidato"]) : (byte?)null
                    };
                    postulantes.Add(postulante);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los postulantes", ex);
            }

            return postulantes;
        }


    }
}


