using System.Collections.Generic;
using System.Threading.Tasks;
using PortalCidadao.Api.Domain.Models;
using PortalCidadao.Domain.Models;

namespace PortalCidadao.Application.Repositories
{
    public interface IPostagemRepository
    {
        Task<IEnumerable<Postagem>> ListarTodos(string bairro, int categoriaId, int subcategoriaId);
        Task<Postagem> ObterPorId(int id);
        Task<IEnumerable<Categoria>> ListarCategorias();
        Task<IEnumerable<string>> ListarBairros();
        Task Inserir(Postagem postagem);
        Task<Postagem> ObterDetalhado(int id);
    }
}
