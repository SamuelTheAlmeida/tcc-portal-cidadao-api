using System.Collections.Generic;
using System.Threading.Tasks;
using PortalCidadao.Api.Domain.Models;
using PortalCidadao.Domain.Models;

namespace PortalCidadao.Application.Repositories
{
    public interface IComentarioRepository
    {   
       
        Task Inserir(Comentario comentario);
        Task<IEnumerable<Comentario>> ListarTodos(int postagemId);
        Task<Comentario> removerComentario(int id);

       
        
    }
}
