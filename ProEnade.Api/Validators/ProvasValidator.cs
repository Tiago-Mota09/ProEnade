using ProEnade.API.Domain.Models.Request;
using FluentValidation;

namespace ProEnade.API.Validators
{
    public class ProvasValidator : AbstractValidator<ProvasRequest>
    {
        public ProvasValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Provas)
                .NotEmpty().WithMessage("Informe o nome")
                .MinimumLength(5).WithMessage("O nome deve ter no mínimo 5 caracteres")
                .MaximumLength(150).WithMessage("O nome deve ter no máximo 150 caracteres")

                .DependentRules(() =>
                {
                           RuleFor(x => x.IdProvas)
                                .NotNull().WithMessage("Informe o Id")
                                .NotEmpty().WithMessage("informe o Id")
                                .GreaterThan(0).WithMessage("Informe o ID");
                       
                });
        }
    }
}
