using System.Threading.Tasks;
using PortalCidadao.Application.Repositories;
using PortalCidadao.Application.Services.Interfaces;

namespace PortalCidadao.Application.Services
{
    public class ArquivoService : IArquivoService
    {
        private readonly IArquivoRepository _arquivoRepository;
        public ArquivoService(IArquivoRepository arquivoRepository)
        {
            _arquivoRepository = arquivoRepository;
        }

        public async Task<byte[]> ObterArquivo(string caminho) =>
            await _arquivoRepository.Obter(caminho);
    }
}
