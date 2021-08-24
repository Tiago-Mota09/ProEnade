using ProEnade.API.Domain.Models.Request;
using FluentValidation;

namespace ProEnade.API.Validators
{
    public class DisciplinaValidator : AbstractValidator<DisciplinaRequest>
    {
        public DisciplinaValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.NomeDisciplina)
               .NotEmpty().WithMessage("Informe o nome")
               .MinimumLength(5).WithMessage("O nome deve ter no mínimo 5 caracteres")
               .MaximumLength(150).WithMessage("O nome deve ter no máximo 150 caracteres");
        }
    }
}

