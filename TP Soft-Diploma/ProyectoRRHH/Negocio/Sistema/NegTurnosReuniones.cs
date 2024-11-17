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

        public void AgregarTurnoReunion(TurnosReuniones turnoReunion)
        {
            repoTurnosReuniones.AgregarTurnoReunion(turnoReunion);
        }

        public void ActualizarTurnoReunion(TurnosReuniones turnoReunion)
        {
            repoTurnosReuniones.ActualizarTurnoReunion(turnoReunion);
        }

        public void EliminarTurnoReunion(int nroReunion)
        {
            repoTurnosReuniones.EliminarTurnoReunion(nroReunion);
        }

        public TurnosReuniones ObtenerTurnoReunionPorId(int nroReunion)
        {
            return repoTurnosReuniones.ObtenerTurnoReunionPorId(nroReunion);
        }
    }
}

