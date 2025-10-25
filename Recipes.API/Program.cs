using Recipes.API.Extensions;
using Recipes.API.Middleware;
using Recipes.Application.Extensions;
using Recipes.Domain.Entities.UserContext;
using Recipes.Infrastructure.Extensions;
using Recipes.Infrastructure.Seeders;
using Serilog;

#region builder
var src = WebApplication.CreateBuilder(args);

src.AddPresentation();
src.Services.AddApplicationServices();
src.Services.AddInfrastructure(src.Configuration);

src.Host.UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));
#endregion

#region app
var app = src.Build();

await app.Services.SeedRolesAsync();
await app.Services.SeedAdminUserAsync(
    email: src.Configuration["BootstrapAdmin:Email"]!,
    password: src.Configuration["BootstrapAdmin:Password"]!);

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseProblemDetails();
app.UseSerilogRequestLogging();
#endregion

app.Run();
