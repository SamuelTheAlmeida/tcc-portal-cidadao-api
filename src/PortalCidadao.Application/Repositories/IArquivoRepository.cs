using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PortalCidadao.Application.Repositories
{
    public interface IArquivoRepository
    {
        Task<string> Salvar(IFormFile file);
    }
}
