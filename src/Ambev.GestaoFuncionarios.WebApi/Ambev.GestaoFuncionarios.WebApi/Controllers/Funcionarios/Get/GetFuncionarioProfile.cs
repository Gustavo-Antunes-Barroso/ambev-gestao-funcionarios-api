using Ambev.GestaoFuncionarios.Application.Funcionarios.Get;
using AutoMapper;

namespace Ambev.GestaoFuncionarios.WebApi.Controllers.Funcionarios.Get
{
    public class GetFuncionarioProfile : Profile
    {
        public GetFuncionarioProfile()
        {
            CreateMap<GetFuncionarioRequest, GetFuncionarioCommand>();
            CreateMap<GetFuncionarioResult, GetFuncionarioResponse>();
        }
    }
}
