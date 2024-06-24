namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Evaluaciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Evaluaciones()
        {
            Tipo_Evaluaciones = new HashSet<Tipo_Evaluaciones>();
            Postulantes = new HashSet<Postulantes>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int numero { get; set; }

        [StringLength(60)]
        public string descripcion { get; set; }

        [StringLength(60)]
        public string resultado { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaEvaluacion { get; set; }

        [StringLength(60)]
        public string profesional { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tipo_Evaluaciones> Tipo_Evaluaciones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Postulantes> Postulantes { get; set; }
    }
}
