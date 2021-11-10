
using PortalCidadao.Application.Model;
using System.Threading.Tasks;

namespace PortalCidadao.Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<BaseModel<UsuarioModel>> Autenticar(LoginModel loginModel);
        Task<BaseModel<UsuarioCadastroModel>> InserirAsync(UsuarioCadastroModel usuarioCadastroModel);
        Task<BaseModel<UsuarioModel>> AtualizarAsync(int id, UsuarioAlteracaoModel usuarioAlteracaoModel);
        Task EsqueciSenha(string email);
        Task RedefinirSenha(RedefinicaoSenhaModel redefinicaoSenhaModel);
    }
}
