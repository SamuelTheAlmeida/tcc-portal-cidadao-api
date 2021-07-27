using System.Collections.Generic;
using System.Threading.Tasks;
using PortalCidadao.Domain.Models;

namespace PortalCidadao.Application.Repositories
{
    public interface IPostagemRepository
    {
        Task<IEnumerable<Postagem>> ListarTodos();
        Task Inserir(Postagem postagem);
    }
}
