using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entity;
using Domain.Entity.Responses;
using Repository.Contracts;
using Service.Contracts;

namespace Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        private readonly ITokenUsuarioService _tokenUsuarioService;

        public UsuarioService(IUsuarioRepository usuarioRepository, ITokenUsuarioService tokenUsuarioService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenUsuarioService = tokenUsuarioService;
        }

        public LoginResponse PegarPorEmailSenha(Usuario usuario)
        {
            Usuario resultado = _usuarioRepository.PegarPorEmailSenha(usuario);

            if (resultado == null)
                return new LoginResponse();

            if (resultado.TokenUsuarios.Count == 0)
            {
                resultado.TokenUsuarios = new List<TokenUsuario>();
                resultado.TokenUsuarios.Add(
                    new TokenUsuario
                    {
                        Token = _tokenUsuarioService.Gerar(resultado, DateTime.UtcNow.AddHours(2))
                    });
            }

            return new LoginResponse
            {
                Nome = resultado.Nome,
                Email = resultado.Email,
                Acesso = resultado.Acesso,
                Token = resultado.TokenUsuarios.First().Token
            };
        }
    }
}