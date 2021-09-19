using ProEnade.API.Domain.Models.Request;
using FluentValidation;

namespace ProEnade.API.Validators
{
    public class ProvasUpdateValidator : AbstractValidator<ProvasUpdateRequest>
    {
        public ProvasUpdateValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.IdProvas)
               .NotNull().WithMessage("Este campo não pode ser nulo")
               .GreaterThan(0).WithMessage("Este campo deve ser maior que 0")

               .DependentRules(() =>
               {
                 RuleFor(x => x.IdProvas)
                   .NotNull().WithMessage("Este campo não pode ser nulo")

                   .DependentRules(() =>
                   {
                       RuleFor(x => x.IdProvas)
                        .NotNull().WithMessage("Este campo não pode ser nulo, informe o compo corretamente");
                   });
            });
        }
    }
}
