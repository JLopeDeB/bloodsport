using System;
using System.Collections.Generic;

namespace BloodsportApi.Models
{
    public partial class Especialidad
    {
        public Especialidad()
        {
            Profesionales = new HashSet<Profesional>();
        }

        public short IdEspecialidad { get; set; }
        public string NombreEspecialidad { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public ICollection<Profesional> Profesionales { get; set; }
    }
}
