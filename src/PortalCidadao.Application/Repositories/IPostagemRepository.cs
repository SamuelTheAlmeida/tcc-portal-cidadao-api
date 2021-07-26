using System.Collections.Generic;
using PortalCidadao.Domain.Models;

namespace PortalCidadao.Application.Repositories
{
    public interface IPostagemRepository
    {
        IEnumerable<Postagem> ListarTodos();
    }
}
