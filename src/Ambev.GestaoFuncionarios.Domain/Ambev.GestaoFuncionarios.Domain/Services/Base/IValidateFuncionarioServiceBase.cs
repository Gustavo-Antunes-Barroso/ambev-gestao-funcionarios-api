using Ambev.GestaoFuncionarios.Domain.Entities;

namespace Ambev.GestaoFuncionarios.Domain.Services.Base
{
    public interface IValidateFuncionarioServiceBase
    {
        Task Validate(Funcionario funcionario);
    }
}
