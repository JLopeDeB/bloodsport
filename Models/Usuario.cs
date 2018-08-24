using System;
using System.Collections.Generic;

namespace BloodsportApi.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Profesionales = new HashSet<Profesional>();
        }

        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public int? Dni { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public ICollection<Profesional> Profesionales { get; set; }
    }
}
