using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using PortalCidadao.Application.Services.Interfaces;

namespace PortalCidadao.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArquivoController : ControllerBase
    {
        private readonly IArquivoService _service;
        public ArquivoController(IArquivoService service)
        {
            _service = service;
        }

        [HttpGet("{nomeArquivo}")]
        public async Task<IActionResult> ObterArquivo(string nomeArquivo)
        {
            try
            {
                var arquivo = await _service.ObterArquivo(nomeArquivo);
                return Ok(new FileContentResult(arquivo, new MediaTypeHeaderValue("image/jpeg")));
            }
            catch (FileNotFoundException)
            {
                return Ok(new FileContentResult(System.Array.Empty<byte>(), new MediaTypeHeaderValue("image/jpeg")));
            }

        }
    }
}
