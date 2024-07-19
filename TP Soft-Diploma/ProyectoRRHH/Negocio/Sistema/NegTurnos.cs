using System.Collections.Generic;
using Datos;
using Modelo;

namespace Negocio
{
    public class NegTurnos
    {
        private RepoTurnos repoTurnos = new RepoTurnos();

        public List<Turnos> ObtenerTurnos()
        {
            return repoTurnos.ObtenerTurnos();
        }
    }
}
