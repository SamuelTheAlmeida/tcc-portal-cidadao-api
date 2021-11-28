using AutoMapper;
using PortalCidadao.Application.Model;
using PortalCidadao.Domain.Models;

namespace PortalCidadao.Application.Mappers
{
    public class DashboardAbertosMapper : Profile
    {
        public DashboardAbertosMapper()
        {
            CreateMap<DashboardAbertos, DashboardAbertosModel>().ReverseMap();
            
            CreateMap<DashboardAbertos, DashboardAbertosItem>()
                .ForMember(p => p.Mes, p => p.MapFrom(x => x.Mes))
                .ForMember(p => p.QtdPostagens, p => p.MapFrom(x => x.QtdPostagens));

                CreateMap<DashboardAbertosItem, DashboardAbertos>()
                .ForMember(p => p.Mes, p => p.MapFrom(x => x.Mes))
                .ForMember(p => p.QtdPostagens, p => p.MapFrom(x => x.QtdPostagens));


        }
    }
}