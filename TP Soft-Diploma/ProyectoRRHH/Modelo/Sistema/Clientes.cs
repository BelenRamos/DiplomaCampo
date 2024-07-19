using System.Collections.Generic;

namespace Modelo
{
    public class Clientes
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string mail { get; set; }

        public ICollection<Clientes_Telefonos> Clientes_Telefonos { get; set; }
        public ICollection<Mensajes> Mensajes { get; set; }
        public ICollection<TurnosReuniones> TurnosReuniones { get; set; }
        public ICollection<Ofertas_Laborales> Ofertas_Laborales { get; set; }

        public Clientes()
        {
            Clientes_Telefonos = new HashSet<Clientes_Telefonos>();
            Mensajes = new HashSet<Mensajes>();
            TurnosReuniones = new HashSet<TurnosReuniones>();
            Ofertas_Laborales = new HashSet<Ofertas_Laborales>();
        }
    }
}
