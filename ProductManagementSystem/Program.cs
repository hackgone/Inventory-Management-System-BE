using AllServices.DbContextService;
using AllServices.DbTestService;
using AllServices.DbService;
using AllServices.RepositoryService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CommonDbContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration["ConnectionString"]);
});

builder.Services.AddTransient(typeof(IUserDbTest<>), typeof(UserDbTest<>));
builder.Services.AddTransient(typeof(IDbService<>), typeof(DbService<>));
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
