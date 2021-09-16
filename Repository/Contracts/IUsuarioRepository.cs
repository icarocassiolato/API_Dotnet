using Domain.Entity;
using Domain.Entity.Responses;

namespace Repository.Contracts
{
    public interface IUsuarioRepository : IPaiRepository<Usuario>
    {
        Usuario PegarPorEmailSenha(Usuario Usuario);
    }
}