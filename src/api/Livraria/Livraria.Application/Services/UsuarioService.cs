using Livraria.Application.Interfaces;
using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        public Task Desabilitar(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Habilitar(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Insert(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Usuario obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> Where(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
