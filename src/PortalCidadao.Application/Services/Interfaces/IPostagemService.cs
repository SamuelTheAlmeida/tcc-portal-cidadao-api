using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PortalCidadao.Application.Model;

namespace PortalCidadao.Application.Services.Interfaces
{
    public interface IPostagemService
    {
        Task<BaseModel<IEnumerable<PostagemModel>>> ListarTodos(string bairro, int categoriaId, int subcategoriaId, string confiabilidade);
        Task<BaseModel<PostagemModel>> ObterPorId(int id);
        Task<BaseModel<PostagemModel>> removerPostagem(int id, bool excluir);
        Task<BaseModel<IEnumerable<PostagemModel>>> PostagensAbertasPorMes(string mes);

        Task<BaseModel> Inserir(PostagemModel model, IFormFile file);
        Task<BaseModel<IEnumerable<CategoriaModel>>> ListarCategorias();
        BaseModel<IEnumerable<EnumModel>> ListarSubcategorias();
        Task<BaseModel<IEnumerable<string>>> ListarBairros();
        Task<BaseModel<IEnumerable<string>>> ListarConfiabilidades();
        Task<BaseModel<PostagemModel>> resolverPostagem(int id, bool resolvido);

    }
}
