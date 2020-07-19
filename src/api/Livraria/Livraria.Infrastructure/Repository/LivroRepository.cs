using Livraria.Domain.Entities;
using Livraria.Infrastructure.Context;
using Livraria.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Infrastructure.Repository
{
    public class LivroRepository : BaseRepository<Livro>, IRepositoryLivro
    {
        private readonly ApplicationDbContext efContext;

        public LivroRepository(ApplicationDbContext efContext) : base(efContext)
        {
            this.efContext = efContext;
        }

        public bool LivroPodeSerEmprestado()
        {
            throw new NotImplementedException();
        }

        public Task<Livro> LivrosDisponiveis()
        {
            throw new NotImplementedException();
        }
    }
}