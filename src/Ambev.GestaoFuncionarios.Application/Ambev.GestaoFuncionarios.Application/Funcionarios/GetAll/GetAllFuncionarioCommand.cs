using MediatR;

namespace Ambev.GestaoFuncionarios.Application.Funcionarios.GetAll
{
    public class GetAllFuncionarioCommand : IRequest<IEnumerable<GetAllFuncionarioResult>>
    {
        public GetAllFuncionarioCommand(bool? isGestor)
        {
            IsGestor = isGestor;
        }

        public bool? IsGestor { get; set; }
    }
}
