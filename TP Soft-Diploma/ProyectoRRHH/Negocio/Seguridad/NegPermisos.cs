using System.Collections.Generic;
using Modelo;
using Datos;

namespace Negocio
{
    public class NegPermisos
    {
        private readonly RepoPermisos _repoPermisos;

        public NegPermisos()
        {
            _repoPermisos = new RepoPermisos();
        }

        public IEnumerable<Permisos> ObtenerTodosPermisos()
        {
            return _repoPermisos.ObtenerTodos();
        }

        public Permisos ObtenerPermisoPorId(int id)
        {
            return _repoPermisos.ObtenerPorId(id);
        }

        public void AgregarPermiso(Permisos permiso)
        {
            _repoPermisos.Agregar(permiso);
        }

        public void ActualizarPermiso(Permisos permiso)
        {
            _repoPermisos.Actualizar(permiso);
        }

        public void EliminarPermiso(int id)
        {
            _repoPermisos.Eliminar(id);
        }
    }
}
