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
                             RuleFor(x => x.Dificuldade)
                               .NotEmpty().WithMessage("A Dificuldade deve ser inserida.")
                               .DependentRules(() =>
                               {
                                   RuleFor(x => x.NomeDisciplina)
                                     .NotNull().WithMessage("Informe o nome da disciplina")//Não pode ser nulo
                                     .NotEmpty().WithMessage("informe o nome da disciplina")//não pode vazio
                                     .MinimumLength(5).WithMessage("O nome deve ter no mínimo 5 caracteres")
                                     .MaximumLength(150).WithMessage("O nome deve ter no máximo 150 caracteres");
                                });
                        });
        }
    }
}
