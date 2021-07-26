using System.Collections.Generic;
using PortalCidadao.Application.Model;

namespace PortalCidadao.Application.Services.Interfaces
{
    public interface IPostagemService
    {
        BaseModel<IEnumerable<PostagemModel>> ListarTodos();
    }
}
