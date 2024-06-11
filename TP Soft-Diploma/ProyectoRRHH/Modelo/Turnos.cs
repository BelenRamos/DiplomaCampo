namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Turnos
    {
        [Key]
        [Column(Order = 0, TypeName = "date")]
        public DateTime fecha { get; set; }

        [Key]
        [Column(Order = 1)]
        public TimeSpan horario { get; set; }

        public byte? disponible { get; set; }

        public int? nro_entrevista { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int mat_psicologo { get; set; }

        public virtual Entrevistas Entrevistas { get; set; }

        public virtual Psicologos Psicologos { get; set; }
    }
}
