using Domain.Entity;

namespace Repository.Contracts
{
    public interface ITokenUsuarioRepository : IPaiRepository<TokenUsuario>
    {
        bool Existe(string token);
    }
}