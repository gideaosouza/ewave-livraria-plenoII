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

        public bool LivroPodeSerEmprestado(int IdLivro)
        {
            return repositoryLivro.LivroPodeSerEmprestado(IdLivro);
        }

        public async Task Update(int id, Livro obj)
        {
            var objOri = repositoryLivro.Find(id).Result;

            objOri.Capa = obj.Capa;
            objOri.Autor = obj.Autor;
            objOri.Habilitado = obj.Habilitado;
            objOri.Genero = obj.Genero;
            objOri.Sinopse = obj.Sinopse;
            objOri.Titulo = obj.Titulo;

            await repositoryLivro.Update(objOri);
        }

        public async Task<IEnumerable<Livro>> Where(Expression<Func<Livro, bool>> predicate)
        {
            return await repositoryLivro.Where(predicate);
        }
    }
}
