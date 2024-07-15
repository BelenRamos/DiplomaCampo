using System.Collections.Generic;
using Modelo;
using Datos;

namespace Negocio
{
    public class NegPermisos
    {
        private readonly RepoPermisos repoPermisos;

        public NegPermisos()
        {
            repoPermisos = new RepoPermisos();
        }

        public IEnumerable<Permisos> ObtenerTodosPermisos()
        {
            return repoPermisos.ObtenerTodos();
        }

        public Permisos ObtenerPermisoPorId(int id)
        {
            return repoPermisos.ObtenerPorId(id);
        }

        public void AgregarPermiso(Permisos permiso)
        {
            repoPermisos.Agregar(permiso);
        }

        public void ActualizarPermiso(Permisos permiso)
        {
            repoPermisos.Actualizar(permiso);
        }

        public void EliminarPermiso(int id)
        {
            repoPermisos.Eliminar(id);
        }
    }
}
