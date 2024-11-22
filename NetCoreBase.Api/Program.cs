using NetCoreBase.Application.Services;
using NetCoreBase.Application;
using NetCoreBase.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // đăng ký application và infrastructure vào DI container
    builder.Services
        .AddApplication()
        .AddInfrastructure();

    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
