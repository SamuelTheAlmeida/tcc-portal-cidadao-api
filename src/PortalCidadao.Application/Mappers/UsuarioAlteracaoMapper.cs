using AutoMapper;
using PortalCidadao.Application.Model;
using PortalCidadao.Domain.Models;

namespace PortalCidadao.Application.Mappers
{
    public class UsuarioAlteracaoMapper : Profile
    {
        public UsuarioAlteracaoMapper()
        {
            CreateMap<Usuario, UsuarioAlteracaoModel>()
                .ForMember(p => p.Nome, p => p.MapFrom(x => x.Nome))
                .ForMember(p => p.Email, p => p.MapFrom(x => x.Email));

            CreateMap<UsuarioAlteracaoModel, Usuario>()
                .ForMember(p => p.Nome, p => p.MapFrom(x => x.Nome))
                .ForMember(p => p.Email, p => p.MapFrom(x => x.Email));
        }
    }
}
