using System;
using PortalCidadao.Application.Model;
using PortalCidadao.Application.Repositories;
using PortalCidadao.Application.Services.Interfaces;
using PortalCidadao.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PortalCidadao.Domain.Models;

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
        public async Task<BaseModel<DashboardAtrasadosModel>> ObterDashboardAtrasados(int mesInicio, int mesFim)
        {
            var dashboardAtrasados = new List<DashboardAtrasados>();
            var data = new DateTime(DateTime.MinValue.Month, mesInicio, DateTime.MinValue.Day);

            var mes = data.Month;
            while (mes != mesFim)
            {
                dashboardAtrasados.Add(await _dashboardRepository.ObterDashboardAtrasados(mes.ToString()));
                data = data.AddMonths(1);
                mes = data.Month;
            }

            var itens = _mapper.Map<IEnumerable<DashboardAtrasadosItem>>(dashboardAtrasados);
            var total = await _dashboardRepository.ObterTotalAtrasados();

            var dados = new DashboardAtrasadosModel
            {
                Itens = itens,
                TotalAtrasados = total
            };

            var baseModelResult = new BaseModel<DashboardAtrasadosModel>(sucesso: true, EMensagens.RealizadaComSucesso, dados);
            return baseModelResult;
        }
         public async Task<BaseModel<DashboardAbertosModel>> ObterDashboardAbertos(int mesInicio, int mesFim)
        {
            var dashboardAbertos = new List<DashboardAbertos>();
            var data = new DateTime(DateTime.MinValue.Month, mesInicio, DateTime.MinValue.Day);

            var mes = data.Month;
            while (mes != mesFim)
            {
                dashboardAbertos.Add(await _dashboardRepository.ObterDashboardAbertos(mes.ToString()));
                data = data.AddMonths(1);
                mes = data.Month;
            }

            var itens = _mapper.Map<IEnumerable<DashboardAbertosItem>>(dashboardAbertos);
            var total = await _dashboardRepository.ObterTotalAbertos();

            var dados = new DashboardAbertosModel
            {
                Itens = itens,
                TotalAbertos = total
            };

            var baseModelResult = new BaseModel<DashboardAbertosModel>(sucesso: true, EMensagens.RealizadaComSucesso, dados);
            return baseModelResult;
        }
       
        
    }
}
