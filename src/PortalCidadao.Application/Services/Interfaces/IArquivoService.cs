using System.Threading.Tasks;

namespace PortalCidadao.Application.Services.Interfaces
{
    public interface IArquivoService
    {
        Task<byte[]> ObterArquivo(string nomeArquivo);
    }
}
