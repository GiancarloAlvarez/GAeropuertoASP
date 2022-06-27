using System;
using System.Collections.Generic;

namespace GAeropuerto.Models
{
    public partial class Vuelo
    {
        public int IdVuelo { get; set; }
        public int? NumeroVuelo { get; set; }
        public DateTime? FechaVuelo { get; set; }
        public int? IdAvion { get; set; }
        public int? IdPiloto { get; set; }

        public virtual Avione? IdAvionNavigation { get; set; }
        public virtual Piloto? IdPilotoNavigation { get; set; }
    }
}
