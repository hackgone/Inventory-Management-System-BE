using AllServices.DbContextService;
using AllServices.DbTestService;
using AllServices.DbService;
using AllServices.RepositoryService;
using Microsoft.EntityFrameworkCore;
using AllServices.AutoMapper;
using AllServices.AuthService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AllServices.JWTService;
using AllServices.Order;

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
builder.Services.AddScoped(typeof(IJwtProvider),typeof(JwtProviderService));
builder.Services.AddScoped(typeof(IOrderService), typeof(OrderService));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("EndUserRole", policy => policy.RequireRole("EndUser"));
    options.AddPolicy("SuperUserRole", policy => policy.RequireRole("SuperUser"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthentication(); // correct order of these two for jwt
app.UseAuthorization();

app.MapControllers();

app.Run();
