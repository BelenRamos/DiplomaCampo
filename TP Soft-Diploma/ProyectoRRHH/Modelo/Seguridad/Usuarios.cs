namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios()
        {
            SessionManager = new HashSet<SessionManager>();
            Grupos = new HashSet<Grupos>();
            Permisos = new HashSet<Permisos>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idUsuario { get; set; }

        [Required]
        [StringLength(20)]
        public string nombreUsuario { get; set; }

        [Required]
        [StringLength(10)]
        public string contrasenia { get; set; }

        [StringLength(200)]
        public string emailUsuario { get; set; }

        public byte? habilitado { get; set; }

        public int? legajo { get; set; }

        public virtual Personas Personas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SessionManager> SessionManager { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grupos> Grupos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permisos> Permisos { get; set; }
    }
}
