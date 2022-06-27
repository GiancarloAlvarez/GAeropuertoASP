using System;
using System.Collections.Generic;

namespace GAeropuerto.Models
{
    public partial class Empleado
    {
        public int IdEmpleado { get; set; }
        public int? IdPersona { get; set; }
        public double? SueldoEmpleado { get; set; }
        public string? TurnoEmpleado { get; set; }

        public virtual Persona? IdPersonaNavigation { get; set; }
    }
}
