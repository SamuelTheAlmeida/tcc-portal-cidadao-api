using System.Collections.Generic;
using System.Threading.Tasks;
using PortalCidadao.Domain.Models;

namespace PortalCidadao.Application.Repositories
{
    public interface ICurtidaRepository
    {   
        Task Inserir(Curtida curtida);
        Task<Curtida> ObterCurtida(int postagemId, int usuarioId);
        Task<Curtida> RemoverCurtida(int curtidaId);
        Task<Curtida> AtualizarCurtida(int curtidaId, bool Acao);
        Task<IEnumerable<Curtida>> ObterCurtidasPorUsuario(int usuarioId);
    }
}
