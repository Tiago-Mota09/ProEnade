using ProEnade.API.Domain.Models.Request;
using FluentValidation;

namespace ProEnade.API.Validators
{
    public class QuestoesValidator : AbstractValidator<QuestoesRequest>
    {
        public QuestoesValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;//da consistência em sequência

           
            RuleFor(x => x.IdQuestao)
                .GreaterThan(0).WithMessage("Informe a questão.")
                .DependentRules(() =>
                 {
                             RuleFor(x => x.IdDisciplina)
                                .GreaterThan(0).WithMessage("Informe a unidade.");
                                //.LessThanOrEqualTo(100).WithMessage("A unidade informada não existe.");
                });
        }
    }
}
