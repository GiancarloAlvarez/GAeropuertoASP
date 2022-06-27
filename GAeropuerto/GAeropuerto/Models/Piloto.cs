using System;
using System.Collections.Generic;

namespace GAeropuerto.Models
{
    public partial class Piloto
    {
        public Piloto()
        {
            Modelos = new HashSet<Modelo>();
            Vuelos = new HashSet<Vuelo>();
        }

        public int IdPiloto { get; set; }
        public int? IdPersona { get; set; }
        public string? Licencia { get; set; }
        public double? HorasVuelo { get; set; }
        public DateTime? FechaRev { get; set; }

        public virtual Persona? IdPersonaNavigation { get; set; }
        public virtual ICollection<Modelo> Modelos { get; set; }
        public virtual ICollection<Vuelo> Vuelos { get; set; }
    }
}
