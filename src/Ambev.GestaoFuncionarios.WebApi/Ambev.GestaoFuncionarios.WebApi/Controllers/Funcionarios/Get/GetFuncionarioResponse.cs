using Ambev.GestaoFuncionarios.Common.Serialization;
using System.Text.Json.Serialization;

namespace Ambev.GestaoFuncionarios.WebApi.Controllers.Funcionarios.Get
{
    public class GetFuncionarioResponse
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required string Documento { get; set; }
        public required string Email { get; set; }
        public required string Telefone { get; set; }
        public string? NomeGestor { get; set; }
        public Guid? IdGestor { get; set; }

        [JsonConverter(typeof(DateOnlyConverter))]
        public DateTime DataNascimento { get; set; }
        public bool IsGestor { get; set; }
    }
}
