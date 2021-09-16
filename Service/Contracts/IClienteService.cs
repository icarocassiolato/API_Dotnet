using System.Collections.Generic;
using Domain.Entity;

namespace Service.Contracts
{
    public interface IClienteService
    {
        IEnumerable<Cliente> PegarTodos();

        Cliente PegarPorId(object id);

        Cliente Adicionar(Cliente cliente);

        int Atualizar(Cliente cliente);

        bool Remover(object id);
    }
}
