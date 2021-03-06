﻿using Livraria.Application.Interfaces;
using Livraria.Domain.Entities;
using Livraria.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Application.Services
{
    public class LivroReservaService : ILivroReservaService
    {
        private readonly IRepositoryLivroReserva repositoryLivroReserva;

        public LivroReservaService(IRepositoryLivroReserva repositoryLivroReserva)
        {
            this.repositoryLivroReserva = repositoryLivroReserva;
        }
        public Task Desabilitar(LivroReserva obj)
        {
            return repositoryLivroReserva.Desabilitar(obj);
        }

        public Task<LivroReserva> Find(int id)
        {
            return repositoryLivroReserva.Find(id);
        }

        public Task<IEnumerable<LivroReserva>> GetAll()
        {
            return repositoryLivroReserva.GetAll();
        }

        public Task Habilitar(LivroReserva obj)
        {
            return repositoryLivroReserva.Habilitar(obj);
        }

        public Task<LivroReserva> Insert(LivroReserva obj)
        {
            return repositoryLivroReserva.Insert(obj);
        }

        public async Task Update(int id, LivroReserva obj)
        {
            var objOri = repositoryLivroReserva.Find(id).Result;

            objOri.LivroId = obj.LivroId;
            objOri.UsuarioId = obj.UsuarioId;
            objOri.Habilitado = obj.Habilitado;
            objOri.DataResgate = obj.DataResgate;

            await repositoryLivroReserva.Update(objOri);
        }

        public async Task<IEnumerable<LivroReserva>> Where(Expression<Func<LivroReserva, bool>> predicate)
        {
            return await repositoryLivroReserva.Where(predicate);
        }
    }
}
