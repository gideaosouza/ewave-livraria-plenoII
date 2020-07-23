using Livraria.Domain.Entities;
using Livraria.Infrastructure.Context;
using Livraria.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Infrastructure.Repository
{
    public class LivroRepository : BaseRepository<Livro>, IRepositoryLivro
    {
        private readonly ApplicationDbContext efContext;

        public LivroRepository(ApplicationDbContext efContext) : base(efContext)
        {
            this.efContext = efContext;
        }

        public bool LivroPodeSerEmprestado(int IdLivro)
        {
            return efContext.EmprestimosLivros.Any(c => c.LivroId == IdLivro && !c.Devolvido && c.Habilitado);
        }

        public List<Livro> LivrosDisponiveis()
        {
            var livrosEmprestados = efContext.EmprestimosLivros.Where(v => !v.Devolvido).Include(q => q.Livro).Select(x => x.Livro).ToList();
            var livrosHabilitados = GetAll().Result.ToList();
            return livrosHabilitados.Except(livrosEmprestados).ToList();
        }
    }
}