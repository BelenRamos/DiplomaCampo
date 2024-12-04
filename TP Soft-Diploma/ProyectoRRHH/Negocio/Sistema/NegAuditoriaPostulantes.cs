using Datos.RepositoriosSistema;
using Modelo;
using Modelo.Sistema;
using System;

namespace Negocio.Sistema
{
    public class NegAuditoriaPostulantes
    {
        private static NegAuditoriaPostulantes instancia;
        private RepoAuditoriaPostulantes repo;

        private NegAuditoriaPostulantes()
        {
            repo = new RepoAuditoriaPostulantes();
        }

        public static NegAuditoriaPostulantes ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegAuditoriaPostulantes();
            }
            return instancia;
        }

        public void CrearRegistroAuditoria(AuditoriaPostulantes auditoria)
        {
            if (auditoria == null)
                throw new ArgumentNullException(nameof(auditoria), "El objeto auditoria no puede ser null.");

            try
            {
                repo.Insertar(auditoria);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el registro de auditoría.", ex);
            }
        }

        public void ActualizarAuditoria(AuditoriaPostulantes auditoria)
        {
            if (auditoria == null)
                throw new ArgumentNullException(nameof(auditoria), "El objeto auditoria no puede ser null.");

            try
            {
                repo.Actualizar(auditoria);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el registro de auditoría.", ex);
            }
        }
        public string ObtenerValoresOriginales(int numeroPostulante)
        {
            try
            {
                return repo.ObtenerValoresOriginales(numeroPostulante);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener los valores originales para el postulante con número {numeroPostulante}.", ex);
            }
        }

        public void Eliminar(int numeroPostulante, string usuario)
        {
            try
            {
                repo.Eliminar(numeroPostulante, usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la auditoría. 2", ex);
            }
        }

    }
}
