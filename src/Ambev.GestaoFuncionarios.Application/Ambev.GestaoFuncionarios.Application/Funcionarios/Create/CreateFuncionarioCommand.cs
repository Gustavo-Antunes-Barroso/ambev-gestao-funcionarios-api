using MediatR;

namespace Ambev.GestaoFuncionarios.Application.Funcionarios.Create
{
    public class CreateFuncionarioCommand : IRequest<CreateFuncionarioResult>
    {
        public string Nome { get; set; } = "";
        public string Sobrenome { get; set; } = "";
        public string Documento { get; set; } = "";
        public string Email { get; set; } = "";
        public string Senha { get; set; } = "";
        public string Telefone { get; set; } = "";
        public string? NomeGestor { get; set; }
        public Guid? IdGestor { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool IsGestor { get; set; }
    }
}
