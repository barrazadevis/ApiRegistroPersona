using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistroInfraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketCore.Entities;
using TicketCore.Interfaces;
//using TicketInfraestructure.Repositories;

namespace TicketsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        private readonly IRegistroRepository _registroRepository;

        public RegistroController(IRegistroRepository registroRepository)
        {
            _registroRepository = registroRepository;
        }

        [HttpGet]
        public IActionResult GetPersonas([FromQuery]PersonaFilters personaFilters)
        {
            var persona = _registroRepository.GetPersonas(personaFilters);
            return Ok(persona);
        }

        [HttpGet ("{identificador}")]
        public async Task<IActionResult> GetPersona(int identificador)
        {
            var persona = await _registroRepository.GetPersona(identificador);
            return Ok(persona);
        }

        [HttpPost]
        public async Task<IActionResult> PostPersona(Persona persona )
        {
            await _registroRepository.InsertPersona(persona);
            return Ok(persona);
        }

        [HttpPut ("{identificador}")]
        public async Task<IActionResult> PutPersona(int identificador, Persona persona)
        {
            var currentePersona = persona;
            currentePersona.Identificador = identificador;
            await _registroRepository.updatePersona(currentePersona);
            return Ok(persona);
        }

        [HttpDelete("{identificador}")]
        public async Task<IActionResult> DeletePersona(int identificador)
        {
            var result = await _registroRepository.DeletePersona(identificador);
            return Ok(result);
        }
    }
}
