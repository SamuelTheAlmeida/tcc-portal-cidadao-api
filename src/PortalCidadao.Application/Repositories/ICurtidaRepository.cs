using System.Collections.Generic;
using System.Threading.Tasks;
using PortalCidadao.Api.Domain.Models;
using PortalCidadao.Domain.Models;

namespace PortalCidadao.Application.Repositories
{
    public interface ICurtidaRepository
    {   
       

        Task Inserir(Curtida curtida);
        Task<Curtida> obterCurtida(int postagemId, int usuarioId);
        Task<Curtida> removerCurtida(int curtidaId);
        Task<Curtida> atualizarCurtida(int curtidaId, bool Acao);
        
    }
}
