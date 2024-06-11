using System;
using System.Collections.Generic;
using Modelo;
using Datos;

namespace Negocio
{
    public class NegReuniones
    {
        private static NegReuniones instancia;
        private RepoReuniones repositorioReuniones;

        private NegReuniones()
        {
            repositorioReuniones = new RepoReuniones();
        }

        public static NegReuniones ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegReuniones();
            }
            return instancia;
        }

        public List<Reuniones> ObtenerTodasLasReuniones()
        {
            try
            {
                return repositorioReuniones.ObtenerTodasLasReuniones();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Reuniones ObtenerReunionPorNumero(int numeroReunion)
        {
            try
            {
                return repositorioReuniones.ObtenerReunionPorNumero(numeroReunion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

