using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Application.Interfaces
{
    public interface IServiceBase<TEntity> where TEntity: BaseEntity
    {
        Task<TEntity> Insert(TEntity obj);
        Task<TEntity> Find(int id);
        Task Update(TEntity obj);
        Task Desabilitar(TEntity obj);
        Task Habilitar(TEntity obj);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);
    }
}
