using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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
        private readonly IArquivoRepository _arquivoRepository;

        public PostagemService(IPostagemRepository repository, IArquivoRepository arquivoRepository, IMapper mapper)
        {
            _repository = repository;
            _arquivoRepository = arquivoRepository;
            _mapper = mapper;
        }

                 public async Task<BaseModel<PostagemModel>> resolverPostagem(int id, bool resolvido) =>
          new(true, EMensagens.RealizadaComSucesso, _mapper.Map<PostagemModel>(await _repository.resolverPostagem(id,resolvido)));

        public async Task<BaseModel<IEnumerable<PostagemModel>>> ListarTodos(string bairro, int categoriaId, int subCategoriaId) =>
            new(true, EMensagens.RealizadaComSucesso, _mapper.Map<IEnumerable<PostagemModel>>(
                await _repository.ListarTodos(bairro, categoriaId, subCategoriaId)));

   public async Task<BaseModel<IEnumerable<PostagemModel>>> PostagensAbertasPorMes(string mes) =>
            new(true, EMensagens.RealizadaComSucesso, _mapper.Map<IEnumerable<PostagemModel>>(
                await _repository.PostagensAbertasPorMes(mes)));
                
        public async Task<BaseModel<PostagemModel>> ObterPorId(int id) =>
          new(true, EMensagens.RealizadaComSucesso, _mapper.Map<PostagemModel>(await _repository.ObterDetalhado(id)));

        public async Task<BaseModel> Inserir(PostagemModel model, IFormFile file)
        {
            model.ImagemUrl = await _arquivoRepository.Salvar(file);
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

         public async Task<BaseModel<PostagemModel>> removerPostagem(int id, bool excluir) =>
          new(true, EMensagens.RealizadaComSucesso, _mapper.Map<PostagemModel>(await _repository.removerPostagem(id, excluir)));
        //public async Task<BaseModel<IEnumerable<OrgaoModel>>> ListarOrgaos() =>
        //    new(true, EMensagens.RealizadaComSucesso, _mapper.Map<IEnumerable<OrgaoModel>>(
        //        await _repository.ListarOrgaos()));
    }
}
