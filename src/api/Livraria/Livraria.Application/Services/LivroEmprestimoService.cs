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

        public Task EfetuarDevolucao(int IdEmprestimo)
        {
            return repositoryLivroEmprestimo.EfetuarDevolucao(IdEmprestimo);
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

        public async Task<IEnumerable<EmprestimoLivro>> LivrosComPrazoExtrapolado()
        {
            return await repositoryLivroEmprestimo.LivrosComPrazoExtrapolado();
        }

        public async Task Update(int id, EmprestimoLivro obj)
        {
            var objOri = repositoryLivroEmprestimo.Find(id).Result;

            objOri.UsuarioId = obj.UsuarioId;
            objOri.LivroId = obj.LivroId;
            objOri.Habilitado = obj.Habilitado;
            objOri.DataDevolucao = obj.DataDevolucao;
            objOri.Devolvido = obj.Devolvido;

            if (obj.Devolvido)
                objOri.DataDevolvido = DateTime.Now;

            await repositoryLivroEmprestimo.Update(objOri);
        }

        public bool UsuarioAtingiuLimiteEmprestimo(int IdUsuario)
        {
            return repositoryLivroEmprestimo.UsuarioAtingiuLimiteEmprestimo(IdUsuario);
        }

        public bool UsuarioEstaBloqueado(int IdUsuario)
        {
            return repositoryLivroEmprestimo.UsuarioEstaBloqueado(IdUsuario);
        }

        public async Task<IEnumerable<EmprestimoLivro>> Where(Expression<Func<EmprestimoLivro, bool>> predicate)
        {
            return await repositoryLivroEmprestimo.Where(predicate);
        }
    }
}
