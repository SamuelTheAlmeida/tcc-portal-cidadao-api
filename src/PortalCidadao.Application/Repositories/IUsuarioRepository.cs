using PortalCidadao.Domain.Models;
using System.Threading.Tasks;

namespace PortalCidadao.Application.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> AutenticarAsync(string login, string senha);
        Task<Usuario> InserirAsync(Usuario usuario);
        Task<Usuario> ObterUsuarioAsync(string cpf, string email);
    }
}
