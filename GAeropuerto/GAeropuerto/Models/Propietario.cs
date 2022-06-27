using System;
using System.Collections.Generic;

namespace GAeropuerto.Models
{
    public partial class Propietario
    {
        public Propietario()
        {
            Aviones = new HashSet<Avione>();
        }

        public int IdPropietario { get; set; }
        public int? IdPersona { get; set; }
        public string? Rif { get; set; }

        public virtual Persona? IdPersonaNavigation { get; set; }
        public virtual ICollection<Avione> Aviones { get; set; }
    }
}
