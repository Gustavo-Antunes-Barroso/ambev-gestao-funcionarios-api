namespace Ambev.GestaoFuncionarios.WebApi.Controllers.Funcionarios.Update
{
    public class UpdateFuncionarioRequest
    {
        public required Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required string Documento { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public required string Telefone { get; set; }
        public string? NomeGestor { get; set; }
        public Guid? IdGestor { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool IsGestor { get; set; }
    }
}
