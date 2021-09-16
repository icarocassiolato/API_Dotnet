using System.Collections.Generic;
using Domain.Entity;
using Repository.Contracts;
using Service.Contracts;

namespace Service.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
            => this._clienteRepository = clienteRepository;

        public IEnumerable<Cliente> PegarTodos()
            => _clienteRepository.PegarTodos();

        public Cliente PegarPorId(object id)
            => _clienteRepository.PegarPorId(id);

        public Cliente Adicionar(Cliente cliente)
            => _clienteRepository.Adicionar(cliente);

        public int Atualizar(Cliente cliente)
            => _clienteRepository.Atualizar(cliente);

        public bool Remover(object id)
            => _clienteRepository.Remover(id);
    }
}
