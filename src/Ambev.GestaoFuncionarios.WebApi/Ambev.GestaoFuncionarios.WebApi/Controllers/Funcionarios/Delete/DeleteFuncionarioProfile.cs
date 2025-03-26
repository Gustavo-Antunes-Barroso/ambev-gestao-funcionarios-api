using Ambev.GestaoFuncionarios.Application.Funcionarios.Delete;
using AutoMapper;

namespace Ambev.GestaoFuncionarios.WebApi.Controllers.Funcionarios.Delete
{
    public class DeleteFuncionarioProfile : Profile
    {
        public DeleteFuncionarioProfile()
        {
            CreateMap<DeleteFuncionarioRequest, DeleteFuncionarioCommand>();
        }
    }
}
