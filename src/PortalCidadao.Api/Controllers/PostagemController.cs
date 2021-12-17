using Microsoft.AspNetCore.Mvc;
using PortalCidadao.Application.Model;
using PortalCidadao.Application.Services.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using PortalCidadao.Api.Request;

namespace PortalCidadao.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class PostagemController : ControllerBase
    {
        private readonly IPostagemService _service;
        public PostagemController(IPostagemService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ListarTodos(string bairro, int categoriaId, int subcategoriaId, string confiabilidade) =>
             Ok(await _service.ListarTodos(bairro, categoriaId, subcategoriaId, confiabilidade));

        [HttpGet("mes/{mes}")]
        public async Task<IActionResult> PostagensAbertasPorMes(string mes) =>
             Ok(await _service.PostagensAbertasPorMes(mes)); 

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> ObterPorId(int id) =>
             Ok(await _service.ObterPorId(id));

        [HttpGet("detalhes/{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> ObterDetalhes(int id) =>
            Ok(await _service.ObterPorId(id));

        [HttpPost]
        public async Task<IActionResult> Inserir(
            [FromForm] NovaPostagemRequest request)
        {
            var model = JsonConvert.DeserializeObject<PostagemModel>(request.Model);
            return Ok(await _service.Inserir(model, request.File));
        }

        [HttpGet("categorias")]
        [AllowAnonymous]
        public async Task<IActionResult> ListarCategorias() =>
            Ok(await _service.ListarCategorias());


         [HttpPut("remover/{id}/{excluir}")]
        public async Task<IActionResult> removerPostagem(int id, bool excluir) =>
            Ok(await _service.removerPostagem(id, excluir));

        [HttpPut("{id}/{resolvido}")]
        public async Task<IActionResult> resolverPostagem(int id, bool resolvido) =>
            Ok(await _service.resolverPostagem(id, resolvido));

        [HttpGet("subcategorias")]
        [AllowAnonymous]
        public IActionResult ListarSubcategorias() =>
            Ok(_service.ListarSubcategorias());

        [HttpGet("bairros")]
        [AllowAnonymous]
        public async Task<IActionResult> ListarBairros() =>
            Ok(await _service.ListarBairros());

        [HttpGet("confiabilidades")]
        [AllowAnonymous]
        public async Task<IActionResult> ListarConfiabilidades() =>
            Ok(await _service.ListarConfiabilidades());

        //[HttpGet]
        //public async Task<IActionResult> ListarOrgaos()
        //{
        //    return Ok(await _service.ListarOrgaos());
        //}

    }
}
