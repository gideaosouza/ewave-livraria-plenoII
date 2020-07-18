using Livraria.Domain.Entities;
using Livraria.Infrastructure.Context;
using Livraria.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Livraria.Infrastructure.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IRepositoryUsuario
    {
        private readonly ApplicationDbContext efContext;

        public UsuarioRepository(ApplicationDbContext efContext) : base(efContext)
        {
            this.efContext = efContext;
        }
    }
}