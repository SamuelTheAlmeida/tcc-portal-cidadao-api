using PortalCidadao.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortalCidadao.Application.Repositories
{
    public interface IDashboardRepository
    {
        Task<IEnumerable<DashboardCategoria>> ObterDashboardCategoria();
        Task<IEnumerable<DashboardBairros>> ObterDashboardBairros();
        Task<int> TotalPostagens();
        Task<DashboardAtrasados> ObterDashboardAtrasados(string mes);
        Task<int> ObterTotalAtrasados();

    }
}
