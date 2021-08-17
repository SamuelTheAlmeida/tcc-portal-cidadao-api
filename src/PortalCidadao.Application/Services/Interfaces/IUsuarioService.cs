
using PortalCidadao.Application.Model;
using System.Threading.Tasks;

namespace PortalCidadao.Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<BaseModel<UsuarioModel>> Autenticar(LoginModel loginModel);
    }
}
