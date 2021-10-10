using System.Collections.Generic;
using System.Threading.Tasks;
using PortalCidadao.Application.Model;
using Microsoft.AspNetCore.Http;
using PortalCidadao.Domain.Models;

namespace PortalCidadao.Application.Services.Interfaces
{
    public interface ICurtidaService
    {             

        Task<BaseModel> Inserir(Curtida curtida);
        Task<BaseModel<CurtidaModel>> obterCurtida(int postagemId, int usuarioId);
        Task<BaseModel<CurtidaModel>> removerCurtida(int curtidaId);
        Task<BaseModel<CurtidaModel>> atualizarCurtida(int curtidaId, bool Acao);

    }
}
