using AutoMapper;
using PortalCidadao.Application.Model;
using PortalCidadao.Domain.Models;

namespace PortalCidadao.Application.Mappers
{
    public class DashboardAtrasadosMapper : Profile
    {
        public DashboardAtrasadosMapper()
        {
            CreateMap<DashboardAtrasados, DashboardAtrasadosModel>().ReverseMap();
            
            CreateMap<DashboardAtrasados, DashboardAtrasadosModel>()
                .ForMember(p => p.Mes, p => p.MapFrom(x => x.Mes))
                .ForMember(p => p.QtdPostagens, p => p.MapFrom(x => x.QtdPostagens));

                CreateMap<DashboardAtrasadosModel, DashboardAtrasados>()
                .ForMember(p => p.Mes, p => p.MapFrom(x => x.Mes))
                .ForMember(p => p.QtdPostagens, p => p.MapFrom(x => x.QtdPostagens));


        }
    }
}