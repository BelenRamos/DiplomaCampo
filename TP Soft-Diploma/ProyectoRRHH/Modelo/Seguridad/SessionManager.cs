namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SessionManager")]
    public partial class SessionManager
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int sessionId { get; set; }

        public int userId { get; set; }

        public DateTime sessionLogIn { get; set; }

        public DateTime? sessionLogOut { get; set; }

        public byte? isLoggedIn { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
