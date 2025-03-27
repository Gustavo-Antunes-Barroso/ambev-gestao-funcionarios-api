using Ambev.GestaoFuncionarios.Application.Funcionarios.Create;
using Ambev.GestaoFuncionarios.Domain.Entities;
using Ambev.GestaoFuncionarios.Domain.Repositories;
using Ambev.GestaoFuncionarios.Domain.Services.Funcionarios;
using Ambev.GestaoFuncionarios.Domain.Services.Rsa;
using Ambev.GestaoFuncionarios.UnitTest.Util;
using AutoMapper;
using NSubstitute;

namespace Ambev.GestaoFuncionarios.UnitTest.Application.Handler
{
    public class CreateFuncionarioHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly IValidateCreateFuncionarioService _validateCreateFuncionarioService;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IRsaService _rsaService;
        private CreateFuncionarioHandler _handler;

        public CreateFuncionarioHandlerTest()
        {
            _mapper = Substitute.For<IMapper>();
            _validateCreateFuncionarioService = Substitute.For<IValidateCreateFuncionarioService>();
            _funcionarioRepository = Substitute.For<IFuncionarioRepository>();
            _rsaService = Substitute.For<IRsaService>();

            _handler = new CreateFuncionarioHandler(_mapper, _validateCreateFuncionarioService, _funcionarioRepository, _rsaService);
        }

        [Fact]
        public async Task Handle_Success()
        {
            // Arrange
            CreateFuncionarioCommand? command = CreateObject.Create<CreateFuncionarioCommand>();
            Funcionario? funcionario = CreateObject.Create<Funcionario>();
            CreateFuncionarioResult? result = CreateObject.Create<CreateFuncionarioResult>();
            var decryptedPassword = "SenhaDescriptografada";

            _mapper.Map<Funcionario>(command).Returns(funcionario);
            _rsaService.Decrypt(funcionario.Senha).Returns(decryptedPassword);
            _funcionarioRepository.CreateAsync(Arg.Any<Funcionario>()).Returns(funcionario);
            _mapper.Map<CreateFuncionarioResult>(funcionario).Returns(result);

            // Act
            var response = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(result.Id, response.Id);
        }

        [Fact]
        public async Task Handle_Validate_Error()
        {
            // Arrange
            CreateFuncionarioCommand command = CreateObject.Create<CreateFuncionarioCommand>();
            Funcionario funcionario = CreateObject.Create<Funcionario>();
            CreateFuncionarioResult result = CreateObject.Create<CreateFuncionarioResult>();
            var decryptedPassword = "SenhaDescriptografada";

            _mapper.Map<Funcionario>(command).Returns(funcionario);
            _rsaService.Decrypt(funcionario.Senha).Returns(decryptedPassword);
            _funcionarioRepository.CreateAsync(Arg.Any<Funcionario>()).Returns(funcionario);
            _mapper.Map<CreateFuncionarioResult>(funcionario).Returns(result);
            _validateCreateFuncionarioService.When(x => x.Validate(funcionario)).Do(x => throw new InvalidOperationException("Error"));

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _handler.Handle(command, CancellationToken.None));
        }
    }
}
