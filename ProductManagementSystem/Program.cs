using AllServices.DbContextService;
using AllServices.DbTestService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CommonDbContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration["ConnectionString"]);
});

builder.Services.Add(new ServiceDescriptor(
    typeof(IUserDbTest),
    typeof(UserDbTest),
    ServiceLifetime.Transient
));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
