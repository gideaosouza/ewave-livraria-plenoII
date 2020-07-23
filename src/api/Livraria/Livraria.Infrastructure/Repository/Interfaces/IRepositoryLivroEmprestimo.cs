using Livraria.Domain.Entities;
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
        Task<IEnumerable<EmprestimoLivro>> LivrosComPrazoExtrapolado();
        Task EfetuarDevolucao(int IdEmprestimo);
        bool UsuarioAtingiuLimiteEmprestimo(int IdUsuario);
        bool UsuarioEstaBloqueado(int IdUsuario);
    }
}
