using Livraria.Domain.Entities;
using Livraria.Infrastructure.Context;
using Livraria.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infrastructure.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IRepositoryUsuario
    {
        public UsuarioRepository(ApplicationDbContext efContext) : base(efContext)
        {
        }
    }
}