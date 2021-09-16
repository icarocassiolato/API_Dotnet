using System.Linq;
using Domain.Entity;
using Repository.Connection;
using Repository.Contracts;

namespace Repository.Repositories
{
    public class TokenUsuarioRepository : PaiRepository<TokenUsuario>, ITokenUsuarioRepository
    {
        public TokenUsuarioRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }

        public bool Existe(string token)
            => dbContext.TokenUsuarios.Where(p => p.Token == token).Count() > 0;
    }
}