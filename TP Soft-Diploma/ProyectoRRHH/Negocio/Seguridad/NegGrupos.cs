using System.Collections.Generic;
using System.Linq;
using Modelo;
using Datos;

namespace Negocio
{
    public class NegGrupos
    {
        private RepoGrupos repoGrupos;

        public NegGrupos()
        {
            repoGrupos = new RepoGrupos();
        }

        public List<Grupos> ObtenerGrupos()
        {
            return repoGrupos.ObtenerTodos().ToList();
        }

        public Grupos ObtenerGrupoPorId(int id)
        {
            return repoGrupos.ObtenerPorId(id);
        }

        public void AgregarGrupo(Grupos Grupos)
        {
            repoGrupos.Agregar(Grupos);
        }

        public void ModificarGrupos(Grupos Grupos)
        {
            repoGrupos.Actualizar(Grupos);
        }

        public void EliminarGrupo(int id)
        {
            repoGrupos.Eliminar(id);
        }
    }
}

