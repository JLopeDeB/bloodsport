using System;
using System.Collections.Generic;

namespace BloodsportApi.Models
{
    public partial class ObraSocial
    {
        public ObraSocial()
        {
            PacientesObrasSociales = new HashSet<PacienteObraSocial>();
        }

        public short IdObraSocial { get; set; }
        public string NombreObraSocial { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public ICollection<PacienteObraSocial> PacientesObrasSociales { get; set; }
    }
}
