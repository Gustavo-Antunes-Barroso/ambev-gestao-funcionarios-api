using Ambev.GestaoFuncionarios.Application.Funcionarios.Update;
using AutoMapper;

namespace Ambev.GestaoFuncionarios.WebApi.Controllers.Funcionarios.Update
{
    public class UpdateFuncionarioProfile: Profile
    {
        public UpdateFuncionarioProfile()
        {
            CreateMap<UpdateFuncionarioRequest, UpdateFuncionarioCommand>();
            CreateMap<UpdateFuncionarioResult, UpdateFuncionarioResponse>();
        }
    }
}
