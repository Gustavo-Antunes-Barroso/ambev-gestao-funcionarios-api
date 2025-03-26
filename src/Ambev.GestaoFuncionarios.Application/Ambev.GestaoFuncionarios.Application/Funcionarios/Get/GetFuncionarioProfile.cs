using Ambev.GestaoFuncionarios.Domain.Entities;
using AutoMapper;

namespace Ambev.GestaoFuncionarios.Application.Funcionarios.Get
{
    public class GetFuncionarioProfile : Profile
    {
        public GetFuncionarioProfile()
        {
            CreateMap<Funcionario, GetFuncionarioResult>();
        }
    }
}
