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
    /// <summary>
    /// Repositorio base com inclusão de relacionamento manual
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : BaseEntity
    {
        private protected readonly ApplicationDbContext _efContext;

        public BaseRepository(ApplicationDbContext efContext)
        {
            _efContext = efContext;
        }

        public virtual async Task<TEntity> Insert(TEntity obj)
        {
            await _efContext.Set<TEntity>().AddAsync(obj).ConfigureAwait(false);
            await _efContext.SaveChangesAsync().ConfigureAwait(false); 
            return obj;
        }

        public virtual async Task Update(TEntity obj)
        {
            _efContext.Entry(obj).State = EntityState.Modified;
            await _efContext.SaveChangesAsync().ConfigureAwait(false); 
        }

        public virtual Task Desabilitar(TEntity obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            obj.Habilitado = false;
            _efContext.Entry(obj).State = EntityState.Modified;
            return _efContext.SaveChangesAsync();
        }
        
        public virtual Task Habilitar(TEntity obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            obj.Habilitado = true;
            _efContext.Entry(obj).State = EntityState.Modified;
            return _efContext.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await  _efContext.Set<TEntity>().Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll() =>
            await _efContext.Set<TEntity>().Where(c => c.Habilitado).ToListAsync().ConfigureAwait(false);
        
        public virtual async Task<TEntity> Find(int id)
        {
            return await _efContext.Set<TEntity>().FirstOrDefaultAsync(c => c.Id == id).ConfigureAwait(false);
        }
    }
}
