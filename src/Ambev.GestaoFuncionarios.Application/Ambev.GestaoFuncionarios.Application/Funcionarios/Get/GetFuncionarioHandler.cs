using Ambev.GestaoFuncionarios.Domain.Entities;
using Ambev.GestaoFuncionarios.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.GestaoFuncionarios.Application.Funcionarios.Get
{
    public class GetFuncionarioHandler(IMapper mapper, IFuncionarioRepository funcionarioRepository)
        : IRequestHandler<GetFuncionarioCommand, GetFuncionarioResult>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IFuncionarioRepository _funcionarioRepository = funcionarioRepository;

        public async Task<GetFuncionarioResult> Handle(GetFuncionarioCommand request, CancellationToken cancellationToken)
        {
            Funcionario? funcionario = await _funcionarioRepository.GetByIdAsync(request.Id);
            GetFuncionarioResult result = _mapper.Map<GetFuncionarioResult>(funcionario);
            return result;
        }
    }
}
