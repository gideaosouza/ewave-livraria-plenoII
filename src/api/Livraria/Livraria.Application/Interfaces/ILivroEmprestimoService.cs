using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Application.Interfaces
{
    public interface ILivroEmprestimoService : IServiceBase<EmprestimoLivro>
    {
        List<Livro> LivrosComPrazoExtrapolados();
    }
}
