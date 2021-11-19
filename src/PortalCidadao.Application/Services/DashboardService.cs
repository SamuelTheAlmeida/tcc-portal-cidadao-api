using PortalCidadao.Application.Model;
using PortalCidadao.Application.Repositories;
using PortalCidadao.Application.Services.Interfaces;
using PortalCidadao.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace PortalCidadao.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;
        private readonly IMapper _mapper;
        public DashboardService(IDashboardRepository dashboardRepository, IMapper mapper)
        {
            _dashboardRepository = dashboardRepository;
            _mapper = mapper;
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

        public async Task<BaseModel<IEnumerable<DashboardBairrosModel>>> ObterDashboardBairros()
        {
            var dashboardBairros = await _dashboardRepository.ObterDashboardBairros();
            var dados = _mapper.Map<IEnumerable<DashboardBairrosModel>>(dashboardBairros);

            return new BaseModel<IEnumerable<DashboardBairrosModel>>(sucesso: true, EMensagens.RealizadaComSucesso, dados);
        }
    }
}
