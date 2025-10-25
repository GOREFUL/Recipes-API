namespace Recipes.API.Middleware;

public static class ProblemDetailsMiddlewareExtensions
{
    public static IApplicationBuilder UseProblemDetails
        (this IApplicationBuilder app)
    {
        app.UseMiddleware<ProblemDetailsMiddleware>();
        return app;
    }
}
