
namespace Modelo.Sistema
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AuditoriaPostulantes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idAuditoria { get; set; } // Identificador único

        [Required]
        [StringLength(50)]
        public string accion { get; set; } // Tipo de acción (INSERT, UPDATE, DELETE)

        [Required]
        [StringLength(100)]
        public string usuario { get; set; } // Usuario que realizó la acción

        [Required]
        public DateTime fechaHora { get; set; } // Fecha y hora de la acción

        [Column(TypeName = "nvarchar(MAX)")]
        public string valoresOriginales { get; set; } // Valores originales en formato JSON (puede ser NULL)

        [Column(TypeName = "nvarchar(MAX)")]
        public string valoresNuevos { get; set; } // Valores nuevos en formato JSON (puede ser NULL)

    }
}

