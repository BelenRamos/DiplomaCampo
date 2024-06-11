namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TurnosReuniones
    {
        [Key]
        [Column(Order = 0, TypeName = "date")]
        public DateTime fecha { get; set; }

        [Key]
        [Column(Order = 1)]
        public TimeSpan horario { get; set; }

        public byte? disponible { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nro_reunion { get; set; }

        public int? id_cliente { get; set; }

        public virtual Clientes Clientes { get; set; }

        public virtual Reuniones Reuniones { get; set; }
    }
}
