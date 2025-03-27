using Ambev.GestaoFuncionarios.Application.Services.Funcionarios;
using Ambev.GestaoFuncionarios.Domain.Entities;
using Ambev.GestaoFuncionarios.Domain.Repositories;
using Ambev.GestaoFuncionarios.UnitTest.Util;
using NSubstitute;

namespace Ambev.GestaoFuncionarios.UnitTest.Application.Services.Funcionarios
{
    public class ValidateCreateFuncionarioServiceTests
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly ValidateCreateFuncionarioService _service;
        Funcionario funcionario = CreateObject.Create<Funcionario>();
        public ValidateCreateFuncionarioServiceTests()
        {
            _funcionarioRepository = Substitute.For<IFuncionarioRepository>();
            _service = new ValidateCreateFuncionarioService(_funcionarioRepository);
        }

        [Fact]
        public async Task Validate_Success()
        {

            _funcionarioRepository.EmailExistsAsync(funcionario.Email).Returns(false);
            _funcionarioRepository.DocumentExistsAsync(funcionario.Documento).Returns(false);
            _funcionarioRepository.GetByIdAsync(funcionario.IdGestor.Value).Returns(new Funcionario());

            var exception = await Record.ExceptionAsync(() => _service.Validate(funcionario));

            Assert.Null(exception);
        }

        [Fact]
        public async Task Validate_EmailExistente_Error()
        {
            _funcionarioRepository.EmailExistsAsync(funcionario.Email).Returns(true);
            _funcionarioRepository.DocumentExistsAsync(funcionario.Documento).Returns(false);
            _funcionarioRepository.GetByIdAsync(funcionario.IdGestor.Value).Returns(new Funcionario());

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _service.Validate(funcionario));
            Assert.Equal($"Funcionário com e-mail {funcionario.Email} já existe.", exception.Message);
        }

        [Fact]
        public async Task Validate_DocumentoExistente_Erro()
        {
            _funcionarioRepository.EmailExistsAsync(funcionario.Email).Returns(false);
            _funcionarioRepository.DocumentExistsAsync(funcionario.Documento).Returns(true);
            _funcionarioRepository.GetByIdAsync(funcionario.IdGestor.Value).Returns(new Funcionario());

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _service.Validate(funcionario));
            Assert.Equal($"Funcionário com documento {funcionario.Documento} já existe.", exception.Message);
        }

        [Fact]
        public async Task Validate_GestorNaoEncontrato_Erro()
        {
            _funcionarioRepository.EmailExistsAsync(funcionario.Email).Returns(false);
            _funcionarioRepository.DocumentExistsAsync(funcionario.Documento).Returns(false);
            _funcionarioRepository.GetByIdAsync(funcionario.IdGestor.Value).Returns((Funcionario)null); // Gestor não encontrado

            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _service.Validate(funcionario));
            Assert.Equal($"Gestor {funcionario.NomeGestor} não encontrado.", exception.Message);
        }
    }
}
