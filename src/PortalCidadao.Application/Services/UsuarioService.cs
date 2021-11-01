using AutoMapper;
using PortalCidadao.Application.Model;
using PortalCidadao.Application.Repositories;
using PortalCidadao.Application.Services.Interfaces;
using PortalCidadao.Application.Validators;
using PortalCidadao.Domain.Enums;
using PortalCidadao.Domain.Models;
using PortalCidadao.Shared.Extensions;
using System.Threading.Tasks;

namespace PortalCidadao.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly LoginModelValidator _loginModelValidator;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IMapper mapper,
            ITokenService tokenService,
            IUsuarioRepository usuarioRepository,
            LoginModelValidator loginModelValidator
            )
        {
            _mapper = mapper;
            _tokenService = tokenService;
            _usuarioRepository = usuarioRepository;
            _loginModelValidator = loginModelValidator;
        }


        public async Task<BaseModel<UsuarioModel>> Autenticar(LoginModel loginModel)
        {
            loginModel.Senha = Md5HashExtensions.CreateMD5(loginModel.Senha);
            var validator = await _loginModelValidator.ValidateAsync(loginModel);
            if (!validator.IsValid)
                return new BaseModel<UsuarioModel>(false, EMensagens.DadosInvalidos);

            var result = await _usuarioRepository.AutenticarAsync(loginModel.Login, loginModel.Senha);

            if (result == default)
                return new BaseModel<UsuarioModel>(false, EMensagens.EmailOuSenhaInvalidos);

            var map = _mapper.Map<UsuarioModel>(result);
            map.Token = _tokenService.GenerateToken(map);

            return new BaseModel<UsuarioModel>(true, EMensagens.RealizadaComSucesso, map);
        }

        public async Task<BaseModel<UsuarioCadastroModel>> InserirAsync(UsuarioCadastroModel usuarioCadastroModel)
        {
            usuarioCadastroModel.Senha = Md5HashExtensions.CreateMD5(usuarioCadastroModel.Senha);
            var validator = await new UsuarioCadastroModelValidator().ValidateAsync(usuarioCadastroModel);
            if (!validator.IsValid)
                return new BaseModel<UsuarioCadastroModel>(false, EMensagens.DadosInvalidos) ;

            var usuarioJaExiste = await _usuarioRepository.ObterUsuarioAsync(usuarioCadastroModel.CPF, usuarioCadastroModel.Email); 
            if(usuarioJaExiste is not null)
                return new BaseModel<UsuarioCadastroModel>(false, EMensagens.UsuarioJaCadastrado);

            var usuario = _mapper.Map<Usuario>(usuarioCadastroModel);
            var result = _mapper.Map<UsuarioCadastroModel>(await _usuarioRepository.InserirAsync(usuario));
            return new BaseModel<UsuarioCadastroModel>(true, EMensagens.RealizadaComSucesso, result);
        }
        public async Task<BaseModel<UsuarioModel>> AtualizarAsync(int id, UsuarioAlteracaoModel usuarioAlteracaoModel)
        {
            if (!string.IsNullOrEmpty(usuarioAlteracaoModel.Email))
            {
                var emailJaExiste = await _usuarioRepository.VerificarEmailAsync(usuarioAlteracaoModel.Email, id);
                if (emailJaExiste is not null)
                    return new BaseModel<UsuarioModel>(false, EMensagens.UsuarioJaCadastrado);
            }

            var usuario = _mapper.Map<Usuario>(usuarioAlteracaoModel);
            await _usuarioRepository.AtualizarAsync(usuario, id);
            var result = _mapper.Map<UsuarioModel>(await _usuarioRepository.ObterUsuarioPorIdAsync(id));
            return new BaseModel<UsuarioModel>(true, EMensagens.RealizadaComSucesso, result);
        }
    }
}