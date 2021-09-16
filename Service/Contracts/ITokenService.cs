using System;
using System.Collections.Generic;
using System.Security.Claims;
using Domain.Entity;

public interface ITokenUsuarioService
{
    bool Existe(string token);

    List<Claim> Decodificar(string token);

    string Gerar(Usuario usuario, DateTime? expiracao = null);
}