using System;
using System.Collections.Generic;

namespace GAeropuerto.Models
{
    public partial class TipoAvion
    {
        public TipoAvion()
        {
            Aviones = new HashSet<Avione>();
        }

        public int IdTipoAvion { get; set; }
        public string? TipoAvion1 { get; set; }

        public virtual ICollection<Avione> Aviones { get; set; }
    }
}
