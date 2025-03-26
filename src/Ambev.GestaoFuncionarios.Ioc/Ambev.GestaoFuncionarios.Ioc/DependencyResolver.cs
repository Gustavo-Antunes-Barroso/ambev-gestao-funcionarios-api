using Ambev.GestaoFuncionarios.Application.Services.Funcionarios;
using Ambev.GestaoFuncionarios.Domain.Repositories;
using Ambev.GestaoFuncionarios.Domain.Services.Funcionarios;
using Ambev.GestaoFuncionarios.ORM.Context;
using Ambev.GestaoFuncionarios.ORM.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.GestaoFuncionarios.Ioc
{
    public static class DependencyResolver
    {
        public static void RegisterDependencies(this IServiceCollection services, string? connectionString)
        {
            ApplicationModuleInitializer(services);
            InfrastructureModuleInitializer(services, connectionString);
        }

        private static void ApplicationModuleInitializer(IServiceCollection services)
        {
            services.AddScoped<IValidateCreateFuncionarioService, ValidateCreateFuncionarioService>();
            services.AddScoped<IValidateUpdateFuncionarioService, ValidateUpdateFuncionarioService>();
        }

        private static void InfrastructureModuleInitializer(IServiceCollection services, string? connectionString)
        {
            // Registrar DapperContext
            services.AddScoped(provider => new DapperContext(connectionString));
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
        }
    }
}
