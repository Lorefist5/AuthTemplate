using Microsoft.OpenApi.Models;
using System.Reflection.PortableExecutable;
using AuthTemplate.Application;
using AuthTemplate.Infrastructure;
namespace AuthTemplate.Server.Extensions;

public static class WebApplicationBuilderExtension
{
    public static WebApplicationBuilder AddPresentation(this WebApplicationBuilder webBuilder)
    {
        webBuilder.Services.AddAuthentication();
        webBuilder.Services.AddControllers();
        webBuilder.Services.AddEndpointsApiExplorer();
        webBuilder.Services.AddApplication().AddInfrastructure(webBuilder.Configuration);

        webBuilder.AddSwaggerGen();



        return webBuilder;
    }
    public static WebApplicationBuilder AddSwaggerGen(this WebApplicationBuilder webBuilder)
    {
        webBuilder.Services.AddSwaggerGen(swaggerOptions =>
        {
            swaggerOptions.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme()
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
            });

            swaggerOptions.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "bearerAuth"
                        }
                    },
                    [] //Not oAuth or connectId so we pass a empty string array
                }
            });
        });
        return webBuilder;
    }
}
