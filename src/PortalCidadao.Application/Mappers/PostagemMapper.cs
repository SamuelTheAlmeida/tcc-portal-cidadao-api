using AutoMapper;
using PortalCidadao.Application.Model;
using PortalCidadao.Domain.Enums;
using PortalCidadao.Domain.Models;
using PortalCidadao.Shared.Extensions;

namespace PortalCidadao.Application.Mappers
{
    public class PostagemMapper : Profile
    {
        public PostagemMapper()
        {
            //CreateMap<Postagem, PostagemModel>().ReverseMap();

            //.ForMember(p => p.Perfil, p => p.MapFrom(x => new EnumModel(x.Perfil)))

            CreateMap<Postagem, PostagemModel>()
                .ForMember(p => p.Id, p => p.MapFrom(x => x.Id))
                .ForMember(p => p.Subcategoria, p => p.MapFrom(x => new EnumModel(x.Subcategoria)))
                .ForMember(p => p.CategoriaId, p => p.MapFrom(x => x.Categoria.Id))
                .ForMember(p => p.Categoria, p => p.MapFrom(x => x.Categoria))
                .ForMember(p => p.Titulo, p => p.MapFrom(x => x.Titulo))
                .ForMember(p => p.Descricao, p => p.MapFrom(x => x.Descricao))
                .ForMember(p => p.ImagemUrl, p => p.MapFrom(x => x.ImagemUrl))
                .ForMember(p => p.Latitude, p => p.MapFrom(x => x.Latitude))
                .ForMember(p => p.Longitude, p => p.MapFrom(x => x.Longitude))
                .ForMember(p => p.Bairro, p => p.MapFrom(x => x.Bairro))
                .ForMember(p => p.DataCadastro, p => p.MapFrom(x => x.DataCadastro))
                .ForMember(p => p.Resolvido, p => p.MapFrom(x => x.Resolvido))
                .ForMember(p => p.UsuarioId, p => p.MapFrom(x => x.UsuarioId))
                .ForMember(p => p.Usuario, p => p.MapFrom(x => x.Usuario))
                .ForMember(p => p.Curtidas, p => p.MapFrom(x => x.Curtidas))
                .ForMember(p => p.Descurtidas, p => p.MapFrom(x => x.Descurtidas));

            CreateMap<PostagemModel, Postagem>()
                .ForMember(p => p.Id, p => p.MapFrom(x => x.Id))
                .ForMember(p => p.Subcategoria, p => p.MapFrom(x => x.Subcategoria.Codigo.GetEnum<ESubcategoria>()))
                .ForMember(p => p.CategoriaId, p => p.MapFrom(x => x.CategoriaId))
                .ForMember(p => p.Categoria, p => p.MapFrom(x => x.Categoria))
                .ForMember(p => p.Titulo, p => p.MapFrom(x => x.Titulo))
                .ForMember(p => p.Descricao, p => p.MapFrom(x => x.Descricao))
                .ForMember(p => p.ImagemUrl, p => p.MapFrom(x => x.ImagemUrl))
                .ForMember(p => p.Latitude, p => p.MapFrom(x => x.Latitude))
                .ForMember(p => p.Longitude, p => p.MapFrom(x => x.Longitude))
                .ForMember(p => p.Bairro, p => p.MapFrom(x => x.Bairro))
                .ForMember(p => p.DataCadastro, p => p.MapFrom(x => x.DataCadastro))
                .ForMember(p => p.Resolvido, p => p.MapFrom(x => x.Resolvido))
                .ForMember(p => p.UsuarioId, p => p.MapFrom(x => x.UsuarioId))
                .ForMember(p => p.Curtidas, p => p.MapFrom(x => x.Curtidas))
                .ForMember(p => p.Descurtidas, p => p.MapFrom(x => x.Descurtidas));
        }
    }
}
