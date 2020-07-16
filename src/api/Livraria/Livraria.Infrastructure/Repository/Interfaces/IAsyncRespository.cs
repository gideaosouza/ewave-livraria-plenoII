using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Infrastructure.Repository.Interfaces
{
    public interface IAsyncRepository<TEntity> where TEntity : BaseEntity
    {

        Task<TEntity> Find(int id);
        Task<TEntity> Insert(TEntity entity);
        Task Update(TEntity entity);
        Task Desabilitar(TEntity entity);
        Task Habilitar(TEntity entity);

        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);
    }
}
