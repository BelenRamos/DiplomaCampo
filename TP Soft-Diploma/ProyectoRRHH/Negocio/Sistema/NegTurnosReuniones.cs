using System.Collections.Generic;
using Datos;
using Modelo;

namespace Negocio
{
    public class NegTurnosReuniones
    {
        private RepoTurnosReuniones repoTurnosReuniones = new RepoTurnosReuniones();

        public List<TurnosReuniones> ObtenerTurnosReuniones()
        {
            return repoTurnosReuniones.ObtenerTurnosReuniones();
        }
    }
}
