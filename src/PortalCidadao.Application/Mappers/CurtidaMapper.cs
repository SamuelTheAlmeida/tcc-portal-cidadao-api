using AutoMapper;
using PortalCidadao.Application.Model;
using PortalCidadao.Domain.Enums;
using PortalCidadao.Domain.Models;
using PortalCidadao.Shared.Extensions;

namespace PortalCidadao.Application.Mappers
{
    public class CurtidaMapper : Profile
    {
        public CurtidaMapper()
        {
            //CreateMap<Postagem, PostagemModel>().ReverseMap();

            //.ForMember(p => p.Perfil, p => p.MapFrom(x => new EnumModel(x.Perfil)))

            CreateMap<Curtida, CurtidaModel>()
               .ForMember(p => p.Id, p => p.MapFrom(x => x.Id))
               .ForMember(p => p.Acao, p => p.MapFrom(x => x.Acao))
               .ForMember(p => p.Pontos, p => p.MapFrom(x => x.Pontos))
               .ForMember(p => p.UsuarioId, p => p.MapFrom(x => x.UsuarioId))
               .ForMember(p => p.PostagemId, p => p.MapFrom(x => x.PostagemId));


            CreateMap<CurtidaModel, Curtida>()
               .ForMember(p => p.Id, p => p.MapFrom(x => x.Id))
               .ForMember(p => p.Acao, p => p.MapFrom(x => x.Acao))
               .ForMember(p => p.Pontos, p => p.MapFrom(x => x.Pontos))
               .ForMember(p => p.UsuarioId, p => p.MapFrom(x => x.UsuarioId))
               .ForMember(p => p.PostagemId, p => p.MapFrom(x => x.PostagemId));
        }
    }
}
