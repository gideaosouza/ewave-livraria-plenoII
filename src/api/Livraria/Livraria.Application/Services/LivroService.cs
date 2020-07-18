using Livraria.Application.Interfaces;
using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Application.Services
{
    public class LivroService : ILivroService
    {
        public Task Desabilitar(Livro obj)
        {
            throw new NotImplementedException();
        }

        public Task<Livro> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Livro>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Habilitar(Livro obj)
        {
            throw new NotImplementedException();
        }

        public Task<Livro> Insert(Livro obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Livro obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Livro>> Where(Expression<Func<Livro, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
