using FluentValidation;
using Livraria.Application.Interfaces;
using Livraria.Domain.Entities;
using Livraria.Domain.Validations;
using Livraria.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Application.Services
{
    public class LivroEmprestimoService : ILivroEmprestimoService
    {
        private readonly IRepositoryLivroEmprestimo repositoryLivroEmprestimo;

        public LivroEmprestimoService(IRepositoryLivroEmprestimo repositoryLivroEmprestimo)
        {
            this.repositoryLivroEmprestimo = repositoryLivroEmprestimo;
        }

        public Task Desabilitar(EmprestimoLivro obj)
        {
            return repositoryLivroEmprestimo.Desabilitar(obj);
        }

        public Task<EmprestimoLivro> Find(int id)
        {
            return repositoryLivroEmprestimo.Find(id);
        }

        public Task<IEnumerable<EmprestimoLivro>> GetAll()
        {
            return repositoryLivroEmprestimo.GetAll();
        }

        public Task Habilitar(EmprestimoLivro obj)
        {
            return repositoryLivroEmprestimo.Habilitar(obj);
        }

        public Task<EmprestimoLivro> Insert(EmprestimoLivro obj)
        {            
            return repositoryLivroEmprestimo.Insert(obj);
        }

        public List<Livro> LivrosComPrazoExtrapolados()
        {
            return repositoryLivroEmprestimo.LivrosComPrazoExtrapolado();
        }

        public Task Update(int id, EmprestimoLivro obj)
        {
            return repositoryLivroEmprestimo.Update(obj);
        }

        public Task<IEnumerable<EmprestimoLivro>> Where(Expression<Func<EmprestimoLivro, bool>> predicate)
        {
            return repositoryLivroEmprestimo.Where(predicate);
        }
    }
}
