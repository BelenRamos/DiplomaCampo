using System;
using System.Collections.Generic;
using Modelo;
using Datos;

namespace Negocio
{
    public class NegEntrevistas
    {
        private static NegEntrevistas instancia;
        private RepoEntrevistas repositorioEntrevistas;

        private NegEntrevistas()
        {
            repositorioEntrevistas = new RepoEntrevistas();
        }

        public static NegEntrevistas ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegEntrevistas();
            }
            return instancia;
        }

        public List<Entrevistas> ObtenerTodasLasEntrevistas()
        {
            try
            {
                return repositorioEntrevistas.ObtenerTodasLasEntrevistas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Entrevistas> ObtenerEntrevistaPorNumero(int numeroEntrevista)
        {
            try
            {
                return repositorioEntrevistas.ObtenerEntrevistaPorNumero(numeroEntrevista);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


