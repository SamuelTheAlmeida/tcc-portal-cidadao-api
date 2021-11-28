using PortalCidadao.Application.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortalCidadao.Application.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<BaseModel<IEnumerable<DashboardCategoriasModel>>> ObterDashboardCategorias();
        Task<BaseModel<IEnumerable<DashboardBairrosModel>>> ObterDashboardBairros();
        Task<BaseModel<DashboardAtrasadosModel>> ObterDashboardAtrasados(int mesInicio, int mesFim);
        Task<BaseModel<DashboardAbertosModel>> ObterDashboardAbertos(int mesInicio, int mesFim);
        Task<BaseModel<DashboardSegurancaModel>> ObterDashboardSeguranca();

    }
}
