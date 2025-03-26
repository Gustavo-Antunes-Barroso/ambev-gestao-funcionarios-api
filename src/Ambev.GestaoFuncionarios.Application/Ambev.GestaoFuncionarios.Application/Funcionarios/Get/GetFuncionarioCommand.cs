using MediatR;

namespace Ambev.GestaoFuncionarios.Application.Funcionarios.Get
{
    public class GetFuncionarioCommand : IRequest<GetFuncionarioResult>
    {
        public Guid Id { get; set; }
    }
}
