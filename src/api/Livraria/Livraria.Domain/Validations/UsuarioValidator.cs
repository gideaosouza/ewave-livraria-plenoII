﻿using FluentValidation;
using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Validations
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(c => c.Nome)
                .NotNull().WithMessage("O Campo não deve ser Nulo")
                .NotEmpty().WithMessage("O Campo não deve ser vazio")
                .MaximumLength(200).WithMessage("O Campo não deve ter mais de 200 caracteres")
                .MinimumLength(3).WithMessage("Provavelmente esse campo está faltando dígitos.");

            RuleFor(c => c.CPF)
              .NotNull().WithMessage("O Campo não deve ser Nulo")
              .NotEmpty().WithMessage("O Campo não deve ser vazio")
              .MaximumLength(200).WithMessage("O Campo não deve ter mais de 200 caracteres")
              .MinimumLength(2).WithMessage("Provavelmente esse campo está faltando dígitos.");

            RuleFor(c => c.Email)
                .MaximumLength(200).WithMessage("O Campo não deve ter mais de 200 caracteres");

            RuleFor(c => c.Telefone)
              .MaximumLength(15).WithMessage("O Campo não deve ter mais de 15 caracteres");

            When(c => string.IsNullOrEmpty(c.Telefone) && string.IsNullOrEmpty(c.Email), () =>
            {
                RuleFor(c => c.Telefone)
                 .NotEmpty().WithMessage("O Campo não deve ser vazio, se um email não for informado")
                 .NotNull().WithMessage("O Campo não deve ser nulo");

                RuleFor(c => c.Email)
                  .NotEmpty().WithMessage("O Campo não deve ser vazio, se um telefone não for informado")
                  .NotNull().WithMessage("O Campo não deve ser nulo");
            });
        }
    }
}
