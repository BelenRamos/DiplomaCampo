using System;
using System.Collections.Generic;
using Modelo;
using Datos;

namespace Negocio
{
    public class NegPsicologos
    {
        private static NegPsicologos instancia;
        private RepoPsicologos repositorioPsicologos;

        private NegPsicologos()
        {
            repositorioPsicologos = new RepoPsicologos();
        }

        public static NegPsicologos ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegPsicologos();
            }
            return instancia;
        }

        public List<Psicologos> ObtenerTodosLosPsicologos()
        {
            try
            {
                return repositorioPsicologos.ObtenerTodosLosPsicologos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Psicologos ObtenerPsicologoPorMatricula(int matriculaPsicologo)
        {
            try
            {
                return repositorioPsicologos.ObtenerPsicologoPorMatricula(matriculaPsicologo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
