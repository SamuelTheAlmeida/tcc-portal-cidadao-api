using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalCidadao.Application.Model;
using PortalCidadao.Application.Services.Interfaces;
using System.Threading.Tasks;

namespace PortalCidadao.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
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
        [AllowAnonymous]
        public async Task<IActionResult> Cadastro([FromBody] UsuarioCadastroModel usuarioCadastroModel)
        {
            if (usuarioCadastroModel is null)
            {
                return BadRequest();
            }

            var response = await _usuarioService.InserirAsync(usuarioCadastroModel);
            return Ok(response);
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> AlterarDados([FromRoute] int id, [FromBody] UsuarioAlteracaoModel usuarioAlteracaoModel)
        {
            if (usuarioAlteracaoModel is null)
                return BadRequest();

            var response = await _usuarioService.AtualizarAsync(id, usuarioAlteracaoModel);
            return Ok(response);
        }

        [HttpPost("esqueci-senha/{email}")]
        [AllowAnonymous]
        public async Task<IActionResult> EsqueciSenha([FromRoute] string email)
        {
            await _usuarioService.EsqueciSenha(email);
            return Ok();
        }

        [HttpPost("redefinir-senha")]
        [AllowAnonymous]
        public async Task<IActionResult> RedefinirSenha([FromBody] RedefinicaoSenhaModel redefinicaoSenhaModel)
        {
            await _usuarioService.RedefinirSenha(redefinicaoSenhaModel);
            return Ok();
        }
    }
}
