using Ambev.GestaoFuncionarios.Domain.Entities;
using AutoMapper;

namespace Ambev.GestaoFuncionarios.Application.Funcionarios.Update
{
    public class UpdateFuncionarioProfile : Profile
    {
        public UpdateFuncionarioProfile()
        {
            CreateMap<UpdateFuncionarioCommand, Funcionario>();
            CreateMap<Funcionario, UpdateFuncionarioResult>();
        }
    }
}
