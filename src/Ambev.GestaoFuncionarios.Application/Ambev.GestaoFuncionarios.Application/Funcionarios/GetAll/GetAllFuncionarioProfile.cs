using Ambev.GestaoFuncionarios.Domain.Entities;
using AutoMapper;

namespace Ambev.GestaoFuncionarios.Application.Funcionarios.GetAll
{
    public class GetAllFuncionarioProfile : Profile
    {
        public GetAllFuncionarioProfile()
        {
            CreateMap<Funcionario, GetAllFuncionarioResult>();
        }
    }
}
