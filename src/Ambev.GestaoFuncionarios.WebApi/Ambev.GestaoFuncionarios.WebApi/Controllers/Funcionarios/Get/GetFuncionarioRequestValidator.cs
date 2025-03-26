using FluentValidation;

namespace Ambev.GestaoFuncionarios.WebApi.Controllers.Funcionarios.Get
{
    public class GetFuncionarioRequestValidator : AbstractValidator<GetFuncionarioRequest>
    {
        public GetFuncionarioRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O Id do funcionário não pode ser vazio.")
                .NotEqual(Guid.Empty)
                .WithMessage("O Id do funcionário não é válido.");
        }
    }
}
