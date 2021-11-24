using PortalCidadao.Application.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortalCidadao.Application.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<BaseModel<IEnumerable<DashboardCategoriasModel>>> ObterDashboardCategorias();
        Task<BaseModel<IEnumerable<DashboardBairrosModel>>> ObterDashboardBairros();
        Task<BaseModel<IEnumerable<DashboardAtrasadosModel>>> ObterDashboardAtrasados(string mes);

    }
}
