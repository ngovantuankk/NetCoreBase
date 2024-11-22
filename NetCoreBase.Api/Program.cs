using NetCoreBase.Application.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddScoped<IAuthService, AuthService>(); // đăng ký IAuthService từ Application vào Api để sử dụng trong controllers
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
