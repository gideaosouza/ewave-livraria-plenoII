using Livraria.Domain.Entities;
using Livraria.Infrastructure.Context;
using Livraria.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infrastructure.Repository
{
    public class InstituicaoEnsinoRepository : BaseRepository<InstituicaoEnsino>, IRepositoryInstituicaoEnsino
    {
        public InstituicaoEnsinoRepository(ApplicationDbContext efContext) : base(efContext)
        {
        }
    }
}