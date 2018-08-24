using System;
using System.Collections.Generic;

namespace BloodsportApi.Models
{
    public partial class TipoPracticaMedica
    {
        public TipoPracticaMedica()
        {
            PracticasMedicas = new HashSet<PracticaMedica>();
        }

        public short IdTipoPracticaMedica { get; set; }
        public string NombrePractica { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public ICollection<PracticaMedica> PracticasMedicas { get; set; }
    }
}
