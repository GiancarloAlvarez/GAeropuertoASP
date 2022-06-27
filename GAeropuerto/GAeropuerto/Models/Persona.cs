using System;
using System.Collections.Generic;

namespace GAeropuerto.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Empleados = new HashSet<Empleado>();
            Pilotos = new HashSet<Piloto>();
            Propietarios = new HashSet<Propietario>();
        }

        public int IdPersona { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Cedula { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<Piloto> Pilotos { get; set; }
        public virtual ICollection<Propietario> Propietarios { get; set; }
    }
}
