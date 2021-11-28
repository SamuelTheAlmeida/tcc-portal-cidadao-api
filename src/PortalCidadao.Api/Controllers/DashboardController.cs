using Microsoft.AspNetCore.Mvc;
using PortalCidadao.Application.Services.Interfaces;
using System.Threading.Tasks;

namespace PortalCidadao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;
        public DashboardController(IDashboardService service)
        {
            _service = service;
        }

        [HttpGet("categorias")]
        public async Task<IActionResult> Categorias()
        {
            return Ok(await _service.ObterDashboardCategorias());
        }

        [HttpGet("bairros")]
        public async Task<IActionResult> Bairros()
        {
            return Ok(await _service.ObterDashboardBairros());
        }
        [HttpGet("atrasados")]
        public async Task<IActionResult> Atrasados([FromQuery] int mesInicio, [FromQuery] int mesFim)
        {
            var result = await _service.ObterDashboardAtrasados(mesInicio, mesFim);
            return Ok(result);
        }
        [HttpGet("abertos")]
        public async Task<IActionResult> Abertos([FromQuery]int mesInicio, [FromQuery] int mesFim)
        {
            var result = await _service.ObterDashboardAbertos(mesInicio, mesFim);
            return Ok(result);     
        }

        [HttpGet("seguranca")]
        public async Task<IActionResult> Segurança()
        {
            var result = await _service.ObterDashboardSeguranca();
            return Ok(result);
        }
    }
}
