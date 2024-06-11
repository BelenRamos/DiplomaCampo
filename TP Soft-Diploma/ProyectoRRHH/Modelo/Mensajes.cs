namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mensajes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int numero { get; set; }

        [StringLength(20)]
        public string asunto { get; set; }

        [StringLength(100)]
        public string contenido { get; set; }

        public int? emisor { get; set; }

        public int? receptor { get; set; }

        public virtual Clientes Clientes { get; set; }

        public virtual Personas Personas { get; set; }
    }
}
