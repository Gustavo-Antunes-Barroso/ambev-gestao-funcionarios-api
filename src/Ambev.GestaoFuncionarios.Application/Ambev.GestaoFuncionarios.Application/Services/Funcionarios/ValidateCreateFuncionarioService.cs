using Ambev.GestaoFuncionarios.Domain.Entities;
using Ambev.GestaoFuncionarios.Domain.Repositories;
using Ambev.GestaoFuncionarios.Domain.Services.Funcionarios;

namespace Ambev.GestaoFuncionarios.Application.Services.Funcionarios
{
    public class ValidateCreateFuncionarioService(IFuncionarioRepository funcionarioRepository) : IValidateCreateFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository = funcionarioRepository;
        public async Task Validate(Funcionario funcionario)
        {
            bool emailExists = false;
            bool documentExists = false;
            bool gestorExists = false;

            Task[] tasks = {
                Task.Run(async () => emailExists = await _funcionarioRepository.EmailExistsAsync(funcionario.Email)),
                Task.Run(async () => documentExists = await _funcionarioRepository.DocumentExistsAsync(funcionario.Documento)),
                Task.Run(async () => gestorExists =  
                                        funcionario.IdGestor != null && funcionario.IdGestor != Guid.Empty ? 
                                            (await _funcionarioRepository.GetByIdAsync(funcionario.IdGestor.Value)) != null :
                                            false)
            };

            if(funcionario.IdGestor != Guid.Empty)

            Task.WaitAll(tasks);

            if (emailExists)
                throw new InvalidOperationException($"Funcionário com e-mail {funcionario.Email} já existe.");

            if (documentExists)
                throw new InvalidOperationException($"Funcionário com documento {funcionario.Documento} já existe.");

            if(!gestorExists)
                throw new KeyNotFoundException($"Gestor {funcionario.NomeGestor} não encontrado.");
        }
    }
}
