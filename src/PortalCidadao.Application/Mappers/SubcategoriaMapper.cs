using AutoMapper;
using PortalCidadao.Application.Model;
using PortalCidadao.Domain.Enums;
using PortalCidadao.Shared.Extensions;

namespace PortalCidadao.Application.Mappers
{
    public class SubcategoriaMapper : Profile
    {
        public SubcategoriaMapper()
        {
            CreateMap<ESubcategoria, EnumModel>()
                .ForMember(x => x.Codigo,
                    x =>
                        x.MapFrom(y => y.GetEnumValue()))
                .ForMember(x => x.Descricao,
                    x =>
                        x.MapFrom(y => y.GetEnumDescription()))
                .ForMember(x => x.Nome,
                    x =>
                        x.MapFrom(y => y.GetEnumName()))
                .ReverseMap();
        }
    }
}
