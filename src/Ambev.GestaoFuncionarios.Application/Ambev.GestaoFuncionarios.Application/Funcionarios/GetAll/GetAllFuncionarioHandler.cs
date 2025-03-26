using Ambev.GestaoFuncionarios.Domain.Entities;
using Ambev.GestaoFuncionarios.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.GestaoFuncionarios.Application.Funcionarios.GetAll
{
    public class GetAllFuncionarioHandler(IMapper mapper, IFuncionarioRepository funcionarioRepository)
        : IRequestHandler<GetAllFuncionarioCommand, IEnumerable<GetAllFuncionarioResult>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IFuncionarioRepository _funcionarioRepository = funcionarioRepository;

        public async Task<IEnumerable<GetAllFuncionarioResult>> Handle(GetAllFuncionarioCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<Funcionario> funcionarios = await _funcionarioRepository.GetAllAsync(request.IsGestor);
            IEnumerable<GetAllFuncionarioResult> response = _mapper.Map<IEnumerable<GetAllFuncionarioResult>>(funcionarios);
            return response;
        }
    }
}
