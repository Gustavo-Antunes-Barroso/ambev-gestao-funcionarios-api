using Ambev.GestaoFuncionarios.Domain.Entities;

namespace Ambev.GestaoFuncionarios.Domain.Services.Auth
{
    public interface ITokenService
    {
        string GenerateToken(string email);
        bool ValidateToken(string token);

    }
}
