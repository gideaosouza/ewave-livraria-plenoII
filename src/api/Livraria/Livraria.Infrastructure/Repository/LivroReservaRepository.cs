using Livraria.Domain.Entities;
using Livraria.Infrastructure.Context;
using Livraria.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace Livraria.Infrastructure.Repository
{
    public class LivroReservaRepository : BaseRepository<LivroReserva>, IRepositoryLivroReserva
    {
        private readonly ApplicationDbContext efContext;

        public LivroReservaRepository(ApplicationDbContext efContext) : base(efContext)
        {
            this.efContext = efContext;
        }

        public bool LivroPodeSerEmprestado(int idLivro)
        {
            throw new NotImplementedException();
        }
    }
}