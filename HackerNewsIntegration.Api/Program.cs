using HakerNewsIntegration.Application.IoC;
using HakerNewsIntegration.Domain.IoC;
using HakerNewsIntegration.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSwaggerGen()
    .AddCustomConfigurations(builder.Configuration)
    .AddApplicationInjections()
    .AddInfraInjections();

builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
