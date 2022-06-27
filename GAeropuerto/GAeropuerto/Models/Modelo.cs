using System;
using System.Collections.Generic;

namespace GAeropuerto.Models
{
    public partial class Modelo
    {
        public Modelo()
        {
            Aviones = new HashSet<Avione>();
        }

        public int IdModelo { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public string? Tipo { get; set; }
        public int? Motores { get; set; }
        public double? Peso { get; set; }
        public int? IdPiloto { get; set; }

        public virtual Piloto? IdPilotoNavigation { get; set; }
        public virtual ICollection<Avione> Aviones { get; set; }
    }
}
