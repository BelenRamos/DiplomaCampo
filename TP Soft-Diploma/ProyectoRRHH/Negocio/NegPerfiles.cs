using System;
using System.Collections.Generic;
using Modelo;
using Datos;

namespace Negocio
{
    public class NegPerfiles
    {
        private static NegPerfiles instancia;
        private RepoPerfiles repositorioPerfiles;

        private NegPerfiles()
        {
            repositorioPerfiles = new RepoPerfiles();
        }

        public static NegPerfiles ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegPerfiles();
            }
            return instancia;
        }

        public List<Perfiles> ObtenerTodosLosPerfiles()
        {
            try
            {
                return repositorioPerfiles.ObtenerTodosLosPerfiles();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Perfiles ObtenerPerfilPorId(int idPerfil)
        {
            try
            {
                return repositorioPerfiles.ObtenerPerfilPorId(idPerfil);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

