using ProEnade.API.Domain.Models.Request;
using FluentValidation;

namespace ProEnade.API.Validators
{
    public class ProfessorUpdateValidator : AbstractValidator<ProfessorUpdateRequest>
    {
        public ProfessorUpdateValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.NomeProfessor)
                .NotEmpty().WithMessage("Informe o nome")
                .MinimumLength(5).WithMessage("O nome deve ter no mínimo 5 caracteres")
                .MaximumLength(150).WithMessage("O nome deve ter no máximo 150 caracteres")
                .DependentRules(() =>
                {
                    RuleFor(x => x.IdDisciplina)
                       .GreaterThanOrEqualTo(18).WithMessage("A idade do professor deve ser maior ou igual a 18 anos.")
                       .LessThanOrEqualTo(80).WithMessage("A idade do professor deve ser menor ou igual a 80 anos.")
                       .DependentRules(() =>
                       {
                                   RuleFor(x => x.IdProfessor)
                                   .GreaterThan(0).WithMessage("Informe a unidade");
                       });                                                
                });
        }
    }
}
