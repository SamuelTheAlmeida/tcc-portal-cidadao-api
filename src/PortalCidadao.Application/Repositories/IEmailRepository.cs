using System;
using System.Threading.Tasks;

namespace PortalCidadao.Application.Repositories
{
    public interface IEmailRepository
    {
        Task EsqueciSenha(string nome, string email, Guid tokenRedefinicao);
    }
}
