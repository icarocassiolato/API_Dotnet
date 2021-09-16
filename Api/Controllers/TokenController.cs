
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Domain.Entity;
using System;

namespace Api.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenUsuarioService _tokenUsuarioService;

        public TokenController(ITokenUsuarioService tokenUsuarioService)
            => this._tokenUsuarioService = tokenUsuarioService;

        [HttpPost]
        public ActionResult<string> GerarToken([FromBody] Usuario usuario)
            => Ok(_tokenUsuarioService.Gerar(usuario, DateTime.UtcNow.AddHours(2)));
    }
}
