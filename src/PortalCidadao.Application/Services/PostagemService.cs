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
        private readonly IPontuacaoService _pontuacaoService;
        private readonly IEmailRepository _emailRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PostagemService(IPostagemRepository repository, 
            IArquivoRepository arquivoRepository, 
            IPontuacaoService pontuacaoService,
            IEmailRepository emailRepository,
            IUsuarioRepository usuarioRepository,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _repository = repository;
            _arquivoRepository = arquivoRepository;
            _pontuacaoService = pontuacaoService;
            _emailRepository = emailRepository;
            _usuarioRepository = usuarioRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<BaseModel<PostagemModel>> resolverPostagem(int id, bool resolvido)
        {
            var postagem = await _repository.ObterDetalhado(id);
            var usuario = postagem.Usuario;
            var idUsuarioResolucao = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "id").Value;
            var usuarioResolucao = await _usuarioRepository.ObterUsuarioPorIdAsync(Convert.ToInt32(idUsuarioResolucao));
            var result = await _repository.resolverPostagem(id, resolvido);
            await _emailRepository.PostagemResolvida(usuario.Nome, postagem.Titulo, usuarioResolucao.Nome, usuario.Email);
            return new BaseModel<PostagemModel>(true, EMensagens.RealizadaComSucesso, _mapper.Map<PostagemModel>(result));
        }
            

        public async Task<BaseModel<IEnumerable<PostagemModel>>> ListarTodos(string bairro, int categoriaId, int subCategoriaId, string confiabilidade) => 
            new(true, EMensagens.RealizadaComSucesso, _mapper.Map<IEnumerable<PostagemModel>>(
                await _repository.ListarTodos(bairro, categoriaId, subCategoriaId, confiabilidade)));

        public async Task<BaseModel<IEnumerable<PostagemModel>>> PostagensAbertasPorMes(string mes) =>
            new(true, EMensagens.RealizadaComSucesso, _mapper.Map<IEnumerable<PostagemModel>>(
                await _repository.PostagensAbertasPorMes(mes)));
                
        public async Task<BaseModel<PostagemModel>> ObterPorId(int id) => 
            new(true, EMensagens.RealizadaComSucesso, _mapper.Map<PostagemModel>(await _repository.ObterDetalhado(id)));

        public async Task<BaseModel> Inserir(PostagemModel model, IFormFile file)
        {
            model.ImagemUrl = await _arquivoRepository.Salvar(file);
            model.Confiabilidade = await CalcularConfiabilidade(model.UsuarioId);
            await _repository.Inserir(_mapper.Map<Postagem>(model));
            return new BaseModel(true, EMensagens.RealizadaComSucesso);
        }

        public async Task<BaseModel<IEnumerable<CategoriaModel>>> ListarCategorias() =>
            new(true, EMensagens.RealizadaComSucesso, _mapper.Map<IEnumerable<CategoriaModel>>(
                await _repository.ListarCategorias()).OrderBy(x => x.Nome));

        public BaseModel<IEnumerable<EnumModel>> ListarSubcategorias() => 
            new(true, EMensagens.RealizadaComSucesso,
                _mapper.Map<IEnumerable<EnumModel>>(Enum.GetValues(typeof(ESubcategoria))).OrderBy(x => x.Descricao));

        public async Task<BaseModel<IEnumerable<string>>> ListarBairros() => 
            new(true, EMensagens.RealizadaComSucesso, await _repository.ListarBairros());
             public async Task<BaseModel<IEnumerable<string>>> ListarConfiabilidades() => 
            new(true, EMensagens.RealizadaComSucesso, await _repository.ListarConfiabilidades());

         public async Task<BaseModel<PostagemModel>> removerPostagem(int id, bool excluir) => 
             new(true, EMensagens.RealizadaComSucesso, _mapper.Map<PostagemModel>(await _repository.removerPostagem(id, excluir)));

         private async Task<string> CalcularConfiabilidade(int usuarioId)
         {
             var pontos = await _pontuacaoService.CalcularPontos(usuarioId);
             return ConverterPontosPostagem(pontos);
         }
         private static string ConverterPontosPostagem(float pontos)
         {
             return pontos switch
             {
                 > 20 => "Alta",
                 > 0 => "Média",
                 _ => "Baixa"
             };
         }
    }
}
