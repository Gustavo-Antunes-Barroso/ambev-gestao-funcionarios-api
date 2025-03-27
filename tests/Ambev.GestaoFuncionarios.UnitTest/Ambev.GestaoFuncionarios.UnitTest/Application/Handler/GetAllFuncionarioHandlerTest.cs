using Ambev.GestaoFuncionarios.Application.Funcionarios.GetAll;
using Ambev.GestaoFuncionarios.Domain.Entities;
using Ambev.GestaoFuncionarios.Domain.Repositories;
using Ambev.GestaoFuncionarios.UnitTest.Util;
using AutoMapper;
using NSubstitute;

namespace Ambev.GestaoFuncionarios.UnitTest.Application.Handler
{
    public class GetAllFuncionarioHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly IFuncionarioRepository _funcionarioRepository;

        GetAllFuncionarioCommand command;
        GetAllFuncionarioHandler _handler;
        IEnumerable<Funcionario> funcionarios;

        public GetAllFuncionarioHandlerTest()
        {
            _mapper = Substitute.For<IMapper>();
            _funcionarioRepository = Substitute.For<IFuncionarioRepository>();

            command = new GetAllFuncionarioCommand(null);
            funcionarios = CreateObject.CreateList<IEnumerable<Funcionario>>();
            _handler = new GetAllFuncionarioHandler(_mapper, _funcionarioRepository);
            _mapper.Map<IEnumerable<GetAllFuncionarioResult>>(funcionarios).Returns(CreateObject.CreateList<IEnumerable<GetAllFuncionarioResult>>());
        }

        [Fact]
        public async Task Handle_Success()
        {
            _funcionarioRepository.GetAllAsync().Returns(funcionarios);

            var response = await _handler.Handle(command, CancellationToken.None);

            Assert.NotNull(response);
            Assert.NotEmpty(response);
        }
    }
}
