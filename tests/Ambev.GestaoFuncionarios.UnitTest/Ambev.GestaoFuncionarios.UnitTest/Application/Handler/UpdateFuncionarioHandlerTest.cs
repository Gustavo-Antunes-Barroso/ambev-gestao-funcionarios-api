using Ambev.GestaoFuncionarios.Application.Funcionarios.Update;
using Ambev.GestaoFuncionarios.Domain.Entities;
using Ambev.GestaoFuncionarios.Domain.Repositories;
using Ambev.GestaoFuncionarios.Domain.Services.Funcionarios;
using Ambev.GestaoFuncionarios.Domain.Services.Rsa;
using Ambev.GestaoFuncionarios.UnitTest.Util;
using AutoMapper;
using NSubstitute;

namespace Ambev.GestaoFuncionarios.UnitTest.Application.Handler
{
    public class UpdateFuncionarioHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly IValidateUpdateFuncionarioService _validateUpdateFuncionarioService;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IRsaService _rsaService;
        private UpdateFuncionarioHandler _handler;

        public UpdateFuncionarioHandlerTest()
        {
            _mapper = Substitute.For<IMapper>();
            _validateUpdateFuncionarioService = Substitute.For<IValidateUpdateFuncionarioService>();
            _funcionarioRepository = Substitute.For<IFuncionarioRepository>();
            _rsaService = Substitute.For<IRsaService>();

            _handler = new UpdateFuncionarioHandler(_mapper, _validateUpdateFuncionarioService, _funcionarioRepository, _rsaService);
        }

        [Fact]
        public async Task Handle_Success()
        {
            UpdateFuncionarioCommand? command = CreateObject.Create<UpdateFuncionarioCommand>();
            Funcionario? funcionario = CreateObject.Create<Funcionario>();
            UpdateFuncionarioResult? result = CreateObject.Create<UpdateFuncionarioResult>();
            var decryptedPassword = "SenhaDescriptografada";
            _mapper.Map<Funcionario>(command).Returns(funcionario);
            _rsaService.Decrypt(funcionario.Senha).Returns(decryptedPassword);
            _mapper.Map<UpdateFuncionarioResult>(funcionario).Returns(result);

            var response = await _handler.Handle(command, CancellationToken.None);

            Assert.NotNull(response);
            Assert.Equal(result.Id, response.Id);
        }
    }
}
