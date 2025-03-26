using FluentValidation;

namespace Ambev.GestaoFuncionarios.WebApi.Controllers.Funcionarios.Delete
{
    public class DeleteFuncionarioRequestValidator : AbstractValidator<DeleteFuncionarioRequest>
    {
        public DeleteFuncionarioRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O Id não pode ser vazio.")
                .NotEqual(Guid.Empty)
                .WithMessage("O Id do funcionário não é válido.");
        }
    }
}
