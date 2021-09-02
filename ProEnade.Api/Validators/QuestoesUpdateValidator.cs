using ProEnade.API.Domain.Models.Request;
using FluentValidation;

namespace ProEnade.API.Validators
{
    public class QuestoesUpdateValidator : AbstractValidator<QuestoesUpdateRequest>
    {
        public QuestoesUpdateValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.IdQuestoes)
               .NotNull().WithMessage("Informe o Id")//Não pode ser nulo
               .NotEmpty().WithMessage("informe o Id")//não pode vazio
               .GreaterThan(0).WithMessage("Informe o ID") //Não pode zero
               .DependentRules(() =>
               {
                   RuleFor(x => x.IdQuestao)
                        .NotNull().WithMessage("Informe o Id")
                        .NotEmpty().WithMessage("informe o Id")
                        .GreaterThan(0).WithMessage("Informe o ID")
                        .DependentRules(() =>
                        {
                            RuleFor(x => x.Dificuldade)
                               .NotEmpty().WithMessage("A Dificuldade deve ser inserida.")
                               .DependentRules(() =>
                               {
                                   RuleFor(x => x.IdDisciplina)
                                     .GreaterThan(0).WithMessage("Informe a unidade.")
                                     .LessThanOrEqualTo(100).WithMessage("A Disciplina informada não existe.");
                                });
                        });
               });
        }
    }
}
