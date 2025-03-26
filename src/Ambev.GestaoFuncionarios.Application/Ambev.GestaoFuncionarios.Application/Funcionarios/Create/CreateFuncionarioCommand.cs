using Ambev.GestaoFuncionarios.Application.Funcionarios.GetAll;
using MediatR;

namespace Ambev.GestaoFuncionarios.Application.Funcionarios.Create
{
    public class CreateFuncionarioCommand : IRequest<CreateFuncionarioResult>
    {
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required string Documento { get; set; }
        public required string Email { get; set; }
        public required string Telefone { get; set; }
        public string? NomeGestor { get; set; }
        public Guid? IdGestor { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool IsGestor { get; set; }
    }
}
