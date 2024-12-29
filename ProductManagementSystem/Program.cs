using AllServices.DbContextService;
using AllServices.DbTestService;
using AllServices.DbService;
using AllServices.RepositoryService;
using Microsoft.EntityFrameworkCore;
using AllServices.AutoMapper;
using AllServices.AuthService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CommonDbContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration["ConnectionString"]);
});

builder.Services.AddScoped(typeof(IUserDbTest<>), typeof(UserDbTest<>));
builder.Services.AddScoped(typeof(IDbService<>), typeof(DbService<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddAutoMapper(typeof(AutoMappingProfile));
builder.Services.AddScoped(typeof(IAuthService), typeof(AuthService));
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
