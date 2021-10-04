using FluentValidation;
using PortalCidadao.Application.Model;

namespace PortalCidadao.Application.Validators
{
    public class UsuarioCadastroModelValidator : AbstractValidator<UsuarioCadastroModel>
    {
        public UsuarioCadastroModelValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);

            RuleFor(x => x.CPF)
                .NotEmpty()
                .NotNull()
                .MinimumLength(11)
                .MaximumLength(11);


            RuleFor(x => x.Email)
              .NotEmpty()
              .NotNull()
              .EmailAddress();

            RuleFor(x => x.PerfilId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.Senha)
                .NotEmpty()
                .NotNull()
                .Length(32)
                .WithMessage("Senha em formato inválido.");
        }
    }
}
