using Ambev.GestaoFuncionarios.Application.Funcionarios.Create;
using Ambev.GestaoFuncionarios.Application.Funcionarios.Delete;
using Ambev.GestaoFuncionarios.Domain.Repositories;
using Ambev.GestaoFuncionarios.UnitTest.Util;
using MediatR;
using NSubstitute;

namespace Ambev.GestaoFuncionarios.UnitTest.Application.Handler
{
    public class DeleteFuncionarioHandlerTest
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private DeleteFuncionarioHandler _handler;

        public DeleteFuncionarioHandlerTest()
        {
            _funcionarioRepository = Substitute.For<IFuncionarioRepository>();
            _handler = new DeleteFuncionarioHandler(_funcionarioRepository);
        }

        [Fact]
        public async Task Handle_Success()
        {
            DeleteFuncionarioCommand command = CreateObject.Create<DeleteFuncionarioCommand>();

            var response = await _handler.Handle(command, CancellationToken.None);

            Assert.IsType<Unit>(response);
        }
    }
}
