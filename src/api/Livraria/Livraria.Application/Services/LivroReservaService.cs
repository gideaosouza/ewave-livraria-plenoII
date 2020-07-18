using Livraria.Application.Interfaces;
using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Application.Services
{
    public class LivroReservaService : ILivroReservaService
    {
        public Task Desabilitar(LivroReserva obj)
        {
            throw new NotImplementedException();
        }

        public Task<LivroReserva> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LivroReserva>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Habilitar(LivroReserva obj)
        {
            throw new NotImplementedException();
        }

        public Task<LivroReserva> Insert(LivroReserva obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, LivroReserva obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LivroReserva>> Where(Expression<Func<LivroReserva, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
