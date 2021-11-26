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
            
            CreateMap<DashboardAtrasados, DashboardAtrasadosItem>()
                .ForMember(p => p.Mes, p => p.MapFrom(x => x.Mes))
                .ForMember(p => p.QtdPostagens, p => p.MapFrom(x => x.QtdPostagens));

                CreateMap<DashboardAtrasadosItem, DashboardAtrasados>()
                .ForMember(p => p.Mes, p => p.MapFrom(x => x.Mes))
                .ForMember(p => p.QtdPostagens, p => p.MapFrom(x => x.QtdPostagens));


        }
    }
}