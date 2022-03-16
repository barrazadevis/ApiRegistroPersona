using Microsoft.EntityFrameworkCore;
using RegistroCore.Entities;
using RegistroInfraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketCore.Entities;
using TicketCore.Interfaces;

namespace TicketInfraestructure.Repositories
{
    public class RegistroRepository : IRegistroRepository
    {
        private readonly RegistroContext _context;
        public RegistroRepository(RegistroContext context)
        {
            _context = context;
        }

        #region "Metodos de Personas"
        public PageList<Persona> GetPersonas(PersonaFilters personaFilters)
        {
            var personas = _context.Persona.ToList();

            if (personaFilters.Identificador > 0)
            {
                personas = personas.Where(x => x.Identificador == personaFilters.Identificador).ToList();
            }
            if (personaFilters.Nombres != null)
            {
                personas = personas.Where(x => x.Nombres == personaFilters.Nombres).ToList();
            }
            if (personaFilters.FechaCreacion != null)
            {
                personas = personas.Where(x => x.FechaCreacion == personaFilters.FechaCreacion).ToList();
            }
            if (personaFilters.Apellidos != null)
            {
                personas = personas.Where(x => x.Apellidos == personaFilters.Apellidos).ToList();
            }

            if (personaFilters.PageSize == 0)
            {
                personaFilters.PageSize = personas.Count;
            }

            var pagePersona = PageList<Persona>.Create(personas, personaFilters.PageNumber, personaFilters.PageSize);

            return pagePersona;
        }

        public async Task<Persona> GetPersona(int identificador)
        {
            var persona = await _context.Persona.FirstOrDefaultAsync(x => x.Identificador == identificador);

            return persona;
        }

        public async Task InsertPersona(Persona persona)
        {
            _context.Persona.Add(persona);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> updatePersona(Persona persona)
        {
            var currentPersona = await GetPersona(persona.Identificador);
            currentPersona.Nombres = persona.Nombres;
            currentPersona.Apellidos = persona.Apellidos;
            currentPersona.NumeroIdentificacion = persona.NumeroIdentificacion;
            currentPersona.TipoIdentificacion = persona.TipoIdentificacion;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeletePersona(int identificador)
        {
            var currentPersona = await GetPersona(identificador);
            _context.Persona.Remove(currentPersona);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        #endregion


        #region "Metodos de Usuario"
        public PageList<Usuario> GetUsuarios(UsuarioFilters usuarioFilters)
        {
            var usuarios = _context.Usuario.ToList();

            if (usuarioFilters.IdUsuario > 0)
            {
                usuarios = usuarios.Where(x => x.IdUsuario == usuarioFilters.IdUsuario).ToList();
            }
            if (usuarioFilters.Usuario1 != null)
            {
                usuarios = usuarios.Where(x => x.Usuario1 == usuarioFilters.Usuario1).ToList();
            }
            if (usuarioFilters.FechaCreacion != null)
            {
                usuarios = usuarios.Where(x => x.FechaCreacion == usuarioFilters.FechaCreacion).ToList();
            }
            
            if (usuarioFilters.PageSize == 0)
            {
                usuarioFilters.PageSize = usuarios.Count;
            }


            var pageUsuario = PageList<Usuario>.Create(usuarios, usuarioFilters.PageNumber, usuarioFilters.PageSize);

            return pageUsuario;
        }

        public async Task<Usuario> GetUsuario( int idUsuario)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(x => x.IdUsuario == idUsuario);

            return usuario;
        }
        public async Task<Usuario> PostObtenerUsuario(Usuario usuario)
        {
            Usuario usuarioResult = await _context.Usuario.FirstOrDefaultAsync(x => x.Usuario1 == usuario.Usuario1 && x.Pass == usuario.Pass);

            return usuarioResult;
        }

        public async Task InsertUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteUsuario(int identificador)
        {
            var currentUsuario = await GetUsuario(identificador);
            _context.Usuario.Remove(currentUsuario);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> updateUsuario(Usuario usuario)
        {
            var currentUsuario = await GetUsuario(usuario.IdUsuario);
            currentUsuario.Usuario1 = usuario.Usuario1;
            currentUsuario.Pass = usuario.Pass;
            currentUsuario.FechaCreacion = usuario.FechaCreacion;
            currentUsuario.FkPersonaNavigation = usuario.FkPersonaNavigation;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        #endregion
    }
}
