using Livraria.Domain.Entities;
using Livraria.Infrastructure.Context;
using Livraria.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Livraria.Domain.Validations;
using FluentValidation;

namespace Livraria.Infrastructure.Repository
{
    public class LivroEmprestimoRepository : BaseRepository<EmprestimoLivro>, IRepositoryLivroEmprestimo
    {
        private readonly ApplicationDbContext efContext;

        public LivroEmprestimoRepository(ApplicationDbContext efContext) : base(efContext)
        {
            this.efContext = efContext;
        }

        public Task EfetuarDevolucao(int IdEmprestimo)
        {
            var obj  = efContext.EmprestimosLivros.Find(IdEmprestimo);
            obj.Devolvido = true;
            return Update(obj);
        }
        public bool UsuarioAtingiuLimiteEmprestimo(int IdUsuario) {
            return Where(c => c.UsuarioId == IdUsuario && c.Devolvido == false).Result.Count() >= 2;
        }
        public List<Livro> LivrosComPrazoExtrapolado()
        {
            return Where(c => c.DataDevolucao > DateTime.Today).Result.Select(c => c.Livro).ToList();
        }
    }
}