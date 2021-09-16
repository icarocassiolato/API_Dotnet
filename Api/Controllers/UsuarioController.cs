
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Domain.Entity;
using Service.Contracts;
using Domain.Entity.Responses;
using Domain.Entity.Requests;

namespace Api.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _UsuarioService;

        public UsuarioController(IUsuarioService UsuarioService)
            => this._UsuarioService = UsuarioService;

        [HttpPost]
        public ActionResult<LoginResponse> Login([FromQuery] LoginRequest request)
        {
            Usuario usuario = new Usuario();
            usuario.Nome = request.Nome;
            usuario.Email = request.Email;
            usuario.Senha = request.Senha;
            return Ok(_UsuarioService.PegarPorEmailSenha(usuario));
        }
    }
}
