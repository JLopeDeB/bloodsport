using System;
using System.Collections.Generic;

namespace BloodsportApi.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consultas = new HashSet<Consulta>();
            PacientesObrasSociales = new HashSet<PacienteObraSocial>();
        }

        public int IdPaciente { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public int? Dni { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? IdProfesionalCabecera { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public Profesional IdProfesionalCabeceraNavigation { get; set; }
        public ICollection<Consulta> Consultas { get; set; }
        public ICollection<PacienteObraSocial> PacientesObrasSociales { get; set; }
    }
}
