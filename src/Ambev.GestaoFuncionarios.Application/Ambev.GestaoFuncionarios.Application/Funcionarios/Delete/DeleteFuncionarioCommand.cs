using MediatR;

namespace Ambev.GestaoFuncionarios.Application.Funcionarios.Delete
{
    public class DeleteFuncionarioCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
