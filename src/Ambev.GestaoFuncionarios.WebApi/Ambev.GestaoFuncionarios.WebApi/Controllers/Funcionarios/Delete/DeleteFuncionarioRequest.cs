namespace Ambev.GestaoFuncionarios.WebApi.Controllers.Funcionarios.Delete
{
    public class DeleteFuncionarioRequest
    {
        public DeleteFuncionarioRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
