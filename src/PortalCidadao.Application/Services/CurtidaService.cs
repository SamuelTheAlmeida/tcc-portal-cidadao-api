using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PortalCidadao.Application.Model;
using PortalCidadao.Application.Repositories;
using PortalCidadao.Application.Services.Interfaces;
using PortalCidadao.Domain.Enums;
using PortalCidadao.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace PortalCidadao.Application.Services
{
    public class CurtidaService : ICurtidaService
    {
        private readonly IMapper _mapper;
        private readonly ICurtidaRepository _repository;

        public CurtidaService(ICurtidaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

     
        public async Task<BaseModel<CurtidaModel>> atualizarCurtida(int curtidaId, bool Acao) =>
          new(true, EMensagens.RealizadaComSucesso, _mapper.Map<CurtidaModel>(await _repository.atualizarCurtida(curtidaId,Acao)));

          public async Task<BaseModel<CurtidaModel>> removerCurtida(int id) =>
          new(true, EMensagens.RealizadaComSucesso, _mapper.Map<CurtidaModel>(await _repository.removerCurtida(id)));

        public async Task<BaseModel<CurtidaModel>> obterCurtida(int postagemId, int usuarioId) =>
         new(true, EMensagens.RealizadaComSucesso, _mapper.Map<CurtidaModel>(await _repository.obterCurtida(postagemId, usuarioId)));

        public async Task<BaseModel> Inserir(Curtida curtida)
        {            
            await _repository.Inserir(_mapper.Map<Curtida>(curtida));
            return new(true, EMensagens.RealizadaComSucesso);
        }




        //public async Task<BaseModel<IEnumerable<OrgaoModel>>> ListarOrgaos() =>
        //    new(true, EMensagens.RealizadaComSucesso, _mapper.Map<IEnumerable<OrgaoModel>>(
        //        await _repository.ListarOrgaos()));
    }
}

