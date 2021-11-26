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
            
            CreateMap<DashboardAbertos, DashboardAbertosModel>()
                .ForMember(p => p.Mes, p => p.MapFrom(x => x.Mes))
                .ForMember(p => p.QtdPostagens, p => p.MapFrom(x => x.QtdPostagens));

                CreateMap<DashboardAbertosModel, DashboardAbertos>()
                .ForMember(p => p.Mes, p => p.MapFrom(x => x.Mes))
                .ForMember(p => p.QtdPostagens, p => p.MapFrom(x => x.QtdPostagens));


        }
    }
}