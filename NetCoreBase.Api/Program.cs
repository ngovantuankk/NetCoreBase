using Microsoft.AspNetCore.Mvc.Infrastructure;
using NetCoreBase.Api.Errors;
using NetCoreBase.Application;
using NetCoreBase.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // đăng ký application và infrastructure vào DI container
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, NetCoreBaseProblemDetailsFactory>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
