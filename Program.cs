using System.Text;
using atteducation.api.Data;
using atteducation.api.Repositorys;
using atteducation.api.Repositorys.Interfaces;
using atteducation.api.Seeders;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));
builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.SetIsOriginAllowed(origin => true);
                        builder.AllowAnyHeader();
                        builder.AllowCredentials();
                        builder.AllowAnyMethod();
                    }
                );
            });

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Appsettings:Token"]))
        };
    });
builder.Services.AddAutoMapper(typeof(IAuthRepository).Assembly);
builder.Services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = 1000000;
            });

LoadRepositorys(builder.Services);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedRoles.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



void LoadRepositorys(IServiceCollection service)
{
    service.AddScoped<IAuthRepository, AuthRepository>();
    service.AddScoped<IUserRepository, UserRepository>();
    service.AddScoped<IRolRepository, RolRepository>();
    service.AddScoped<IThemeRepository, ThemeRepository>();
    service.AddScoped<ICommentRepository, ComentRepository>();
    service.AddScoped<IContentRepository, ContentRepository>();
}