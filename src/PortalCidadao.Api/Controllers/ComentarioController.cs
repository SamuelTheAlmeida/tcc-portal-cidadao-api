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
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioService _service;
        public ComentarioController(IComentarioService service)
        {
            _service = service;
        }
        

            [HttpPost]
        public async Task<IActionResult> Inserir(Comentario model) =>
            Ok(await _service.Inserir(model));

            [HttpDelete("{id}")]
        public async Task<IActionResult> removerComentario(int id) =>
            Ok(await _service.removerComentario(id));
            

        [HttpGet("{postagemId}")]
        [AllowAnonymous]
        public async Task<IActionResult> ListarTodos(int postagemId) =>
            Ok(await _service.ListarTodos(postagemId));
        
       

        //[HttpGet]
        //public async Task<IActionResult> ListarOrgaos()
        //{
        //    return Ok(await _service.ListarOrgaos());
        //}

    }
}
