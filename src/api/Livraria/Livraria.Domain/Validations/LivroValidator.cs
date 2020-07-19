using FluentValidation;
using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Validations
{
    public class LivroValidator : AbstractValidator<Livro>
    {
        public LivroValidator()
        {
            RuleFor(c => c.Titulo)
                .NotNull().WithMessage("O Campo não deve ser Nulo")
                .NotEmpty().WithMessage("O Campo não deve ser vazio")
                .MaximumLength(200).WithMessage("O Campo não deve ter mais de 15 caracteres")
                .MinimumLength(3).WithMessage("Provavelmente esse campo está faltando dígitos.");

            RuleFor(c => c.Genero)
              .NotNull().WithMessage("O Campo não deve ser Nulo")
              .NotEmpty().WithMessage("O Campo não deve ser vazio")
              .MaximumLength(200).WithMessage("O Campo não deve ter mais de 15 caracteres")
              .MinimumLength(2).WithMessage("Provavelmente esse campo está faltando dígitos.");

            RuleFor(c => c.Autor)
              .NotNull().WithMessage("O Campo não deve ser Nulo")
              .NotEmpty().WithMessage("O Campo não deve ser vazio")
              .MaximumLength(200).WithMessage("O Campo não deve ter mais de 15 caracteres")
              .MinimumLength(2).WithMessage("Provavelmente esse campo está faltando dígitos.");

            RuleFor(c => c.Capa)
              .NotNull().WithMessage("O Campo não deve ser Nulo")
              .NotEmpty().WithMessage("O Campo não deve ser vazio")
              .MaximumLength(1000).WithMessage("O Campo não deve ter mais de 15 caracteres")
              .MinimumLength(1).WithMessage("Provavelmente esse campo está faltando dígitos.");
        }
    }
}
