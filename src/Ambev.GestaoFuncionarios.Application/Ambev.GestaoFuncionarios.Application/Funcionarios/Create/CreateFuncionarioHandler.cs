using Ambev.GestaoFuncionarios.Domain.Entities;
using Ambev.GestaoFuncionarios.Domain.Repositories;
using Ambev.GestaoFuncionarios.Domain.Services.Funcionarios;
using Ambev.GestaoFuncionarios.Domain.Services.Rsa;
using AutoMapper;
using MediatR;

namespace Ambev.GestaoFuncionarios.Application.Funcionarios.Create
{
    public class CreateFuncionarioHandler(IMapper mapper, IValidateCreateFuncionarioService validateCreateFuncionarioService,
        IFuncionarioRepository funcionarioRepository, IRsaService rsaService)
        : IRequestHandler<CreateFuncionarioCommand, CreateFuncionarioResult>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IValidateCreateFuncionarioService _validateCreateFuncionarioService = validateCreateFuncionarioService;
        private readonly IFuncionarioRepository _funcionarioRepository = funcionarioRepository;
        private readonly IRsaService _rsaService = rsaService;

        public async Task<CreateFuncionarioResult> Handle(CreateFuncionarioCommand request, CancellationToken cancellationToken)
        {
            Funcionario funcionario = _mapper.Map<Funcionario>(request);
            await _validateCreateFuncionarioService.Validate(funcionario);
            funcionario.Senha = _rsaService.Decrypt(funcionario.Senha);
            Funcionario response = await _funcionarioRepository.CreateAsync(funcionario);
            return _mapper.Map<CreateFuncionarioResult>(response);
        }
    }
}
