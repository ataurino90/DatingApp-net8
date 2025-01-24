using System.Text;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using API.Extensions;
using Microsoft.Build.Framework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationsServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
#region AddApplicationsServices
// builder.Services.AddControllers();

// builder.Services.AddDbContext<DataContext>(opt => {
//     opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
// });

// builder.Services.AddCors();
// builder.Services.AddScoped<ITokenService,TokenService>();
#endregion 

#region AddIdentityServices
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
// AddJwtBearer(options =>{
//      var tokenKey = builder.Configuration["TokenKey"] ?? throw new Exception("Cannot access tokenKey from appsettings");
//      options.TokenValidationParameters= new TokenValidationParameters{
//         ValidateIssuerSigningKey= true,
//         IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
//         ValidateIssuer= false,
//         ValidateAudience= false
//      };
// });
#endregion 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
.WithOrigins("http://localhost:4200","https://localhost:4200" ));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
