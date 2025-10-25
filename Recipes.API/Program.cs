using Recipes.API.Extensions;
using Recipes.API.Middleware;
using Recipes.Application.Extensions;
using Recipes.Domain.Entities.UserContext;
using Recipes.Infrastructure.Extensions;
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
