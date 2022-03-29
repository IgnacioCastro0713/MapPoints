using API.Core.Extensions;
using API.Core.Middlewares;

var builder = WebApplication.CreateBuilder(args);

{
    var services = builder.Services;

    services.AddControllers();
    
    services.AddAppSettings(builder.Configuration);
    services.AddMySqlDbContext(builder.Configuration);

    services.AddUnitOfWork();
    services.AddServices();

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}


var app = builder.Build();

{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    app.UseMiddleware<JwtMiddleware>();

    app.MapControllers();
}

app.Run();