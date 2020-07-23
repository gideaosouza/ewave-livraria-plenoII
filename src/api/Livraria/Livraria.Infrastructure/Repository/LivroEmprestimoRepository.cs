using Livraria.Domain.Entities;
using Livraria.Infrastructure.Context;
using Livraria.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

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
            return Where(c => c.UsuarioId == IdUsuario && !c.Devolvido && c.Habilitado).Result.Count() >= 2;
        }
        
        public async Task<IEnumerable<EmprestimoLivro>> LivrosComPrazoExtrapolado()
        {
            return await _efContext.EmprestimosLivros.Include(c => c.Livro).Include(c => c.Usuario).Where(c => c.DataDevolucao < DateTime.Today).ToListAsync().ConfigureAwait(false);
        }
        
        public async Task<IEnumerable<EmprestimoLivro>> Where(Expression<Func<EmprestimoLivro, bool>> predicate)
        {
            return await _efContext.EmprestimosLivros.Include(c => c.Livro).Include(c => c.Usuario).Where(predicate).ToListAsync().ConfigureAwait(false);
        }
        
        public override async Task<IEnumerable<EmprestimoLivro>> GetAll()
        {
            return await _efContext.EmprestimosLivros.Where(c => c.Habilitado).Include(c=>c.Livro).Include(c=>c.Usuario).ToListAsync().ConfigureAwait(false);
        }
    }
}