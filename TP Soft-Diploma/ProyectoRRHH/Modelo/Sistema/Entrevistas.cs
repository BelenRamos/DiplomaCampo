namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Entrevistas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Entrevistas()
        {
            Turnos = new HashSet<Turnos>();
            Perfiles = new HashSet<Perfiles>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int numero { get; set; }

        [StringLength(100)]
        public string observaciones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Turnos> Turnos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Perfiles> Perfiles { get; set; }
    }
}
