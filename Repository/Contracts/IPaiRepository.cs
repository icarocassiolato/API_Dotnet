using System;
using System.Collections.Generic;
using Domain.Contracts;

namespace Repository.Contracts
{
    public interface IPaiRepository<TEntity> : IDisposable where TEntity : class, IIdentityEntity
    {
        TEntity Adicionar(TEntity obj);
        int AdicionarVarios(IEnumerable<TEntity> entities);

        TEntity PegarPorId(object id);
        IEnumerable<TEntity> PegarTodos();

        int Atualizar(TEntity obj);
        int AtualizarVarios(IEnumerable<TEntity> entities);

        bool Remover(object id);
        int Remover(TEntity obj);
        int RemoverVarios(IEnumerable<TEntity> entities);
    }
}