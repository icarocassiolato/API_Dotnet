using Domain.Entity;
using Repository.Connection;
using Repository.Contracts;
using System.Linq;

namespace Repository.Repositories
{
    public class ClienteRepository : PaiRepository<Cliente>, IClienteRepository
    {

        public ClienteRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }
    }
}
