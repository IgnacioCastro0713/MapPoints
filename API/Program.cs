using API.Core.Interfaces.Services;
using API.Persistance.DbContext;
using API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    var services = builder.Services;
    services.AddControllers();
    services.AddDbContext<ApplicationDbContext>(optionsBuilder =>
        optionsBuilder.UseMySql(
            builder.Configuration.GetConnectionString("Connection"),
            ServerVersion.Parse(builder.Configuration.GetConnectionString("MySqlServerVersion"))
        ));
    
    services.AddScoped<IUserService, UserService>(); 
    
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

    app.MapControllers();
}

app.Run();