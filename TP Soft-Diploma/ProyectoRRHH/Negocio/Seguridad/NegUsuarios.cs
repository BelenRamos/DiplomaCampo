using Modelo;
using Datos.RepoSeguridad;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class NegUsuarios
    {
        private static NegUsuarios instancia;
        private RepoUsuarios repositorio;
        private List<Usuarios> usuarios;

        public Usuarios UsuarioActual { get; private set; }
        public List<Permisos> PermisosUsuarioActual { get; private set; }

        private NegUsuarios()
        {
            repositorio = new RepoUsuarios();
            usuarios = new List<Usuarios>();
        }

        public static NegUsuarios ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegUsuarios();
            }
            return instancia;
        }

        public List<Usuarios> ObtenerTodosLosUsuarios()
        {
            try
            {
                if (usuarios.Count > 0)
                {
                    return usuarios;
                }
                else
                {
                    usuarios = repositorio.ObtenerTodosLosUsuarios();
                    return usuarios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los usuarios.", ex);
            }
        }

        public Usuarios ObtenerUsuarioPorID(int idUsuario)
        {
            try
            {
                return repositorio.ObtenerUsuarioPorID(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario por ID.", ex);
            }
        }

        public int AltaUsuario(Usuarios usuario)
        {
            try
            {
                int resultado = repositorio.AltaUsuarioSimple(usuario);
                if (resultado > 0)
                {
                    usuarios.Add(usuario); // Agregar a la lista local si la inserción fue exitosa
                }
                return resultado;
            }
            catch (Exception ex)
            {
                // Agregar más información del error
                string mensajeError = $"Error al dar de alta el usuario. {ex.Message}";
                if (ex.InnerException != null)
                {
                    mensajeError += $"\nDetalles internos: {ex.InnerException.Message}";
                }
                mensajeError += $"\nPila de llamadas: {ex.StackTrace}";
                throw new Exception(mensajeError, ex);
            }
        }

        public int ModificarUsuario(Usuarios usuario)
        {
            try
            {
                int filasAfectadas = repositorio.ModificarUsuario(usuario);
                if (filasAfectadas > 0)
                {
                    Usuarios usuarioExistente = usuarios.Find(u => u.idUsuario == usuario.idUsuario);
                    if (usuarioExistente != null)
                    {
                        usuarioExistente.nombreUsuario = usuario.nombreUsuario;
                        usuarioExistente.contrasenia = usuario.contrasenia;
                        usuarioExistente.emailUsuario = usuario.emailUsuario;
                        usuarioExistente.habilitado = usuario.habilitado;
                        usuarioExistente.legajo = usuario.legajo;
                    }
                }
                return filasAfectadas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el usuario: " + ex.Message);
            }
        }


        public int BajaUsuario(int idUsuario)
        {
            try
            {
                int resultado = repositorio.BajaUsuario(idUsuario);
                if (resultado > 0)
                {
                    // Remover de la lista local si la eliminación fue exitosa
                    Usuarios usuarioExistente = usuarios.Find(u => u.idUsuario == idUsuario);
                    if (usuarioExistente != null)
                    {
                        usuarios.Remove(usuarioExistente);
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja el usuario.", ex);
            }
        }

        public List<Permisos> ObtenerPermisosPorUsuario(int idUsuario)
        {
            return repositorio.ObtenerPermisosPorUsuario(idUsuario);
        }

        public Usuarios ValidarUsuario(string email, string contrasenia)
        {
            return repositorio.ValidarUsuario(email, contrasenia);
        }

        public List<Permisos> ObtenerPermisosUsuario(int idUsuario)
        {
            return repositorio.ObtenerPermisosUsuario(idUsuario);
        }

        public void EstablecerUsuarioActual(Usuarios usuario)
        {
            UsuarioActual = usuario;
            PermisosUsuarioActual = ObtenerPermisosPorUsuario(usuario.idUsuario);
        }

        public int ObtenerGrupoUsuario(int idUsuario)
        {
            return repositorio.ObtenerGrupoUsuario(idUsuario);
        }

        public bool CambiarContraseña(string email, string nuevaContrasenia, string confirmaContrasenia)
        {
            // Validar parámetros básicos (puedes añadir más validaciones si es necesario)
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(nuevaContrasenia) || string.IsNullOrEmpty(confirmaContrasenia))
            {
                throw new ArgumentException("Todos los campos son obligatorios.");
            }

            // Llamar al método del repositorio
            int filasAfectadas = repositorio.CambiarContraseña(email, nuevaContrasenia, confirmaContrasenia);
            return filasAfectadas > 0; // Retorna true si se actualizó correctamente
        }
    }
}
