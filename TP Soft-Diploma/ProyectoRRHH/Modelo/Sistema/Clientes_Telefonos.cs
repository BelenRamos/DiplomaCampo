namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clientes_Telefonos
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_cliente { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string telefono { get; set; }

        public virtual Clientes Clientes { get; set; }
    }
}
