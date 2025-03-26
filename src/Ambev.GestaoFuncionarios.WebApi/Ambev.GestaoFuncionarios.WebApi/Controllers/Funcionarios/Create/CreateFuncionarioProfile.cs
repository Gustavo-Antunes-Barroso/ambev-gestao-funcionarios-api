using Ambev.GestaoFuncionarios.Application.Funcionarios.Create;
using AutoMapper;

namespace Ambev.GestaoFuncionarios.WebApi.Controllers.Funcionarios.Create
{
    public class CreateFuncionarioProfile : Profile
    {
        public CreateFuncionarioProfile()
        {
            CreateMap<CreateFuncionarioRequest, CreateFuncionarioCommand>();
            CreateMap<CreateFuncionarioResult, CreateFuncionarioResponse>();
        }
    }
}
