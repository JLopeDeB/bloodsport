using System;
using System.Collections.Generic;

namespace BloodsportApi.Models
{
    public partial class Profesional
    {
        public Profesional()
        {
            Consultas = new HashSet<Consulta>();
            Pacientes = new HashSet<Paciente>();
            PracticasMedicas = new HashSet<PracticaMedica>();
        }

        public int IdProfesional { get; set; }
        public short IdEspecialidad { get; set; }
        public string Matricula { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public Usuario IdUsuarioNavigation { get; set; }
        public Especialidad IdEspecialidadNavigation { get; set; }
        public ICollection<Consulta> Consultas { get; set; }
        public ICollection<Paciente> Pacientes { get; set; }
        public ICollection<PracticaMedica> PracticasMedicas { get; set; }
    }
}
