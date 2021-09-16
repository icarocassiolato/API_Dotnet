using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Connection;
using Repository.Contracts;
using System.Linq;

namespace Repository.Repositories
{
    public class UsuarioRepository : PaiRepository<Usuario>, IUsuarioRepository
    {

        public UsuarioRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }

        public Usuario PegarPorEmailSenha(Usuario usuario)
        {
            return dbContext
                .Usuarios
                .Include(u => u.TokenUsuarios)
                .Where(p => (p.Nome == usuario.Nome || p.Email == usuario.Email) && p.Senha == usuario.Senha)
                .Select(p => new Usuario()
                {
                    Nome = p.Nome,
                    Email = p.Email,
                    TokenUsuarios = p.TokenUsuarios
                })
                .FirstOrDefault();
        }
    }
}
