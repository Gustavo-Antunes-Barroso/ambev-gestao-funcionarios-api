using Ambev.GestaoFuncionarios.Domain.Entities;
using AutoMapper;

namespace Ambev.GestaoFuncionarios.Application.Funcionarios.Create
{
    public class CreateFuncionarioProfile : Profile
    {
        public CreateFuncionarioProfile()
        {
            CreateMap<CreateFuncionarioCommand, Funcionario>();
            CreateMap<Funcionario, CreateFuncionarioResult>();
        }
    }
}
