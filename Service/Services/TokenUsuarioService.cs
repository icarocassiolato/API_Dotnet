using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Domain.Entity;
using Domain.ValueObjects;
using System.Linq;
using System.Collections.Generic;
using Repository.Contracts;

namespace Service.Services
{
    public class TokenUsuarioService : ITokenUsuarioService
    {
        private readonly ITokenUsuarioRepository tokenRepository;

        public TokenUsuarioService(ITokenUsuarioRepository tokenRepository)
            => this.tokenRepository = tokenRepository;

        public string Gerar(Usuario usuario, DateTime? expiracao = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Acesso.ToString())
                }),
                Expires = expiracao,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public List<Claim> Decodificar(string token)
        {
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var handler = new JwtSecurityTokenHandler();
            var valid = handler.ReadJwtToken(token).ValidTo >= DateTime.Now;

            if (valid)
                return handler.ReadJwtToken(token).Claims.ToList();

            return new List<Claim>();
        }

        public bool Existe(string token)
            => tokenRepository.Existe(token);
    }
}
