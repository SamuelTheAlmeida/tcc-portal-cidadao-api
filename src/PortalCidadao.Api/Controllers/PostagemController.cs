﻿using Microsoft.AspNetCore.Mvc;
using PortalCidadao.Application.Model;
using PortalCidadao.Application.Services.Interfaces;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PortalCidadao.Api.Request;

namespace PortalCidadao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostagemController : ControllerBase
    {
        private readonly IPostagemService _service;
        public PostagemController(IPostagemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos(string bairro, int categoriaId) =>
             Ok(await _service.ListarTodos(bairro, categoriaId));

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id) =>
             Ok(await _service.ObterPorId(id));

        [HttpGet("detalhes/{id:int}")]
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
        public async Task<IActionResult> ListarCategorias() =>
            Ok(await _service.ListarCategorias());


        [HttpGet("subcategorias")]
        public IActionResult ListarSubcategorias() =>
            Ok(_service.ListarSubcategorias());

        [HttpGet("bairros")]
        public async Task<IActionResult> ListarBairros() =>
            Ok(await _service.ListarBairros());

        //[HttpGet]
        //public async Task<IActionResult> ListarOrgaos()
        //{
        //    return Ok(await _service.ListarOrgaos());
        //}

    }
}
