using Modelo.Sistema;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Modelo
{
    public partial class Modelo : DbContext
    {
        public Modelo()
            : base("name=Modelo")
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Clientes_Telefonos> Clientes_Telefonos { get; set; }
        public virtual DbSet<Entrevistas> Entrevistas { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<Evaluaciones> Evaluaciones { get; set; }
        public virtual DbSet<Formularios> Formularios { get; set; }
        public virtual DbSet<Grupos> Grupos { get; set; }
        public virtual DbSet<Mensajes> Mensajes { get; set; }
        public virtual DbSet<Modulos> Modulos { get; set; }
        public virtual DbSet<Ofertas_Laborales> Ofertas_Laborales { get; set; }
        public virtual DbSet<Perfiles> Perfiles { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<Postulantes> Postulantes { get; set; }
        public virtual DbSet<Psicologos> Psicologos { get; set; }
        public virtual DbSet<Requisitos> Requisitos { get; set; }
        public virtual DbSet<Reuniones> Reuniones { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<SessionManager> SessionManager { get; set; }
        public virtual DbSet<Tipo_Evaluaciones> Tipo_Evaluaciones { get; set; }
        public virtual DbSet<Turnos> Turnos { get; set; }
        public virtual DbSet<TurnosReuniones> TurnosReuniones { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<AuditoriaPostulantes> AuditoriaPostulantes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Clientes_Telefonos)
                .WithRequired(e => e.Clientes)
                .HasForeignKey(e => e.id_cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Mensajes)
                .WithOptional(e => e.Clientes)
                .HasForeignKey(e => e.emisor);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.TurnosReuniones)
                .WithOptional(e => e.Clientes)
                .HasForeignKey(e => e.id_cliente);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Ofertas_Laborales)
                .WithMany(e => e.Clientes)
                .Map(m => m.ToTable("OL_Clientes").MapLeftKey("id_cliente").MapRightKey("nro_OL"));

            modelBuilder.Entity<Entrevistas>()
                .HasMany(e => e.Turnos)
                .WithOptional(e => e.Entrevistas)
                .HasForeignKey(e => e.nro_entrevista);

            modelBuilder.Entity<Estados>()
                .HasMany(e => e.Ofertas_Laborales)
                .WithMany(e => e.Estados)
                .Map(m => m.ToTable("OL_Estados").MapLeftKey("codigo_estado").MapRightKey("nro_OL"));

            modelBuilder.Entity<Evaluaciones>()
                .HasMany(e => e.Postulantes)
                .WithMany(e => e.Evaluaciones)
                .Map(m => m.ToTable("Evaluciones_Postulantes").MapLeftKey("nro_evaluacion").MapRightKey("nro_postulante"));

            modelBuilder.Entity<Formularios>()
                .Property(e => e.nombreForm)
                .IsUnicode(false);

            modelBuilder.Entity<Grupos>()
                .Property(e => e.nombreGrupo)
                .IsUnicode(false);

            modelBuilder.Entity<Grupos>()
                .HasMany(e => e.Grupos1)
                .WithMany(e => e.Grupos2)
                .Map(m => m.ToTable("Grupos_Grupos").MapLeftKey("idGrupoPadre").MapRightKey("idGrupoHijo"));

            modelBuilder.Entity<Grupos>()
                .HasMany(e => e.Permisos)
                .WithMany(e => e.Grupos)
                .Map(m => m.ToTable("Permisos_Grupos").MapLeftKey("idGrupo").MapRightKey("idPermiso"));

            modelBuilder.Entity<Grupos>()
                .HasMany(e => e.Usuarios)
                .WithMany(e => e.Grupos)
                .Map(m => m.ToTable("Usuarios_Grupos").MapLeftKey("idGrupo").MapRightKey("idUsuario"));

            modelBuilder.Entity<Modulos>()
                .Property(e => e.nombreModulo)
                .IsUnicode(false);

            modelBuilder.Entity<Ofertas_Laborales>()
                .HasMany(e => e.Postulantes)
                .WithMany(e => e.Ofertas_Laborales)
                .Map(m => m.ToTable("OL_Postulantes").MapLeftKey("nro_OL").MapRightKey("nro_postulante"));

            modelBuilder.Entity<Perfiles>()
                .HasMany(e => e.Entrevistas)
                .WithMany(e => e.Perfiles)
                .Map(m => m.ToTable("Entrevistas_Perfiles").MapLeftKey("id_perfil").MapRightKey("nro_entrevista"));

            modelBuilder.Entity<Perfiles>()
                .HasMany(e => e.Ofertas_Laborales)
                .WithMany(e => e.Perfiles)
                .Map(m => m.ToTable("OL_Perfiles").MapLeftKey("id_perfil").MapRightKey("nro_OL"));

            modelBuilder.Entity<Perfiles>()
                .HasMany(e => e.Postulantes)
                .WithMany(e => e.Perfiles)
                .Map(m => m.ToTable("Perfiles_Postulantes").MapLeftKey("id_perfil").MapRightKey("nro_postulante"));

            modelBuilder.Entity<Permisos>()
                .Property(e => e.nombrePermiso)
                .IsUnicode(false);

            modelBuilder.Entity<Permisos>()
                .HasMany(e => e.Usuarios)
                .WithMany(e => e.Permisos)
                .Map(m => m.ToTable("Usuarios_Permisos").MapLeftKey("idPermiso").MapRightKey("idUsuario"));

            modelBuilder.Entity<Personas>()
                .HasMany(e => e.Mensajes)
                .WithOptional(e => e.Personas)
                .HasForeignKey(e => e.receptor);

            modelBuilder.Entity<Personas>()
                .HasMany(e => e.Ofertas_Laborales)
                .WithMany(e => e.Personas)
                .Map(m => m.ToTable("OL_Consultor_Asignado").MapLeftKey("legajo_consultor").MapRightKey("nro_OL"));

            modelBuilder.Entity<Psicologos>()
                .HasMany(e => e.Turnos)
                .WithRequired(e => e.Psicologos)
                .HasForeignKey(e => e.mat_psicologo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Requisitos>()
                .HasMany(e => e.Ofertas_Laborales)
                .WithMany(e => e.Requisitos)
                .Map(m => m.ToTable("OL_Requisitos").MapLeftKey("id_requisito").MapRightKey("nro_OL"));

            modelBuilder.Entity<Reuniones>()
                .HasMany(e => e.TurnosReuniones)
                .WithRequired(e => e.Reuniones)
                .HasForeignKey(e => e.nro_reunion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.Personas)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("Personas_Rol").MapLeftKey("id_Rol").MapRightKey("legajo"));

            modelBuilder.Entity<Tipo_Evaluaciones>()
                .HasMany(e => e.Evaluaciones)
                .WithMany(e => e.Tipo_Evaluaciones)
                .Map(m => m.ToTable("Evaluaciones_Tipos").MapLeftKey("id_tipo").MapRightKey("nro_evaluacion"));

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.nombreUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.contrasenia)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.emailUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.SessionManager)
                .WithRequired(e => e.Usuarios)
                .HasForeignKey(e => e.userId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AuditoriaPostulantes>()
                .Property(e => e.accion)
                .IsUnicode(false);

            modelBuilder.Entity<AuditoriaPostulantes>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<AuditoriaPostulantes>()
                .Property(e => e.valoresOriginales)
                .IsUnicode(false);

            modelBuilder.Entity<AuditoriaPostulantes>()
                .Property(e => e.valoresNuevos)
                .IsUnicode(false);

        }
    }
}
