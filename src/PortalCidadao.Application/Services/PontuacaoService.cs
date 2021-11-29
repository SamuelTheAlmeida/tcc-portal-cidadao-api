using System;
using System.Linq;
using System.Threading.Tasks;
using PortalCidadao.Application.Repositories;
using PortalCidadao.Application.Services.Interfaces;

namespace PortalCidadao.Application.Services
{
    public class PontuacaoService : IPontuacaoService
    {
        private readonly IPostagemRepository _postagemRepository;
        private readonly ICurtidaRepository _curtidaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public PontuacaoService(IPostagemRepository postagemRepository,
            ICurtidaRepository curtidaRepository,
            IUsuarioRepository usuarioRepository)
        {
            _postagemRepository = postagemRepository;
            _curtidaRepository = curtidaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<float> CalcularPontos(int usuarioId)
        {
            var curtidasUsuario = (await _curtidaRepository.ObterCurtidasPorUsuario(usuarioId)).ToList();
            var positivo = curtidasUsuario.Where(x => x.Acao).Sum(x => x.Pontos);
            var negativo = curtidasUsuario.Where(x => !x.Acao).Sum(x => x.Pontos);

            var saldo = positivo - negativo;
            var quantidadePosts = await _postagemRepository.TotalPorUsuario(usuarioId);
            var usuario = await _usuarioRepository.ObterUsuarioPorIdAsync(usuarioId);
            var mesesCadastro = 12 * (usuario.DataCadastro.Year - DateTime.Now.Year) + usuario.DataCadastro.Month - DateTime.Now.Month;
            var pontosPorMesesCadastro = mesesCadastro > 0 ? mesesCadastro : 0;

            var pontosTotais = (saldo * 2) + quantidadePosts + pontosPorMesesCadastro;
            return pontosTotais;
        }
    }
}
