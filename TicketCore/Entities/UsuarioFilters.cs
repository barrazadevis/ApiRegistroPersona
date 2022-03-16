using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroCore.Entities
{
    public class UsuarioFilters
    {
        public int IdUsuario { get; set; }
        public string Usuario1 { get; set; }
        public string Pass { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? FkPersona { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
