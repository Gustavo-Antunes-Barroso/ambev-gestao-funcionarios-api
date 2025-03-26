using Ambev.GestaoFuncionarios.Domain.Entities;
using Ambev.GestaoFuncionarios.Domain.Repositories;
using Ambev.GestaoFuncionarios.Domain.Services.Funcionarios;
using AutoMapper;
using MediatR;

namespace Ambev.GestaoFuncionarios.Application.Funcionarios.Create
{
    public class CreateFuncionarioHandler(IMapper mapper, IValidateCreateFuncionarioService validateCreateFuncionarioService,
        IFuncionarioRepository funcionarioRepository)
        : IRequestHandler<CreateFuncionarioCommand, CreateFuncionarioResult>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IValidateCreateFuncionarioService _validateCreateFuncionarioService = validateCreateFuncionarioService;
        private readonly IFuncionarioRepository _funcionarioRepository = funcionarioRepository;

        public async Task<CreateFuncionarioResult> Handle(CreateFuncionarioCommand request, CancellationToken cancellationToken)
        {
            Funcionario funcionario = _mapper.Map<Funcionario>(request);
            await _validateCreateFuncionarioService.Validate(funcionario);
            Funcionario response = await _funcionarioRepository.CreateAsync(funcionario);
            return _mapper.Map<CreateFuncionarioResult>(response);
        }
    }
}
