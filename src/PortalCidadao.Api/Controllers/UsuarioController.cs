using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalCidadao.Application.Model;
using PortalCidadao.Application.Services.Interfaces;
using System.Threading.Tasks;

namespace PortalCidadao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            return Ok(await _usuarioService.Autenticar(model));
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro([FromBody] UsuarioCadastroModel usuarioCadastroModel)
        {
            if (usuarioCadastroModel is null)
            {
                return BadRequest();
            }

            var response = await _usuarioService.InserirAsync(usuarioCadastroModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> AlterarDados([FromBody] UsuarioAlteracaoModel usuarioAlteracaoModel)
        {
            if (usuarioAlteracaoModel is null)
                return BadRequest();

            var response = await _usuarioService.AtualizarAsync(usuarioAlteracaoModel);
            return Ok(response);
        }
    }
}
