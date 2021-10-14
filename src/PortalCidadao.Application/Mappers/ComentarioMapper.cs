﻿using AutoMapper;
using PortalCidadao.Application.Model;
using PortalCidadao.Domain.Enums;
using PortalCidadao.Domain.Models;
using PortalCidadao.Shared.Extensions;

namespace PortalCidadao.Application.Mappers
{
    public class ComentarioMapper : Profile
    {
        public ComentarioMapper()
        {

           

            //CreateMap<Postagem, PostagemModel>().ReverseMap();

            //.ForMember(p => p.Perfil, p => p.MapFrom(x => new EnumModel(x.Perfil)))

            CreateMap<Comentario, ComentarioModel>()
               .ForMember(p => p.Id, p => p.MapFrom(x => x.Id))
               .ForMember(p => p.Descricao, p => p.MapFrom(x => x.Descricao))
               .ForMember(p => p.DataCadastro, p => p.MapFrom(x => x.DataCadastro))
               .ForMember(p => p.UsuarioId, p => p.MapFrom(x => x.UsuarioId))
               .ForMember(p => p.PostagemId, p => p.MapFrom(x => x.PostagemId));


            CreateMap<ComentarioModel, Comentario>()
               .ForMember(p => p.Id, p => p.MapFrom(x => x.Id))
               .ForMember(p => p.Descricao, p => p.MapFrom(x => x.Descricao))
               .ForMember(p => p.DataCadastro, p => p.MapFrom(x => x.DataCadastro))
               .ForMember(p => p.UsuarioId, p => p.MapFrom(x => x.UsuarioId))
               .ForMember(p => p.PostagemId, p => p.MapFrom(x => x.PostagemId));
        }
    }
}
