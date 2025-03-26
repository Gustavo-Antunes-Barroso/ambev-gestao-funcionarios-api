using Ambev.GestaoFuncionarios.Domain.Entities;
using Ambev.GestaoFuncionarios.Domain.Repositories;
using Ambev.GestaoFuncionarios.Domain.Services.Funcionarios;
using AutoMapper;
using MediatR;

namespace Ambev.GestaoFuncionarios.Application.Funcionarios.Update
{
    public class UpdateFuncionarioHandler(IMapper mapper, IValidateUpdateFuncionarioService validateUpdateFuncionarioService,
        IFuncionarioRepository funcionarioRepository)
        : IRequestHandler<UpdateFuncionarioCommand, UpdateFuncionarioResult>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IValidateUpdateFuncionarioService _validateUpdateFuncionarioService = validateUpdateFuncionarioService;
        private readonly IFuncionarioRepository _funcionarioRepository = funcionarioRepository;

        public async Task<UpdateFuncionarioResult> Handle(UpdateFuncionarioCommand request, CancellationToken cancellationToken)
        {
            Funcionario funcionario = _mapper.Map<Funcionario>(request);
            await _validateUpdateFuncionarioService.Validate(funcionario);
            await _funcionarioRepository.UpdateAsync(funcionario);
            UpdateFuncionarioResult response = _mapper.Map<UpdateFuncionarioResult>(funcionario);
            return response;
        }
    }
}
