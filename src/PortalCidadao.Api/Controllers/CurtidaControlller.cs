using Microsoft.AspNetCore.Mvc;
using PortalCidadao.Domain.Models;
using PortalCidadao.Application.Services.Interfaces;
using System.Threading.Tasks;

namespace PortalCidadao.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CurtidaController : ControllerBase
    {
        private readonly ICurtidaService _service;
        public CurtidaController(ICurtidaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(Curtida model) =>
            Ok(await _service.Inserir(model));

        [HttpPut("{id:int}/{acao:bool}")]
        public async Task<IActionResult> AtualizarCurtida(int id, bool acao) =>
            Ok(await _service.AtualizarCurtida(id, acao));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoverCurtida(int id) =>
            Ok(await _service.RemoverCurtida(id));

        [HttpGet("{postagemId:int}/{usuarioId:int}")]
        public async Task<IActionResult> ObterCurtida(int postagemId, int usuarioId) =>
            Ok(await _service.ObterCurtida(postagemId, usuarioId));
    }
}
