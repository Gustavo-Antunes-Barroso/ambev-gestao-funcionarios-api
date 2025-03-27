using Ambev.GestaoFuncionarios.Application.Services.Funcionarios;
using Ambev.GestaoFuncionarios.Domain.Entities;
using Ambev.GestaoFuncionarios.Domain.Repositories;
using Ambev.GestaoFuncionarios.UnitTest.Util;
using NSubstitute;

namespace Ambev.GestaoFuncionarios.UnitTest.Application.Services.Funcionarios
{
    public class ValidateUpdateFuncionarioServiceTest
    {
        private readonly IFuncionarioRepository _repo;
        private readonly ValidateUpdateFuncionarioService _service;
        Funcionario funcionario;
        public ValidateUpdateFuncionarioServiceTest()
        {
            _repo = Substitute.For<IFuncionarioRepository>();
            _service = new ValidateUpdateFuncionarioService(_repo);
            funcionario = CreateObject.Create<Funcionario>();
        }

        [Fact]
        public async Task Validate_Success()
        {
            _repo.GetByIdAsync(funcionario.Id).Returns(new Funcionario());
            _repo.EmailExistsAsync(funcionario.Id, funcionario.Email).Returns(false);
            _repo.DocumentExistsAsync(funcionario.Id, funcionario.Documento).Returns(false);
            _repo.GetByIdAsync(funcionario.IdGestor.Value).Returns(new Funcionario());

            var exception = await Record.ExceptionAsync(() => _service.Validate(funcionario));

            Assert.Null(exception);
        }

        [Fact]
        public async Task Validate_GestorNaoEncontrato_Erro()
        {
            _repo.GetByIdAsync(funcionario.Id).Returns(new Funcionario()); // Funcionário encontrado
            _repo.EmailExistsAsync(funcionario.Id, funcionario.Email).Returns(false);
            _repo.DocumentExistsAsync(funcionario.Id, funcionario.Documento).Returns(false);
            _repo.GetByIdAsync(funcionario.IdGestor.Value).Returns((Funcionario)null); // Gestor não encontrado

            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _service.Validate(funcionario));
            Assert.Equal($"Gestor {funcionario.NomeGestor} não encontrado.", exception.Message);
        }

        [Fact]
        public async Task Validate_DocumentoExistente_Erro()
        {
            _repo.GetByIdAsync(funcionario.Id).Returns(new Funcionario()); // Funcionário encontrado
            _repo.EmailExistsAsync(funcionario.Id, funcionario.Email).Returns(false);
            _repo.DocumentExistsAsync(funcionario.Id, funcionario.Documento).Returns(true); // Documento duplicado
            _repo.GetByIdAsync(funcionario.IdGestor.Value).Returns(new Funcionario());

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _service.Validate(funcionario));
            Assert.Equal($"Funcionário com documento {funcionario.Documento} já existe.", exception.Message);
        }

        [Fact]
        public async Task Validate_EmailExistente_Erro()
        {
            var funcionario = new Funcionario
            {
                Id = Guid.NewGuid(),
                Email = "funcionario@email.com",
                Documento = "123456789",
                IdGestor = Guid.NewGuid()
            };

            _repo.GetByIdAsync(funcionario.Id).Returns(new Funcionario()); // Funcionário encontrado
            _repo.EmailExistsAsync(funcionario.Id, funcionario.Email).Returns(true); // Email duplicado
            _repo.DocumentExistsAsync(funcionario.Id, funcionario.Documento).Returns(false);
            _repo.GetByIdAsync(funcionario.IdGestor.Value).Returns(new Funcionario());

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _service.Validate(funcionario));
            Assert.Equal($"Funcionário com e-mail {funcionario.Email} já existe.", exception.Message);
        }

        [Fact]
        public async Task Validate_FuncionarioNaoEncontrado_Erro()
        {
            _repo.GetByIdAsync(funcionario.Id).Returns((Funcionario)null); // Funcionário não encontrado

            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _service.Validate(funcionario));
            Assert.Equal($"Funcionário com ID {funcionario.Id} não encontrado.", exception.Message);
        }
    }
}
