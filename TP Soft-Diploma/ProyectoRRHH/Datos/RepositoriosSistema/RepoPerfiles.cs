using Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class RepoPerfiles : RepositorioMaestro
    {
        private string connectionString;

        public RepoPerfiles()
        {
            // Obtener la cadena de conexión desde la configuración
            connectionString = ConfigurationManager.ConnectionStrings["Modelo"].ConnectionString;
        }

        public List<Perfiles> ObtenerTodosLosPerfiles()
        {
            List<Perfiles> perfiles = new List<Perfiles>();
            string consultaSQL = "SELECT * FROM Perfiles";

            try
            {
                DataTable tablaPerfiles = ExecuteReader(consultaSQL);

                foreach (DataRow fila in tablaPerfiles.Rows)
                {
                    Perfiles perfil = new Perfiles
                    {
                        id = Convert.ToInt32(fila["id"]),
                        nombre = fila["nombre"].ToString(),
                        descripcion = fila["descripcion"].ToString()
                    };
                    perfiles.Add(perfil);
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al obtener los perfiles", ex);
            }

            return perfiles;
        }

        public Perfiles ObtenerPerfilPorId(int id)
        {
            Perfiles perfil = null;
            string consultaSQL = "SELECT * FROM Perfiles WHERE id = @id";

            parametros.Clear();
            parametros.Add(new SqlParameter("@id", id));

            try
            {
                DataTable tablaPerfil = ExecuteReader(consultaSQL);

                if (tablaPerfil.Rows.Count > 0)
                {
                    DataRow fila = tablaPerfil.Rows[0];
                    perfil = new Perfiles
                    {
                        id = Convert.ToInt32(fila["id"]),
                        nombre = fila["nombre"].ToString(),
                        descripcion = fila["descripcion"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al obtener el perfil por ID", ex);
            }

            return perfil;
        }

        public int AltaPerfil(Perfiles perfil)
        {
            string consultaSQL = @"INSERT INTO Perfiles (id, nombre, descripcion) 
                                   VALUES (@id, @nombre, @descripcion)";

            parametros.Clear();
            parametros.Add(new SqlParameter("@id", perfil.id));
            parametros.Add(new SqlParameter("@nombre", perfil.nombre ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@descripcion", perfil.descripcion ?? (object)DBNull.Value));

            try
            {
                return ExecuteNonQuery(consultaSQL);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al dar de alta el perfil", ex);
            }
        }

        public int BajaPerfil(int id)
        {
            string consultaSQL = "DELETE FROM Perfiles WHERE id = @id";

            parametros.Clear();
            parametros.Add(new SqlParameter("@id", id));

            try
            {
                return ExecuteNonQuery(consultaSQL);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al dar de baja el perfil", ex);
            }
        }

        public int ModificarPerfil(Perfiles perfil)
        {
            string consultaSQL = @"UPDATE Perfiles 
                                   SET nombre = @nombre, 
                                       descripcion = @descripcion 
                                   WHERE id = @id";

            parametros.Clear();
            parametros.Add(new SqlParameter("@id", perfil.id));
            parametros.Add(new SqlParameter("@nombre", perfil.nombre ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@descripcion", perfil.descripcion ?? (object)DBNull.Value));

            try
            {
                return ExecuteNonQuery(consultaSQL);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al modificar el perfil", ex);
            }
        }

        public int ObtenerTotalPerfiles()
        {
            string consultaSQL = "SELECT COUNT(*) FROM Perfiles";
            int totalPerfiles = 0;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(consultaSQL, conexion))
                {
                    conexion.Open();
                    totalPerfiles = (int)comando.ExecuteScalar();
                }
            }

            return totalPerfiles;
        }
    }
}
