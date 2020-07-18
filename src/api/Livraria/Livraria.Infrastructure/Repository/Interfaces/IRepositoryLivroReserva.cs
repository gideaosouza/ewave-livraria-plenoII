using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infrastructure.Repository.Interfaces
{
    public interface IRepositoryLivroReserva : IAsyncRepository<LivroReserva>
    {
        /// <summary>
        /// Informa se a reserva pode ser efetuada, não necessáriamente se o usuário já tem o maximo de livros emprestados!!!
        /// </summary>
        /// <returns></returns>
        bool LivroPodeSerEmprestado(int idLivro);
    }
}
