using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Infrastructure.Repository.Interfaces
{
    public interface IRepositoryLivro : IAsyncRepository<Livro>
    {
        /// <summary>
        /// Informa se o livro tem o maximo de emprestimos e ou reservas atingido, não necessáriamente se o usuário já tem o maximo de livros emprestados!!!
        /// </summary>
        /// <returns></returns>
        bool LivroPodeSerEmprestado();
        /// <summary>
        /// Livros emprestados deverão estar indisponiveis para outros Usuários
        /// </summary>
        /// <returns></returns>
        Task<Livro> LivrosDisponiveis();


        ///O Usuário que infringir a regra dos dias fica impossibilitado de emprestar qualquer outro livro até a devolução e só poderá emprestar novamente após 30 dias.
    }
}
