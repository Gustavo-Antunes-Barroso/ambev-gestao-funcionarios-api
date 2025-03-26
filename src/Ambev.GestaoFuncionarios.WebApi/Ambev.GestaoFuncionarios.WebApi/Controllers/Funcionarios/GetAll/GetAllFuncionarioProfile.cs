using Ambev.GestaoFuncionarios.Application.Funcionarios.GetAll;
using AutoMapper;

namespace Ambev.GestaoFuncionarios.WebApi.Controllers.Funcionarios.GetAll
{
    public class GetAllFuncionarioProfile : Profile
    {
        public GetAllFuncionarioProfile()
        {
            CreateMap<GetAllFuncionarioResult, GetAllFuncionarioResponse>();
        }
    }
}
