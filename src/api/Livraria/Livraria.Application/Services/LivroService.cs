using Livraria.Application.Interfaces;
using Livraria.Domain.Entities;
using Livraria.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Application.Services
{
    public class LivroService : ILivroService
    {
        private readonly IRepositoryLivro repositoryLivro;

        public LivroService(IRepositoryLivro repositoryLivro)
        {
            this.repositoryLivro = repositoryLivro;
        }
        public Task Desabilitar(Livro obj)
        {
            return repositoryLivro.Desabilitar(obj);
        }

        public Task<Livro> Find(int id)
        {
            return repositoryLivro.Find(id);
        }

        public Task<IEnumerable<Livro>> GetAll()
        {
            return repositoryLivro.GetAll();
        }

        public Task Habilitar(Livro obj)
        {
            return repositoryLivro.Habilitar(obj);
        }

        public Task<Livro> Insert(Livro obj)
        {
            return repositoryLivro.Insert(obj);
        }

        public Task Update(int id, Livro obj)
        {
            return repositoryLivro.Update(obj);
        }

        public Task<IEnumerable<Livro>> Where(Expression<Func<Livro, bool>> predicate)
        {
            return repositoryLivro.Where(predicate);
        }
    }
}
