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
    public class LivroReservaRepository : BaseRepository<LivroReserva>, IRepositoryLivroReserva
    {
        private readonly ApplicationDbContext efContext;

        public LivroReservaRepository(ApplicationDbContext efContext) : base(efContext)
        {
            this.efContext = efContext;
        }

        public override async Task<IEnumerable<LivroReserva>> GetAll()
        {
            return await efContext.ReservasLivros.Where(c => c.Habilitado).Include(c => c.Livro).Include(c => c.Usuario).ToListAsync().ConfigureAwait(false);
        }
    }
}