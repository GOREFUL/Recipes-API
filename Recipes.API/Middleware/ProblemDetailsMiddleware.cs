using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Recipes.API.Middleware;

public class ProblemDetailsMiddleware(ILogger<ProblemDetailsMiddleware> logger, 
	RequestDelegate _next)
{
    private RequestDelegate next = _next;

    public async Task InvokeAsync(HttpContext ctx)
    {
		try
		{
			await next(ctx);
        }
		catch (FluentValidation.ValidationException ex)
		{
			logger.LogWarning(ex, "Validation error occurred");
			ctx.Response.StatusCode = StatusCodes.Status400BadRequest;
			ctx.Response.ContentType = "application/problem+json";

			var problemDetails = new
			{
				type = "https://httpstatueses.com/400",
				title = "Validation failed.",
				status = 400,
				errors = ex.Errors.Select(e => new
				{
					e.PropertyName,
					e.ErrorMessage
				})
			};

			await ctx.Response.
				WriteAsync(JsonSerializer.Serialize(problemDetails));
		}
		catch (KeyNotFoundException ex)
		{
			ctx.Response.StatusCode = StatusCodes.Status404NotFound;
			ctx.Response.ContentType = "application/problem+json";
			var problemDetails = new
			{
				type = "https://httpstatuses.com/404",
				title = "The requested resource was not found.",
				status = 404,
				detail = ex.Message
			};
			await ctx.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
        }

        catch (UnauthorizedAccessException)
        {
            ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            ctx.Response.ContentType = "application/problem+json";
            var pd = new { type = "https://httpstatuses.com/401", title = "Unauthorized", status = 401 };
            await ctx.Response.WriteAsync(JsonSerializer.Serialize(pd));
        }
        catch (InvalidOperationException ex)
        {
            ctx.Response.StatusCode = (int)HttpStatusCode.Conflict;
            ctx.Response.ContentType = "application/problem+json";
            var pd = new { type = "https://httpstatuses.com/409", title = ex.Message, status = 409 };
            await ctx.Response.WriteAsync(JsonSerializer.Serialize(pd));
        }
    }
}
