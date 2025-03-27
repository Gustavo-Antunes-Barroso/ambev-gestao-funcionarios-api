using Ambev.GestaoFuncionarios.Domain.Entities;
using Ambev.GestaoFuncionarios.Domain.Repositories;
using Ambev.GestaoFuncionarios.Domain.Services.Rsa;
using AutoMapper;
using MediatR;

namespace Ambev.GestaoFuncionarios.Application.Funcionarios.Get
{
    public class GetFuncionarioHandler(IMapper mapper, IFuncionarioRepository funcionarioRepository, IRsaService rsaService)
        : IRequestHandler<GetFuncionarioCommand, GetFuncionarioResult>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IFuncionarioRepository _funcionarioRepository = funcionarioRepository;
        private readonly IRsaService _rsaService = rsaService;

        public async Task<GetFuncionarioResult> Handle(GetFuncionarioCommand request, CancellationToken cancellationToken)
        {
            Funcionario? funcionario = await _funcionarioRepository.GetByIdAsync(request.Id);

            if(funcionario is not null)
                funcionario.Senha = _rsaService.Encrypt(funcionario.Senha);

            GetFuncionarioResult result = _mapper.Map<GetFuncionarioResult>(funcionario);
            return result;
        }
    }
}
