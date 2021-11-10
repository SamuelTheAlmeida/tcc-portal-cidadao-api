﻿using AutoMapper;
using PortalCidadao.Application.Model;
using PortalCidadao.Domain.Enums;
using PortalCidadao.Domain.Models;
using PortalCidadao.Shared.Extensions;

namespace PortalCidadao.Application.Mappers
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<Usuario, UsuarioModel>().ReverseMap();


            CreateMap<Usuario, UsuarioModel>()
                .ForMember(p => p.Id, p => p.MapFrom(x => x.Id))
                .ForMember(p => p.Email, p => p.MapFrom(x => x.Email))
                .ForMember(p => p.PerfilId, p => p.MapFrom(x => x.Perfil.GetEnumValue()))
                .ForMember(p => p.Perfil, p => p.MapFrom(x => new EnumModel(x.Perfil)))
                .ForMember(p => p.Senha, p => p.MapFrom(x => x.Senha))
                .ForMember(p => p.TokenRedefinicaoSenha, p => p.MapFrom(x => x.TokenRedefinicaoSenha))
                .ForMember(p => p.Token, p => p.Ignore());

            CreateMap<UsuarioModel, Usuario>()
                .ForMember(p => p.Id, p => p.MapFrom(x => x.Id))
                .ForMember(p => p.Email, p => p.MapFrom(x => x.Email))
                .ForMember(p => p.Perfil, p => p.MapFrom(x => x.PerfilId.Value.GetEnum<EPerfis>()))
                .ForMember(p => p.TokenRedefinicaoSenha, p => p.MapFrom(x => x.TokenRedefinicaoSenha))
                .ForMember(p => p.Senha, p => p.MapFrom(x => x.Senha));

        }
    }
}
