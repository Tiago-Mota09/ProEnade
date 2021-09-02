using FluentValidation;
using ProEnade.API.Domain.Models.Request;

namespace ProEnade.API.Validators
{
    public class CursoValidator : AbstractValidator<CursoRequest>
    {
        public CursoValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.NomeCurso)
               .NotEmpty().WithMessage("Informe o nome")
               .MinimumLength(5).WithMessage("O nome deve ter no mínimo 5 caracteres")
               .MaximumLength(150).WithMessage("O nome deve ter no máximo 150 caracteres");
        }
    }
}
