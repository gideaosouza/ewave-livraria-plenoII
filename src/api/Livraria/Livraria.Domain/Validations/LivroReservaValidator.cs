using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Livraria.Domain.Entities;

namespace Livraria.Domain.Validations
{
    public class LivroReservaValidator : AbstractValidator<LivroReserva>
    {
        public LivroReservaValidator()
        {
            RuleFor(c => c.UsuarioId).NotEqual(0).WithMessage("O Id do Usuário não foi informado");
            RuleFor(c => c.LivroId).NotEqual(0).WithMessage("O Id do Livro não foi informado");
            RuleFor(c => c.DataResgate)
                .NotNull().WithMessage("A data de resgate não foi informada")
                .LessThan(DateTime.Today).WithMessage("A data de resgate não deve ser antes de hoje.");
        }
    }
}
