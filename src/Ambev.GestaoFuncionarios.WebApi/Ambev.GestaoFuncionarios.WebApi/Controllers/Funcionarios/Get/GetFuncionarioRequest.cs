namespace Ambev.GestaoFuncionarios.WebApi.Controllers.Funcionarios.Get
{
    public class GetFuncionarioRequest
    {
        public GetFuncionarioRequest(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
