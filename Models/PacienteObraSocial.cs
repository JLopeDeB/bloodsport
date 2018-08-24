using System;
using System.Collections.Generic;

namespace BloodsportApi.Models
{
    public partial class PacienteObraSocial
    {
        public PacienteObraSocial()
        {
            Consultas = new HashSet<Consulta>();
        }

        public int IdPaciente { get; set; }
        public short IdObraSocial { get; set; }
        public string NumeroAsociado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public ObraSocial IdObraSocialNavigation { get; set; }
        public Paciente IdPacienteNavigation { get; set; }
        public ICollection<Consulta> Consultas { get; set; }
    }
}
