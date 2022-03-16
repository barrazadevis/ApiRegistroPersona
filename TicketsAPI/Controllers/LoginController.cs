using Microsoft.AspNetCore.Mvc;
using RegistroInfraestructure.Data;
using System.Threading.Tasks;
using TicketCore.Interfaces;

namespace RegistroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController: Controller
    {
        private readonly IRegistroRepository _registroRepository;

        public LoginController(IRegistroRepository registroRepository)
        {
            _registroRepository = registroRepository;
        }

        //[HttpGet]
        //public IActionResult GetUsuarios([FromQuery] UsuarioFilters usuarioFilters)
        //{
        //    var usuario = _registroRepository.GetUsuarios(usuarioFilters);
        //    return Ok(usuario);
        //}

        [HttpPost()]
        public async Task<IActionResult> PostObtenerUsuario(Usuario usuario)
        {
            Usuario usuarioResult = await _registroRepository.PostObtenerUsuario(usuario);
            return Ok(usuarioResult);
        }
    }
}
