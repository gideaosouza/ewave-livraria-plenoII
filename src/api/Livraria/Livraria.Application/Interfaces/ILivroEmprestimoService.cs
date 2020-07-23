using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Application.Interfaces
{
    public interface ILivroEmprestimoService : IServiceBase<EmprestimoLivro>
    {
        Task<IEnumerable<EmprestimoLivro>> LivrosComPrazoExtrapolado();
        Task EfetuarDevolucao(int IdEmprestimo);
        bool UsuarioAtingiuLimiteEmprestimo(int IdUsuario);
    }
}
