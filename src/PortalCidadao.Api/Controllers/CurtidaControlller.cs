using Microsoft.AspNetCore.Mvc;
using PortalCidadao.Application.Model;
using PortalCidadao.Domain.Models;
using PortalCidadao.Application.Services.Interfaces;
using System.Threading.Tasks;

namespace PortalCidadao.Api.Controllers
{
    [Route("api/[controller]")]
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

             [HttpPut("{id}/{Acao}")]
        public async Task<IActionResult> atualizarCurtida(int id, bool Acao) =>
            Ok(await _service.atualizarCurtida(id, Acao));

             [HttpDelete("{id}")]
        public async Task<IActionResult> removerCurtida(int id) =>
            Ok(await _service.removerCurtida(id));

        [HttpGet("{postagemId}/{usuarioId}")]
        public async Task<IActionResult> obterCurtida(int postagemId, int usuarioId) =>
            Ok(await _service.obterCurtida(postagemId, usuarioId));
        
       

        //[HttpGet]
        //public async Task<IActionResult> ListarOrgaos()
        //{
        //    return Ok(await _service.ListarOrgaos());
        //}

    }
}
