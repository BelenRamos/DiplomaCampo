using System;
using System.Collections.Generic;
using Modelo;
using Datos;

namespace Negocio
{
    public class NegTurnosReuniones
    {
        private static NegTurnosReuniones instancia;
        private RepoTurnosReuniones repositorioTurnosReuniones;

        private NegTurnosReuniones()
        {
            repositorioTurnosReuniones = new RepoTurnosReuniones();
        }

        public static NegTurnosReuniones ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegTurnosReuniones();
            }
            return instancia;
        }

        public List<TurnosReuniones> ObtenerTodosLosTurnosReuniones()
        {
            try
            {
                return repositorioTurnosReuniones.ObtenerTodosLosTurnosReuniones();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TurnosReuniones ObtenerTurnoReunionPorClave(DateTime fecha, TimeSpan horario, int nro_reunion)
        {
            try
            {
                return repositorioTurnosReuniones.ObtenerTurnoReunionPorClave(fecha, horario, nro_reunion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

