﻿using AutoMapper;
using PortalCidadao.Application.Model;
using PortalCidadao.Application.Repositories;
using PortalCidadao.Application.Services.Interfaces;
using PortalCidadao.Application.Validators;
using PortalCidadao.Domain.Enums;
using PortalCidadao.Shared.Extensions;
using System.Threading.Tasks;

namespace PortalCidadao.Application.Services
{
    class UsuarioService : IUsuarioService
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
            var validator = _loginModelValidator.Validate(loginModel);
            if (!validator.IsValid)
            {
                return new BaseModel<UsuarioModel>(false, EMensagens.DadosInvalidos);
            }

            var result = await _usuarioRepository.AutenticarAsync(loginModel.Email, loginModel.Senha);

            if (result == default)
            {
                return new BaseModel<UsuarioModel>(false, EMensagens.EmailOuSenhaInvalidos);
            }

            var map = _mapper.Map<UsuarioModel>(result);
            map.Token = _tokenService.GenerateToken(map);

            return new BaseModel<UsuarioModel>(true, EMensagens.RealizadaComSucesso, map);
        }
    }
}
