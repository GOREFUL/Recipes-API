using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Recipes.API.Auth;

namespace Recipes.API.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddPresentation(this WebApplicationBuilder src)
    {
        src.Services.AddOpenApi();
        src.Services.AddControllers();
        src.Services.AddEndpointsApiExplorer();
        src.Services.AddSwaggerGen();

        // authorization policies
        src.Services.AddAuthorization(opt =>
        {
            opt.AddPolicy("SelfOrAdmin", policy =>
            {
                policy.Requirements.Add(new SelfOrAdminRequirement());
            });
        });
        src.Services.AddSingleton<IAuthorizationHandler, SelfOrAdminHandler>();

        src.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter 'Bearer {token}'"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                        Type = ReferenceType.SecurityScheme, Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }
}