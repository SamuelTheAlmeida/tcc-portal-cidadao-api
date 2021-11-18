using PortalCidadao.Application.Model;
using PortalCidadao.Application.Repositories;
using PortalCidadao.Application.Services.Interfaces;
using PortalCidadao.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalCidadao.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;
        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<BaseModel<IEnumerable<DashboardCategoriasModel>>> ObterDashboardCategorias()
        {
            var totalPostagens = await _dashboardRepository.TotalPostagens();
            var dashboardCategorias = await _dashboardRepository.ObterDashboardCategoria();
            var dados = dashboardCategorias.Select(x => new DashboardCategoriasModel
            {
                NomeCategoria = x.NomeCategoria,
                Porcentagem = (x.QtdPostagens / (double)totalPostagens) * 100
            });

            return new BaseModel<IEnumerable<DashboardCategoriasModel>>(sucesso: true, EMensagens.RealizadaComSucesso, dados);
        }
    }
}
