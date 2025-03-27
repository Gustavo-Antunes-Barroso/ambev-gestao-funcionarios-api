using Ambev.GestaoFuncionarios.Application;
using Ambev.GestaoFuncionarios.Ioc;
using Ambev.GestaoFuncionarios.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(ApplicationLayer).Assembly);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(ApplicationLayer).Assembly,
        typeof(Program).Assembly
    );
});

// String de conexão do PostgreSQL
string? connectionString = builder.Configuration.GetConnectionString("PostgresConnection");
DependencyResolver.RegisterDependencies(builder.Services, connectionString);

var app = builder.Build();
app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<TokenValidationMiddleware>();
app.MapControllers();

app.Run();
