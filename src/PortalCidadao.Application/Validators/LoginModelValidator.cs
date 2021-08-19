using FluentValidation;
using PortalCidadao.Application.Model;

namespace PortalCidadao.Application.Validators
{
    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            //RuleFor(x => x.Login).NotNull().EmailAddress();// TODO adicionar validacao pro login
            RuleFor(x => x.Senha).Length(32).WithMessage("Senha em formato inválido.");
        }
    }
}
