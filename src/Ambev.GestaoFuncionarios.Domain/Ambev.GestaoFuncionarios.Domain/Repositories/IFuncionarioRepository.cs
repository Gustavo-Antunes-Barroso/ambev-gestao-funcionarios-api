using Ambev.GestaoFuncionarios.Domain.Entities;

namespace Ambev.GestaoFuncionarios.Domain.Repositories
{
    public interface IFuncionarioRepository
    {
        Task<Funcionario> CreateAsync(Funcionario funcionario);
        Task UpdateAsync(Funcionario funcionario);
        Task DeleteAsync(Guid id);
        Task<Funcionario?> GetByIdAsync(Guid id);
        Task<IEnumerable<Funcionario>> GetAllAsync(bool? isGestor = null);
        Task<bool> EmailExistsAsync(string email);
        Task<bool> EmailExistsAsync(Guid id, string email);
        Task<bool> DocumentExistsAsync(string document);
        Task<bool> DocumentExistsAsync(Guid id, string document);
        Task<bool> ValidLogin(string email, string password);
    }
}
