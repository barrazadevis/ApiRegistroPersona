using Microsoft.AspNetCore.Mvc;
using RegistroCore.Entities;
using RegistroInfraestructure.Data;
using System.Threading.Tasks;
using TicketCore.Interfaces;

namespace RegistroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {

        private readonly IRegistroRepository _registroRepository;

        public UsuarioController(IRegistroRepository registroRepository)
        {
            _registroRepository = registroRepository;
        }

        [HttpGet]
        public IActionResult GetUsuarios([FromQuery] UsuarioFilters usuarioFilters)
        {
            var usuario = _registroRepository.GetUsuarios(usuarioFilters);
            return Ok(usuario);
        }

        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> GetUsuario(int idUsuario)
        {
            var usuario = await _registroRepository.GetUsuario(idUsuario);
            return Ok(usuario);
        }

        
        [HttpPost]
        public async Task<IActionResult> PostUsuario(Usuario usuario)
        {
            await _registroRepository.InsertUsuario(usuario);
            return Ok(usuario);
        }

        [HttpPut("{idUsuario}")]
        public async Task<IActionResult> PutUsuario(int idUsuario, Usuario usuario)
        {
            var currentUsuario = usuario;
            currentUsuario.IdUsuario = idUsuario;
            await _registroRepository.updateUsuario(currentUsuario);
            return Ok(usuario);
        }

        [HttpDelete("{idUsuario}")]
        public async Task<IActionResult> DeleteUsuario(int idUsuario)
        {
            var result = await _registroRepository.DeleteUsuario(idUsuario);
            return Ok(result);
        }
    }
}
