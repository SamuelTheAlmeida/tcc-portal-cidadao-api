using System.Collections.Generic;
using System.Threading.Tasks;
using PortalCidadao.Application.Model;

namespace PortalCidadao.Application.Services.Interfaces
{
    public interface IPostagemService
    {
        Task<BaseModel<IEnumerable<PostagemModel>>> ListarTodos(string bairro);
        Task<BaseModel<PostagemModel>> ObterPorId(int id);
        Task<BaseModel> Inserir(PostagemModel model);
        Task<BaseModel<IEnumerable<CategoriaModel>>> ListarCategorias();
        BaseModel<IEnumerable<EnumModel>> ListarSubcategorias();
        Task<BaseModel<IEnumerable<string>>> ListarBairros();
    }
}
