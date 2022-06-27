using System;
using System.Collections.Generic;

namespace GAeropuerto.Models
{
    public partial class Estadium
    {
        public int IdEstadia { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? IdHangar { get; set; }
        public int? IdAvion { get; set; }

        public virtual Avione? IdAvionNavigation { get; set; }
        public virtual Hangar? IdHangarNavigation { get; set; }
    }
}
