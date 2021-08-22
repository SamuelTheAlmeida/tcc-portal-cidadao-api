﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PortalCidadao.Application.Model;
using PortalCidadao.Application.Repositories;
using PortalCidadao.Application.Services.Interfaces;
using PortalCidadao.Domain.Enums;
using PortalCidadao.Domain.Models;

namespace PortalCidadao.Application.Services
{
    public class PostagemService : IPostagemService
    {
        private readonly IMapper _mapper;
        private readonly IPostagemRepository _repository;

        public PostagemService(IPostagemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseModel<IEnumerable<PostagemModel>>> ListarTodos(string bairro) =>
            new(true, EMensagens.RealizadaComSucesso, _mapper.Map<IEnumerable<PostagemModel>>(
                await _repository.ListarTodos(bairro)));

        public async Task<BaseModel<PostagemModel>> ObterPorId(int id) =>
          new(true, EMensagens.RealizadaComSucesso, _mapper.Map<PostagemModel>(await _repository.ObterPorId(id)));

        public async Task<BaseModel> Inserir(PostagemModel model)
        {
            await _repository.Inserir(_mapper.Map<Postagem>(model));
            return new(true, EMensagens.RealizadaComSucesso);
        }

        public async Task<BaseModel<IEnumerable<CategoriaModel>>> ListarCategorias() =>
            new(true, EMensagens.RealizadaComSucesso, _mapper.Map<IEnumerable<CategoriaModel>>(
                await _repository.ListarCategorias()).OrderBy(x => x.Nome));

        public BaseModel<IEnumerable<EnumModel>> ListarSubcategorias() =>
             new(true, EMensagens.RealizadaComSucesso,
                _mapper.Map<IEnumerable<EnumModel>>(Enum.GetValues(typeof(ESubcategoria))).OrderBy(x => x.Descricao));

        public async Task<BaseModel<IEnumerable<string>>> ListarBairros() =>
          new(true, EMensagens.RealizadaComSucesso, await _repository.ListarBairros());

        //public async Task<BaseModel<IEnumerable<OrgaoModel>>> ListarOrgaos() =>
        //    new(true, EMensagens.RealizadaComSucesso, _mapper.Map<IEnumerable<OrgaoModel>>(
        //        await _repository.ListarOrgaos()));
    }
}
