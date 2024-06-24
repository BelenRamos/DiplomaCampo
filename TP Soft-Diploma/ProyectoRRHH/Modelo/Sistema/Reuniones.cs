namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reuniones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reuniones()
        {
            TurnosReuniones = new HashSet<TurnosReuniones>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int numero { get; set; }

        [StringLength(100)]
        public string observaciones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TurnosReuniones> TurnosReuniones { get; set; }
    }
}
