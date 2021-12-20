using Microsoft.AspNetCore.Http;

namespace PortalCidadao.Api.Request
{
    public class NovaPostagemRequest
    {
        public IFormFile File { get; set; }
        public string Model { get; set; }
    }
}
