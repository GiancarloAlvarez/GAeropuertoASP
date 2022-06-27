using System;
using System.Collections.Generic;

namespace GAeropuerto.Models
{
    public partial class Hangar
    {
        public Hangar()
        {
            Estadia = new HashSet<Estadium>();
        }

        public int IdHangar { get; set; }
        public string? CodigoHangar { get; set; }
        public string? Ubicacion { get; set; }
        public int? Capacidad { get; set; }

        public virtual ICollection<Estadium> Estadia { get; set; }
    }
}
