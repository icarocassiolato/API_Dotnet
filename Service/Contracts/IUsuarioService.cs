using Domain.Entity;
using Domain.Entity.Responses;

namespace Service.Contracts
{
    public interface IUsuarioService
    {
        LoginResponse PegarPorEmailSenha(Usuario usuario);
    }
}