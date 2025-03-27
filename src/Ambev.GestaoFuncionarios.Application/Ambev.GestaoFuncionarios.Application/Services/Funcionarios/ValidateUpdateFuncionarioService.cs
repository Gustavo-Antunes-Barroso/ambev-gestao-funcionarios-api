using Ambev.GestaoFuncionarios.Domain.Entities;
using Ambev.GestaoFuncionarios.Domain.Repositories;
using Ambev.GestaoFuncionarios.Domain.Services.Funcionarios;

namespace Ambev.GestaoFuncionarios.Application.Services.Funcionarios
{
    public class ValidateUpdateFuncionarioService(IFuncionarioRepository funcionarioRepository)
        : IValidateUpdateFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository = funcionarioRepository;

        public async Task Validate(Funcionario funcionario)
        {
            bool emailExists = false;
            bool documentExists = false;
            bool gestorExists = false;
            Funcionario? funcionarioDb = await _funcionarioRepository.GetByIdAsync(funcionario.Id);

            if (funcionarioDb is null)
                throw new KeyNotFoundException($"Funcionário com ID {funcionario.Id} não encontrado.");

            Task[] tasks = {
                Task.Run(async () => emailExists = await _funcionarioRepository.EmailExistsAsync(funcionario.Id, funcionario.Email)),
                Task.Run(async () => documentExists = await _funcionarioRepository.DocumentExistsAsync(funcionario.Id, funcionario.Documento)),
                Task.Run(async () => gestorExists =
                                        funcionario.IdGestor != null && funcionario.IdGestor != Guid.Empty ?
                                            (await _funcionarioRepository.GetByIdAsync(funcionario.IdGestor.Value)) != null :
                                            true)
            };

            Task.WaitAll(tasks);

            if (emailExists)
                throw new InvalidOperationException($"Funcionário com e-mail {funcionario.Email} já existe.");

            if (documentExists)
                throw new InvalidOperationException($"Funcionário com documento {funcionario.Documento} já existe.");

            if (!gestorExists)
                throw new KeyNotFoundException($"Gestor {funcionario.NomeGestor} não encontrado.");
        }
    }
}
