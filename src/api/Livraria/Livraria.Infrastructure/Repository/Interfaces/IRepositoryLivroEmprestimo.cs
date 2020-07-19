﻿using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Infrastructure.Repository.Interfaces
{
    public interface IRepositoryLivroEmprestimo : IAsyncRepository<EmprestimoLivro>
    {
        /// <summary>
        /// Informar ao Administrador do Sistema caso um livro extrapole o prazo máximo de dias emprestado
        /// </summary>
        /// <returns></returns>
        List<Livro> LivrosComPrazoExtrapolado();
        Task EfetuarDevolucao(int IdEmprestimo);
    }
}
