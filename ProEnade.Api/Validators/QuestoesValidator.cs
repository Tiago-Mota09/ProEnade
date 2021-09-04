using ProEnade.API.Domain.Models.Request;
using FluentValidation;

namespace ProEnade.API.Validators
{
    public class QuestoesValidator : AbstractValidator<QuestoesRequest>
    {
        public QuestoesValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;//da consistência em sequência

           
            RuleFor(x => x.IdQuestoes)
                .GreaterThan(0).WithMessage("Informe a questão.")
                .DependentRules(() =>
                 {
                             RuleFor(x => x.NomeDisciplina)
                                .NotEmpty().WithMessage("Informe a Disciplina")
                                .MinimumLength(5).WithMessage("O nome deve ter no mínimo 5 caracteres")
                                .MaximumLength(150).WithMessage("O nome deve ter no máximo 150 caracteres");
                 });
        }
    }
}
