using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Livraria.Domain.Entities;

namespace Livraria.Domain.Validations
{
    public class InstituicaoEnsinoValidator : AbstractValidator<InstituicaoEnsino>
    {
        public InstituicaoEnsinoValidator()
        {
            RuleFor(customer => customer.CPNJ)
                .NotNull().WithMessage("O Campo não deve ser Nulo")
                .NotEmpty().WithMessage("O Campo não deve ser vazio")
                .MaximumLength(15).WithMessage("O Campo não deve ter mais de 15 caracteres")
                .MinimumLength(14).WithMessage("Provavelmente esse campo está faltando dígitos.");

            RuleFor(customer => customer.Telefone)
                .NotNull().WithMessage("O Campo não deve ser Nulo")
                .NotEmpty().WithMessage("O Campo não deve ser vazio")
                .MaximumLength(11).WithMessage("O Campo não deve ter mais de 11 caracteres")
                .MinimumLength(10).WithMessage("Provavelmente esse campo está faltando dígitos.");

            RuleFor(customer => customer.Endereco)
                .NotNull().WithMessage("O Campo não deve ser Nulo")
                .NotEmpty().WithMessage("O Campo não deve ser vazio")
                .MaximumLength(500).WithMessage("O Campo não deve ter mais de 500 caracteres");

            RuleFor(customer => customer.Nome)
                .NotNull().WithMessage("O Campo não deve ser Nulo")
                .NotEmpty().WithMessage("O Campo não deve ser vazio")
                .MaximumLength(200).WithMessage("O Campo não deve ter mais de 200 caracteres");
        }
    }
}
