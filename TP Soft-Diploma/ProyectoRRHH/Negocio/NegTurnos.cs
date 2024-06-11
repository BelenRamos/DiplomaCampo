using System;
using System.Collections.Generic;
using Modelo;
using Datos;

namespace Negocio
{
    public class NegTurnos
    {
        private static NegTurnos instancia;
        private RepoTurnos repositorioTurnos;

        private NegTurnos()
        {
            repositorioTurnos = new RepoTurnos();
        }

        public static NegTurnos ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegTurnos();
            }
            return instancia;
        }

        public List<Turnos> ObtenerTodosLosTurnos()
        {
            try
            {
                return repositorioTurnos.ObtenerTodosLosTurnos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Turnos ObtenerTurnoPorClave(DateTime fecha, TimeSpan horario, int mat_psicologo)
        {
            try
            {
                return repositorioTurnos.ObtenerTurnoPorClave(fecha, horario, mat_psicologo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

