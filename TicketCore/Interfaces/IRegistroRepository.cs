using RegistroCore.Entities;
using RegistroInfraestructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketCore.Entities;

namespace TicketCore.Interfaces
{
    public interface IRegistroRepository
    {
        #region "Metodos de Persona"
        PageList<Persona> GetPersonas(PersonaFilters personaFilters);
        Task<Persona> GetPersona(int id);

        Task InsertPersona(Persona persona);

        Task<bool> DeletePersona(int Id);

        Task<bool> updatePersona(Persona persona);

        #endregion

        #region "Metodos Usuario"
        PageList<Usuario> GetUsuarios(UsuarioFilters usuarioFilters);
        Task<Usuario> GetUsuario(int id);

        Task<Usuario> PostObtenerUsuario(Usuario usuario);

        Task InsertUsuario(Usuario usuario);

        Task<bool> DeleteUsuario(int Id);

        Task<bool> updateUsuario(Usuario usuario);

        #endregion
    }
}
