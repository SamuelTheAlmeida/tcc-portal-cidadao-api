﻿using Microsoft.IdentityModel.Tokens;
using PortalCidadao.Application.Model;
using PortalCidadao.Application.Services.Interfaces;
using PortalCidadao.Shared.Helpers;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PortalCidadao.Application.Services
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(UsuarioModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(ConfigurationHelper.PrivateKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new(ClaimTypes.Email, user.Email),
                    new("id", user.Id.ToString()),
                    new(ClaimTypes.Role, user.Perfil.Nome)
                }),
                Expires = DateTime.UtcNow.AddYears(999),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
