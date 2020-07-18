using Livraria.Application.Interfaces;
using Livraria.Domain.Entities;
using Livraria.Domain.Validations;
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

        ///Em algum momento poderia melhorar isso com alguma bilbioteca de transferencia de dados, como Mapper por exemplo.
        ///A validação do FluentValidation me assegura que aqui, os dados estarão conforme o necessário.
        public async Task Update(int id, InstituicaoEnsino obj)
        {
            var objOri = instituicaoEnsinoRepository.Find(id).Result;

            objOri.CPNJ = obj.CPNJ;
            objOri.Endereco = obj.Endereco;
            objOri.Habilitado = obj.Habilitado;
            objOri.Nome = obj.Nome;
            objOri.Telefone = obj.Telefone;
        }

        public Task<IEnumerable<InstituicaoEnsino>> Where(Expression<Func<InstituicaoEnsino, bool>> predicate)
        {
            return instituicaoEnsinoRepository.Where(predicate);
        }
    }
}
