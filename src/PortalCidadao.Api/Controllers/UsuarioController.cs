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


        /// <summary>
        /// Autenticação do usuário de qualquer perfil no sistema via login e senha
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            return Ok(await _usuarioService.Autenticar(model));
        }


        /// <summary>
        /// Cadastro de novo usuário cidadão no sistema
        /// </summary>
        /// <param name="usuarioCadastroModel"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Alteração de dados do usuário
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuarioAlteracaoModel"></param>
        /// <returns></returns>
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> AlterarDados([FromRoute] int id, [FromBody] UsuarioAlteracaoModel usuarioAlteracaoModel)
        {
            if (usuarioAlteracaoModel is null)
                return BadRequest();

            var response = await _usuarioService.AtualizarAsync(id, usuarioAlteracaoModel);
            return Ok(response);
        }

        /// <summary>
        /// Solicita o envio de e-mail de redefinição de senha
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("esqueci-senha/{email}")]
        [AllowAnonymous]
        public async Task<IActionResult> EsqueciSenha([FromRoute] string email)
        {
            await _usuarioService.EsqueciSenha(email);
            return Ok();
        }

        /// <summary>
        /// Realiza a alteração de senha do usuário
        /// </summary>
        /// <param name="redefinicaoSenhaModel"></param>
        /// <returns></returns>
        [HttpPost("redefinir-senha")]
        [AllowAnonymous]
        public async Task<IActionResult> RedefinirSenha([FromBody] RedefinicaoSenhaModel redefinicaoSenhaModel)
        {
            await _usuarioService.RedefinirSenha(redefinicaoSenhaModel);
            return Ok();
        }
    }
}
