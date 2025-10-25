using FluentValidation;
using MediatR;

namespace Recipes.API.Extensions;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = new List<FluentValidation.Results.ValidationFailure>();

            foreach (var v in _validators)
            {
                var result = await v.ValidateAsync(context, ct);
                failures.AddRange(result.Errors.Where(f => f != null));
            }

            if (failures.Count > 0)
                throw new ValidationException(failures);
        }
        return await next();
    }
}
