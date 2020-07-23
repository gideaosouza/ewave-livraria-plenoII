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
    public class UsuarioService : IUsuarioService
    {
        private readonly IRepositoryUsuario repositoryUsuario;

        public UsuarioService(IRepositoryUsuario repositoryUsuario)
        {
            this.repositoryUsuario = repositoryUsuario;
        }
        public Task Desabilitar(Usuario obj)
        {
            return repositoryUsuario.Desabilitar(obj);
        }

        public Task<Usuario> Find(int id)
        {
            return repositoryUsuario.Find(id);
        }

        public Task<IEnumerable<Usuario>> GetAll()
        {
            return repositoryUsuario.GetAll();
        }

        public Task Habilitar(Usuario obj)
        {
            return repositoryUsuario.Habilitar(obj);
        }

        public Task<Usuario> Insert(Usuario obj)
        {
            return repositoryUsuario.Insert(obj);
        }

        public async Task Update(int id, Usuario obj)
        {
            var objOri = repositoryUsuario.Find(id).Result;

            objOri.CPF = obj.CPF;
            objOri.Email = obj.Email;
            objOri.Habilitado = obj.Habilitado;
            objOri.Endereco = obj.Endereco;
            objOri.InstituicaoEnsinoId = obj.InstituicaoEnsinoId;
            objOri.Nome = obj.Nome;
            objOri.Telefone = obj.Telefone;

            await repositoryUsuario.Update(objOri);
        }

        public async Task<IEnumerable<Usuario>> Where(Expression<Func<Usuario, bool>> predicate)
        {
            return await repositoryUsuario.Where(predicate);
        }
    }
}
