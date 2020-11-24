using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace App.Api.DiConfigure
{
    /// <summary>
    /// Инициализация Swagger
    /// </summary>
    public static class SwaggerInit
    {
        /// <summary>
        /// Инициализация DI Swagger
        /// </summary>
        public static IServiceCollection SwaggerDiInit(this IServiceCollection services, string title, string description)
        {
            services.AddSwaggerGen(options =>
            {
                //options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = title,
                    Version = "v1",
                    Description = description
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                // Swagger authorization
/*                options.AddSecurityDefinition(AuthorizationConst.TokenType, new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = AuthorizationConst.AuthHeader,
                    Type = SecuritySchemeType.ApiKey
                });*/
/*
                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = AuthorizationConst.TokenType
                            }
                        },
                        new string[] {}
                    }
                });*/
            });

            return services;
        }

        /// <summary>
        /// Инициализация Middlware Swagger
        /// </summary>
        public static IApplicationBuilder SwaggerMidlwareInit(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(setup =>
            {
                setup.RoutePrefix = string.Empty;
                setup.SwaggerEndpoint($"swagger/v1/swagger.json", "App.API V1");
            });

            return app;
        }
    }
}
