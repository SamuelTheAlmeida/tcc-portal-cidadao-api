using PortalCidadao.Domain.Models;
using System;
using System.Threading.Tasks;

namespace PortalCidadao.Application.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> AutenticarAsync(string login, string senha);
        Task<Usuario> InserirAsync(Usuario usuario);
        Task<Usuario> ObterUsuarioAsync(string cpf = "", string email = "");
        Task<Usuario> ObterUsuarioPorIdAsync(int id);
        Task<Usuario> VerificarEmailAsync(string email, int usuarioId);
        Task<Usuario> AtualizarAsync(Usuario usuario, int id);
        Task AtualizarTokenRedefinicaoSenha(int usuarioId, Guid? token);
        Task<Usuario> BuscarPorTokenRedefinicaoSenha(Guid? token);
    }
}
