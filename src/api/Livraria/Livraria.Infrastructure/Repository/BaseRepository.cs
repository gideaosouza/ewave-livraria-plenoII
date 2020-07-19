using Livraria.Domain.Entities;
using Livraria.Infrastructure.Context;
using Livraria.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : BaseEntity
    {
        private protected readonly ApplicationDbContext _efContext;

        public BaseRepository(ApplicationDbContext efContext)
        {
            _efContext = efContext;
        }

        public virtual async Task<TEntity> Insert(TEntity obj)
        {
            _efContext.Set<TEntity>().Add(obj);
            await _efContext.SaveChangesAsync();
            return obj;
        }

        public virtual Task Update(TEntity obj)
        {
            _efContext.Entry(obj).State = EntityState.Modified;
            return _efContext.SaveChangesAsync();
        }

        public virtual Task Desabilitar(TEntity obj)
        {
            obj.Habilitado = false;
            _efContext.Entry(obj).State = EntityState.Modified;
            return _efContext.SaveChangesAsync();
        }
        public virtual Task Habilitar(TEntity obj)
        {
            obj.Habilitado = true;
            _efContext.Entry(obj).State = EntityState.Modified;
            return _efContext.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate) =>
            await _efContext.Set<TEntity>().Where(predicate).ToListAsync();

        public virtual async Task<IEnumerable<TEntity>> GetAll() =>
            await _efContext.Set<TEntity>().Where(c => c.Habilitado).ToListAsync();

        public virtual async Task<TEntity> Find(int id) => 
            await _efContext.Set<TEntity>().FindAsync(id);
    }
}
