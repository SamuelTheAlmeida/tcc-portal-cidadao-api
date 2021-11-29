using System.Threading.Tasks;
using PortalCidadao.Application.Model;
using PortalCidadao.Domain.Models;

namespace PortalCidadao.Application.Services.Interfaces
{
    public interface ICurtidaService
    {             
        Task<BaseModel> Inserir(Curtida curtidaModel);
        Task<BaseModel<CurtidaModel>> ObterCurtida(int postagemId, int usuarioId);
        Task<BaseModel<CurtidaModel>> RemoverCurtida(int curtidaId);
        Task<BaseModel<CurtidaModel>> AtualizarCurtida(int curtidaId, bool acao);
    }
}
