using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DrugovichApp.Api.Filter;
using DrugovichApp.Infrastructure.Repository;
using DrugovichApp.IOC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;

namespace DrugovichApp.Api;

[ExcludeFromCodeCoverage]
public class Application
{
    public static void Init(string[] args)
    {
        var key = Encoding.ASCII.GetBytes(Settings.Secret);
        var builder = WebApplication.CreateBuilder();

        builder.Host.UseSerilog();
        builder.Configuration.AddEnvironmentVariables();
        builder.Services.Register(builder.Configuration);

        builder.Services.AddControllers(
            config =>
            {
                config.Filters.Add(typeof(ExceptionFilter));
                config.Filters.Add(typeof(UnitOfWork));

            }
        ).AddJsonOptions(
            options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            }
        );
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddHealthChecks();


        //Padronização do JSON nas requisições 
        builder.Services.Configure<JsonOptions>(
            options =>
            {
                options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.SerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                options.SerializerOptions.PropertyNameCaseInsensitive = true;
                options.SerializerOptions.WriteIndented = true;
                options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
            }
        );
        //Vertsionamento API
        builder.Services.AddApiVersioning(
            options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            }
        );
        builder.Services.AddAuthentication(
            options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
        ).AddJwtBearer(
            x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            }
         );

        //Swagger
        builder.Services.AddSwaggerGen(
        s =>
        {
            s.CustomSchemaIds(type => type.ToString());
            s.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Teste Back-End Drugovich",
                        Description = "Api Crud Teste",
                        Version = "v1"

                    }
                );
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Adicionar o token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                s.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
            }
        );

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI(
            options =>
            {
                options.SwaggerEndpoint($"/swagger/v1/swagger.json", $"v1");
            }
        );


        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}