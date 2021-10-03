using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PortalCidadao.Application.Repositories;

namespace PortalCidadao.Infra.Data.Repositories
{
    public class ArquivoRepository : IArquivoRepository
    {
        public async Task<string> Salvar(IFormFile file)
        {
            const string uploads = "\\tmp\\uploads-portal-cidadao"; // pegar do appsettings
            var filePath = Path.Combine(uploads, file.FileName);
            await using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return filePath;
        }
    }
}
