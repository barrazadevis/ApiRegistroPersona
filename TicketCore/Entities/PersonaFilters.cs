using System;
using System.Collections.Generic;
using System.Text;

namespace TicketCore.Entities
{
    public class PersonaFilters
    {
        public int Identificador { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Email { get; set; }
        public string TipoIdentificacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string IdentificacionCompleta { get; set; }
        public string NombreCompleto { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
