using AutoMapper;
using PortalCidadao.Application.Model;
using PortalCidadao.Domain.Models;

namespace PortalCidadao.Application.Mappers
{
    public class DashboardBairrosMapper : Profile
    {
        public DashboardBairrosMapper()
        {
            CreateMap<DashboardBairros, DashboardBairrosModel>().ReverseMap();
        }
    }
}
