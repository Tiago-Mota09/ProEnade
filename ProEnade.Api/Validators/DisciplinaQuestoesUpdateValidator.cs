using ProEnade.API.Domain.Models.Request;
using FluentValidation;

namespace ProEnade.API.Validators
{
    public class DisciplinaQuestoesUpdateValidator : AbstractValidator<DisciplinaQuestoesUpdateRequest>
    {
        public DisciplinaQuestoesUpdateValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.IdProfessor)
               .NotNull().WithMessage("Este campo não pode ser nulo, informe o professor")
               .GreaterThan(0).WithMessage("Este campo deve ser maior que 0, informe o professor")

               .DependentRules(() =>
               {
                 RuleFor(x => x.IdQuestoes)
                   .NotNull().WithMessage("Este campo não pode ser nulo, informe o aluno")

                   .DependentRules(() =>
                   {
                       RuleFor(x => x.IdProfessorQuestoes)
                        .NotNull().WithMessage("Este campo não pode ser nulo, informe o campo professrorAluno corretamente");
                   });
            });
        }
    }
}
