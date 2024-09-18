using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PruebaTecnica.Core.Business.Code;
using PruebaTecnica.Core.Business.Contracts;
using PruebaTecnica.Core.Service.Code.Commands;
using PruebaTecnica.Core.Service.Code.Queries;
using PruebaTecnica.Core.Service.Contracts;
using PruebaTecnica.Persistence.Database;
using PruebaTecnica.Seguridad.Business.Code;
using PruebaTecnica.Seguridad.Business.Contracts;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API-PRUEBA-TECNICA-DESARROLLADOR-BACKEND", Version = "v1.0" });

    //JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "APISecurity",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
       new OpenApiSecurityScheme {
        Reference = new OpenApiReference {
        Type = ReferenceType.SecurityScheme,
        Id = "Bearer"
        }
       },
       new string[] {}
    }
    });
});
//JWT
builder.Services.AddAuthorization(c =>
{
    c.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
    .RequireAuthenticatedUser()
    .Build();
});
var signiKey = builder.Configuration["AutenticationSettings:SigniKey"];
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["AutenticationSettings:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["AutenticationSettings:Audience"],
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signiKey))
    };
});

string mongoConnectionString = builder.Configuration["MongoDbSettings:ConnectionString"];
string mongoDatabaseName = builder.Configuration["MongoDbSettings:DatabaseName"];

builder.Services.AddSingleton<MongoDb>(sp =>
    new MongoDb(mongoConnectionString, mongoDatabaseName)
);

//Commands
builder.Services.AddTransient<IProveedorCommands, ProveedorCommands>();

//Queries
builder.Services.AddTransient<IProveedorQueries, ProveedorQueries>();

//Business
builder.Services.AddTransient<IProveedorBusiness, ProveedorBusiness>();
builder.Services.AddScoped<IAutorizacionBusiness, AutorizacionBusiness>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
