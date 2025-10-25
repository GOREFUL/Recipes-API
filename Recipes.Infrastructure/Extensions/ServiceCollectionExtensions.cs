using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Entities.UserContext;
using Recipes.Domain.Repositories.Business.Cooking;
using Recipes.Domain.Repositories.Business.Cooking.Advanced;
using Recipes.Domain.Repositories.Business.Enumerations;
using Recipes.Domain.Repositories.Business.Social;
using Recipes.Domain.Repositories.System;
using Recipes.Infrastructure.Auth;
using Recipes.Infrastructure.Persistance;
using Recipes.Infrastructure.Repositories.Business.Cooking;
using Recipes.Infrastructure.Repositories.Business.Cooking.Advanced;
using Recipes.Infrastructure.Repositories.Business.Enumerations;
using Recipes.Infrastructure.Repositories.Business.Social;
using Recipes.Infrastructure.Repositories.System;
using Recipes.Infrastructure.Security;
using Recipes.Infrastructure.UnitOfWork;
using System.Security.Cryptography;
using System.Text;

namespace Recipes.Infrastructure.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection src,
        IConfiguration cfg)
    {
        var connectionString = cfg.GetConnectionString("RecipesDb");

        src.AddDbContext<RecipesDbContext>(opt =>
        opt.UseSqlServer(connectionString)
        .EnableSensitiveDataLogging());

        src.AddIdentityCore<ApplicationUser>(opt =>
        {
            opt.User.RequireUniqueEmail = true;
            opt.Password.RequiredLength = 8;
            opt.Password.RequireDigit = true;
            opt.Password.RequireLowercase = true;
            opt.Password.RequireUppercase = false;
            opt.Password.RequireNonAlphanumeric = false;
        })
        .AddRoles<IdentityRole<Guid>>()
        .AddEntityFrameworkStores<RecipesDbContext>()
        .AddSignInManager();

        // UoW
        src.AddScoped<IUnitOfWork, EfUnitOfWork>();

        // Posts
        src.AddScoped<IPostRepository, PostRepository>();
        src.AddScoped<IMediaUnitRepository, MediaUnitRepository>();
        src.AddScoped<ISocialDataRepository, SocialDataRepository>();

        // Dishes
        src.AddScoped<IDishRepository, DishRepository>();
        src.AddScoped<IDishInfoRepository, DishInfoRepository>();
        src.AddScoped<IDishImageRepository, DishImageRepository>();
        src.AddScoped<IIngredientUnitRepository, IngredientUnitRepository>();
        src.AddScoped<IMacronutrientsRepository, MacronutrientsRepository>();
        src.AddScoped<IMicronutrientsRepository, MicronutrientsRepository>();

        // lookups
        src.AddScoped<ILevelRepository, LevelRepository>();
        src.AddScoped<IIngredientRepository, IngredientRepository>();
        src.AddScoped<IMeasureUnitRepository, MeasureUnitRepository>();
        src.AddScoped<IAllergyRepository, AllergyRepository>();
        src.AddScoped<ICuisineRepository, CuisineRepository>();


        src.AddScoped<IJwtTokenService, JwtTokenService>();
        src.AddScoped<IIdentityRepository, IdentityRepository>();
        src.AddScoped<ICurrentUser, CurrentUser>();

        // Bind JwtOptions
        src.AddOptions<JwtOptions>()
            .Bind(cfg.GetSection("Jwt"))
            .Validate(o => !string.IsNullOrWhiteSpace(o.Key), "Jwt:Key is required");


        var jwt = cfg.GetSection("Jwt").Get<JwtOptions>()!;


        src.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwt.Issuer,
                ValidAudience = jwt.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key)),
                ClockSkew = TimeSpan.Zero
            };
        });
    }
}
