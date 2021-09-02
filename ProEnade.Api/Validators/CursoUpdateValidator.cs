using FluentValidation;
using ProEnade.API.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEnade.API.Validators
{
    public class CursoUpdateValidator : AbstractValidator<CursoUpdateRequest>
    {
        public CursoUpdateValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.NomeCurso)
                .NotEmpty().WithMessage("Informe o nome")
                .MinimumLength(5).WithMessage("O nome deve ter no mínimo 5 caracteres")
                .MaximumLength(150).WithMessage("O nome deve ter no máximo 150 caracteres")
                .DependentRules(() =>
                {

                    RuleFor(x => x.IdCurso)
                      .GreaterThan(0).WithMessage("Informe o Curso");
                });
        }
    }
}