using Microsoft.AspNetCore.Mvc;
using PortalCidadao.Domain.Models;
using PortalCidadao.Application.Services.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace PortalCidadao.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CurtidaController : ControllerBase
    {
        private readonly ICurtidaService _service;
        public CurtidaController(ICurtidaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Registra uma curtida ou descurtida em uma postagem
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Inserir(Curtida model) =>
            Ok(await _service.Inserir(model));

        /// <summary>
        /// Atualiza um registro de curtida ou descurtida em uma postagem
        /// </summary>
        /// <param name="id"></param>
        /// <param name="acao"></param>
        /// <returns></returns>
        [HttpPut("{id:int}/{acao:bool}")]
        public async Task<IActionResult> AtualizarCurtida(int id, bool acao) =>
            Ok(await _service.AtualizarCurtida(id, acao));

        /// <summary>
        /// Remove uma curtida ou descurtida em uma postagem
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoverCurtida(int id) =>
            Ok(await _service.RemoverCurtida(id));

        /// <summary>
        /// Obtém os detalhes de curtidas de uma postagem
        /// </summary>
        /// <param name="postagemId"></param>
        /// <param name="usuarioId"></param>
        /// <returns></returns>
        [HttpGet("{postagemId:int}/{usuarioId:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> ObterCurtida(int postagemId, int usuarioId) =>
            Ok(await _service.ObterCurtida(postagemId, usuarioId));
    }
}
