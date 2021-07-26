using AutoMapper;
using PortalCidadao.Application.Model;
using PortalCidadao.Domain.Models;

namespace PortalCidadao.Application.Mappers
{
    public class PostagemMapper : Profile
    {
        public PostagemMapper()
        {
            CreateMap<Postagem, PostagemModel>().ReverseMap();
        }
    }
}
