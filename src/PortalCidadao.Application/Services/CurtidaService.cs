using System.Threading.Tasks;
using AutoMapper;
using PortalCidadao.Application.Model;
using PortalCidadao.Application.Repositories;
using PortalCidadao.Application.Services.Interfaces;
using PortalCidadao.Domain.Enums;
using PortalCidadao.Domain.Models;

namespace PortalCidadao.Application.Services
{
    public class CurtidaService : ICurtidaService
    {
        private readonly IMapper _mapper;
        private readonly ICurtidaRepository _repository;
        private readonly IPontuacaoService _pontuacaoService;

        public CurtidaService(ICurtidaRepository repository, 
            IPontuacaoService pontuacaoService, 
            IMapper mapper)
        {
            _repository = repository;
            _pontuacaoService = pontuacaoService;
            _mapper = mapper;
        }        

        public async Task<BaseModel<CurtidaModel>> AtualizarCurtida(int curtidaId, bool acao) => 
            new(true, EMensagens.RealizadaComSucesso, _mapper.Map<CurtidaModel>(await _repository.AtualizarCurtida(curtidaId,acao)));

        public async Task<BaseModel<CurtidaModel>> RemoverCurtida(int id) => 
            new(true, EMensagens.RealizadaComSucesso, _mapper.Map<CurtidaModel>(await _repository.RemoverCurtida(id)));

        public async Task<BaseModel<CurtidaModel>> ObterCurtida(int postagemId, int usuarioId) => 
            new(true, EMensagens.RealizadaComSucesso, _mapper.Map<CurtidaModel>(await _repository.ObterCurtida(postagemId, usuarioId)));

        public async Task<BaseModel> Inserir(Curtida curtidaModel)
        {
            var curtida = _mapper.Map<Curtida>(curtidaModel);
            curtida.Pontos = await CalcularPontos(curtidaModel.UsuarioId);

            await _repository.Inserir(curtida);
            return new BaseModel(true, EMensagens.RealizadaComSucesso);
        }

        private async Task<float> CalcularPontos(int usuarioId)
        {
            var pontos = await _pontuacaoService.CalcularPontos(usuarioId);
            return ConverterPontosCurtida(pontos);
        }

        private static float ConverterPontosCurtida(float pontos)
        {
            return pontos switch
            {
                > 20 => 1.00f,
                > 10 => 0.50f,
                _ => 0.25f
            };
        }
    }
}

