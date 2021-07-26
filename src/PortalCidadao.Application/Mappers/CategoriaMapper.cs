using AutoMapper;
using PortalCidadao.Api.Domain.Models;
using PortalCidadao.Application.Model;

namespace PortalCidadao.Application.Mappers
{
    public class CategoriaMapper : Profile
    {
        public CategoriaMapper()
        {
            CreateMap<Categoria, CategoriaModel>().ReverseMap();
        }
    }
}
