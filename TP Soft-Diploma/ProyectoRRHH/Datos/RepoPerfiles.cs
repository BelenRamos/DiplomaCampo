using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Datos
{
    public class RepoPerfiles : RepositorioMaestro
    {
        public List<Perfiles> ObtenerTodosLosPerfiles()
        {
            List<Perfiles> perfiles = new List<Perfiles>();
            string consultaSQL = "SELECT * FROM Perfiles"; // Ajusta esto según el nombre de tu tabla de perfiles

            DataTable tablaPerfiles = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaPerfiles.Rows)
            {
                Perfiles perfil = new Perfiles
                {
                    id = Convert.ToInt32(fila["id"]),
                    nombre = fila["nombre"].ToString(),
                    descripcion = fila["descripcion"].ToString(),
                    // Ajusta el mapeo de propiedades según tu clase Perfiles
                };
                perfiles.Add(perfil);
            }
            return perfiles;
        }

        public Perfiles ObtenerPerfilPorId(int idPerfil)
        {
            Perfiles perfil = null;
            string consultaSQL = "SELECT * FROM Perfiles WHERE id = @ID_Perfil";
            parametros.Add(new SqlParameter("@ID_Perfil", idPerfil));
            DataTable tablaPerfiles = ExecuteReader(consultaSQL);

            if (tablaPerfiles.Rows.Count > 0)
            {
                DataRow fila = tablaPerfiles.Rows[0];
                perfil = new Perfiles
                {
                    id = Convert.ToInt32(fila["id"]),
                    nombre = fila["nombre"].ToString(),
                    descripcion = fila["descripcion"].ToString(),
                    // Ajusta el mapeo de propiedades según tu clase Perfiles
                };
            }
            return perfil;
        }
    }
}

