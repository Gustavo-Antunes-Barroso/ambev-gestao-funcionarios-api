using Ambev.GestaoFuncionarios.Common.Validators;
using FluentValidation;

namespace Ambev.GestaoFuncionarios.WebApi.Controllers.Funcionarios.Create
{
    public class CreateFuncionarioRequestValidator : AbstractValidator<CreateFuncionarioRequest>
    {
        public CreateFuncionarioRequestValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .MinimumLength(2)
                .WithMessage("Nome precisa ser preenchido com pelo menos 2 letras.")
                .Matches(@"^[a-zA-Zà-úÀ-Ú]+$")
                .WithMessage("O nome deve conter somente letras.");

            RuleFor(x => x.Sobrenome)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Sobrenome precisa ser preenchido com pelo menos 3 letras.")
                .Matches(@"^[a-zA-Zà-úÀ-Ú\s]+$")
                .WithMessage("O sobrenome deve conter somente letras.");

            RuleFor(x => x.Documento)
                .NotEmpty()
            .WithMessage("O documento não pode estar vazio.")
            .Must(DocumentValidator.IsValidDocumento)
            .WithMessage("O documento informado é inválido.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("O e-mail informado é inválido.");

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .Matches(@"^\d{10,11}$")
                .WithMessage("O telefone informado é inválido.");

            RuleFor(x => x.DataNascimento)
                .NotEmpty()
                .LessThan(DateTime.Now)
                .WithMessage("A data de nascimento não pode ser maior que a data atual.")
                .NotEqual(DateTime.Now)
                .WithMessage("A data de nascimento não pode ser a data atual.")
                .Must(AgeValidator.IsAdult)
                .WithMessage("O funcionário precisa ser maior de idade.");

            RuleFor(x => x.IsGestor)
                .NotNull()
                .WithMessage("O campo IsGestor não pode ser null.");
        }
    }
}
