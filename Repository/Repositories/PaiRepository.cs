using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Repository.Connection;
using Repository.Contracts;

namespace Repository.Repositories
{
    public class PaiRepository<TEntity> : IPaiRepository<TEntity> where TEntity : class, IIdentityEntity
    {

        protected readonly ApplicationContext dbContext;
        protected readonly DbSet<TEntity> dbSet;

        protected PaiRepository(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TEntity>();
        }

        public void Dispose()
        {
            dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            var r = dbSet.Add(obj);
            Salvar();
            return r.Entity;
        }

        public virtual int AdicionarVarios(IEnumerable<TEntity> entities)
        {
            dbSet.AddRange(entities);
            return Salvar();
        }

        public virtual IEnumerable<TEntity> PegarTodos() => dbSet;

        public virtual TEntity PegarPorId(object id) => dbSet.Find(id);

        public virtual bool Remover(object id)
        {
            TEntity entity = PegarPorId(id);

            if (entity == null)
                return false;

            return Remover(entity) > 0;
        }

        public virtual int Remover(TEntity obj)
        {
            dbSet.Remove(obj);
            return Salvar();
        }

        public virtual int RemoverVarios(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
            return Salvar();
        }

        public virtual int Atualizar(TEntity obj)
        {
            dbContext.Entry(obj).State = EntityState.Modified;
            return Salvar();
        }

        public virtual int AtualizarVarios(IEnumerable<TEntity> entities)
        {
            dbSet.UpdateRange(entities);
            return Salvar();
        }

        private int Salvar() => dbContext.SaveChanges();
    }
}