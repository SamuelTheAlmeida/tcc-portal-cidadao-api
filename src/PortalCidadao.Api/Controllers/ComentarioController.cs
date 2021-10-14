using Microsoft.AspNetCore.Mvc;
using PortalCidadao.Application.Model;
using PortalCidadao.Domain.Models;
using PortalCidadao.Application.Services.Interfaces;
using System.Threading.Tasks;

namespace PortalCidadao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            

        [HttpGet("{postagemId}")]
        public async Task<IActionResult> ListarTodos(int postagemId) =>
            Ok(await _service.ListarTodos(postagemId));
        
       

        //[HttpGet]
        //public async Task<IActionResult> ListarOrgaos()
        //{
        //    return Ok(await _service.ListarOrgaos());
        //}

    }
}
