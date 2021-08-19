using PortalCidadao.Application.Model;

namespace PortalCidadao.Application.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(UsuarioModel usuario);
    }
}
