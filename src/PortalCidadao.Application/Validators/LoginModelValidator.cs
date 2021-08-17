using FluentValidation;
using PortalCidadao.Application.Model;

namespace PortalCidadao.Application.Validators
{
    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.Senha).Length(32).WithMessage("Senha em formato inválido.");
        }
    }
}
