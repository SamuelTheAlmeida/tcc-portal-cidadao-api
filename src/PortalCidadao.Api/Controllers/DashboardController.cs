using Microsoft.AspNetCore.Mvc;
using PortalCidadao.Application.Services.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace PortalCidadao.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;
        public DashboardController(IDashboardService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista os dados para indicadores por categoria
        /// </summary>
        /// <returns></returns>
        [HttpGet("categorias")]
        public async Task<IActionResult> Categorias()
        {
            return Ok(await _service.ObterDashboardCategorias());
        }

        /// <summary>
        /// Lista os dados para indicadores por bairro
        /// </summary>
        /// <returns></returns>
        [HttpGet("bairros")]
        public async Task<IActionResult> Bairros()
        {
            return Ok(await _service.ObterDashboardBairros());
        }

        /// <summary>
        /// Lista os dados para indicadores de postagens em atraso
        /// </summary>
        /// <param name="mesInicio"></param>
        /// <param name="mesFim"></param>
        /// <returns></returns>
        [HttpGet("atrasados")]
        public async Task<IActionResult> Atrasados([FromQuery] int mesInicio, [FromQuery] int mesFim)
        {
            var result = await _service.ObterDashboardAtrasados(mesInicio, mesFim);
            return Ok(result);
        }

        /// <summary>
        /// Lista os dados para indicadores de postagens abertas
        /// </summary>
        /// <param name="mesInicio"></param>
        /// <param name="mesFim"></param>
        /// <returns></returns>
        [HttpGet("abertos")]
        public async Task<IActionResult> Abertos([FromQuery]int mesInicio, [FromQuery] int mesFim)
        {
            var result = await _service.ObterDashboardAbertos(mesInicio, mesFim);
            return Ok(result);     
        }

        /// <summary>
        /// Lista os dados para indicadores de segurança
        /// </summary>
        /// <returns></returns>
        [HttpGet("seguranca")]
        public async Task<IActionResult> Segurança()
        {
            var result = await _service.ObterDashboardSeguranca();
            return Ok(result);
        }
    }
}
