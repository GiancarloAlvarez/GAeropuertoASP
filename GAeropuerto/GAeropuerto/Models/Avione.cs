using System;
using System.Collections.Generic;

namespace GAeropuerto.Models
{
    public partial class Avione
    {
        public Avione()
        {
            Estadia = new HashSet<Estadium>();
            Vuelos = new HashSet<Vuelo>();
        }

        public int IdAvion { get; set; }
        public string? SiglasAvion { get; set; }
        public int? IdTipoAvion { get; set; }
        public double? CapacidadPeso { get; set; }
        public int? IdModelo { get; set; }
        public int? IdPropietario { get; set; }

        public virtual Modelo? IdModeloNavigation { get; set; }
        public virtual Propietario? IdPropietarioNavigation { get; set; }
        public virtual TipoAvion? IdTipoAvionNavigation { get; set; }
        public virtual ICollection<Estadium> Estadia { get; set; }
        public virtual ICollection<Vuelo> Vuelos { get; set; }
    }
}
