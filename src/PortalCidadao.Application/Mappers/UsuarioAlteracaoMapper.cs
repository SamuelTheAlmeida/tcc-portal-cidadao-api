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
                .ForMember(p => p.Id, p => p.MapFrom(x => x.Id))
                .ForMember(p => p.Nome, p => p.MapFrom(x => x.Nome))
                .ForMember(p => p.Email, p => p.MapFrom(x => x.Email))
                .ForMember(p => p.Senha, p => p.MapFrom(x => x.Senha));

            CreateMap<UsuarioAlteracaoModel, Usuario>()
                .ForMember(p => p.Id, p => p.MapFrom(x => x.Id))
                .ForMember(p => p.Nome, p => p.MapFrom(x => x.Nome))
                .ForMember(p => p.Email, p => p.MapFrom(x => x.Email))
                .ForMember(p => p.Senha, p => p.MapFrom(x => x.Senha));
        }
    }
}
