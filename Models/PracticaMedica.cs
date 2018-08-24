using System;
using System.Collections.Generic;

namespace BloodsportApi.Models
{
    public partial class PracticaMedica
    {
        public int IdPracticaMedica { get; set; }
        public short IdTipoPracticaMedica { get; set; }
        public DateTime FechaPracticaMedica { get; set; }
        public short TiposPracticaMedicaIdTipoPracticaMedica { get; set; }
        public int IdProfesional { get; set; }
        public int IdConsulta { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public Consulta IdConsultaNavigation { get; set; }
        public Profesional IdProfesionalNavigation { get; set; }
        public TipoPracticaMedica IdTipoPracticaMedicaNavigation { get; set; }
    }
}
