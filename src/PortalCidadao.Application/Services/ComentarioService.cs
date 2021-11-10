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
    public class ComentarioService : IComentarioService
    {
        private readonly IMapper _mapper;
        private readonly IComentarioRepository _repository;

        public ComentarioService(IComentarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }          
            
        public async Task<BaseModel<IEnumerable<ComentarioModel>>> ListarTodos(int postagemId) =>
            new(true, EMensagens.RealizadaComSucesso, _mapper.Map<IEnumerable<ComentarioModel>>(
                await _repository.ListarTodos(postagemId)));

        public async Task<BaseModel> Inserir(Comentario comentario)
        {            
            await _repository.Inserir(_mapper.Map<Comentario>(comentario));
            return new(true, EMensagens.RealizadaComSucesso);
        }
       
        public async Task<BaseModel<ComentarioModel>> removerComentario(int id) =>
          new(true, EMensagens.RealizadaComSucesso, _mapper.Map<ComentarioModel>(await _repository.removerComentario(id)));



        //public async Task<BaseModel<IEnumerable<OrgaoModel>>> ListarOrgaos() =>
        //    new(true, EMensagens.RealizadaComSucesso, _mapper.Map<IEnumerable<OrgaoModel>>(
        //        await _repository.ListarOrgaos()));
    }
}

