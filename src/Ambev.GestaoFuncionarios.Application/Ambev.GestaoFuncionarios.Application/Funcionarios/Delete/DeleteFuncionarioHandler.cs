using Ambev.GestaoFuncionarios.Domain.Repositories;
using MediatR;

namespace Ambev.GestaoFuncionarios.Application.Funcionarios.Delete
{
    public class DeleteFuncionarioHandler(IFuncionarioRepository funcionarioRepository)
        : IRequestHandler<DeleteFuncionarioCommand, Unit>
    {
        private readonly IFuncionarioRepository _funcionarioRepository = funcionarioRepository;

        public async Task<Unit> Handle(DeleteFuncionarioCommand request, CancellationToken cancellationToken)
        {
            await _funcionarioRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
