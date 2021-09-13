using ProEnade.API.Domain.Models.Request;
using FluentValidation;

namespace ProEnade.API.Validators
{
    public class DisciplinaQuestoesValidator : AbstractValidator<DisciplinaQuestoesRequest>
    {
        public DisciplinaQuestoesValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.IdProfessor)
                .NotEmpty().WithMessage("Este campo não pode ser vazio, informe o professor")
                .NotNull().WithMessage("Este campo não pode ser nulo, informe o professor")
                .GreaterThan(0).WithMessage("Informe o professor")

                .DependentRules(() =>
                {
                    RuleFor(x => x.IdQuestoes)
                       .GreaterThan(0).WithMessage("Este campo não pode ser vazio, informe a questão")
                       .NotNull().WithMessage("Este campo deve ser maior que 0, informe a questão");
                });
        }
    }
}
