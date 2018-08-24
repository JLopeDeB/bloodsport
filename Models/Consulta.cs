using System;
using System.Collections.Generic;

namespace BloodsportApi.Models
{
    public partial class Consulta
    {
        public Consulta()
        {
            PracticasMedicas = new HashSet<PracticaMedica>();
        }

        public int IdConsulta { get; set; }
        public DateTime FechaConsulta { get; set; }
        public int IdPaciente { get; set; }
        public int IdProfesional { get; set; }
        public short? IdObraSocial { get; set; }
        public bool? Particular { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public PacienteObraSocial Id { get; set; }
        public Paciente IdPacienteNavigation { get; set; }
        public Profesional IdProfesionalNavigation { get; set; }
        public ICollection<PracticaMedica> PracticasMedicas { get; set; }
    }
}
