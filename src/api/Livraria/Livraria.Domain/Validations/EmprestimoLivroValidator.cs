using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Livraria.Domain.Entities;

namespace Livraria.Domain.Validations
{
    public class EmprestimoLivroValidator : AbstractValidator<EmprestimoLivro>
    {
        public EmprestimoLivroValidator()
        {
            RuleFor(c => c.UsuarioId).NotEqual(0).WithMessage("O Usuário não foi informado");
            RuleFor(c => c.LivroId).NotEqual(0).WithMessage("O Livro não foi informado");
            RuleFor(c => c.DataDevolucao).NotNull().WithMessage("A data de devolução não foi informada")
                .GreaterThan(DateTime.Today).WithMessage("A data de devolução não deve ser antes de hoje.")
                .LessThan(DateTime.Today.AddDays(30)).WithMessage("A data de devolução não deve ser superior a 30 dias");
        }
    }
}
