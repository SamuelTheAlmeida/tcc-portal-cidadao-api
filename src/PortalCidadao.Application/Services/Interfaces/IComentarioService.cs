using System.Collections.Generic;
using System.Threading.Tasks;
using PortalCidadao.Application.Model;
using Microsoft.AspNetCore.Http;
using PortalCidadao.Domain.Models;

namespace PortalCidadao.Application.Services.Interfaces
{
    public interface IComentarioService
    {             

        Task<BaseModel> Inserir(Comentario comentario);
        Task<BaseModel<IEnumerable<ComentarioModel>>> ListarTodos(int postagemId);

    }
}
