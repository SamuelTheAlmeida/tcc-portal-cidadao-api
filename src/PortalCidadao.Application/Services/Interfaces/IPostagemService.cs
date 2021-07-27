using System.Collections.Generic;
using System.Threading.Tasks;
using PortalCidadao.Application.Model;

namespace PortalCidadao.Application.Services.Interfaces
{
    public interface IPostagemService
    {
        Task<BaseModel<IEnumerable<PostagemModel>>> ListarTodos();
        Task<BaseModel> Inserir(PostagemModel model);
    }
}
