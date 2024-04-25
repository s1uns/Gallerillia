using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Gallerillia.Server.BuildExtensions
{


    internal static class SwaggerInjection
    {
        internal static void AddSetSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Gallerillia Api",
                        Version = "v1",
                        Description = "Gallerillia Web API\n\n" +
                        "Creator - Illia Teliuk",
                        Contact = new OpenApiContact
                        {
                            Name = "GitHub",
                            Url = new Uri("https://github.com/s1uns")
                        }
                    });
                setup.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Please enter a valid token",
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        Scheme = "Bearer"
                    });
                setup.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
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
                setup.EnableAnnotations();

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                setup.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }
    }
}
