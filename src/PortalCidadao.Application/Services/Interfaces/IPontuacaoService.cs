using System.Threading.Tasks;

namespace PortalCidadao.Application.Services.Interfaces
{
    public interface IPontuacaoService
    {
        Task<float> CalcularPontos(int usuarioId);
    }
}
