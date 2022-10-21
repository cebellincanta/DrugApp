using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        builder.Services.AddControllers();
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

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("user", policy => policy.RequireClaim("Store", "user"));
            options.AddPolicy("admin", policy => policy.RequireClaim("Store", "admin"));
        });
        //Swagger
        builder.Services.AddSwaggerGen(
            s =>{
                s.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Teste Back-End Drugovich",
                        Description = "Api Crud Teste",
                        Version = "v1"

                    }
                );
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