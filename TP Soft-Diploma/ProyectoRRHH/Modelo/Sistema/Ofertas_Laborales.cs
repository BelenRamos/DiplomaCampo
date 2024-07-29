namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ofertas_Laborales
    {
        public Ofertas_Laborales ofertaLaboral;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ofertas_Laborales()
        {
            Clientes = new HashSet<Clientes>();
            Personas = new HashSet<Personas>();
            Estados = new HashSet<Estados>();
            Perfiles = new HashSet<Perfiles>();
            Postulantes = new HashSet<Postulantes>();
            Requisitos = new HashSet<Requisitos>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int numero { get; set; }

        [StringLength(50)]
        public string titulo { get; set; }

        [StringLength(100)]
        public string descripcion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaCreacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaPublicacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaCierre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clientes> Clientes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personas> Personas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estados> Estados { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Perfiles> Perfiles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Postulantes> Postulantes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Requisitos> Requisitos { get; set; }
    }
}
