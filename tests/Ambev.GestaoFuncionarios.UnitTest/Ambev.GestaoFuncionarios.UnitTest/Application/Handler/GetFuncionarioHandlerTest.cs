using Ambev.GestaoFuncionarios.Application.Funcionarios.Get;
using Ambev.GestaoFuncionarios.Domain.Entities;
using Ambev.GestaoFuncionarios.Domain.Repositories;
using Ambev.GestaoFuncionarios.Domain.Services.Rsa;
using Ambev.GestaoFuncionarios.UnitTest.Util;
using AutoMapper;
using NSubstitute;

namespace Ambev.GestaoFuncionarios.UnitTest.Application.Handler
{
    public class GetFuncionarioHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IRsaService _rsaService;
        private GetFuncionarioHandler _handler;

        GetFuncionarioCommand? command;
        Funcionario? funcionario;
        GetFuncionarioResult? result;

        public GetFuncionarioHandlerTest()
        {
            _mapper = Substitute.For<IMapper>();
            _funcionarioRepository = Substitute.For<IFuncionarioRepository>();
            _rsaService = Substitute.For<IRsaService>();

            command = CreateObject.Create<GetFuncionarioCommand>();
            funcionario = CreateObject.Create<Funcionario>();
            result = CreateObject.Create<GetFuncionarioResult>();
            _mapper.Map<Funcionario>(command).Returns(funcionario);
            _mapper.Map<GetFuncionarioResult>(funcionario).Returns(result);

            _handler = new GetFuncionarioHandler(_mapper, _funcionarioRepository, _rsaService);
        }

        [Fact]
        public async Task Handle_Success()
        {
            _funcionarioRepository.GetByIdAsync(Arg.Any<Guid>()).Returns(funcionario);

            var response = await _handler.Handle(command, CancellationToken.None);

            Assert.NotNull(response);
            Assert.Equal(result.Id, response.Id);
            Assert.IsType<GetFuncionarioResult>(response);
        }

        [Fact]
        public async Task Handle_KeyNotFound_Error()
        {
            _funcionarioRepository.GetByIdAsync(Arg.Any<Guid>()).Returns((Funcionario)null);

            await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
