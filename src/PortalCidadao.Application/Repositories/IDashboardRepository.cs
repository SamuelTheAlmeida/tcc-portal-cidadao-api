using PortalCidadao.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortalCidadao.Application.Repositories
{
    public interface IDashboardRepository
    {
        Task<IEnumerable<DashboardCategoria>> ObterDashboardCategoria();
        Task<int> TotalPostagens();
    }
}
