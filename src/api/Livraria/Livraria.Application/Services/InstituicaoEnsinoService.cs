using Livraria.Application.Interfaces;
using Livraria.Domain.Entities;
using Livraria.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Application.Services
{
    public class InstituicaoEnsinoService : IInstituicaoEnsinoService
    {
        private readonly IRepositoryInstituicaoEnsino instituicaoEnsinoRepository;
        public InstituicaoEnsinoService(IRepositoryInstituicaoEnsino instituicaoEnsinoRepository)
        {
            this.instituicaoEnsinoRepository = instituicaoEnsinoRepository;
        }

        public Task Desabilitar(InstituicaoEnsino obj)
        {
            return instituicaoEnsinoRepository.Desabilitar(obj);
        }

        public Task<InstituicaoEnsino> Find(int id)
        {
            return instituicaoEnsinoRepository.Find(id);
        }

        public Task<IEnumerable<InstituicaoEnsino>> GetAll()
        {
            return instituicaoEnsinoRepository.GetAll();
        }

        public Task Habilitar(InstituicaoEnsino obj)
        {
            return instituicaoEnsinoRepository.Habilitar(obj);
        }

        public Task<InstituicaoEnsino> Insert(InstituicaoEnsino obj)
        {
            return instituicaoEnsinoRepository.Insert(obj);
        }

        public Task Update(InstituicaoEnsino obj)
        {
            return instituicaoEnsinoRepository.Update(obj);
        }

        public Task<IEnumerable<InstituicaoEnsino>> Where(Expression<Func<InstituicaoEnsino, bool>> predicate)
        {
            return instituicaoEnsinoRepository.Where(predicate);
        }
    }
}
